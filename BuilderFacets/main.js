class Person
{
    constructor()
    {
        //Address
        this.streetName = this.postcode = this.city = '';
        //works
        this.companyName = this.position = '';
        this.annualIncome = 0;
    }
    toString()
    {
        return `this person lives at ${this.streetName}, ${this.postcode}, ${this.city}`
        + ` works at ${this.companyName}, as a ${this.position} with annual income of ${this.annualIncome} .`;
    }
}
class PersonBuilder
{
    constructor(person = new Person())
    {
        this.person = person;
    }
    get lives()
    {
        return new PersonAddressBuilder(this.person);
    }
    get works()
    {
        return new PersonCompanyBuilder(this.person);
    }
    build()
    {
        return this.person;
    }
}
class PersonCompanyBuilder extends PersonBuilder
{
    constructor(person)
    {
        super(person);
    }
    at(companyName)
    {
        this.person.companyName = companyName;
        return this;
    }
    asA(position)
    {
        this.person.position = position;
        return this;
    }
    withIncome(income)
    {
        this.person.annualIncome = income;
        return this;
    }
}
class PersonAddressBuilder extends PersonBuilder
{
    constructor(person)
    {
        super(person);
    }
    at(streetName)
    {
        this.person.streetName = streetName;
        return this;
    }
    with(postcode)
    {
        this.person.postcode = postcode;
        return this;
    }
    in(city)
    {
        this.person.city = city;
        return this;
    }
}
let pb = new PersonAddressBuilder();
let person = pb.lives.at('St 123 Road').with('Postcode: BR2456').in('City:Siliguri')
.works.at('Google').asA('Software Engineer').withIncome(1000000).build();
console.log(person.toString());