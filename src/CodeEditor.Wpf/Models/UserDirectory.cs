using System.Collections.ObjectModel;
using System.IO;

namespace CodeEditor.Wpf.Models
{
    public class UserDirectory
    {
        public ObservableCollection<UserDirectory> Subfolders { get; set; } = new ObservableCollection<UserDirectory>();
        public ObservableCollection<UserFile> Files { get; set; } = new ObservableCollection<UserFile>();

        public string? DirectoryPath { get; set; }
        public string? Name { get { return Path.GetFileName(DirectoryPath); } }

        public UserDirectory(string directoryPath)
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