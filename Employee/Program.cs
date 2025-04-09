// See https://aka.ms/new-console-template for more information

var e = new Employee();
var m = new Manager();

// m2 is the reference
// new Manager() is the object on the heap
Employee m2 = m;

// abstract is sub type of virtual
Console.WriteLine($"Employee {e.GetSalary()}");
Console.WriteLine($"Manager {m.GetTitle()}");

Console.WriteLine($"Manager m2 {m2.GetTitle()}");

public class Employee
{
    protected double salary = 10;

    
    public virtual double GetSalary()
    {
        return salary;
    }
    
    public string GetTitle() => "Employee";
}

public class Manager : Employee
{
    protected string department = "Sales";
    protected double bonus =20;

    public override double GetSalary()
    {
        return salary + bonus;
    }
    public new string GetTitle() => "Manager";

}