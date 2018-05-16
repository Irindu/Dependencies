using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Runtime.InteropServices;

namespace ReadDllImportsConsoleApp
{
    class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                Console.ReadLine();
                // This variable holds the amount of indenting that 
                // should be used when displaying each line of information.
                Int32 indent = 0;
                // Display information about the EXE assembly.
                Type type = typeof(Program);
                Assembly a = type.Assembly;


                Display(indent, "");
                a = Assembly.LoadFrom("E:\\project1.exe");

                Display(indent, "Assembly identity={0}", a.FullName);
                Display(indent + 1, "Codebase={0}", a.CodeBase);

            Display(indent, "");

            //get dll imports used
            Dictionary<Type, List<MethodInfo>> exports = a.GetTypes()
                .SelectMany(type1 => type1.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                                        .Where(method => method.GetCustomAttributes(typeof(DllImportAttribute), false).Length > 0))
                .GroupBy(method => method.DeclaringType)
                .ToDictionary(item => item.Key, item => item.ToList())
                ;

                foreach (var item in exports)
                {
                    Console.WriteLine(item.Key.FullName);

                    foreach (var method in item.Value)
                    {
                        DllImportAttribute attr = method.GetCustomAttributes(typeof(DllImportAttribute), false)[0] as DllImportAttribute;
                        Console.WriteLine("\tDLL: {0}, Function: {1}", attr.Value, method.Name);
                    }
                }



                // Display the set of assemblies our assemblies reference.
                Display(indent, "");

                Display(indent, "Referenced assemblies:");
                foreach (AssemblyName an in a.GetReferencedAssemblies())
                {
                    Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
                }
                Display(indent, "");

                foreach (Type t in a.GetTypes())
                {
                    Display(indent, "Type: {0}", t);
                    MethodInfo[] info = t.GetMethods();
                    //MessageBox.Show(info.Length.ToString());
                    foreach (MethodInfo methodInfo in info)
                    {

                        Console.WriteLine("method information={0}", methodInfo.ToString());
                    }
                }
            Display(indent, "");

            foreach (Type exportedType in typeof(Program).Assembly.GetExportedTypes())
            {
                Console.WriteLine("exportedType={0}", exportedType);
            }
            indent += 1;
                
                type = a.GetType();

                MethodInfo[] methodInfos = type.GetType()
                               .GetMethods(BindingFlags.Public | BindingFlags.Instance);

                foreach (MethodInfo methodInfo in methodInfos)
                {
                    Console.WriteLine("method info={0}", methodInfo);
                }

                Display(indent, "");

               
                //Display information about each assembly loading into this AppDomain.
                foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
                {
                Console.WriteLine("Assembly information loaded into this AppDomain");
                    Display(indent, "Assembly: {0}", b);

                    // Display information about each module of this assembly.
                    foreach (Module m in b.GetModules(true))
                    {

                        Display(indent + 1, "Module: {0}", m.Name);
                    }
                    Display(indent, "");
                    // Display information about each type exported from this assembly.

                    indent += 1;
                    //foreach (Type t in b.GetExportedTypes())
                    //{

                    //    Display(0, "");
                    //    Display(indent, "Type: {0}", t);

                    //    // For each type, show its members & their custom attributes.

                    //    indent += 1;
                    //    //foreach (MemberInfo mi in t.GetMembers())
                    //    //{
                    //    //    Display(indent, "Member: {0}", mi.Name);
                    //    //    DisplayAttributes(indent, mi);

                    //    //    // If the member is a method, display information about its parameters.

                    //    //    if (mi.MemberType == MemberTypes.Method)
                    //    //    {
                    //    //        foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                    //    //        {
                    //    //            Display(indent + 1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name);
                    //    //        }
                    //    //    }

                    //    //    // If the member is a property, display information about the property's accessor methods.
                    //    //    if (mi.MemberType == MemberTypes.Property)
                    //    //    {
                    //    //        foreach (MethodInfo am in ((PropertyInfo)mi).GetAccessors())
                    //    //        {
                    //    //            Display(indent + 1, "Accessor method: {0}", am);
                    //    //        }
                    //    //    }
                    //    //}
                    //    indent -= 1;
                    //}
                    indent -= 1;
                }
                Console.ReadLine();

            }

            // Displays the custom attributes applied to the specified member.
            public static void DisplayAttributes(Int32 indent, MemberInfo mi)
            {
                // Get the set of custom attributes; if none exist, just return.
                object[] attrs = mi.GetCustomAttributes(false);
                if (attrs.Length == 0) { return; }

                // Display the custom attributes applied to this member.
                Display(indent + 1, "Attributes:");
                foreach (object o in attrs)
                {
                    Display(indent + 2, "{0}", o.ToString());
                }
            }

            // Display a formatted string indented by the specified amount.
            public static void Display(Int32 indent, string format, params object[] param)

            {
                Console.Write(new string(' ', indent * 2));
                Console.WriteLine(format, param);
            }
        }
    
}
