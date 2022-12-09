using System.Windows.Controls;
using System.Windows;

namespace CodeEditor.Wpf.Helper
{
    public static class CaretBehavior
    {
        public static readonly DependencyProperty ObserveCaretProperty = DependencyProperty.RegisterAttached("ObserveCaret", typeof(bool), typeof(CaretBehavior),
            new UIPropertyMetadata(false, OnObserveCaretPropertyChanged));

        public static bool GetObserveCaret(DependencyObject obj)
        {
            return (bool)obj.GetValue(ObserveCaretProperty);
        }
        public static void SetObserveCaret(DependencyObject obj, bool value)
        {
            obj.SetValue(ObserveCaretProperty, value);
        }
        private static void OnObserveCaretPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox) dpo;
            if (textBox != null)
            {
                if ((bool)e.NewValue == true)
                {
                    textBox.SelectionChanged += textBox_SelectionChanged;
                }
                else
                {
                    textBox.SelectionChanged -= textBox_SelectionChanged;
                }
            }
        }
        static void textBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox) sender;
            int caretIndex = textBox.CaretIndex;
            int lineIndex = textBox.GetLineIndexFromCharacterIndex(caretIndex);
            SetCharIndex(textBox, caretIndex - textBox.GetCharacterIndexFromLineIndex(lineIndex) + 1);
            SetLineIndex(textBox, lineIndex + 1);
        }

        private static readonly DependencyProperty CharIndexProperty = DependencyProperty.RegisterAttached("CharIndex", typeof(int), typeof(CaretBehavior));
        public static void SetCharIndex(DependencyObject element, int value)
        {
            element.SetValue(CharIndexProperty, value);
        }
        public static int GetCaretIndex(DependencyObject element)
        {
            return (int)element.GetValue(CharIndexProperty);
        }

        private static readonly DependencyProperty LineIndexProperty = DependencyProperty.RegisterAttached("LineIndex", typeof(int), typeof(CaretBehavior));
        public static void SetLineIndex(DependencyObject element, int value)
        {
            element.SetValue(LineIndexProperty, value);
        }
        public static int GetLineIndex(DependencyObject element)
        {
            return (int)element.GetValue(LineIndexProperty);
        }
    }
}
