using System.Diagnostics;
using System.IO;

namespace VegaIDE_V2.Shared
{
    public class Compiler
    {
        public Code Code { get; set; } = new Code(Language.Python, "", @"\TempScripts\PythonFiles\");
        public Output Output { get; set; }

        public void RunCode()
        {
            Language language = Code.Language;
            switch (language)
            {
                case Language.Python:

                    Code.Location = @"\TempScripts\PythonFiles\";
                    //move this to initial
                    CreateFile(Code.CodeString, Code.Location);
                    Output = new Output(ExecutePythonScript(Code.Location));
                    break;
            }
        }
        public void CreateFile(string code, string location)
        {

            using (StreamWriter sw = new StreamWriter(location))
            {
                sw.Write(code);
            }

        }
        private string ExecutePythonScript(string ScriptLocation, string pythonLocation = @"C:\Python39\python.exe")
        {
            //1. create process info
            var psi = new ProcessStartInfo();
#pragma warning disable CA1416 // Validate platform compatibility
            psi.FileName = pythonLocation;
#pragma warning restore CA1416 // Validate platform compatibility

            //var a = "cat";

            //2. provide script and argument

            psi.Arguments = $"\"{ScriptLocation}\"";

            //3. process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            //4. Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                results = process.StandardOutput.ReadToEnd();
                errors = process.StandardError.ReadToEnd();
            }

            return results;
        }
    }
}