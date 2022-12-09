using System.IO;

namespace CodeEditor.Wpf.Models
{
    public class UserFile
    {
        public string? FilePath { get; set; }

        public string? Name { get { return Path.GetFileName(FilePath); } }

        public UserFile(string filePath)
        {
            FilePath = filePath;
        }
    }
}