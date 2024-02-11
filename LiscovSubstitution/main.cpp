#include <iostream>

using namespace std;

class Rectangle
{
    
protected:
    int width;
    int height;
public:
    virtual void setWidth(int value)
    {
        width = value;
    }
    virtual void setHeight(int value)
    {
        height = value;
    }
    Rectangle() {}
    Rectangle(int width, int height) : width(width), height(height) {}
    int Area()
    {
        return width * height;
    }
    string ToString()
    {
        return "width: " + to_string(width) + ", height: " + to_string(height);
    }
};
class Square : public Rectangle
{
public:
    Square(){};
    Square(int width)
    {
        this->width = width;;
        this->height = width;
    }
    void setWidth(int value) override
    {
        width = value;;
        height = value;
    }
    void setHeight(int value) override
    {
        width = value;
        height = value;
    }
};

int main(int argc, char const *argv[])
{
    Rectangle r = Rectangle(2, 3);

    cout << r.ToString() << " has area of " << r.Area() << endl;

    Rectangle *c = new Square(4);
    c->setWidth(9);
    cout << c->ToString() << " has area of " << c->Area() << endl;
    return 0;
}
