using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Collections;
using Xunit.Abstractions;
using ObjectLibrary;

namespace CollectionsDemoTests;


// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-9.0
// https://learn.microsoft.com/en-us/dotnet/standard/generics/collections

public class CollectionsDemoTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IList<Shape> _listOfShapes;
    
    private readonly IEnumerable<Shape> _deferredShapes;

    
    public CollectionsDemoTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var rand = new Random();
        
        // List<> is a generic. It's a class that depends on another class
        _listOfShapes = new List<Shape>();
        //var listOfShapes = new LinkedList<Shape>();
    
        // for (var i = 0; i<100; i++)
        // {
        //     var size1 = rand.NextDouble() * 100;
        //     _listOfShapes.Add(ObjectFactory.CreateCircle(size1));
        //     var size2 = rand.NextDouble() * 100;
        //     _listOfShapes.Add(ObjectFactory.CreateSquare(size2));
        //     _listOfShapes.Add(ObjectFactory.CreateIsosceles(size1, size2));
        // }

        // foreach (var shape in GetShapes())
        // {
        //     _listOfShapes.Add(shape);
        // }
        _deferredShapes = GetShapes();
        // var shapeSource = GetShapes().GetEnumerator();
        // var shape1 = shapeSource.Current;
        // var shape2 = shapeSource.MoveNext() ? shapeSource.Current : null;
        // var shape3 = shapeSource.MoveNext() ? shapeSource.Current : null;
    }

    private IEnumerable<Shape> GetShapes() // public interface IEnumerable<out T>
    {
        var rand = new Random();
        for (var i = 0; i < 100; i++)
        {
            var size1 = rand.NextDouble() * 100;
            var size2 = rand.NextDouble() * 100;
            yield return ObjectFactory.CreateCircle(size1);
            yield return ObjectFactory.CreateSquare(size2);
            yield return ObjectFactory.CreateIsosceles(size1, size2);
        }
    }
    
    [Fact]
    public void DemoList()
    {
        // Where, OrderBy etc are called the LINQ collection extension methods define in System.Linq.Enumerable
        var bigShapes = _listOfShapes
            .Where((shape) =>  shape.Area() > 15000 )// like .filter()
            .OrderBy((shape) =>  shape.Area())
            .Select((shape, index) => new { area= shape.Area(), index })// like .map()
            .ToList();

        foreach (var shape in bigShapes)
        {
            _testOutputHelper.WriteLine($"{shape.index}: {shape.area}");
        }
    }

    [Fact]
    public void DemoFilter()
    {
        // bigShapes does NOT query immediately but it is deferred.
        IEnumerable<Shape> bigShapes = _deferredShapes
            .Where((shape) => shape.Area() > 15000);// like .filter()
        IEnumerable<Shape> smallShapes = _deferredShapes
            .Where((shape) => shape.Area() < 15000);// like .filter()
// deferred execution(means not running anything unless we use the result) 

        bigShapes = bigShapes.Where((shape) => shape is Circle);
        bigShapes = bigShapes.Select((shape, index) => shape.MagnifyShape(2.0));
        
        ProcessLists(bigShapes, smallShapes);
        
        // foreach (var shape in bigShapes)
        // {
        //     _testOutputHelper.WriteLine($"{shape.index}: {shape.area}");
        // }
    }
    void ProcessLists(IEnumerable<Shape> bigShapes, IEnumerable<Shape>  littleShapes)
    {
        if (bigShapes.Count() > 10)
        {
            Console.WriteLine(bigShapes.Count());
        }
        else
        {
            Console.WriteLine(littleShapes.Count());
        }
    }
}

public class MyClass
{
    private string _name;
    private string _info;

    public MyClass(string name)
    {
        _name = name;
    }

    public MyClass(int num)
    {
        _name = num.ToString();
    }
    
    public MyClass(int num, string info)
    {
        _name = num.ToString();
        _info = info;
    }

    
    public void OverloadedMethod(int a, float b, string c)
    {
        
    }
    public void OverloadedMethod(List<int> a, float b, string c)
    {
        
    }
    public string Name => _name;

    public static void NewMyClass()
    {
        var c1 = new MyClass("Fred");
        var c2 = new MyClass(1);
        
        c1.OverloadedMethod(1, 1.0f, "");
        c1.OverloadedMethod([], 1.0f, "");
        
    }
}