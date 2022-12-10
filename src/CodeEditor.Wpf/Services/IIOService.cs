using System.IO;

namespace CodeEditor.Wpf.Services
{
    public interface IIOService
    {
        string OpenFileDialog();
        string ReadFile(string path);
    }
}