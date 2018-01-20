using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptEngine pythonEngine =
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

            var scope = Python.ImportModule(pythonEngine, "HelloWorldModule");
            dynamic printHelloWorldFunction = scope.GetVariable("PrintHelloWorld");
            printHelloWorldFunction();

            dynamic printMessageFunction = scope.GetVariable("PrintMessage");
            printMessageFunction("Goodbye!");

            dynamic addFunction = scope.GetVariable("Add");
            System.Console.Out.WriteLine("The sum of 1 and 2 is " + addFunction(1, 2));
        }
    }
}
