#include <iostream>
#include <string>
#include <vector>

using namespace std;

class HtmlElement
{
    string Name;
    string Text;
    public:
    vector<HtmlElement> Elements {};
    const int IndentSize  {2};
    HtmlElement(){};
    HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }
    string ToStringImp(int indent)
    {
        vector<string> Strings {};
        string i = std::string(' ',indent + IndentSize);
        Strings.push_back(i+"<"+Name+">\n");
        if(!Text.empty())
        {
            Strings.push_back(std::string(" ",(indent+1) + IndentSize)+Text+"\n");
        }
        for(HtmlElement e:Elements)
        {
            Strings.push_back(e.ToStringImp(indent + 1));
        }
        Strings.push_back(i+"</"+Name+">\n");
        string finalString {};
        for(string s:Strings)
        {
            finalString += s;
        }
        return finalString;
    }
    string ToString()
    {
        return ToStringImp(0);
    }
};
class HtmlBuilder
{
    HtmlElement* root;
    HtmlElement* child;
    string RootName;
    public:
    HtmlBuilder(string rootName)
    {
        RootName = rootName;
        root = new HtmlElement(rootName,"");

    }
    void AddChild(string childTag, string childText)
    {
        child = new HtmlElement(childTag, childText);
        root->Elements.push_back(*child);
    }
    string ToString()
    {
        return root->ToString();
    }
    ~HtmlBuilder()
    {
        delete child;
        delete root;
        
    }

};
int main(int argc, char const *argv[])
{
    HtmlBuilder builder = HtmlBuilder("ul");
    builder.AddChild("li","Hello");
    builder.AddChild("li","World");
    cout << builder.ToString() << endl;
    return 0;
}
