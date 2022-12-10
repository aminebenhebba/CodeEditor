using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;

namespace CodeEditor.Wpf.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public CompileCommand CreateCompileCommand(MainViewModel mainViewModel, ICompileService compileService)
        {
            return new CompileCommand(mainViewModel, compileService);
        }

        public ExitCommand CreateExitCommand(MainViewModel mainViewModel)
        {
            return new ExitCommand(mainViewModel);
        }

        public OpenFileCommand CreateOpenFileCommand(MainViewModel mainViewModel, IIOService ioService)
        {
            return new OpenFileCommand(mainViewModel, ioService);
        }
    }
}