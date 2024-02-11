from enum import Enum
from abc import ABC, abstractmethod

class Relationship(Enum):
    Parent = 0
    Child = 1
    Sibling = 2

class Person:
    def __init__(self,name):
        self.name = name

class IRelationships(ABC):
    @abstractmethod
    def findAllChildrenOf(self,name):
        pass


class Relationships(IRelationships):
    def __init__(self):
        self.Relations = []
    def AddParentAndChild(self,parent,child):
        rel = (parent,Relationship.Parent,child)
        self.Relations.append(rel)
    def findAllChildrenOf(self,name):
        rels = []
        for rel in self.Relations:
            if rel[0].name == name and rel[1].Parent == Relationship.Parent:
                rels.append(rel[2])
        return rels
    
class Research:
    def __init__(self,relations):
        for rel in relations.findAllChildrenOf("Iran"):
            print("Iran has a child named " + rel.name)
        


parent = Person("Iran")
child1 = Person("Risad")
child2 = Person("Liza")
relations = Relationships()
relations.AddParentAndChild(parent,child1)
relations.AddParentAndChild(parent,child2)
r = Research(relations)





