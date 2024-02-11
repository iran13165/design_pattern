using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
class Person
{
    public string streetName { get; set; }
    public string postcode { get; set; }
    public string city { get; set; }
    public string companyName { get; set; }
    public string position { get; set; }
    public int annualIncome { get; set; }
    public Person()
    {
        streetName = postcode = city = "";
        companyName = position = "";
        annualIncome = 0;

    }
    public override string ToString()
    {
        return $"this person lives at {this.streetName}, {this.postcode}, {this.city}"
       + $" works at {this.companyName}, as a {this.position} with annual income of {this.annualIncome} .";

    }
}
class PersonBuilder
{
    public Person person = new Person();

    public PersonBuilder()
    {
    }
    public PersonAddressBuilder lives   // property
    {
        get { return new PersonAddressBuilder(person); }   // get method
                                                                  //set { name = value; }  // set method
    }
    public PersonCompanyBuilder works   // property
    {
        get { return new PersonCompanyBuilder(person); }   // get method
                                                           //set { name = value; }  // set method
    }
    public Person build()
    {
        return this.person;
    }
}
class PersonAddressBuilder : PersonBuilder
{

    public PersonAddressBuilder(Person person)
    {
        this.person = person;
    }
    public PersonAddressBuilder at(string streetName)
    {
        this.person.streetName = streetName;
        return this;
    }
    public PersonAddressBuilder with(string postcode)
    {
        this.person.postcode = postcode;
        return this;
    }
    public PersonAddressBuilder ina(string city)
    {
        this.person.city = city;
        return this;
    }
}
class PersonCompanyBuilder : PersonBuilder
{

    public PersonCompanyBuilder(Person person)
    {
        this.person = person;
    }
    public PersonCompanyBuilder at(string companyName)
    {
        this.person.companyName = companyName;
        return this;
    }
    public PersonCompanyBuilder asA(string position)
    {
        this.person.position = position;
        return this;
    }
    public PersonCompanyBuilder withIncome(int income)
    {
        this.person.annualIncome = income;
        return this;
    }
}
class Demo
{
    static void Main(string[] args)
    {
        PersonBuilder pb = new PersonBuilder();
        Person p = pb.lives.at("St 123 Road").with("Postcode: BR2456").ina("City:Siliguri")
        .works.at("Google").asA("Software Engineer").withIncome(1000000).build();
        Console.WriteLine(p.ToString());
    }
}