namespace ObjectLibrary2;
using ObjectLibrary;

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
}