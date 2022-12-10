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

        public string SaveFileDialog()
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "cs",
                AddExtension = true,
                Filter = "CS Files (.cs)|*.cs",
                FilterIndex = 1
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

        public void SaveFile(string path, string fileContent)
        {
            var stream = File.Create(path);
            var streamWriter = new StreamWriter(stream);

            streamWriter.Write(fileContent);
            streamWriter.Flush();

            stream.Close();
        }
    }
}