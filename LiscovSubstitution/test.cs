using System;
class A
{
    public void Test()
    {
        Console.WriteLine("A Test");
    }
}
class B:A
{
     public new void Test()
    {
        Console.WriteLine("B Test");
    }
}
class Demo
{
    static void Main(string[] args)
    {
        A a = new A();
        B b = new B();
        a.Test();
        b.Test();
        a = new B();
        a.Test();
        

    }
}