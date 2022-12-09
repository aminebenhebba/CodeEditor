using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;
using Microsoft.CodeAnalysis.CSharp;
using System;

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
            if (!_mainViewModel.ConsoleDisplay)
            {
                _mainViewModel.ConsoleDisplay = true;
            }

            if (string.IsNullOrWhiteSpace(_mainViewModel.CurrentProgram))
            {
                _mainViewModel.Errors = "Empty Program - nothing to check !! please enter you code and try again.";
            }
            else
            {
                if(LanguageVersionFacts.TryParse(_mainViewModel.SelectedCSharpVersion, out var languageVersion))
                {
                    _mainViewModel.Errors = _compileService.CheckProgram(_mainViewModel.CurrentProgram,languageVersion);
                }
            }
        }
    }
}