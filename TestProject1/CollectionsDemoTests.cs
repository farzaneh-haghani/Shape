using System.Collections.Immutable;
using Microsoft.VisualBasic;
using Xunit.Abstractions;

namespace Shape;
using System.Collections;

public class CollectionsDemoTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CollectionsDemoTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void DemoList()
    {
        var rand = new Random();
        
    // List<> is a generic. It's a class that depends on another class
         var listOfShapes = new List<Shape>();
         //var listOfShapes = new LinkedList<Shape>();
    
        for (var i = 0; i<100; i++)
        {
            var size1 = rand.NextDouble() * 100;
            listOfShapes.Add(ShapeFactory.CreateCircle(size1));
            var size2 = rand.NextDouble() * 100;
            listOfShapes.Add(ShapeFactory.CreateSquare(size2));
            listOfShapes.Add(ShapeFactory.CreateIsosceles(size1, size2));
        }

        // Where, OrderBy etc are called the LINQ collection extension methods define
        // in System.Linq.Enumerable
        var bigShapes = listOfShapes
            .Where((shape) =>  shape.Area() > 15000 )// like .filter()
            .OrderBy((shape) =>  shape.Area())
            .Select((shape, index) => new { area= shape.Area(), index })// like .map()
            .ToList();

        foreach (var shape in bigShapes)
        {
            _testOutputHelper.WriteLine($"{shape.index}: {shape.area}");
        }
    }

}