from enum import Enum
from abc import ABC, abstractmethod

class Color(Enum):
    Red = 0
    Green = 1
    Blue = 2
class Size(Enum):
    Small = 0
    Medium = 1
    Large = 2

class Product:
    
    def __init__(self,name,color,size):
        self.name = name
        self.color = color
        self.size = size

class ProductFilter:
    def filterByColor(self,products,color):
        return list(filter(lambda p: p.color == color,products))
    def filterBySize(self,products,size):
        return list(filter(lambda p: p.size == size,products))
################################################################
class Specification(ABC):
    @abstractmethod
    def IsSatisfied(self,product):
        pass

class BetterFilter():
    def Filter(self,products,spec):
        returnProducts = []
        for product in products:
            if spec.IsSatisfied(product):
                returnProducts.append(product)
        return returnProducts

class ColorSpecification(Specification):
    def __init__(self,color):
        self.color = color
    def IsSatisfied(self,product):
        return self.color == product.color

class SizeSpecification(Specification):
    def __init__(self,size):
        self.size = size
    def IsSatisfied(self,product):
        return self.size == product.size

class AndSpecification(Specification):
    def __init__(self,spec1,spec2):
        self.spec1 = spec1
        self.spec2 = spec2
    def IsSatisfied(self,product):
        return self.spec1.IsSatisfied(product) and self.spec2.IsSatisfied(product)




apple = Product("Apple",Color.Green,Size.Small)
house = Product("House",Color.Blue,Size.Large)
tree = Product("Tree",Color.Green,Size.Large)
products = [apple, house, tree]

fp = ProductFilter()
print("Product is Green(Old):\n")
for p in fp.filterByColor(products,Color.Green):
    item = p.name
    print(f"{item} is Green")

bf = BetterFilter()
print("Product is Green(New):\n")
for p in bf.Filter(products,ColorSpecification(Color.Green)):
    item = p.name
    print(f"{item} is Green")

print("Product is Green and Large (New):\n")
for p in bf.Filter(products,AndSpecification(ColorSpecification(Color.Green),SizeSpecification(Size.Large))):
    item = p.name
    print(f"{item} is large and Green")





