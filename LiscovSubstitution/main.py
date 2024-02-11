class Rectangle:
    def __init__(self,width,height):
        self._width = width
        self._height = height

    @property
    def width(self):
        return self._width
    @width.setter
    def width(self,value):
        self._width = value
    
    @property
    def height(self):
        return self._height
    @height.setter
    def height(self,value):
        self._height = value

    
    def area(self):
        return self.width*self.height
    def ToString(self):
        return "Width: {0} , Height: {1}".format(self.width,self.height)

class Square(Rectangle):
    def __init__(self,width):
        self.height = width
        self.width = width
    @property
    def width(self):
        value = super().width
        return value
    @width.setter
    def width(self,value):
        super(__class__, self.__class__).width.__set__(self, value)
        super(__class__, self.__class__).height.__set__(self, value)
    
    @property
    def height(self):
        value = super().height
        return value
    @height.setter
    def height(self,value):
        super(__class__, self.__class__).height.__set__(self, value)
        super(__class__, self.__class__).width.__set__(self, value)



r = Rectangle(2,3)
print(r.ToString()+" has area is "+str(r.area()))
s = Square(4)
s.width = 10
print(s.ToString()+" has area is "+str(s.area()))
