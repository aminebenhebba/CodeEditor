using System;

namespace CodeEditor.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public event Action? RequestClose;

        public void OnRequestClose()
        {
            RequestClose?.Invoke();
        }
    }
}