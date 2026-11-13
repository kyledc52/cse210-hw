using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(5, "Red");
        Rectangle rectangle = new Rectangle(10, 5, "Blue");
        Circle circle = new Circle(10, "Yellow");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape cur in shapes)
        {
            Console.WriteLine(cur.GetArea());
        }
    }
}