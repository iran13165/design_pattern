#ifndef pb 
#define pb 
#include "p.hpp"
#include "jb.hpp"
class PersonBuilder
{
public:
    Person person = Person();
    PersonAddressBuilder lives()
    {
       PersonAddressBuilder address = PersonAddressBuilder(&person);
        return  address;
    }
     PersonJobBuilder works()
    {
        return  PersonJobBuilder(&person);
    }
    Person build()
    {
        return person;
    }
};
#endif