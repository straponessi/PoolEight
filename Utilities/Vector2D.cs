using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Utilities
{
    class Vector2D
    {
        public double x, y;

        public Vector2D(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public Vector2D(double _xy)
        {
            x = _xy;
            y = _xy;
        }

        public Vector2D Normalize() => this / Length; //возвращает нормализованную версию вектора, то есть вектор с тем же направлением, но с единичной длиной.
                                                      //Это достигается путем деления каждой компоненты вектора на его длину.

        public double Length                        //возвращает длину вектора, рассчитанную с использованием формулы для нахождения гипотенузы прямоугольного треугольника.
        {
            get { return Math.Sqrt(x * x + y * y); }
        }

        public double SquaredLength                 //возвращает квадрат длины вектора. Вместо извлечения квадратного корня, оно просто складывает квадраты компонент вектора,
                                                    //что может быть полезно в некоторых случаях для ускорения вычислений.
        {
            get { return x * x + y * y; }
        }

        // +- Vector2D
        public static Vector2D operator +(Vector2D a) => a;
        public static Vector2D operator -(Vector2D a) => new Vector2D(-a.x, -a.y);

        // Vector2D +- Vector2D
        public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.x + b.x, a.y + b.y); //Сложение векторов
        public static Vector2D operator -(Vector2D a, Vector2D b) => a + (-b);                          //Вычитание векторов

        // Vector2D */ Vector2D
        public static Vector2D operator *(Vector2D a, Vector2D b) => new Vector2D(a.x * b.x, a.y * b.y); //Выполняют поэлементное умножение 
        public static Vector2D operator /(Vector2D a, Vector2D b) => new Vector2D(a.x / b.x, a.y / b.y); //И деление векторов.

        // Vector2D */ double
        public static Vector2D operator *(Vector2D a, double s) => new Vector2D(a.x * s, a.y * s);       //Умножение 
        public static Vector2D operator /(Vector2D a, double s) => a * (1 / s);                          //И деление вектора на скаляр

        // double */ Vector2D
        public static Vector2D operator *(double s, Vector2D a) => a * s;                                //Умножение 
        public static Vector2D operator /(double s, Vector2D a) => a / s;                                // И деление скаляра на вектор

        // bool operators componentwise
        public static bool operator <(Vector2D a, Vector2D b) => a.x < b.x && a.y < b.y;
        public static bool operator >(Vector2D a, Vector2D b) => b < a;

        // cast Point to Vector2D vice versa
        public static implicit operator Vector2D(Point p) => new Vector2D(p.X, p.Y);

        public static implicit operator Point(Vector2D v) => new Point(v.x, v.y);

        // cast Point3D to Vector2D vice versa

        public static implicit operator Vector2D(Point3D p) => new Point3D(p.X, p.Y, 0);

        public static implicit operator Point3D(Vector2D v) => new Point3D(v.x, v.y, 0);
    }
}