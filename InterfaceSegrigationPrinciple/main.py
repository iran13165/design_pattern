from abc import ABC, abstractmethod

class Document:
    pass

class IMachine(ABC):
    @abstractmethod
    def Print(d):
       pass
    @abstractmethod
    def Fax(d):
       pass
    @abstractmethod
    def Scan(d):
       pass
    

    # ok if you need a multifunction machine
class MultiFunctionPrinter(IMachine):
    def Print(d):
       pass

    def Fax(d):
       pass
         
    def Scan(d):
       pass

class OldFashionedPrinter(IMachine): 
    def Print(d):
        pass
    def Fax(d):
         pass

    def Scan(d):
        pass


class IPrinter:
    @abstractmethod
    def Print(d):
        pass
    

class IScanner:
    @abstractmethod
    def Scan(d):
        pass

class Printer(IPrinter):
    def Print(d):
        pass

class Photocopier(IPrinter,IScanner): 
    def Print(d):
        pass
    def Scan(d):
        pass

class IMultiFunctionDevice(IPrinter, IScanner):
    pass

class MultiFunctionMachine(IMultiFunctionDevice):
    def __init__(self,printer,scanner):
        self.printer = printer
        self.scanner = scanner

    def Print(self,d):
        self.printer.Print(d)

    def Scan(self,d):
        self.scanner.Scan(d)
d = Document()
Printer.Print(d)
