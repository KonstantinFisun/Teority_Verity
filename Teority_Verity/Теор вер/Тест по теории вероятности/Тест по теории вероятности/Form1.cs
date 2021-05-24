using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace Тест_по_теории_вероятности
{
    public partial class Test : Form
    {
        int question_count_rand_ev;//Счетчик вопросов из 1й темы
        int question_count_rand_iv;//Счетчик вопросов из 2й темы

        string variant; //Вариант
        string otvet; //Ответ

        StreamReader Reader; // Считывание из файла

        List<RandomEvents> random_events;//Список вопросов по теме случайные события
        List<RandomEvents> random_variables;//Список вопросов по теме случайные величины

        public Test()
        {
            InitializeComponent();
        }


        void Gener_quest_random_events()
        {
            Random rnd = new Random();
            int[] a = new int[3];
            a[0] = rnd.Next(0, question_count_rand_ev);
            for (int i = 1; i < 4;)
            {
                int num = rnd.Next(0, question_count_rand_ev); // генерируем элемент
                int j;
                // поиск совпадения среди заполненных элементов
                for (j = 0; j < i; j++)
                {
                    if (num == a[j])
                        break; // совпадение найдено, элемент не подходит
                }
                if (j == i)
                { // совпадение не найдено
                    a[i] = num; // сохраняем элемент
                    i++; // переходим к следующему элементу
                }
            }
            
        }
    
        void Pereme(string[] a,int numb_quest,int num)
        {
            Random rnd = new Random();


            for (int i = 0; i < 50; i++)
            {
                int i1 = rnd.Next(0, 4); // первый индекс
                int i2 = rnd.Next(0, 4); // второй индекс
                                           // обмен значений элементов с индексами i1 и i2
                string temp = a[i1];
                a[i1] = a[i2];
                a[i2] = temp;
            }

            for (int i = 0; i < 4; i++)
            {
                variant += "\n" + (i+1)+ ". " + random_events[numb_quest].Answers(i);

                if (random_events[numb_quest].Answers(i) == random_events[numb_quest].Corect_answerStr) otvet += "\n" + (num) + ". " + (i+1);
            }

        }

        void Pereme_2(string[] a, int numb_quest, int num)
        {
            Random rnd = new Random();


            for (int i = 0; i < 50; i++)
            {
                int i1 = rnd.Next(0, 4); // первый индекс
                int i2 = rnd.Next(0, 4); // второй индекс
                                         // обмен значений элементов с индексами i1 и i2
                string temp = a[i1];
                a[i1] = a[i2];
                a[i2] = temp;
            }

            for (int i = 0; i < 4; i++)
            {
                variant += "\n" + (i + 1) + ". " + random_variables[numb_quest].Answers(i);

                if (random_variables[numb_quest].Answers(i) == random_variables[numb_quest].Corect_answerStr) otvet += "\n" + (num) + ". " + (i+1);
            }

        }

        void AddQuestions()
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001); //Подключаем Кириллицу
            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test.txt", Encoding); //Обращаемся к нашему файлу с вопросами
            random_events = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_events.Add(new RandomEvents(ex, ans, cor_ans));//Добавляем 
                question_count_rand_ev++;
            }
            Reader.Close();
            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test2.txt", Encoding);//Открываем файл с темой Случайные события
            random_variables = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_variables.Add(new RandomEvents(ex, ans, cor_ans));
                question_count_rand_iv++;
            }
        }
        //Смена вопроса
        void Quest(int iter_variants)
        {

            int numb_ques1, numb_ques2, numb_ques3, numb_ques4, numb_ques5, numb_ques6;

            int[] random_events_num = new int[5];

            //Генерация первый 3 - х вопросов
            {
                Random rnd = new Random();
                random_events_num[0] = rnd.Next(0, question_count_rand_ev);
                for (int i = 1; i < 4;)
                {
                    int num = rnd.Next(0, question_count_rand_ev); // генерируем элемент
                    int j;
                    // поиск совпадения среди заполненных элементов
                    for (j = 0; j < i; j++)
                    {
                        if (num == random_events_num[j])
                            break; // совпадение найдено, элемент не подходит
                    }
                    if (j == i)
                    { // совпадение не найдено
                        random_events_num[i] = num; // сохраняем элемент
                        i++; // переходим к следующему элементу
                    }
                }

            }


            int[] random_variables_num = new int[5];

            //Генерация второй 3 - х вопросов
            {
                Random rnd = new Random();

                random_variables_num[0] = rnd.Next(0, question_count_rand_ev);
                for (int i = 1; i < 4;)
                {
                    int num = rnd.Next(0, question_count_rand_ev); // генерируем элемент
                    int j;
                    // поиск совпадения среди заполненных элементов
                    for (j = 0; j < i; j++)
                    {
                        if (num == random_variables_num[j])
                            break; // совпадение найдено, элемент не подходит
                    }
                    if (j == i)
                    { // совпадение не найдено
                        random_variables_num[i] = num; // сохраняем элемент
                        i++; // переходим к следующему элементу
                    }
                }

            }
            //Заголовок
            variant += ("\t\t\t\t\t\tВариант № " + (iter_variants+1));

            otvet += ("\nВариант №" + (iter_variants+1));

            //Генерируем первый вопрос
            {
                numb_ques1 = random_events_num[0];

                variant += ("\n1. " + random_events[numb_ques1].Question); //Описание первого вопроса

                Pereme(random_events[numb_ques1].Answe, numb_ques1, 1);

               
            }

            //Генерируем второй вопрос
            {
                numb_ques2 = random_events_num[1];

                

                variant += ("\n2. " + random_events[numb_ques2].Question); //Описание второго вопроса

                Pereme(random_events[numb_ques2].Answe, numb_ques2, 2);

                
            }

            //Генерируем третий вопрос
            {
                numb_ques3 = random_events_num[2];

               

                variant += ("\n3. " + random_events[numb_ques3].Question); //Описание третий вопроса

                Pereme(random_events[numb_ques3].Answe, numb_ques3, 3);
               
            }

            //Генерируем четвертый вопрос 
            {
                numb_ques4 = random_variables_num[0];

                variant += ("\n4. " + random_variables[numb_ques4].Question); //описание четвертого вопроса

                Pereme_2(random_variables[numb_ques4].Answe, numb_ques4, 4);

                
            }

            //Генерируем пятый вопрос
            {
                numb_ques5 = random_variables_num[1];


                variant += ("\n5. " + random_variables[numb_ques5].Question);

                Pereme_2(random_variables[numb_ques5].Answe, numb_ques5, 5);

                
            }


            //Генерируем шестой вопрос
            {
                numb_ques6 = random_variables_num[2];

                
                
                variant += ("\n6. " + random_variables[numb_ques6].Question);

                Pereme_2(random_variables[numb_ques6].Answe, numb_ques6, 6);

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

            Word.Application objWord = new Word.Application(); //Создали экземпляр
            objWord.Visible = true; //Появится
            objWord.WindowState = Word.WdWindowState.wdWindowStateNormal; //Появление

            //создаем документ
            Word.Document objDoc = objWord.Documents.Add();

            //Добавляем параграф
            Word.Paragraph objPara;

            otvet = ""; //Ответов пока нет
            int count_variants = int.Parse(textBox1.Text); //Считали количество вариантов
            
            for(int i = 0; i < count_variants; i++)
            {
                variant = ""; //Варианта пока нет
                Quest(i);

                objPara = objDoc.Paragraphs.Add();
                objPara.Range.Text = variant;
                objPara = objDoc.Paragraphs.Add();
            }

            //MessageBox.Show(variant);
            //MessageBox.Show(otvet);
            //Вывод ответов на тест

            objPara = objDoc.Paragraphs.Add();
            objPara.Range.Text = otvet;

           
            objDoc.SaveAs2(Directory.GetCurrentDirectory() + @"\Варианты.docx");//Путь файла
            objDoc.Close();
            objWord.Quit();

            MessageBox.Show("Варианты успешно сгенерированны");

            this.Close();

        }
     

        private void Test_Load(object sender, EventArgs e)
        {
            AddQuestions();//Добавили вопросы

            

        }

    }
}
