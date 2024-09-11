using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;

namespace LT13
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void listBoxTask2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in listBoxTask2.Items)
            {
                var listBoxItem = item as ListBoxItem;
                if(listBoxItem.IsSelected ) listBoxItem.FontStyle = FontStyles.Italic;
            }
        }

        private void listBoxTask3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in listBoxTask3.Items)
            {
                var listBoxItem = item as ListBoxItem;
                if(listBoxItem.IsSelected ) listBoxItem.Foreground =  Brushes.Red;
            }
        }

        private void listBoxTask4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = e.Source as ListBoxItem;
            if (listBoxItem != null)
            {
                listBoxItem.FontStyle = FontStyles.Normal ;
            }
        }

        private void listBoxTask4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in listBoxTask4.Items)
            {
                var listBoxItem = item as ListBoxItem;
                if (listBoxItem.IsSelected) listBoxItem.FontStyle = FontStyles.Italic;
            }
        }

        private void GridTask5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Правый клик по окну обработан: {e.Source}");
            this.Background = Brushes.Red;
        }

        private void GridTask6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = "Лабораторная работа №13 - Усов Алексей",
                Margin = new Thickness(10, 10 + GridTask6.Children.Count * 20, 0, 0)
            };
            GridTask6.Children.Add(textBlock);
        }

        private void GridTask7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && textBoxTask8.IsFocused)
            {
                confirmationTextTask8.Text = "Подтверждено: " + textBoxTask8.Text;
            }

            if (e.Key == Key.Escape)
            {
                this.Close();
            }

            if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                }
            }

            if (e.Key == Key.O && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                }
            }

            if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Clipboard.SetText("Текст скопирован!");
            }

            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                MessageBox.Show(Clipboard.GetText());
            }

            if (e.Key == Key.P && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                var printDialog = new System.Windows.Controls.PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                }
            }

            if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control &&
                (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
            }

            if (e.Key == Key.F && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control &&
                (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
            }
        }
    }
}