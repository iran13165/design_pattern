const fs = require('fs');
class Journal
{
    constructor()
    {
        this.entries = {};
    }
    addEntry(text)
    {
        let c = ++Journal.count;
        let entry = `${c}: ${text}`;
        this.entries[c] = entry;
        return c;
    }
    removeEntry(index)
    {
        delete this.entries[index];
    }
    toString()
    {
        return Object.values(this.entries).join('\n');
    }
}
class PersistenceManager
{
    saveJournal(filename,journal)
    {
        fs.writeFileSync(filename,journal.toString());
    }
}
Journal.count = 0;
let j = new Journal();
j.addEntry('I cried today');
j.addEntry('I ate burgers today');
console.log(j.toString());
let p = new PersistenceManager();
p.saveJournal('journal.txt',j);

