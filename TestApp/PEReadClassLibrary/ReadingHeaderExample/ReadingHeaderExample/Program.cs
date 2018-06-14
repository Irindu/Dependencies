using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using ReadingHeaderExample;
using System.Security;

namespace ReadingHeaderExample

{
    class program {
        const uint DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
        const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;

        [DllImport("kernel32.dll"), SuppressUnmanagedCodeSecurity]
        static extern uint LoadLibraryEx(string fileName, uint notUsedMustBeZero, uint flags);



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            unsafe
            {
           // ReadingHeaderExample readingHeaderExample = new ReadingHeaderExample;
                var path = @"E:\\CPPDll.dll";
                var hLib = LoadLibraryEx("E://CPPDll.dll", 0,
                               DONT_RESOLVE_DLL_REFERENCES | LOAD_IGNORE_CODE_AUTHZ_LEVEL);


                List<ImportFunctionObject> importFunctions = ReadingHeaderExample.PERead.LoadImports(path, true);
                foreach(ImportFunctionObject import in importFunctions)
                {
                    Console.WriteLine("import function= {0}, Address ={1}, dependency = {2}", import.function, import.baseAddress, import.dependency);
                }
                List<FunctionObject> exportedFunctions = ReadingHeaderExample.PERead.LoadExports(path, true);
                foreach (FunctionObject export in exportedFunctions)
                {
                    Console.WriteLine("exports={0}", export.function);
                }
                List<HeaderObject> headers = ReadingHeaderExample.PERead.GetHeader(path);

                foreach (HeaderObject header in headers)
                {
                    Console.WriteLine("header Name={0}, value={1}",header.name,header.value);

                }


                List<SectionObject> sections  =ReadingHeaderExample.PERead.GetSections(path);
                List<DirectoryObject> directories  =ReadingHeaderExample.PERead.GetDirectories(path);
                

            }
            Console.ReadKey();
        }
    }


}
