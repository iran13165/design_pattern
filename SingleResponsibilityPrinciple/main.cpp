#include <vector>
#include <iostream>
#include <fstream>

using namespace std;
class Journal
{
private:
    vector<string> entries{};
    int count = 0;

public:
    Journal(/* args */);
    int addEntry(string text);
    string toString();
    ~Journal();
};

Journal::Journal(/* args */)
{
}

Journal::~Journal()
{
}
int Journal::addEntry(string text)
{
    entries.push_back(to_string(++count) + ": " + text);
    return count;
}
string Journal::toString()
{
    string output = "";
    for (string entry : entries)
    {
        output += entry + "\n";
    }
    return output;
}
class PersistanceManager
{
public:
    void saveJournal(string filename, Journal *j)
    {
        ofstream output;
        output.open(filename);
        output << j->toString();
        output.close();
    }
};
int main(int argc, char const *argv[])
{
    Journal *j = new Journal();
    j->addEntry("I cried today c++");
    j->addEntry("I ate a bug");
    cout << j->toString();
    PersistanceManager *pm = new PersistanceManager();
    string filename = "testcpp.txt";
    pm->saveJournal(filename, j);

    delete j;
    delete pm;
    return 0;
}
