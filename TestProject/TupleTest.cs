namespace TestProject1;

public class TupleTest
{
    (double, int) MethodThatReturnsTuple()
    {
        return (1.0, 2);
    }
    [Fact]
    public void Tuples()
    {
        int i = 1; //Single tuple
        (int, int) d = (1, 2); // double, the type is (int,int)
        (string, int) v = d; // invalid
    }

    public class NamedClass
    {
        private int X;
        private string Y;
    }
    [Fact]
    public void AnonymousClass()
    {
        
        int[]  a = { 1, 2, 3 };
        var r = a.Select((x) => new {X=x,Y=x.ToString()}).ToList(); // { int X, string Y } is an anonymous class
        // [{1,"1"},{2,"2"}]
        foreach (var e in r)
        {
            var b = e.X;
            var c = e.Y;
        }
    }
    // [
    // {
    //  X : d // int
    //  Y : { // string
    //       c : e
    //       }
    // }
    // ]
                
            }
}

