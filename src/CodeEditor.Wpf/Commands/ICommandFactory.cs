using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;
using System.Windows.Input;

namespace CodeEditor.Wpf.Commands
{
    public interface ICommandFactory
    {
        CompileCommand CreateCompileCommand(MainViewModel mainViewModel, ICompileService compileService);

        ExitCommand CreateExitCommand(MainViewModel mainViewModel);

        OpenFileCommand CreateOpenFileCommand(MainViewModel mainViewModel, IIOService ioService);

        SaveFileCommand CreateSaveFileCommand(MainViewModel mainViewModel, IIOService ioService);

        NewFileCommand CreateNewFileCommand(MainViewModel mainViewModel);
    }
}
