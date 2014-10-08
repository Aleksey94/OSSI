using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace TP1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList myAL = new ArrayList();
        int number;
        int iCount;
        int i;
        Random Rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            myAL.Clear();
            iCount = Convert.ToInt32(textBox1.Text);
            listBox1.Items.Clear();
            for (i = 0; i < iCount; i++)
            {
                number = 1 + Rand.Next(50);
                myAL.Add(number);
                listBox1.Items.Add(number);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            for (int i = 0; i < iCount; i++)
            {
                if ((int)myAL[i] > 25) { index = i; break; }
            }
            
            if (index > -1)
            {
                textBlock1.Text = textBlock1.Text + "\n Номер элемента равен " + (index + 1).ToString();
            }
         
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < iCount; i++)
            {
                if ((int)myAL[i] > (int)myAL[1])
                { Sum = Sum + (int)myAL[i]; }
            }
            textBlock1.Text = textBlock1.Text + "\n Сумма элементов равна " + Sum.ToString();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
           int kol = 0;
           for (i = 1; i < iCount-1; i++)
           {
               if ((int)myAL[i] > (int)myAL[i - 1] && (int)myAL[i] > (int)myAL[i + 1])
               { kol = kol + 1; }
           }
           textBlock1.Text = textBlock1.Text + "\n Кол-во элементов равно " + kol.ToString();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in listBox1.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        }


      }
    



