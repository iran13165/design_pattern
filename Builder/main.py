
class HtmlElement:
    def __init__(self,name,text):
        self.Name = name
        self.Text = text
        self.Elements = []
        self.IndentSize = 2
    def ToStringImp(self,indent):
        str_list = []
        i = ' '*indent*self.IndentSize
        str_list.append(i+f"<{self.Name}>\n")
        if self.Text != None and self.Text != '':
            str_list.append(' '*(indent+1)*self.IndentSize)
            str_list.append(i+f"{self.Text}\n")
        
        for child in self.Elements:
           str_list.append(child.ToStringImp(indent+1))

        str_list.append(i+f"</{self.Name}>\n")
        return ''.join(str_list)
    def ToString(self):
        return self.ToStringImp(0)

class HtmlBuilder:
    def __init__(self,rootName):
        self.rootName = rootName
        self.root = HtmlElement(rootName,'')
    
    def AddChild(self,childTag,childText):
        child = HtmlElement(childTag,childText)
        self.root.Elements.append(child)
    
    def ToString(self):
        return self.root.ToString()
    
bulder = HtmlBuilder('ul')
bulder.AddChild('li','Hello')
bulder.AddChild('li','World')

print(bulder.ToString())
        