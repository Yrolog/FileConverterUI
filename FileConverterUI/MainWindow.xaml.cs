using Microsoft.Win32;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace FileConverterUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(isBadEng.IsChecked == true)
            {
                GetTextBox.Text = EncDecClass.DecodeString(EncDecClass.
                                                EncodeString(EnterTextBox.Text));
            }
            else
            {
                GetTextBox.Text = EncDecClass.EncodeString(EnterTextBox.Text);
            }
        }

        private void isBadEng_Click(object sender, RoutedEventArgs e)
        {
            if (isBadEng.IsChecked == true)
            {
                GetTextBox.Text = EncDecClass.DecodeString(EncDecClass.
                                                EncodeString(EnterTextBox.Text));
            }
            else
            {
                GetTextBox.Text = EncDecClass.EncodeString(EnterTextBox.Text);
            }
        }

        private void SelectAllGetTextBox_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GetTextBox.Text);
            SelectButtonPopup.IsOpen = true;
        }

        private void MenuItemFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    FileName = "Document", // Default file name
                    DefaultExt = ".csv", // Default file extension
                    Filter = "Table documents (.csv)|*.csv" // Filter files by extension
                };
                string filePathToLoad = string.Empty;

                if (openFileDialog.ShowDialog() == true)
                {
                    filePathToLoad = openFileDialog.FileName;
                }

                DataTable table = NewTablesOperations.GetTable(filePathToLoad);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "Document", // Default file name
                    DefaultExt = ".csv", // Default file extension
                    Filter = "Table documents (.csv)|*.csv" // Filter files by extension
                };
                string filePathToSave = string.Empty;

                if (saveFileDialog.ShowDialog() == true)
                {
                    filePathToSave = saveFileDialog.FileName;
                }

                NewTablesOperations.WriteDataTable(table, filePathToSave);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show($"{ex.Message} Это ловля ошибок. Если словил, но не понял почему, то скидывай мне");
            }

        }
    }
}