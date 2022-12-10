using CodeEditor.Wpf.ViewModels;

namespace CodeEditor.Wpf.Commands
{
    public class NewFileCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public NewFileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.SelectedPath = "";

            _mainViewModel.FileName = "<New> ...";

            _mainViewModel.CurrentProgram = "";

            _mainViewModel.Errors = "";
        }
    }
}