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
        


        public String ReadFile() 
        {
            if (ExistFile())
            {
                return File.ReadAllText(path); ;
            }
            else
            {
                return "";
            }
        }
        public bool ExistFile()
        {
            return File.Exists(path);
            
        }
        public void AddText(string newText)
        {
            File.WriteAllText(path, ReadFile() + newText);
        }
        public void AddLine(string newLine)
        {
            File.WriteAllText(path, ((ReadFile() != "") ? ReadFile() + "\n" : "") + newLine);
        }
        





    }
}
