using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;

namespace CodeEditor.Wpf.Commands
{
    public interface ICommandFactory
    {
        CompileCommand CreateCompileCommand(MainViewModel mainViewModel, ICompileService compileService);

        ExitCommand CreateExitCommand(MainViewModel mainViewModel);
    }
}
