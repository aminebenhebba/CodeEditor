using CodeEditor.Wpf.Commands;
using CodeEditor.Wpf.Services;
using System;
using System.Windows.Input;

namespace CodeEditor.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public event Action? RequestClose;

        public void OnRequestClose()
        {
            RequestClose?.Invoke();
        }

        private string? _currentProgram;
        public string? CurrentProgram
        {
            get { return _currentProgram; }
            set
            {
                _currentProgram = value;
                OnPropertyChange(nameof(CurrentProgram));
            }
        }

        private string? _errors;
        public string? Errors
        {
            get { return _errors; }
            set
            {
                _errors = value;
                OnPropertyChange(nameof(Errors));
            }
        }

        public ICommand CompileCommand { get; }

        public ICommand ExitCommand { get; }

        public MainViewModel(ICommandFactory commandFactory, ICompileService compileService)
        {
            CompileCommand = commandFactory.CreateCompileCommand(this, compileService);
            ExitCommand = commandFactory.CreateExitCommand(this);
        }
    }
}