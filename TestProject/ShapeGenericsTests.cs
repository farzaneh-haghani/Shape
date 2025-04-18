using ObjectLibrary;

namespace TestProject1;

public class Sorter<T>  where T  : IComparable<T>
{
    public T[] Sort(T[] array)
    {
        //sorts
        for (var i = 0; i < array.Length - 1; i++)
        {
            // compare
            if (array[i].CompareTo(array[i + 1]) > 0)
            {
                // swap
            }
        }
        return null;
    }
}

public class TotallyGeneric<T> // no where condition on T.
{
    public void Print(T value)
    {
        // but EVERY class happens to derive from System.Object
        var t = value?.GetType();
        System.Console.WriteLine(value?.ToString());
    }
}
public class AreaComparer<T> where T : IArea
{
    public bool Compare(T value, T value2)
    {
        return value.Area() == value2.Area();
    }
}



public class MyClass
{
    
}
public class MyData : IComparable<MyData>
{
    private double _value = 9.0;

    public int CompareTo(MyData? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return _value.CompareTo(other._value);
    }
}

public class ShapeGenericsTests
{
    [Fact]
    public void TestPrism()
    {
        Circle? circle = ObjectFactory.CreateCircle(1.0) as Circle;
        var prism = new Prism<Circle>(circle, 5.0);
        
        Square? square = ObjectFactory.CreateSquare(1.0) as Square;
        var prism2 = new Prism<Square>(square, 5.0);
        
        Rectangle? rectangle = ObjectFactory.CreateRectangle(2.0, 1.0) as Rectangle;
        var prism3 = new Prism<Rectangle>(rectangle, 2.0);
        
    }

    [Fact]
    public void TestSorted()
    {
        var s1 = new Sorter<double>(); // double is alias for System.Double
        var s2 = new Sorter<string>(); // string is alias for System.String
        var s3 = new  Sorter<MyData>();
        int x = 1; // Int32
    }

    [Fact]
    public void TestExtensionMethod()
    {
        var circle = ObjectFactory.CreateCircle(1.0);
        var cylinder = circle.MakePrismFrom(3.0);

        List<int> myList = [1, 2, 3, 4, 5];
        myList.PrintPlus(4); // Extension

        int[] xa = [1, 2, 3]; // array. It's 3 elements of memory
        List<int> ya = [1, 2, 3]; // class that "wraps" and array, so is has extra methods like Add, Contains,
        IList<int> yb = xa; // IList is the interface implemented by List

        // void Method(IList<int> l);
        //[]dx  List<int>
    }

    public static class UsefulFunctions
    {
        public static double SurfaceAreaToVolumeRatio<TSolid>(TSolid solid) where TSolid : Solid
        {
            // Solid is the abstract parent of Sphere and Cube
            // TSolid Type   e.g Sphere
            return solid.Area() / solid.Volume();
        }
    }
    [Fact]
    public void HomeWork()
    {
        var circle = ObjectFactory.CreateCircle(1.0);
        // These are extension methods on Circle
        var bigCircle = circle.MagnifyShape(2.0);
        var boundingBox = circle.BoundingBox(); // (return a new object)  return a Square that contains the Circle
        var boundedBox = circle.BoundedBox(); // (return a new object)  return a Square that fits inside the Circle
        // Generic
        // write a method SurfaceAreaToVolumeRatio<Solid> { double Ratio() } // i.e. Area()/Volume()
        // does have a Sphere have a smaller Surface area to volume ratio than a Cube. Why are bubbles spherical?

        var sphere = ObjectFactory.CreateSphere(0.2);
        var sratio = UsefulFunctions.SurfaceAreaToVolumeRatio(sphere);
        var cube = ObjectFactory.CreateCube(0.2);
        var cratio = UsefulFunctions.SurfaceAreaToVolumeRatio(cube);
    }
    public int Function(int x, int y)
    {
        return x * y;
    }
}