using System;
using System.Collections.Generic;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Scripting.Hosting.ScriptEngine pythonEngine =
                  IronPython.Hosting.Python.CreateEngine();
            ICollection<string> searchPaths = pythonEngine.GetSearchPaths();
            // Now modify the search paths to include the directory
            // where the standard library has been installed
            searchPaths.Add(@"C:\Program Files\IronPython 2.7\Lib");
            pythonEngine.SetSearchPaths(searchPaths);

            // Execute the script
            // We execute this script from Visual Studio
            // so the program will executed from bin\Debug or bin\Release
            Microsoft.Scripting.Hosting.ScriptSource pythonScript =
                pythonEngine.CreateScriptSourceFromFile("example.py");
            pythonScript.Execute();
            Console.WriteLine("Hello World!");
        }
    }
}
