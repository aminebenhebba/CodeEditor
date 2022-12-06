using System.Windows;
using System.Windows.Input;

namespace CodeEditor.Wpf.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }

        private void FileTreeChecked(object sender, RoutedEventArgs e)
        {
            if(TreeViewExpander != null) TreeViewExpander.IsExpanded = true;
        }

        private void FileTreeUnchecked(object sender, RoutedEventArgs e)
        {
            if (TreeViewExpander != null) TreeViewExpander.IsExpanded = false;
        }

        private void ConsoleChecked(object sender, RoutedEventArgs e)
        {
            if (ConsoleExpander != null) ConsoleExpander.IsExpanded = true;
        }

        private void ConsoleUnchecked(object sender, RoutedEventArgs e)
        {
            if (ConsoleExpander != null) ConsoleExpander.IsExpanded = false;
        }
    }
}