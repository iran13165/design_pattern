const Relationship = Object.freeze({
 child: 0,
 parent: 1,
 sibling: 2
});
class Person
{
    constructor(name)
    {
        this.name = name;
    }
}
class RelationshipBrowser
{
    constructor()
    {
        if(this.constructor.name === 'RelationshipBrowser')
        {
            throw new Error('RelationshipBrowser is an abstract class');
        }
    }
    findAllChildenOf(name){}
}
class Relationships extends RelationshipBrowser
{
    constructor()
    {
        super();
        this.data = [];
    }
    addParentAndChild(parent, child)
    {
        this.data.push({
            from: parent,
            type: Relationship.parent,
            to: child
        });
    }
    findAllChildenOf(name)
    {
        return this.data.filter(x=>x.from.name === name && x.type === Relationship.parent).map(x=>x.to);
    }

}

class Research
{
    // constructor(relationship)
    // {
    //     let relations = relationship.data;
    //     for(let rel of relations.filter(r => r.from.name === "Iran" && r.type === Relationship.parent)) { 
    //         console.log(`Iran has a child named ${rel.to.name}`);
    //     }
    // }
    constructor(brower)
    {
        for(let rel of brower.findAllChildenOf("Iran"))
        {
            console.log(`Iran has a child named ${rel.name}`);
        }
    }
}
let parent = new Person("Iran");
let chaild1 = new Person("Risad");
let chaild2 = new Person("Liza");
let relation = new Relationships();
relation.addParentAndChild(parent, chaild1);
relation.addParentAndChild(parent, chaild2);
new Research(relation);