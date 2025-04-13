namespace ObjectLibrary;

public static class ObjectFactory
{
    public static Solid CreateSphere(double radius)
    {
        return new Sphere(radius);
    }

    public static Solid CreateCube(double side)
    {
        return new Cube(side);
    }

    public static Shape CreateCircle(double radius)
    {
        return new Circle(radius);
    }

    public static Shape CreateSquare(double side)
    {
        return new Square(side);
    }

    public static Shape CreateRectangle(double width,double height)
    {
        return new Rectangle(width, height);
    }

    public static Shape Equilateral(double side)
    {
        return new Equilateral(side);
    }

    public static Shape Isosceles(double sideA, double sideB)
    {
        return new Isosceles(sideA, sideB);
    }

    public static Shape Scalene(double sideA, double sideB, double sideC)
    {
        return new Scalene(sideA, sideB, sideC);
    }
}

public interface IVolume
{
     double Volume();
}

public interface IArea
{
    double Area();
}

public interface IPerimeter
{
    double Perimeter();
}

public abstract class Solid:IVolume,IArea
{
    public abstract double Volume();
    public abstract double Area();
}

public abstract class Shape:IPerimeter,IArea
{
    public abstract double Perimeter();
    public abstract double Area();
}

internal class Sphere : Solid
{
    private readonly double _radius;

    public Sphere(double radius)
    {
        _radius = radius;
    }

    public override double Area()
    {
        return 4 * Math.PI * _radius * _radius;
    }

    public override double Volume()
    {
        return 4 * Math.PI * _radius * _radius/3;
    }
}

internal class Cube : Solid
{
    private readonly double _side;

    public Cube(double side)
    {
        _side = side;
    }

    public override double Area()
    {
        return 6 * _side * _side;
    }

    public override double Volume()
    {
        return _side * _side * _side;
    }
}

public class Circle:Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public override double Area()
    {
        return Math.PI * _radius * _radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * _radius;
    }
}

public class Square : Shape
{
    private readonly double _side;

    public Square(double side)
    {
        _side = side;
    }

    public override double Area()
    {
        return _side * _side;
    }

    public override double Perimeter()
    {
        return 4 * _side;
    }
}

public class Rectangle : Shape
{
    private readonly double _width;
    private readonly double _height;

    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public override double Area()
    {
        return  _width* _height;
    }

    public override double Perimeter()
    {
        return 2 * _width + 2 * _height;
    }
}

internal abstract class Triangle:Shape
{
    protected double SideA;
    protected double SideB;
    protected double SideC;

    public override double Perimeter()
    {
        return SideA + SideB + SideC;
    }
}

internal class Equilateral : Triangle
{
    public Equilateral(double sideA)
    {
        SideA = sideA;
        SideB = sideA;
        SideC = sideA;
    }
    public override double Area()
    {
        return Math.Sqrt(3) / 4 * SideA*SideB;
    }
}

internal class Isosceles : Triangle
{
    public Isosceles(double sideA, double sideB)
    {
        SideA = sideA;
        SideC = sideA;
        SideB = sideB;
    }

    public override double Area()
    {
        return SideB * Math.Sqrt(SideA*SideA - SideB*SideB/4)/2;
    }
}

internal class Scalene : Triangle
{
    public Scalene(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double Area()
    {
        var p = Perimeter();
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }
}
