using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;
using System.IO;

namespace CodeEditor.Wpf.Commands
{
    public class SaveFileCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IIOService _ioService;

        public SaveFileCommand(MainViewModel mainViewModel, IIOService ioService)
        {
            _mainViewModel = mainViewModel;
            _ioService = ioService;
        }

        public override void Execute(object? parameter)
        {
            // if file allready exist : just save the content on the current opened file
            if (!string.IsNullOrEmpty(_mainViewModel.SelectedPath))
            {
                _ioService.SaveFile(_mainViewModel.SelectedPath, _mainViewModel.CurrentProgram?? "");
                return;
            }

            var path = _ioService.SaveFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                _mainViewModel.SelectedPath = path;

                _ioService.SaveFile(path, _mainViewModel.CurrentProgram ?? "");

                _mainViewModel.FileName = Path.GetFileName(path);
            }
        }
    }
}
