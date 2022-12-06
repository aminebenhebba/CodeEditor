using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;

namespace CodeEditor.Wpf.Commands
{
    public class CompileCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly ICompileService _compileService;

        public CompileCommand(MainViewModel mainViewModel, ICompileService compileService)
        {
            _mainViewModel = mainViewModel;
            _compileService = compileService;
        }

        public override void Execute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_mainViewModel.CurrentProgram))
            {
                _mainViewModel.Errors = "Error: Empty Program";
            }
            else
            {
                _mainViewModel.Errors = _compileService.CheckProgram(_mainViewModel.CurrentProgram);
            }
        }
    }
}