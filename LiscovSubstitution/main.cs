using System;
namespace DesignPattern
{
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle() { }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}:{Height}";
        }

    }
    class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
        public Square(){}
        public Square(int width)
        {
            base.Width = width;
            base.Height =width;
        }
    }
    class Demo
    {
        public static int Area(Rectangle r)
        {
            return r.Width * r.Height;
        }
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(2, 3);
            Console.WriteLine($"{r} has Area {Area(r)}");
            Rectangle s = new Square();
            s.Width = 70;
            Console.WriteLine($"{s} has Area {Area(s)}");
        }
    }
}
