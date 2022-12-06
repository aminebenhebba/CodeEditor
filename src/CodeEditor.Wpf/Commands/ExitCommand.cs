using CodeEditor.Wpf.ViewModels;

namespace CodeEditor.Wpf.Commands
{
    public class ExitCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public ExitCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.OnRequestClose();
        }
    }
}