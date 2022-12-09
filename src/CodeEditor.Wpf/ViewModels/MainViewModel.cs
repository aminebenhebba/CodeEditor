using CodeEditor.Wpf.Commands;
using CodeEditor.Wpf.Services;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ObservableCollection<string> LanguageVergions { get; set; }

        private string _selectedCSharpVersion;
        public string SelectedCSharpVersion
        {
            get { return _selectedCSharpVersion; }
            set
            {
                _selectedCSharpVersion = value;
                OnPropertyChange(nameof(SelectedCSharpVersion));
            }
        }


        private bool _consoleDisplay;
        public bool ConsoleDisplay
        {
            get { return _consoleDisplay; }
            set
            {
                _consoleDisplay = value;
                OnPropertyChange(nameof(ConsoleDisplay));
            }
        }

        private bool _fileTreeDisplay;
        public bool FileTreeDisplay
        {
            get { return _fileTreeDisplay; }
            set
            {
                _fileTreeDisplay = value;
                OnPropertyChange(nameof(FileTreeDisplay));
            }
        }

        public ICommand CompileCommand { get; }

        public ICommand ExitCommand { get; }

        public MainViewModel(ICommandFactory commandFactory, ICompileService compileService)
        {
            var listOfCSharpVersions = Enum.GetValues<LanguageVersion>()
                                           .ToList()
                                           .Select(e => e.ToDisplayString());

            LanguageVergions = new ObservableCollection<string>(listOfCSharpVersions);
            SelectedCSharpVersion = listOfCSharpVersions.Last();

            ConsoleDisplay = true;
            FileTreeDisplay = true;

            CompileCommand = commandFactory.CreateCompileCommand(this, compileService);
            ExitCommand = commandFactory.CreateExitCommand(this);
        }
    }
}