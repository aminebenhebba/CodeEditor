using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Text;

namespace CodeEditor.Wpf.Services
{
    public class CompileService : ICompileService
    {
        public string CheckProgram(string program, LanguageVersion languageVersion)
        {
            // Roslyn checks for Syntax Errors on the code
            var syntaxTree = CSharpSyntaxTree.ParseText(program, new CSharpParseOptions(languageVersion));
            var diagnostics = syntaxTree.GetDiagnostics().ToList();

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Roslyn : C# {languageVersion.ToDisplayString()} version of the language :");
            
            if (diagnostics.Any())
            {
                // Syntax Error detected : prepare them for dispaly on the console
                foreach (var d in diagnostics)
                {
                    stringBuilder.AppendLine($"{d.Severity.ToString()}[{d.Id}] : Ln:{d.Location.GetLineSpan().StartLinePosition.Line + 1} Ch:{d.Location.GetLineSpan().EndLinePosition.Character + 1}. {d.GetMessage()}");
                }
            }
            else
            {
                stringBuilder.AppendLine("Syntax Compilation Succeded.");
            }

            return stringBuilder.ToString();
        }
    }
}