namespace Shape
{
    public static class Program
    {
        public static void Main()
        {
            // var examples
            //var x = 1;
            //x = "Hello";
            
            // when a class is abstract you can't new() it
            // Shape s = new Shape(); s.Area() doesn't mean anything
            // Triangle t = new Triangle();
            
            // using ShapeFactory and Shape, we have inverted the dependency so that
            // program is only dependent on more general stuff (importantly it's dependent
            // something that doesn't change much)
            var myCircle = ShapeFactory.CreateCircle(2.0);
            //myCircle.Radius = 2; doesn't work any more because myCircle is a Shape
            Console.WriteLine(myCircle.Area());
            
            // Since ShapeFactory is static and a Singleton, I don't need to do:
            // x = new ShapeFactory(); y = x.CreateCircle(...)
            // because then there is no confusion if somewhere else I do y = new ShapeFactory()...
            
            Shape mySquare = ShapeFactory.CreateSquare(2.0);
            Console.WriteLine(mySquare.Area());

            Shape myRectangle = ShapeFactory.CreateRectangle(2.0, 2.0);
            Console.WriteLine(myRectangle.Area());

            Shape myEquilateral = ShapeFactory.CreateEquilateral(3.0);
            Console.WriteLine(myEquilateral.Area());

            Shape myIsosceles = ShapeFactory.CreateIsosceles(side:7.0,baseSide:8.0);
            Console.WriteLine(myIsosceles.Area());

            Shape myScalene = ShapeFactory.CreateScalene(3.0,4.0,5.0);
            Console.WriteLine(myScalene.Area());

            // Circle c = new Circle(1); dependencies are now hidden, so changes to them can't break your code
        }
    }
}