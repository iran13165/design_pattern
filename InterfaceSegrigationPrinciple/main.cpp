#include <iostream>

using namespace std;


    class Document
    {
    };

    class IMachine
    {
        public:
        virtual void Print(Document d);
        virtual void Fax(Document d);
        virtual void Scan(Document d);
    };

    // ok if you need a multifunction machine
    class MultiFunctionPrinter : public IMachine
    {
        public:
         void Print(Document d) override
        {
            //
        }

         void Fax(Document d) override
        {
            //
        }

         void Scan(Document d) override
        {
            //
        }
    };

     class OldFashionedPrinter : IMachine
    {
        public:
         void Print(Document d) override
        {
            // yep
        }

         void Fax(Document d) override
        {
            //
        }

         void Scan(Document d) override
        {
           // throw new System.NotImplementedException();
        }
    };

     class IPrinter
    {
        public:
        virtual void Print(Document d);
    };

    class IScanner
    {
        public:
        virtual void Scan(Document d);
    };

    class Printer : public IPrinter
    {
        public:
         void Print(Document d) override
        {

        }
    };

    class Photocopier : IPrinter, IScanner
    {
        public:
        void Print(Document d) override
        {
            //throw new System.NotImplementedException();
        }

        void Scan(Document d) override
        {
            //throw new System.NotImplementedException();
        }
    };

    class IMultiFunctionDevice : IPrinter, IScanner //
    {
        
    };

    class MultiFunctionMachine : IPrinter, IScanner
    {
        // compose this out of several modules
       
        IPrinter printer;
        IScanner scanner;
        public:
        MultiFunctionMachine(IPrinter printer, IScanner scanner): printer(printer), scanner(scanner)
        {
           
        }

        void Print(Document d) override
        {
            printer.Print(d);
        }

        void Scan(Document d) override
        {
            scanner.Scan(d);
        }
    };

    int main(int argc, char const *argv[])
    {
        
        return 0;
    }
    
    
