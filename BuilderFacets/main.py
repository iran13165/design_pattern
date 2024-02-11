class Person:
    def __init__(self):
        self.streetName = ''
        self.postalCode = ''
        self.city = ''
        self.company = ''
        self.position = ''
        self.yearlyIncome = 0
    def ToString(self):
        return f"this person lives at {self.streetName}, {self.postalCode}, {self.city}"+ f" works at {self.company}, as a {self.position} with annual income of {self.yearlyIncome} ."
    
class PersonBuilder:
    def __init__(self):
        self.person = Person()
    
    @property
    def lives(self):
        return PersonAddressBuilder(self.person)
    
    @property
    def works(self):
        return PersonJobBuilder(self.person)
    
    def build(self):
        return self.person
    
class PersonJobBuilder(PersonBuilder):
    def __init__(self, person):
        self.person = person
    
    def at(self,company):
        self.person.company = company
        return self
    
    def position(self,position):
        self.person.position = position
        return self
    
    def withIncome(self,yearlyIncome):
        self.person.yearlyIncome = yearlyIncome
        return self

class PersonAddressBuilder(PersonBuilder):
    def __init__(self, person):
        self.person = person
    
    def at(self,streetName):
        self.person.streetName = streetName
        return self
    
    def withpost(self,postcode):
        self.person.postalCode = postcode
        return self
    
    def inA(self,city):
        self.person.city = city
        return self

pb = PersonBuilder()
person = pb.lives.at('St 123 Road').withpost('Postcode: BR2456').inA('City:Siliguri').works.at('Google').position('Software Engineer').withIncome(1000000).build()
print(person.ToString())