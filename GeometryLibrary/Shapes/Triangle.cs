using GeometryLibrary.Abstract;

namespace GeometryLibrary.Shapes;

public class Triangle : IShape
{
    public double Side1 { get; }
    public double Side2 { get; }
    public double Side3 { get; }

    public Triangle(double side1, double side2, double side3)
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0)
        {
            throw new ArgumentException("All sides should be positive numbers.");
        }

        if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
        {
            throw new ArgumentException("The given sides cannot form a triangle.");
        }
   
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }
    
    public Triangle(double side1, double side2)
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = CalculateHypotenuse(side1, side2);
    }
    
    /// <summary>
    /// Здесь мы используем формулу Герона.
    /// </summary>
    /// <returns>Площадь треугольника.</returns>
    public double GetArea()
    {
        double s = (Side1 + Side2 + Side3) / 2;
        return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
    }
    
    /// <summary>
    /// Мы используем константу double.Epsilon для учета погрешностей округления.
    /// double.Epsilon - это наименьшее положительное число, которое можно представить в формате double.
    /// Мы умножаем double.Epsilon на квадрат наибольшей стороны треугольника, чтобы учитывать масштаб чисел.
    /// Таким образом, мы можем сравнить разницу между квадратом наибольшей стороны и суммой квадратов двух меньших
    /// сторон с погрешностью, которая равна машинной точности вещественных чисел. Это позволяет более точно проверять,
    /// является ли треугольник прямоугольным.
    /// </summary>
    /// <returns>Является ли треугольник прямоугольным.</returns>
    public bool IsRightAngled()
    {
        double[] sides = { Side1, Side2, Side3 };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) 
               <= double.Epsilon * Math.Pow(sides[2], 2);
    }

    private double CalculateHypotenuse(double a, double b)
    {
        return Math.Sqrt(a * a + b * b);
    }
}