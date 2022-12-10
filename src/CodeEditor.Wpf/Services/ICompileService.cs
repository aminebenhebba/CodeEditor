using Microsoft.CodeAnalysis.CSharp;

namespace CodeEditor.Wpf.Services
{
    public interface ICompileService
    {
        string CheckProgram(string program, LanguageVersion languageVersion);

        string FormatProgram(string program, LanguageVersion languageVersion);
    }
}