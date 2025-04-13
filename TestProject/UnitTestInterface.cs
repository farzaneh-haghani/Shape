namespace ShapeInterfaceLibrary;

public class UnitTestInterface
{
    [Fact]
    public void TestCircle()
    {
        var myCircle= ShapeFactory.CreateCircle((double)2);
        Assert.Equal(myCircle.Area(),4*Math.PI,0.00000001);
    }
    // e.g If developers in another company decided to change intyernal things, our code not depend of them and doesn't break(Changing later)
    // Always dependencies get upgrade
    [Fact]
    public void TestSquare()
    {
        var mycircle = ShapeFactory.CreateSquare((double)5);
        Assert.Equal(mycircle.Area(),25,0.00000001);
    }
    
    [Fact]
    public void TestRectangle()
    {
        var mycircle = ShapeFactory.CreateRectangle((double)7,3);
        Assert.Equal(mycircle.Area(),21,0.00000001);
    }
    
    [Fact]
    public void TestEquilateral()
    {
        var myEquilateral = ShapeFactory.CreateEquilateral((double)3);
        Assert.Equal(myEquilateral.Area(),9*Math.Sqrt(3)/4,0.00000001);
    }
    
    [Fact]
    public void TestPolygon()
    {
        var polygon = ShapeFactory.CreatePolygon([1,1,-2], [2,-2,0]);
        Assert.Equal(polygon.Perimeter() ,2*Math.Sqrt(5)+2,0.00000001);
    }

    [Fact]
    public void TestShapeName()
    {
        var shape = ShapeFactory.CreateCircle(1.0);
        var shapeWithName = shape as IShapeName; // Employee & manage were parent & child
        // IShape & IShapeName are both parents 
        // implicit cast works from Child to Parent only - i.e. Parent x = child; works
        // "C as D" is an explicit cast, and at runtime it works out if it is possible.
        Assert.Equal("Circle",shapeWithName?.ShapeName());
    }
    
    [Fact]
    public void TestNoShapeName()
    {
        var shape = ShapeFactory.CreateEquilateral(1.0);
        var shapeWithName = shape as IShapeName; // returns null because Triangle does not implement IShapeName
        Assert.Null(shapeWithName);
    }
    
}