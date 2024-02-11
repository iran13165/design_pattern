#include <vector>
#include <string>
#include <iostream>

using namespace std;

enum Size
{
    Small,
    Medium,
    Large
};
enum Color
{
    Red,
    Green,
    Blue
};

class Product
{
public:
    std::string name;
    Size size;
    Color color;

    Product(std::string name, Size size, Color color) : name(name), size(size), color(color) {}
};
class ProductFilter
{
public:
    std::vector<Product> filterProductByColor(std::vector<Product> products, Color color)
    {
        std::vector<Product> result{};
        for (Product p : products)
        {
            if (p.color == color)
                result.push_back(p);
        }
        return result;
    };
};

class Specification
{
public:
    virtual bool IsSatisfied(Product p) = 0;
};
class ColorSpecification : public Specification
{
public:
    Color color;
    ColorSpecification(Color color) : color{color} {};
    bool IsSatisfied(Product p) override
    {
        return p.color == color;
    }
};
class SizeSpecification : public Specification
{
public:
    Size size;
    SizeSpecification(Size size) : size{size} {};
    bool IsSatisfied(Product p) override
    {
        return p.size == size;
    }
};
template <typename T1, typename T2>
class AndSpecification : public Specification
{
public:
    T1 spec1;
    T2 spec2;
    AndSpecification(T1 spec1, T2 spec2) : spec1{spec1}, spec2{spec2} {};
    bool IsSatisfied(Product p) override
    {
        return spec1.IsSatisfied(p) && spec2.IsSatisfied(p);
    }
};

template <typename T>
class BetterFilter
{
public:
    std::vector<Product> Filter(std::vector<Product> products, T spec)
    {
        std::vector<Product> result;
        for (Product p : products)
        {
            if (spec.IsSatisfied(p))
                result.push_back(p);
        }
        return result;
    }
};

int main(int argc, char const *argv[])
{
    std::vector<int> gg;
    Product apple = Product("Apple", Small, Green);
    Product house = Product("House", Large, Blue);
    Product tree = Product("Tree", Large, Green);
    std::vector<Product> products{apple, house, tree};

    ProductFilter pf;
    for (Product p : pf.filterProductByColor(products, Green))
    {
        cout << p.name << " is Green" << std::endl;
    }
    BetterFilter<ColorSpecification> bf;

    for (Product p : bf.Filter(products, ColorSpecification(Color::Green)))
    {
        cout << p.name << " is Green" << std::endl;
    }

    BetterFilter<AndSpecification<SizeSpecification,ColorSpecification>> abf;

    for (Product p : abf.Filter(products, AndSpecification(SizeSpecification(Size::Large),ColorSpecification(Color::Green))))
    {
        cout << p.name << "is Large and Green" << std::endl;
    }
    return 0;
}