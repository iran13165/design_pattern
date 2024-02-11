class Journal:
    entries = []
    count = 0
    def addEntry(self,text):
        self.count = self.count + 1
        j_text = str(self.count) + ": " + text
        self.entries.append(j_text)

    def toString(self):
        j_text = ""
        for entry in self.entries:
            j_text = j_text+entry+"\n"
        return j_text
    
class PersistanceManager:
    def saveJournal(self,filename,journal):
        f = open(filename, "w")
        f.write(journal.toString())
        f.close()

j = Journal()
j.addEntry("Hi i am iran.")
j.addEntry("Hi i ate pizza.")
print(j.toString())
pm = PersistanceManager()
filename = "text_py.txt"
pm.saveJournal(filename,j)



        
