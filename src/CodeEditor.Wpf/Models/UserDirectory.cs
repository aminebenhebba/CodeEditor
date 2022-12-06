using System;
using System.Collections.ObjectModel;

namespace CodeEditor.Wpf.Models
{
    public class UserDirectory
    {
        public ObservableCollection<UserDirectory> Subfolders { get; set; } = new ObservableCollection<UserDirectory>();
        public ObservableCollection<UserFile> Files { get; set; } = new ObservableCollection<UserFile>();

        public String? DirectoryPath { get; set; }
        public String? Name { get { return System.IO.Path.GetFileName(DirectoryPath); } }

        public UserDirectory(String directoryPath)
        {
            DirectoryPath = directoryPath;

            foreach (var directory in System.IO.Directory.GetDirectories(directoryPath))
            {
                Subfolders.Add(new UserDirectory(directory));
            }

            foreach (var file in System.IO.Directory.GetFiles(directoryPath))
            {
                Files.Add(new UserFile(file));
            }
        }
    }
}