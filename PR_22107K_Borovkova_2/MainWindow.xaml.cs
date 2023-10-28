using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_22107K_Borovkova_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btres_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string slova = txvvod.Text;

                if (string.IsNullOrEmpty(slova))
                {
                    MessageBox.Show("Введите буквы");
                    return;
                }



                int colichglbukv = CountVowels(slova);
                listres.Items.Add("Количество гласных букв: " + colichglbukv);
                string longestWord = FindLongestWord(slova);
                listres.Items.Add("Самое длинное слово: " + longestWord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }

        private int CountVowels(string slovo)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
            int count = 0;
            foreach (char c in slovo.ToLower())
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }

        private string FindLongestWord(string slovo)
        {
            string[] words = slovo.Split(' ');
            string longestWord = "";
            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }

        private void txvvod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text,0))
            {
                e.Handled = true;
            }
        }
    }
}
