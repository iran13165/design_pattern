#ifndef jb 
#define jb 

#include "pb.hpp"
#include "p.hpp"
#include <string>
class PersonAddressBuilder : public PersonBuilder
{
public:
    Person* person;
    PersonAddressBuilder(Person* p)
    {
        person = p;
    }
    PersonAddressBuilder at(string streetName)
    {
        person->streetName = streetName;
        return *this;
    }
    PersonAddressBuilder with(string postcode)
    {
        person->postcode = postcode;
        return *this;
    }
    PersonAddressBuilder ina(string city)
    {
        person->city = city;
        return *this;
    }
};
class PersonJobBuilder : public PersonBuilder
{
public:
    Person* person;
    PersonJobBuilder(Person* p)
    {
        person = p;
    }
    PersonJobBuilder at(string companyName)
    {
        person->company = companyName;
        return *this;
    }
    PersonJobBuilder asA(string position)
    {
        person->position = position;
        return *this;
    }
    PersonJobBuilder withIncome(int income)
    {
        person->income = income;
        return *this;
    }
};
#endif
