using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Text;

namespace CodeEditor.Wpf.Services
{
    public class CompileService : ICompileService
    {
        public string CheckProgram(string program)
        {
            // Roslyn checks for Errors on the code
            var syntaxTree = CSharpSyntaxTree.ParseText(program);
            var diagnostics = syntaxTree.GetDiagnostics().ToList();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var d in diagnostics)
            {
                stringBuilder.AppendLine($"{d.Severity.ToString()}[{d.Id}] : Ln:{d.Location.GetLineSpan().StartLinePosition.Line+1} Ch:{d.Location.GetLineSpan().EndLinePosition.Character}. {d.GetMessage()}");
            }
            return stringBuilder.ToString();
        }
    }
}