using System;
using System.Linq;
using System.Windows;
using Render;
using Physics;
using Utilities;
using System.Windows.Media;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using Physics.Events.Triggers;
using System.Runtime.CompilerServices;
using GameRules;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace PoolEight
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly PhysicsEngine physicsEngine;
        private readonly Renderer renderer;

        private int miss = 0;

        private long t = DateTime.Now.Ticks / 10000;

        Player[] players = new[]
        {
           new Player{ },
           new Player{ }
        };

        private int turn = 0;

        private string score;
        public string Score
        {
            get { return score; }
            set
            {
                if (score != value)
                {
                    score = value;
                    OnPropertyChanged();
                }
            }
        }
        private string hitTurnMessage;
        public string HitTurnMessage
        {
            get { return hitTurnMessage; }
            set
            {
                if (hitTurnMessage != value)
                {
                    hitTurnMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool isHit = false;
        public bool isTriggered = false;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            renderer.Show(HitTurn);

            Score = $"{players[0].Name}\tСчёт:{players[0].Score}\n"
                + $"{players[1].Name}\tСчёт:{players[1].Score}";

            if (isHit && physicsEngine.Resting && !isTriggered)
            {
                SwitchTurn();
                isHit = false;
            }
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
            renderer.Show(WonHelper, true);
        }

        private void Lost()
        {
            renderer.Show(LooseScreen, true);
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

            isHit = true;
        }

        private void CalculateScore(TriggerEvent e)
        {
            switch (turn)
            {
                case 0:

                    if (e.ball.index > 8)
                    {
                        players[0].Score += 10;
                        isTriggered = false;
                    }

                    if (e.ball.index < 8 && e.ball.index != 0)
                    {
                        players[0].Score -= 5;
                        isTriggered = false;
                    }

                    if (physicsEngine.HalfBalls.Count == 7 && e.ball.index == 8)
                        Won();
                    else if (e.ball.index == 8)
                    {
                        Lost();
                    }

                    break;
                case 1:

                    if (e.ball.index < 8 && e.ball.index > 0)
                    {
                        players[1].Score += 10;
                        isTriggered = false;
                    }

                    if (e.ball.index > 8)
                    {
                        players[1].Score -= 5;
                        isTriggered = false;
                    }

                    if (physicsEngine.FullBalls.Count == 7 && e.ball.index == 8)
                        Won();
                    else if (e.ball.index == 8)
                    {
                        Lost();
                    }
                    break;
            }
        }

        private string SwitchTurn()
        {
            if (turn == 0)
            {
                turn = 1;
                HitTurnMessage = $"{players[turn].Name} должен забить цветной шар";
                if(physicsEngine.FullBalls.Count == 7)
                {
                    HitTurnMessage = $"{players[turn].Name} должен забить черный шар";
                }
            }
            else if (turn == 1)
            {
                turn = 0;
                HitTurnMessage = $"{players[turn].Name} должен забить полосатый шар";
                if (physicsEngine.HalfBalls.Count == 7)
                {
                    HitTurnMessage = $"{players[turn].Name} должен забить черный шар ";
                }
            }
            return hitTurnMessage;
        }

        private void Trigger(object sender, TriggerEvent e)
        {
            isTriggered = true;

            CalculateScore(e);

            if (e.ball.index == 0)
            {
                e.ball.velocity = new Vector2D(0, 0);
                e.ball.position = new Vector2D(273, 547 / 2);

                miss++;

                if(miss % 2 == 1)
                {
                    players[turn].Score -= 2;
                    isTriggered = false;
                }
                else
                {
                    players[turn].Score -= 2;
                    isTriggered = false;
                }
                return;
            }
            PBallWithG newBall = new PBallWithG(e.ball.index, 20, new Vector2D(100, 100), e.ball.velocity);

            physicsEngine.TransferBall(e.ball, newBall);
            renderer.AddSideBall(newBall);
            renderer.RemoveBall(e.ball);
        }
        #endregion

        #region UIEventhandlers
        private void LetsPlay(object sender, RoutedEventArgs e)
        {
            players[0].Name = firstPlayer.Text;
            players[1].Name = secondPlayer.Text;

            renderer.Show(PlayerBoard, true);
            renderer.Show(TopPanel, true);

            CompositionTarget.Rendering += Update;
            renderer.ResetAll(physicsEngine.balls);
            identification.Visibility = Visibility.Hidden;
            HitTurnMessage = players[turn].Name + "должен забить полосатый шар";
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            renderer.Hide(PlayBtn, true);
            renderer.Show(identification, true);
        }

        private void RestartGame(object sender = null, RoutedEventArgs e = null)
        {
            players[0].Score = 0;
            players[1].Score = 0;

            renderer.Hide(LooseScreen);
            miss = 0;
            physicsEngine.Init();
            renderer.ResetAll(physicsEngine.balls);
        }

        private void OpenHighscore(object sender, RoutedEventArgs e)
        {
            renderer.Show(Highscore, true);

            Scores.ItemsSource = ScoreManager.Scores;
        }

        private void CloseHighscore(object sender, RoutedEventArgs e)
        {
            renderer.Hide(Highscore, true);
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SendHighscoreAndRestart(object sender, RoutedEventArgs e)
        {
            ScoreManager.SaveScore(players[0], players[1]);

            RestartGame();
            WonHelper.Visibility = Visibility.Hidden;
        }

        #endregion

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            physicsEngine = new PhysicsEngine();
            physicsEngine.Trigger += Trigger;


            renderer = new Renderer(Table, Half, Full, Queue, Overlay);
        }
    }
}