using System.IO;

namespace CodeEditor.Wpf.Services
{
    public interface IIOService
    {
        string OpenFileDialog();
        string SaveFileDialog();
        string ReadFile(string path);
        void SaveFile(string path, string fileContent);
    }
}