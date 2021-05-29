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
        //Счетчик вопросов теста из 1й темы
        int question_count_rand_ev_1;
        int question_count_rand_ev_2;
        int question_count_rand_ev_3;
        //Счетчик вопросов теста из 2й темы
        int question_count_rand_iv_4;
        int question_count_rand_iv_5;
        int question_count_rand_iv_6;


        string variant; //Вариант
        string otvet; //Ответ

        StreamReader Reader; // Считывание из файла

        List<RandomEvents> random_events_1;//Список первых вопросов по теме случайные события
        List<RandomEvents> random_events_2;//Список второх вопросов по теме случайные события
        List<RandomEvents> random_events_3;//Список третих вопросов по теме случайные события

        List<RandomEvents> random_variables_4;//Список 4 - х вопросов по теме случайные величины
        List<RandomEvents> random_variables_5;//Список 5 - х вопросов по теме случайные величины
        List<RandomEvents> random_variables_6;//Список 6 - х вопросов по теме случайные величины






        public Test()
        {
            InitializeComponent();
        }


        void Random_answer_random_events(List<RandomEvents> random_events, string[] a,int numb_quest,int num)
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

        void Random_answer_random_variables(List<RandomEvents> random_variables,string[] a, int numb_quest, int num)
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

        void AddQuestions_test()
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001); //Подключаем Кириллицу

            //Считываем первые вопросы по теме случайные события
            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test\test1.txt", Encoding); //Обращаемся к нашему файлу с вопросами
            random_events_1 = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_events_1.Add(new RandomEvents(ex, ans, cor_ans));//Добавляем 
                question_count_rand_ev_1++;
            }
            Reader.Close();

            //Считываем вторые вопросы по теме случайные события
            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test\test2.txt", Encoding); //Обращаемся к нашему файлу с вопросами
            random_events_2 = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_events_2.Add(new RandomEvents(ex, ans, cor_ans));//Добавляем 
                question_count_rand_ev_2++;
            }
            Reader.Close();

            //Считываем третие вопросы по теме случайные события
            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test\test3.txt", Encoding); //Обращаемся к нашему файлу с вопросами
            random_events_3 = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_events_3.Add(new RandomEvents(ex, ans, cor_ans));//Добавляем 
                question_count_rand_ev_3++;
            }
            Reader.Close();


            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test\test4.txt", Encoding);//Открываем файл с темой Случайные события
            random_variables_4 = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_variables_4.Add(new RandomEvents(ex, ans, cor_ans));
                question_count_rand_iv_4++;
            }

            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test\test5.txt", Encoding);//Открываем файл с темой Случайные события
            random_variables_5 = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_variables_5.Add(new RandomEvents(ex, ans, cor_ans));
                question_count_rand_iv_5++;
            }

            Reader = new StreamReader(Directory.GetCurrentDirectory() + @"\test\test6.txt", Encoding);//Открываем файл с темой Случайные события
            random_variables_6 = new List<RandomEvents>();
            while (!Reader.EndOfStream)
            {
                string ex = Reader.ReadLine();//Считываем задание
                string[] ans = new string[4];//Считываем массив ответов
                for (int i = 0; i < ans.Length; i++)
                    ans[i] = Reader.ReadLine();
                int cor_ans = Convert.ToInt32(Reader.ReadLine());//Считываем правильный ответ

                random_variables_6.Add(new RandomEvents(ex, ans, cor_ans));
                question_count_rand_iv_6++;
            }
        }

        void AddQuestions_IDS()
        {

        }
        //Смена вопроса
        void Quest_test(int iter_variants)
        {

            int numb_ques1, numb_ques2, numb_ques3, numb_ques4, numb_ques5, numb_ques6;


            
            //Заголовок
            variant += ("\t\t\t\t\t\tВариант № " + (iter_variants+1));

            otvet += ("\nВариант №" + (iter_variants+1));

            Random rnd = new Random();

            //Генерируем первый вопрос
            {
                numb_ques1 =  rnd.Next(0,question_count_rand_ev_1);

                variant += ("\n1. " + random_events_1[numb_ques1].Question); //Описание первого вопроса

                Random_answer_random_events(random_events_1,random_events_1[numb_ques1].Answe, numb_ques1, 1);

               
            }

            //Генерируем второй вопрос
            {
                numb_ques2 = rnd.Next(0, question_count_rand_ev_2); 

                variant += ("\n2. " + random_events_2[numb_ques2].Question); //Описание второго вопроса

                Random_answer_random_events(random_events_2,random_events_2[numb_ques2].Answe, numb_ques2, 2);

                
            }

            //Генерируем третий вопрос
            {
                numb_ques3 = rnd.Next(0, question_count_rand_ev_3);

                variant += ("\n3. " + random_events_3[numb_ques3].Question); //Описание третий вопроса

                Random_answer_random_events(random_events_3,random_events_3[numb_ques3].Answe, numb_ques3, 3);
               
            }

            //Генерируем четвертый вопрос 
            {
                numb_ques4 = rnd.Next(0, question_count_rand_iv_4);

                variant += ("\n4. " + random_variables_4[numb_ques4].Question); //описание четвертого вопроса

                Random_answer_random_variables(random_variables_4,random_variables_4[numb_ques4].Answe, numb_ques4, 4);

                
            }

            //Генерируем пятый вопрос
            {
                numb_ques5 = rnd.Next(0, question_count_rand_iv_5);

                variant += ("\n5. " + random_variables_5[numb_ques5].Question);

                Random_answer_random_variables(random_variables_5,random_variables_5[numb_ques5].Answe, numb_ques5, 5);

                
            }


            //Генерируем шестой вопрос
            {
                numb_ques6 = rnd.Next(0, question_count_rand_iv_6);

                variant += ("\n6. " + random_variables_6[numb_ques6].Question);

                Random_answer_random_variables(random_variables_6,random_variables_6[numb_ques6].Answe, numb_ques6, 6);

            }

        }


        //Создание теста
        private void button1_Click(object sender, EventArgs e)
        {
            AddQuestions_test();//Добавили вопросы

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
                Quest_test(i);

                objPara = objDoc.Paragraphs.Add();
                objPara.Range.Text = variant;
                objPara = objDoc.Paragraphs.Add();
            }

            
            //Вывод ответов на тест

            objPara = objDoc.Paragraphs.Add();
            objPara.Range.Text = otvet;
           
            objDoc.SaveAs2(Directory.GetCurrentDirectory() + @"\Варианты.docx");//Путь файла
            objDoc.Close();
            objWord.Quit();

            MessageBox.Show("Варианты успешно сгенерированны");
       
            this.Close();

        }

        //Создание варианта ИДС
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Test_Load(object sender, EventArgs e)
        {
                   
        }

    }
}
