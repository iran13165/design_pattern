using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
enum Relationship{Parent,Child,Sibling}

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
}
interface IRelationship
{
    IEnumerable<Person> findAllChildrenOf(string name);
}
class Relationships : IRelationship
{
    private List<(Person,Relationship,Person)> relations = new List<(Person, Relationship, Person)>();
    public Relationships()
    {

    }
    public void AddRelationship(Person parent, Person child)
    {
        var rel = (parent,Relationship.Parent,child);
        relations.Add(rel);
    }
    public IEnumerable<Person> findAllChildrenOf(string name)
    {
        foreach(var r in relations.Where(r => r.Item1.Name == name && r.Item2 == Relationship.Parent))
        {
            yield return r.Item3;
        }
    }
}
class Research
{
    public Research(IRelationship relationships)
    {
        // List<(Person,Relationship,Person)> rels = relationships.relations;
        // foreach (var rel in rels.Where(r=>r.Item1.Name == "Iran" && r.Item2 == Relationship.Parent))
        // {
        //     Console.WriteLine($"Iran has a children named {rel.Item3.Name}");
        // }
          // List<(Person,Relationship,Person)> rels = relationships.findAllChildrenOf("Iran");
           foreach (var rel in relationships.findAllChildrenOf("Iran"))
           {
                Console.WriteLine($"Iran has a children named {rel.Name}");
           }
    }
}
class Demo
{
    static void Main(string[] args)
    {
        var parent = new Person("Iran");
        var child1 = new Person("Risad");
        var child2 = new Person("Liza");
        var relations = new Relationships();
        relations.AddRelationship(parent, child1);
        relations.AddRelationship(parent, child2);
        new Research(relations);

    }
}