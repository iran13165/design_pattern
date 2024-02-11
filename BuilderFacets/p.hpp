#ifndef jbp 
#define jbp
#include <string>
#include <iostream>

using namespace std;
class Person
{
public:
    string streetName;
    string postcode;
    string city;
    string company;
    string position;
    int income;
    Person()
    {
        streetName = postcode = city = company = position = "";
        income = 0;
    }
    string ToString()
    {
        return "this person lives at " + streetName + "," + postcode + "," + city + " works at " + company + " as a " + position + "with annual income of " + to_string(income);
    }
};
#endif