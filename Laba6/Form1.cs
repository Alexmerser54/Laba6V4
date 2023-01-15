using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(?<!\d)(\d{2})(?!\d)"); // слева не должно быть цифры, затем идут две цифры, после не должно быть цифры
            string result = ""; // результирующая строка
            string text = richTextBox1.Text; // входной текст
            string[] lines = text.Split(new string[] { ". " }, StringSplitOptions.RemoveEmptyEntries); // разбить строку на предложения с удаленим пустых элементов
            
            for (int i = 0; i < lines.Length; i++) // перебор предложений
            {
                if (regex.IsMatch(lines[i])) // если в предложении есть совпададение с шаблоном
                {
                    result += lines[i] + "\n"; // добавить предложение в результат и конактенировать символ новой строки
                }
            }
            richTextBox1.Text = result; // вывести результат
        }

        bool HaveRepeaingChars(string inp) // метод для проверки наличия повторяющихся символов
        {
            for (int i = 0; i < inp.Length; i++)
            {
                 for (int j = i + 1; j < inp.Length; j++) // алгоритм сортировки пузырька
                {
                    if (inp[i] == inp[j]) return true; // если буквы равны, то вернуть истину
                }
                
            }
            return false; // если метод не вернул значение в цикле, то в конце вернуть ложь
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string lastWord; // строка для последнего слова
            string tmp; // временная переменная
            string result = ""; // результирующая строка
            Regex regex = new Regex(@"\S+(?<![.,!:])"); // множество непробельных символов (букв), за исключением знаков препинания
            string text = richTextBox2.Text; // входной текст
            var words = regex.Matches(text); // разбить строку на предложения с удаленим пустых элементов
            lastWord = words[words.Count - 1].ToString().ToLower(); // последнее слово - это последний элемент массива words, 
                                                                    // приведённый к строке и нижнему регистру
            for (int i = 0; i < words.Count-1; i++) // перебор слов, не включая последнего
            {
                tmp = words[i].ToString(); // присваимваем временной переменной слово
                if (tmp.ToLower() != lastWord && !HaveRepeaingChars(tmp.ToLower())) // если слово в нижнем регистре не равно последнему слову
                                                                                    // и в слове в нижнем регистре нет повторяющихся символов
                    result += tmp + " "; // добавить слово в результат вместе с пробелом
            }

            richTextBox2.Text = result; // вывести результат
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int wordsCount; // кол-во слов
            int numsCount; // кол-во чисел
            string output; // результирующая строка
            string text = richTextBox3.Text; // входной текст

            Regex wordRegex = new Regex(@"\S+(?<![,.!:]|\d)"); // поиск любых непробельных символов, за исключением знаков препинания и чисел

            Regex numRegex = new Regex(@"\d+"); // поиск цифры, кол-во которых больше или равно 1
            wordsCount = wordRegex.Matches(text).Count; // количество совпаднений шаблона поиска слов записывается в переменную
            numsCount = numRegex.Matches(text).Count; // количество совпадений шаблона поиска чисел записывается в переменную

            output = $"В тексте {wordsCount} групп букв и {numsCount} групп цифр\n"; // запись количества в результат
            if (wordsCount > numsCount) // сравнение
                output += "Верно, групп букв больше групп цифр"; // запись в результат
            else output += "Неверно, групп букв не больше групп цифр"; // запись в результат

            richTextBox3.Text = output; // вывод результата
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = richTextBox4.Text; // входной текст
            string output = ""; // результирующая строка
            Regex regex = new Regex(@"www.\w{3,}.\w{3,}.ru"); // шаблон поиска домена. \w{3,} - это минимум 3 буквы
            foreach (var domen in regex.Matches(text)) // перебор найденных доменов
            {
                output += domen.ToString() + " "; // запись найденного домена в результат
            }
            richTextBox4.Text = output; // вывод результата
        }
    }
}
