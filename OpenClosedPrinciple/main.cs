using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
public enum Color
{
    Red, Blue, Green
}
public enum Size
{
    Small, Medium, Large
}

public class Product
{
    public string Name;
    public Color Color;
    public Size Size;
    public Product(string name, Color color, Size size)
    {
        Name = name;
        Color = color;
        Size = size;
    }
}
class ProductFilter
{
    public IEnumerable<Product> filterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var product in products)
        {
            if (product.Color == color)
                yield return product;
        }
    }
    public IEnumerable<Product> filterBySize(IEnumerable<Product> products, Size size)
    {
        foreach (var product in products)
        {
            if (product.Size == size)
                yield return product;
        }
    }
    public List<Product> filterBySizeAndColor(List<Product> products, Size size, Color color)
    {
        return products.Where(p => p.Size == size && p.Color == color).ToList();
    }
    //state space explosion
    //criterion = 7 different methods
}
public interface ISpecification<T>
{
    bool IsSatisfied(T t);
}
public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}
class ColorSpecification : ISpecification<Product>
{
    public Color color;
    public ColorSpecification(Color color)
    {
        this.color = color;
    }
    public bool IsSatisfied(Product p)
    {
        return p.Color == color;
    }
}
class SizeSpecification : ISpecification<Product>
{
    public Size size;
    public SizeSpecification(Size size)
    {
        this.size = size;
    }
    public bool IsSatisfied(Product p)
    {
        return p.Size == size;
    }
}
class AndSpecification<T> : ISpecification<T>
{
    ISpecification<T> first, second;
    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
        this.first = first;
        this.second = second;
    }
    public bool IsSatisfied(T t)
    {
        return first.IsSatisfied(t) && second.IsSatisfied(t);
    }
}
class BetterFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
        foreach (var p in items)
            if (spec.IsSatisfied(p))
                yield return p;
    }
}

class Demo
{
    static void Main(string[] args)
    {
        var apple = new Product("Apple", Color.Green, Size.Small);
        var tree = new Product("Tree", Color.Green, Size.Large);
        var house = new Product("House", Color.Blue, Size.Large);
        Product[] products = { apple, tree, house };
        var pf = new ProductFilter();
        Console.WriteLine("Green Products(Old): ");
        foreach (var p in pf.filterByColor(products, Color.Green))
        {
            Console.WriteLine($"{p.Name} is green");
        }
        // var pr = new List<Product>();
        // pr.Add(apple);
        // pr.Add(tree);
        // pr.Add(house);
        // foreach (var p in pf.filterBySizeAndColor(pr,Size.Large,Color.Green))
        // {
        //     Console.WriteLine($"{p.Name} is green & large");
        // }
        var bf = new BetterFilter();
        Console.WriteLine("Green Products(New): ");
        foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
        {
            Console.WriteLine($"{p.Name} is green");
        }
        Console.WriteLine("Green and Large Products(New): ");
        foreach (var p in bf.Filter(products,
        new AndSpecification<Product>(
           new ColorSpecification(Color.Green),
           new SizeSpecification(Size.Large))
           ))
        {
            Console.WriteLine($"{p.Name} is large and green");
        }
    }
}

////////////////////////
// class BetterFilter 
// {
//     filter(items, spec)
//     {
//         return items.filter(x => spec.isSatisfied(x));
//     }
// }
// let bf = new BetterFilter();
// console.log('Green Products(New): ');
// for(let p of bf.filter(products,new ColorSpecification(Color.green)))
// {
//     console.log(`* ${p.name} is green`);
// }

// let spec = new AndSpecification(new ColorSpecification(Color.green), new SizeSpecification(Size.large));

// console.log('Large & Green Products(New): ');
// for(let p of bf.filter(products,spec))
// {
//     console.log(`* ${p.name} is large & green`);
// }