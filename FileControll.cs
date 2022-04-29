using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsersList
{

    internal class FileControll
    {
        private string path="";

        //getters and setters:
        public string Path
        {
            get => path;
            set => path = value;
        }

        
        public FileControll()
        {
            //default value
            this.path = @"D:\test.txt";
        }

        public FileControll(string path)
        {
            this.path = path;
        }
        


        public String readFile() 
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path); ;
            }
            else
            {
                return "";
            }
        }

        public void addText(string newText)
        {
            File.WriteAllText(path, readFile() + newText);
        }
        public void addLine(string newLine)
        {
            File.WriteAllText(path, ((readFile() != "") ? readFile() + "\n" : "") + newLine);
        }
        





    }
}
