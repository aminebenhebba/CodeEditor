using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeEditor.Wpf.Commands
{
    public class FormatCodeCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly ICompileService _compileService;

        public FormatCodeCommand(MainViewModel mainViewModel, ICompileService compileService)
        {
            _mainViewModel = mainViewModel;
            _compileService = compileService;
        }

        public override void Execute(object? parameter)
        {

            if (string.IsNullOrWhiteSpace(_mainViewModel.CurrentProgram))
            {
                _mainViewModel.Errors = "Empty Program - nothing to Format please enter your Code and try again";
            }
            else
            {
                LanguageVersionFacts.TryParse(_mainViewModel.SelectedCSharpVersion, out var languageVersion);

                _mainViewModel.CurrentProgram = _compileService.FormatProgram(_mainViewModel.CurrentProgram, languageVersion);
            }
        }
    }
}
