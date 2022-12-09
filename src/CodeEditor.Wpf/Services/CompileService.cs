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

            switch (languageVersion)
            {
                case LanguageVersion.CSharp1:
                    stringBuilder.AppendLine($"Roslyn : C#1 version of the language :");
                    break;
                case LanguageVersion.CSharp2:
                    stringBuilder.AppendLine($"Roslyn :  C#2 version of the language :");
                    break;
                case LanguageVersion.CSharp3:
                    stringBuilder.AppendLine($"Roslyn :  C#3 version of the language :");
                break;
                case LanguageVersion.CSharp4:
                    stringBuilder.AppendLine($"Roslyn :  C#4 version of the language :");
                    break;
                case LanguageVersion.CSharp5:
                    stringBuilder.AppendLine($"Roslyn :  C#5 version of the language :");
                    break;
                case LanguageVersion.CSharp6:
                    stringBuilder.AppendLine($"Roslyn :  C#6 version of the language :");
                    break;
                case LanguageVersion.CSharp7:
                    stringBuilder.AppendLine($"Roslyn :  C#7 version of the language :");
                    break;
                case LanguageVersion.CSharp7_1:
                    stringBuilder.AppendLine($"Roslyn :  C#7.1 version of the language :");
                    break;
                case LanguageVersion.CSharp7_2:
                    stringBuilder.AppendLine($"Roslyn :  C#7.2 version of the language :");
                    break;
                case LanguageVersion.CSharp7_3:
                    stringBuilder.AppendLine($"Roslyn :  C#7.3 version of the language :");
                    break;
                case LanguageVersion.CSharp8:
                    stringBuilder.AppendLine($"Roslyn :  C#8 version of the language :");
                    break;
                case LanguageVersion.CSharp9:
                    stringBuilder.AppendLine($"Roslyn :  C#9 version of the language :");
                    break;
                case LanguageVersion.CSharp10:
                    stringBuilder.AppendLine($"Roslyn :  C#10 version of the language :");
                    break;
                case LanguageVersion.CSharp11:
                    stringBuilder.AppendLine($"Roslyn :  C#11 version of the language :");
                    break;
                case LanguageVersion.LatestMajor:
                    stringBuilder.AppendLine($"Roslyn :  C# Latest Major version of the language :");
                    break;
                case LanguageVersion.Preview:
                    stringBuilder.AppendLine($"Roslyn :  C# Preview version of the language :");
                    break;
                case LanguageVersion.Latest:
                    stringBuilder.AppendLine($"Roslyn :  C# Latest version of the language :");
                    break;
                default:
                    stringBuilder.AppendLine($"Roslyn :  C# Default version of the language :");
                    break;
            }
            
            if (diagnostics.Any())
            {
                // Error detected : prepare them for dispaly on the console
                foreach (var d in diagnostics)
                {
                    stringBuilder.AppendLine($"{d.Severity.ToString()}[{d.Id}] : Ln:{d.Location.GetLineSpan().StartLinePosition.Line+1} Ch:{d.Location.GetLineSpan().EndLinePosition.Character}. {d.GetMessage()}");
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