using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;
using System.IO;

namespace CodeEditor.Wpf.Commands
{
    public class OpenFileCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IIOService _ioService;

        public OpenFileCommand(MainViewModel mainViewModel, IIOService ioService)
        {
            _mainViewModel = mainViewModel;
            _ioService = ioService;
        }

        public override void Execute(object? parameter)
        {
            var path = _ioService.OpenFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                _mainViewModel.SelectedPath = path;

                _mainViewModel.CurrentProgram = _ioService.ReadFile(path);

                _mainViewModel.FileName = Path.GetFileName(path);
            }
        }
    }
}