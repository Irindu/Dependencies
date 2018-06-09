using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEScannerLibrary
{
    public class PortableExecutable
    {
        public PortableExecutable()
        {
            // This is the no parameter constructor method.
            // First Constructor
        }

        public PortableExecutable(String fileName)
        {
               this.FileName = fileName;
        }

        public string FileName
        {
            get;
            set;
        }

        public ArrayList Dependencies { get => dependencies; set => dependencies = value; }

        ArrayList dependencies = new ArrayList();

        List<string> ExportedFunctions = new List<string>();
        List<string> Imports = new List<string>();


        public ArrayList GetDependencies() {
            return dependencies;
        }


       public List<String> GetExports()
        {
            return ExportedFunctions;
        }

        public List<String> GetImports()
        {
            return Imports;
        }

        public void MakeDependencies()
        {
            for (int i = 0; i < 10; i++)
            {
                String filename = "filename" + i;
                PortableExecutable portableExecutable = new PortableExecutable(filename);
                this.dependencies.Add(portableExecutable);

            }
        }

        public void MakeExports()
        {
            for (int i = 0; i < 10; i++)
            {
                String str = "functionName" + i + "(Type arg1,Type arg2)";
                this.ExportedFunctions.Add(str);

            }
        }

        public void MakeImports()
        {

            for (int i = 0; i < 10; i++) {
                String str = "functionName"+ i +"(Type arg1,Type arg2)";
                this.Imports.Add(str);

            }

        }
    }
}
