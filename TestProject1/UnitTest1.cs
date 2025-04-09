﻿namespace Shape;

public class UnitTest1
{
    [Fact]
    public void TestCircle()
    {
        Shape mycircle = ShapeFactory.CreateCircle((double)2);
        Assert.Equal(mycircle.Area(),4*Math.PI,0.00000001);
    }
    
    [Fact]
    public void TestSquare()
    {
        Shape mycircle = ShapeFactory.CreateSquare((double)5);
        Assert.Equal(mycircle.Area(),25,0.00000001);
    }
    
    [Fact]
    public void TestRectangle()
    {
        Shape mycircle = ShapeFactory.CreateRectangle((double)7,3);
        Assert.Equal(mycircle.Area(),21,0.00000001);
    }
    
    [Fact]
    public void TestEquilateral()
    {
        Shape myEquilateral = ShapeFactory.CreateEquilateral((double)3);
        Assert.Equal(myEquilateral.Area(),9*Math.Sqrt(3)/4,0.00000001);
    }
    
    [Fact]
    public void TestPolygon()
    {
        Shape polygon = ShapeFactory.CreatePolygon([1,1,-2], [2,-2,0]);
        Assert.Equal(polygon.Perimeter() ,2*Math.Sqrt(5)+2,0.00000001);
    }
}