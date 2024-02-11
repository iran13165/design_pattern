using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    private readonly List<string> entries = new List<string>();
    private static int count = 0;
    public int addEntry(string text)
    {
        entries.Add($"{++count}: {text}");
        
        return count; //memento
    }
    public void removeEntry(int index)
    {
       entries.RemoveAt(index);
    }
    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }
}
public class PersistenceManager
{
    public void saveJournal(string filename,Journal j, bool overrite = false)
    {
        if(overrite || !File.Exists(filename))
        File.WriteAllText(filename,j.ToString());
    }
}
public class Demo
{
    static void Main(string[] args)
    {
        Journal j = new Journal();
        j.addEntry("I cried today");
        j.addEntry("I ate a bug");
       Console.WriteLine(j);
       var p = new PersistenceManager();
       string filename = "journal_c.txt";
       p.saveJournal(filename,j,true);
    }
}

