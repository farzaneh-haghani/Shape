namespace Shape;

public class UnitTest1
{
    [Fact]
    public void TestEquilateral()
    {
        Shape myEquilateral = ShapeFactory.CreateEquilateral((double)3);
        Assert.Equal(myEquilateral.Area(),9*Math.Sqrt(3)/4,0.00000001);
    }
}