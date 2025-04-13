namespace ObjectLibrary;

// A shape is a 2D thing. But I can generate a 3D solid from a shape
// in at least one way. A Prism takes a Shape and creates a Solid by moving the Shape in the z direction.
public class Prism<TShape> : Solid where TShape : Shape
{
    private TShape _shape;
    private double _height;
    public Prism(TShape shape, double height)
    {
        _shape = shape;
        _height = height;
    }

    public override double Volume()
    {
        return _shape.Area() * _height;
    }

    public override double Area()
    {
        return 2 * _shape.Area() + _height * _shape.Perimeter();
    }
}

public class Pyramid<TShape> : Solid where TShape : Shape
{
    private TShape _shape;
    private double _height;
    public Pyramid(TShape shape, double height)
    {
        _shape = shape;
        _height = height;
    }

    public override double Volume()
    {
        return  _shape.Area() * _height / 3.0; // ??Check
    }

    public override double Area()
    {
        return _shape.Area() + _height * _shape.Perimeter() / 2.0; // Way too hard to 
    }
}
