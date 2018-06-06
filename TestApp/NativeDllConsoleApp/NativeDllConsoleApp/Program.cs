using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PETest2
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IMAGE_IMPORT_BY_NAME
    {
        [FieldOffset(0)]
        public ushort Hint;
        [FieldOffset(2)]
        public fixed char Name[1];
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_IMPORT_DESCRIPTOR
    {
        #region union
        /// <summary>
        /// CSharp doesnt really support unions, but they can be emulated by a field offset 0
        /// </summary>

        [FieldOffset(0)]
        public uint Characteristics;            // 0 for terminating null import descriptor
        [FieldOffset(0)]
        public uint OriginalFirstThunk;         // RVA to original unbound IAT (PIMAGE_THUNK_DATA)
        #endregion

        [FieldOffset(4)]
        public uint TimeDateStamp;
        [FieldOffset(8)]
        public uint ForwarderChain;
        [FieldOffset(12)]
        public uint Name;
        [FieldOffset(16)]
        public uint FirstThunk;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct THUNK_DATA
    {
        [FieldOffset(0)]
        public uint ForwarderString;      // PBYTE 
        [FieldOffset(0)]
        public uint Function;             // PDWORD
        [FieldOffset(0)]
        public uint Ordinal;
        [FieldOffset(0)]
        public uint AddressOfData;        // PIMAGE_IMPORT_BY_NAME
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_EXPORT_DIRECTORY
    {
        public UInt32 Characteristics;
        public UInt32 TimeDateStamp;
        public UInt16 MajorVersion;
        public UInt16 MinorVersion;
        public UInt32 Name;
        public UInt32 Base;
        public UInt32 NumberOfFunctions;
        public UInt32 NumberOfNames;
        public UInt32 AddressOfFunctions;     // RVA from base of image
        public UInt32 AddressOfNames;     // RVA from base of image
        public UInt32 AddressOfNameOrdinals;  // RVA from base of image
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct LOADED_IMAGE
    {
        public IntPtr moduleName;
        public IntPtr hFile;
        public IntPtr MappedAddress;
        public IntPtr FileHeader;
        public IntPtr lastRvaSection;
        public UInt32 numbOfSections;
        public IntPtr firstRvaSection;
        public UInt32 charachteristics;
        public ushort systemImage;
        public ushort dosImage;
        public ushort readOnly;
        public ushort version;
        public IntPtr links_1;  // these two comprise the LIST_ENTRY
        public IntPtr links_2;
        public UInt32 sizeOfImage;
    }


    public unsafe class Interop
    {
        #region Public Constants
        public static readonly ushort IMAGE_DIRECTORY_ENTRY_IMPORT = 1;
        public static readonly ushort IMAGE_DIRECTORY_ENTRY_EXPORT = 0;

        #endregion
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Winapi" /> for Windows to 
        ///     indicate that the default should be used.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
        #endregion CallingConvention CALLING_CONVENTION
        #region IMPORT DLL FUNCTIONS
        private const string KERNEL_DLL = "kernel32";
        private const string DBGHELP_DLL = "Dbghelp";
        private const string IMAGEHLP_DLL = "ImageHlp";
        #endregion
        #endregion Private Constants

        [DllImport(KERNEL_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "GetModuleHandleA"), SuppressUnmanagedCodeSecurity]
        public static extern void* GetModuleHandleA(/*IN*/ char* lpModuleName);

        [DllImport(KERNEL_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "GetModuleHandleW"), SuppressUnmanagedCodeSecurity]
        public static extern void* GetModuleHandleW(/*IN*/ char* lpModuleName);

        [DllImport(KERNEL_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "IsBadReadPtr"), SuppressUnmanagedCodeSecurity]
        public static extern bool IsBadReadPtr(void* lpBase, uint ucb);

        [DllImport(DBGHELP_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "ImageDirectoryEntryToData"), SuppressUnmanagedCodeSecurity]
        public static extern void* ImageDirectoryEntryToData(void* Base, bool MappedAsImage, ushort DirectoryEntry, out uint Size);


        [DllImport(DBGHELP_DLL, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ImageRvaToVa(
            IntPtr pNtHeaders,
            IntPtr pBase,
            uint rva,
            IntPtr pLastRvaSection);

        [DllImport(DBGHELP_DLL, CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ImageNtHeader(IntPtr pImageBase);

        [DllImport(IMAGEHLP_DLL, CallingConvention = CallingConvention.Winapi), SuppressUnmanagedCodeSecurity]
        public static extern bool MapAndLoad(string imageName, string dllPath, out LOADED_IMAGE loadedImage, bool dotDll, bool readOnly);

    }


    static class Foo
    {
        // From winbase.h in the Win32 platform SDK.

        const uint DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
        const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;

        [DllImport("kernel32.dll"), SuppressUnmanagedCodeSecurity]
        static extern uint LoadLibraryEx(string fileName, uint notUsedMustBeZero, uint flags);

        //  private readonly List<string> _exports = new List<string>();
        // public IEnumerable<string> Exports { get { return _exports; } }
        // private readonly List<Tuple<string, List<string>>> _imports = new List<Tuple<string, List<string>>>();
        // public IEnumerable<Tuple<string, List<string>>> Imports { get { return _imports; } }

        public static void Main()
        {

            var path = @"E:\\CppDll.dll";
            // map it into memory and then just add the RVA to the returned module base address
            var hLib = LoadLibraryEx(path, 0,
                                     DONT_RESOLVE_DLL_REFERENCES | LOAD_IGNORE_CODE_AUTHZ_LEVEL);

            LoadImports(hLib, true);
            LoadExports(hLib, true);

            Console.WriteLine("Press Any Key To Continue......");
            Console.ReadKey();
        }


        // using mscoree.dll as an example as it doesnt export any thing
        // so nothing shows up when use the own module.
        // and the only none delayload in mscoree.dll is the Kernel32.dll
        private static void LoadImports(uint hLib, bool mappedAsImage)
        {
            unsafe
            {

                {

                    void* hMod = (void*)hLib;

                    uint size = 0;
                    uint BaseAddress = (uint)hMod;

                    if (hMod != null)
                    {

                        IMAGE_IMPORT_DESCRIPTOR* pIID = (IMAGE_IMPORT_DESCRIPTOR*)Interop.ImageDirectoryEntryToData((void*)hMod, mappedAsImage, Interop.IMAGE_DIRECTORY_ENTRY_IMPORT, out size);
                        if (pIID != null)
                        {
                            Console.WriteLine("Got Image Import Descriptor");
                            //walk the array until find the end of the array
                            while (pIID->OriginalFirstThunk != 0)
                            {

                                try
                                {
                                    //Name contains the RVA to the name of the dll. 
                                    //Thus convert it to a virtual address first
                                    char* szName = (char*)(BaseAddress + pIID->Name);
                                    string name = Marshal.PtrToStringAnsi((IntPtr)szName);
                                    Console.WriteLine("pIID->Name = {0} BaseAddress - {1}", name, (uint)BaseAddress);
                                    // value in OriginalFirstThunk is an RVA. 
                                    // convert it to virtual address.
                                    THUNK_DATA* pThunkOrg = (THUNK_DATA*)(BaseAddress + pIID->OriginalFirstThunk);

                                    while (pThunkOrg->AddressOfData != 0)
                                    {
                                        char* szImportName;
                                        uint Ord;

                                        if ((pThunkOrg->Ordinal & 0x80000000) > 0)
                                        {
                                            Ord = pThunkOrg->Ordinal & 0xffff;
                                            Console.WriteLine("imports ({0}).Ordinal{1} - Address: {2}", name, Ord, pThunkOrg->Function);
                                        }
                                        else
                                        {
                                            IMAGE_IMPORT_BY_NAME* pIBN = (IMAGE_IMPORT_BY_NAME*)(BaseAddress + pThunkOrg->AddressOfData);

                                            if (!Interop.IsBadReadPtr((void*)pIBN, (uint)sizeof(IMAGE_IMPORT_BY_NAME)))
                                            {
                                                Ord = pIBN->Hint;
                                                szImportName = (char*)pIBN->Name;
                                                string sImportName = Marshal.PtrToStringAnsi((IntPtr)szImportName); // yes i know i am a lazy ass
                                                Console.WriteLine("imports ({0}).{1}@{2} - Address: {3}", name, sImportName, Ord, pThunkOrg->Function);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Bad ReadPtr Detected or EOF on Imports");
                                                break;
                                            }
                                        }

                                        pThunkOrg++;
                                    }
                                }
                                catch (AccessViolationException e)
                                {
                                    Console.WriteLine("An Access violation occured\n" +
                                                      "this seems to suggest the end of the imports section\n");
                                    Console.WriteLine(e);
                                }

                                pIID++;
                            }

                        }

                    }
                }
            }


        }
        private static void LoadExports(uint hLib, bool mappedAsImage)
        {

            unsafe
            {

                void* hMod = (void*)hLib;
                uint BaseAddress = (uint)hMod;

                // var hMod = (void*)loadedImage.MappedAddress;

                if (hMod != null)
                {

                    uint size;
                    IMAGE_EXPORT_DIRECTORY* pExportDir = (IMAGE_EXPORT_DIRECTORY*)Interop.ImageDirectoryEntryToData((void*)hLib, true, Interop.IMAGE_DIRECTORY_ENTRY_EXPORT, out size);

                    if (pExportDir != null)
                    {
                        Console.WriteLine("Got Image Export Descriptor");

                        uint* pFuncNames = (uint*)(BaseAddress + pExportDir->AddressOfNames);

                        for (uint i = 0; i < pExportDir->NumberOfNames; i++)
                        {

                            uint funcNameRva = pFuncNames[i];
                            if (funcNameRva != 0)
                            {

                                char* funcName = (char*)(BaseAddress + funcNameRva);
                                var name = Marshal.PtrToStringAnsi((IntPtr)funcName);
                                Console.WriteLine("Exported functionName: {0}", name);
                                // exports.Add(name);
                            }

                        }

                    }

                }

            }
        }

    }
}