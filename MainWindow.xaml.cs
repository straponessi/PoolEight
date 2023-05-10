using System;
using System.Linq;
using System.Windows;
using PoolEight.Render;
using PoolEight.Physics;
using PoolEight.Utilities;
using System.Windows.Media;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using PoolEight.Physics.Events.Triggers;
using System.Runtime.CompilerServices;

namespace PoolEight
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly Queue<double> fpsDeltas = new Queue<double>(new double[8]);
        
        public event PropertyChangedEventHandler PropertyChanged;

        private long t = DateTime.Now.Ticks / 10000;

        private readonly PhysicsEngine physicsEngine;
        private readonly Renderer renderer;

        private int miss = 0;

        private string fps;
        public string FPS
        {
            get { return fps; }
            set
            {
                if (fps != value)
                {
                    fps = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            CompositionTarget.Rendering += Update;

            InitializeComponent();
            physicsEngine = new PhysicsEngine();
            physicsEngine.Trigger += Trigger;

            renderer = new Renderer(Table, Half, Full, Queue, Overlay);
            renderer.ResetAll(physicsEngine.balls);
        }

        #region Gameloop
        private void Update(object sender, EventArgs e)
        {
            UpdateUI();
            UpdatePhysics();
            UpdateRenderer();
        }

        private void UpdateUI()
        {
            fpsDeltas.Dequeue();
            fpsDeltas.Enqueue(1000.0d / (DateTime.Now.Ticks / 10000 - t));

            FPS = Math.Round(fpsDeltas.Sum() / 8).ToString() + " FPS";

            //Score = "Punkte: " + CalculateScore();
        }

        private void UpdatePhysics()
        {
            long nextT = DateTime.Now.Ticks / 10000;
            for (long i = t; i < nextT; i += 8)
            {
                physicsEngine.Step(0.008);
                if (nextT - i > 500) break;
            }

            t = DateTime.Now.Ticks / 10000;
        }

        private void UpdateRenderer()
        {
            renderer.Update();

            if (physicsEngine.Resting)
            {
                Vector2D p = Mouse.GetPosition(Table);

                var (ballPosition, ballRadius) = physicsEngine.balls.Find(x => x.index == 0);

                renderer.DrawQueue(ballPosition, ballRadius, p);
                renderer.DrawTrajectory(ballRadius, physicsEngine.CalculateTrajectory(ballPosition, (ballPosition - p).Normalize(), ballRadius));
            }
        }
        #endregion

        #region Gameeventhandlers and utitilies
        private void Won()
        {
            //renderer.Show(WonHelper, true);
        }

        private void Lost()
        {
            //renderer.Show(LooseScreen, true);
        }

        private int CalculateScore()
        {
            int sum = 0;

            for (int i = 0; i < Math.Min(physicsEngine.HalfBalls.Count, physicsEngine.FullBalls.Count); i++)
            {
                sum += physicsEngine.HalfBalls[i].index * physicsEngine.FullBalls[i].index;
            }

            for (int i = 1; i < miss; i++)
            {
                sum -= 2 * i;
            }

            return sum;
        }

        private void HitBall(object sender, RoutedEventArgs e)
        {
            if (!physicsEngine.Resting)
            {
                return;
            }

            Vector2D p = Mouse.GetPosition(Table);

            PBall ball = physicsEngine.balls.Last();

            Vector2D n = (ball.position - p).Normalize();
            Vector2D force = Math.Min((ball.position - p).Length, 200) * 10 * n;

            physicsEngine.ApplyForce(ball, force);
        }

        private void Trigger(object sender, TriggerEvent e)
        {
            if (e.ball.index == 0)
            {
                e.ball.velocity = new Vector2D(0, 0);
                e.ball.position = new Vector2D(273, 547 / 2);
                miss++;
                return;
            }

            if (physicsEngine.balls.Count == 2)
            {
                Won();
            }
            else if (e.ball.index == 8)
            {
                Lost();
            }

            PBallWithG newBall = new PBallWithG(e.ball.index, 20, new Vector2D(100, 100), e.ball.velocity);

            physicsEngine.TransferBall(e.ball, newBall);
            renderer.AddSideBall(newBall);
            renderer.RemoveBall(e.ball);
        }
        #endregion
    }
}