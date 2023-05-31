using System;

namespace Utilities
{
    static class MathV
    {
        public static double Mix(double x, double y, double a)              //Возвращает их линейную интерполяцию. 
        {                                                                   //Формула для интерполяции выглядит следующим образом: x * (1.0 - a) + y * a
            return x * (1.0 - a) + y * a;
        }

        public static double Clamp(double x, double minVal, double maxVal)  //Принимает число x и ограничивает его значение в указанном диапазоне от minVal до maxVal. 
        {                                                                   //Если x меньше minVal, то возвращается minVal, а если x больше maxVal, то возвращается maxVal
            return Math.Min(Math.Max(x, minVal), maxVal);
        }

        public static Vector2D Abs(Vector2D v)                              //Принимает вектор v и возвращает новый вектор, состоящий из абсолютных значений его компонент
        {
            return new Vector2D(Math.Abs(v.x), Math.Abs(v.y));
        }

        public static double Dot(Vector2D a, Vector2D b)                    //Принимает два вектора a и b и возвращает их скалярное произведение.
        {                                                                   //Скалярное произведение векторов определяется как сумма произведений соответствующих компонент векторов. 
            return a.x * b.x + a.y * b.y;                                   //Этот метод может использоваться, например, для определения угла между двумя векторами.
        }

        public static Vector2D Max(Vector2D v, double d)                    //Gринимает вектор v и число d и возвращает новый вектор, у которого каждая компонента равна максимуму 
        {                                                                   //из соответствующей компоненты вектора v и числа d. Этот метод может использоваться для установки верхней границы значений вектора
            return new Vector2D(Math.Max(v.x, d), Math.Max(v.y, d));
        }

        public static Vector2D Min(Vector2D a, Vector2D b)                  //Принимает два вектора a и b и возвращает новый вектор, у которого каждая компонента равна минимуму из соответствующих компонент 
        {                                                                   //Векторов a и b. Этот метод может использоваться для определения нижней границы значений вектора.
            return new Vector2D(
                Math.Min(a.x, b.x),
                Math.Min(a.y, b.y)
            );
        }

        public static double GetAngleToX(Vector2D a)                                    //принимает вектор a и возвращает угол между этим вектором и осью X в градусах. Для расчета угла используется функция Math.Acos, 
        {                                                                               //которая возвращает арккосинус значения, полученного путем скалярного произведения вектора a и вектора (1, 0). 
            if (a.y > 0)                                                                //Результат умножается на 180 / Math.PI, чтобы преобразовать его из радиан в градусы. 
            {                                                                           //Если значение a.y отрицательно, то угол умножается на -1, чтобы получить правильное направление поворота.
                return Math.Acos(MathV.Dot(a, new Vector2D(1, 0))) * 180 / Math.PI;
            }
            else
            {
                return -Math.Acos(MathV.Dot(a, new Vector2D(1, 0))) * 180 / Math.PI;
            }
        }
    }
}