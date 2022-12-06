using System;

namespace CodeEditor.Wpf.Models
{
    public class UserFile
    {
        public String? FilePath { get; set; }

        public String? Name { get { return System.IO.Path.GetFileName(FilePath); } }

        public UserFile(string filePath)
        {
            FilePath = filePath;
        }
    }
}