using System;
using System.Text;
using System.IO;

class PointFactory
{
    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }
    public static Point NewPolarPoint(double rho, double theta)
    {
        return new Point(rho * Math.Sin(theta), rho * Math.Cos(theta));
    }
}
class Point
{

    private double x;
    private double y;
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
    }
}
class Demo
{
    static void Main()
    {
        var p = PointFactory.NewPolarPoint(4, Math.PI / 2);
        Console.WriteLine(p.ToString());
    }
}