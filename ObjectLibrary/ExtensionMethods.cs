namespace ObjectLibrary;

public static class ExtensionMethods
{
    public static Solid MakePrismFrom(this Shape shape, double height)
    {
  
        return new Prism<Shape>(shape, height);
    }

    public static void PrintPlus(this List<int> list, double add)
    {
        foreach (var i in list)
        {
            Console.WriteLine(i + add);
        }
    }
    
    // public static Shape Magnify(this Circle circle,double zoom)
    // {
    //     // return new Circle( circle.Radius*zoom);
    //     return ObjectFactory.CreateCircle(circle.Radius * zoom);
    // }
    
    // public static Circle MagnifyCircle(this Circle circle,double zoom)
    // {
    //     var ret = ObjectFactory.CreateCircle(circle.Radius * zoom) as Circle; // null if !Circle
    //     return null; // BUT the caller will have to depend on Circle.
    // }
    
    public static Shape MagnifyShape(this Shape shape,double zoom)
    {
        switch (shape)
        {
            case Circle c:
            {
                return ObjectFactory.CreateCircle(c.Radius * zoom);
            }
            case Square s:
            {
                return ObjectFactory.CreateSquare(s.Side * zoom);
            }
            case Rectangle r:
            {
                return ObjectFactory.CreateRectangle(width: r._width, height: r._height);
            }
            case Equilateral et:
            {
                return ObjectFactory.CreateEquilateral(side: et.SideA * zoom);
            }
            case Isosceles it:
            {
                return ObjectFactory.CreateIsosceles(sideA: it.SideA * zoom, sideB: it.SideB * zoom);
            }
            case Scalene sc:
            {
                return ObjectFactory.CreateScalene(sideA: sc.SideA * zoom, sideB: sc.SideA * zoom,
                    sideC: sc.SideC * zoom);
            }
            default:
            {
                throw  new Exception("Shape not implemented");
            }
        }
    }

    public static Shape BoundingBox(this Shape shape)
    {
        if (shape is Circle circle)
        {
            return ObjectFactory.CreateSquare(side: 2 * circle.Radius);
        }
        else
        {
            throw new Exception("Shape must be a Circle");
        }
    }

    public static Shape BoundedBox(this Shape shape)
    {
        if (shape is Circle circle)
        {
            return ObjectFactory.CreateCircle(circle.Radius / Math.Sqrt(2));
        }
        else
        {
            throw new Exception("Shape must be a circle");
        }
    }
}