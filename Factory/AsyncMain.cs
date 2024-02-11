using System;
using System.Threading.Tasks;
class Foo
{
    private Foo()
    {}
    private async Task<Foo> InitAsync()
    {
        await Task.Delay(1000);
        return this;
    }
    public static async Task<Foo> CreateAsync()
    {
        var result = new Foo();
        return await result.InitAsync();
    }
}
class Demo
{
    public static async Task Main(string[] args)
    {
      Foo x = await Foo.CreateAsync();
    }
}