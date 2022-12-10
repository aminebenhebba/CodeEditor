using Microsoft.Win32;
using System.IO;

namespace CodeEditor.Wpf.Services
{
    public class IOService : IIOService
    {
        public string OpenFileDialog()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CS Files (.cs)|*.cs|All Files (*.*)|*.*",
                FilterIndex = 1,
            };

            dialog.ShowDialog();

            return dialog.FileName;
        }

        public string ReadFile(string path)
        {
            var stream = File.OpenRead(path);
            var streamReader = new StreamReader(stream);

            var result = streamReader.ReadToEnd();

            stream.Close();

            return result;
        }
    }
}