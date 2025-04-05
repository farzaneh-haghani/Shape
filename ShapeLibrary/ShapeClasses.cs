using System.Formats.Asn1;

namespace Shape
{
    // static means there are no instances of this class (you can't "new()" it)
    // There is only one of these objects in the whole program.
    // this static class is also an example of the Singleton pattern.
    public static class ShapeFactory
    {
        //private int x; because x only belongs to an object that is new()'d
        private static int _x = 1; // this is ok, and it means there is only one instance of ShapeFactory.x in the program
        
        // static for a method means that the "this" variable isn't here.
        public static Shape CreateCircle(double radius)
        {
            return new Circle(){Radius = radius};
        }

        public static Shape CreateRectangle(double width, double height)
        {
            return new Rectangle(width, height);
        }

        public static Shape CreateSquare(double side)
        {
            return new Square(side);
        }

        public static Shape CreateEquilateral(double side)
        {
            return new Equilateral(side);
        }
        
      
        public static Shape CreateIsosceles(double side, double baseSide)
        {
            return new Isosceles(side, baseSide);
        }
        
        
        public static Shape CreateScalene(double sideA, double sideB, double sideC)
        {
            return new Scalene(sideA, sideB, sideC);
        }   
    }
    // Single Responsibility and Closed for Modification (new shapes will be new Classes - Open for Extension)
    public abstract class Shape
    {  
        // abstract means the derived class MUST provide an implementation
        public abstract double Area();
        
        // TODO add Perimeter
        
        // in any base class you can also delare the function  to have an
        // implementation. Overriding is optional.
        // public virtual string GetName() {....}
    }

    // Single Responsibility
// internal means that these classes are not visible outside of the class library
    internal class Circle : Shape
    {
        private double _radius;

        public double Radius
        {
            set { _radius = value; }
        }

        // override means that this function provides the implementation (body)
        // for the base Area() method
        public override double Area()
        {
            return Math.PI * Math.Pow(this._radius ,2);
        }
    }

    // Single Responsibility

    internal class Square : Shape
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }

        public override double Area()
        {
            return Math.Pow(_side,2);
        }
    }
    // Single Responsibility

    internal class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public override double Area()
        {
            return _width * _height;
        }
    }

    internal abstract class Triangle : Shape
    {
        protected double _sideA;
        protected double _sideB; 
        protected double _sideC;
        //public override double Perimeter() {...}
    }
    // Single Responsibility

    internal class Equilateral : Triangle
    {
        public Equilateral(double side)
        {
            _sideA = side;
            _sideB = side;
            _sideC = side;
        }

        public override double Area()
        {
            return Math.Sqrt(3) / 4 * _sideA*_sideB;
        }
    }
    // Single Responsibility

    internal class Isosceles : Triangle
    {
        public Isosceles(double side, double baseSide)
        {
            _sideA = side;
            _sideB = side;
            _sideC = baseSide;
        }

        public override double Area()
        {
            return _sideC * Math.Sqrt(_sideA*_sideA - _sideC*_sideC/4)/2;
        }
    }
    // Single Responsibility

    internal class Scalene : Triangle
    {
        public Scalene(double sideA,double sideB,double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }
      
        public override double Area()
        {
            double s = Perimeter();
            return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
        }

        public double Perimeter()
        {
            return _sideA+_sideB+_sideC;
        }
    }
}