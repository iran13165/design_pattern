#ifndef jbm
#define jbm
#include <string>
#include <iostream>
#include <sstream>
#include "pb.hpp"
#include "p.hpp"


using namespace std;

class PersonBuilder;


int main(int argc, char const *argv[])
{
    PersonBuilder pbs = PersonBuilder();

    Person p = pbs.lives()
                   .at("St 123 Road")
                   .with("Postcode: BR2456")
                   .ina("City:Siliguri")
                   .works()
                   .at("Google")
                   .asA("Software Engineer")
                   .withIncome(1000000)
                   .build();
    cout << p.ToString() << endl;
    return 0;
}
#endif