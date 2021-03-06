﻿using System;
using System.IO;
using System.Reflection;

namespace ConsoleAppTestReflection
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
            Console.WriteLine("Type :{0}",type);
            Assembly a = type.Assembly;
            
            a = Assembly.LoadFrom("E:\\project1.exe");

            Display(indent, "Assembly identity={0}", a.FullName);
            Display(indent + 1, "Codebase={0}", a.CodeBase);

            // Display the set of assemblies our assemblies reference.

            Display(indent, "Referenced assemblies:");
            foreach (AssemblyName an in a.GetReferencedAssemblies())
            {
                Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
            }
            Display(indent, "");
            Console.ReadLine();
            // Display information about each assembly loading into this AppDomain.
            foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
            {
                Display(indent, "assembly: {0}", b);

                // display information about each module of this assembly.
                foreach (Module m in b.GetModules(true))
                {
                    Display(indent + 1, "module: {0}", m.Name);
                }

                // display informatIon about each type exported from this assembly.

                indent += 1;
            foreach (Type t in b.GetExportedTypes())
            {
                Display(0, "");
                Display(indent, "type: {0}", t);

                // for each type, show its members & their custom attributes.

                indent += 1;
                foreach (MemberInfo mi in t.GetMembers())
                {
                    Display(indent, "member: {0}", mi.Name);
                    DisplayAttributes(indent, mi);

                    // if the member is a method, display information about its parameters.

                    if (mi.MemberType == MemberTypes.Method)
                    {
                        foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                        {
                            Display(indent + 1, "parameter: type={0}, name={1}", pi.ParameterType, pi.Name);
                        }
                    }

                    // if the member is a property, display information about the property's accessor methods.
                    if (mi.MemberType == MemberTypes.Property)
                    {
                        foreach (MethodInfo am in ((PropertyInfo)mi).GetAccessors())
                        {
                            Display(indent + 1, "accessor method: {0}", am);
                        }
                    }
                }
                indent -= 1;
            }
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
