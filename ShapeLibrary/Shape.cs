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
        
        public static Shape CreatePolygon(double[] dx, double[] dy)
        {
            return new Polygon(dx, dy);
        }
    }
    // Single Responsibility and Closed for Modification (new shapes will be new Classes - Open for Extension)
    public abstract class Shape
    {  
        // abstract means the derived class MUST provide an implementation
        public abstract double Area();
        public abstract double Perimeter();  //function signiture that has no body, We can't use new from abstact.

        // in any base class you can also declare the function  to have an
        // implementation. Overriding is optional.
        // public virtual string GetName() {....}
        
        //helper to calculate area of Triangle. It might be better to put in the Polygon class.
        public static double TriangleArea(double a, double b, double c)
        {
            return double.NaN;
        }
    // }

    // internal abstract class Derived : Shape
    // {
    //     protected abstract void Method();
        // or
        // protected virtual void Method();
        // {
        //     return;
        // }
    }

    // internal class MoreDerived : Derived
    // {
    //     public override double Area()
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     protected override void Method()
    //     {
    //         return;
    //     }
        

    //     public override double Perimeter()
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
    internal class Polygon:Shape
    {
        private double[] _dx;
        private double[] _dy;

        public Polygon(double[] dx, double[] dy)
        {
            _dx = dx;
            _dy = dy;
            // Array.Copy(dx,_dx,dx.Length);
            // Array.Copy(dy,_dy,dy.Length);
        }

        public override double Area()
        {
           // Area (A) = | (x1y2 – y1x2) + (x2y3 – y2x3)…. + (xny1 – ynx1)/2 |
            return 0.0;
        }

        public override double Perimeter()
        {
            double _premiter = 0.0;
            for (int i = 0; i < _dx.Length; i++)
            {
                
                // double diffX=Math.Abs(_dx[i] - _dx[i + 1]);
                // double diffY = Math.Abs(_dy[i] - _dy[i + 1]);
                // double side = Math.Sqrt(diffX * diffX + diffY * diffY);
                _premiter += Math.Sqrt(_dx[i]*_dx[i]+_dy[i]*_dy[i]);
            }
            // double lastDiffX=Math.Abs(_dx[_dx.Length-1] - _dx[0]);
            // double lastDiffY = Math.Abs(_dy[_dx.Length-1] - _dy[0]);
            // double lastside = Math.Sqrt(lastDiffX * lastDiffX + lastDiffY * lastDiffY);
            // _premiter += lastside;
            return _premiter;
        }
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
            return Math.PI * _radius * _radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * _radius;
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
            return _side * _side;
        }

        public override double Perimeter()
        {
            return 4 * _side;
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

        public override double Perimeter()
        {
            return 2 * (_width + _height);
        }
    }

    internal abstract class Triangle : Shape
    {
        protected double _sideA;
        protected double _sideB; 
        protected double _sideC;

        public override double Perimeter()
        {
          return _sideA + _sideB + _sideC;
        }
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


    }
}
 