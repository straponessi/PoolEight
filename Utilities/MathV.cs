﻿using System;

namespace PoolEight.Utilities
{
    static class MathV
    {
        public static double Mix(double x, double y, double a)
        {
            return x * (1.0 - a) + y * a;
        }

        public static double Clamp(double x, double minVal, double maxVal)
        {
            return Math.Min(Math.Max(x, minVal), maxVal);
        }

        public static Vector2D Abs(Vector2D v)
        {
            return new Vector2D(Math.Abs(v.x), Math.Abs(v.y));
        }

        public static double Dot(Vector2D a, Vector2D b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static Vector2D Max(Vector2D v, double d)
        {
            return new Vector2D(Math.Max(v.x, d), Math.Max(v.y, d));
        }

        public static Vector2D Min(Vector2D a, Vector2D b)
        {
            return new Vector2D(
                Math.Min(a.x, b.x),
                Math.Min(a.y, b.y)
            );
        }

        public static double GetAngleToX(Vector2D a)
        {
            if (a.y > 0)
            {
                return Math.Acos(MathV.Dot(a, new Vector2D(1, 0))) * 180 / Math.PI;
            }
            else
            {
                return -Math.Acos(MathV.Dot(a, new Vector2D(1, 0))) * 180 / Math.PI;
            }
        }
    }
}