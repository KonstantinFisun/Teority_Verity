﻿using System;
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
                variant += "\n" + random_events[numb_quest].Answers(i);

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
                variant += "\n" + random_variables[numb_quest].Answers(i);

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

            int[] random_events_num = new int[4];

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


            int[] random_variables_num = new int[4];

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
            variant += ("Вариант № " + iter_variants);

            otvet += ("\nВариант №" + iter_variants);



            //Генерируем первый вопрос
            {
                numb_ques1 = random_events_num[0];

                variant += ("\n1. " + random_events[numb_ques1].Question); //Описание первого вопроса

                Pereme(random_events[numb_ques1].Answe, numb_ques1, 1);

                //Генерируем ответы на вопрос
                /*
                {
                    numb1_answer = rnd.Next(0, 4); //Первый ответ

                    //Второй ответ
                    numb2_answer = rnd.Next(0, 4);

                    while (numb1_answer != numb2_answer)
                    {
                        numb2_answer = rnd.Next(0, 4);
                    }

                    //третий ответ
                    numb3_answer = rnd.Next(0, 4);

                    while (numb3_answer != numb1_answer && numb3_answer != numb2_answer)
                    {
                        numb3_answer = rnd.Next(0, 4);
                    }

                    //четвертый ответ
                    numb4_answer = rnd.Next(0, 4);

                    while (numb4_answer != numb1_answer && numb4_answer != numb2_answer && numb4_answer != numb3_answer)
                    {
                        numb4_answer = rnd.Next(0, 4);
                    }



                }

                MessageBox.Show(Convert.ToString(numb1_answer));
                MessageBox.Show(Convert.ToString(numb2_answer));
                MessageBox.Show(Convert.ToString(numb3_answer));
                MessageBox.Show(Convert.ToString(numb4_answer));

                //Вывод ответов на этот вопрос
                variant += "\n" + random_events[numb_ques1].Answers(numb1_answer);
                variant += "\n" + random_events[numb_ques1].Answers(numb2_answer);
                variant += "\n" + random_events[numb_ques1].Answers(numb3_answer);
                variant += "\n" + random_events[numb_ques1].Answers(numb4_answer);

                //Выводим правильный номер в ответ
                if (random_events[numb_ques1].Answers(numb1_answer) == random_events[numb_ques1].Corect_answerStr) otvet += "\n1. " + numb1_answer;
                if (random_events[numb_ques1].Answers(numb2_answer) == random_events[numb_ques1].Corect_answerStr) otvet += "\n1. " + numb2_answer;
                if (random_events[numb_ques1].Answers(numb3_answer) == random_events[numb_ques1].Corect_answerStr) otvet += "\n1. " + numb3_answer;
                if (random_events[numb_ques1].Answers(numb4_answer) == random_events[numb_ques1].Corect_answerStr) otvet += "\n1. " + numb4_answer;
                */

            }



            //Генерируем второй вопрос
            {
                numb_ques2 = random_events_num[1];

                

                variant += ("\n2. " + random_events[numb_ques2].Question); //Описание второго вопроса

                Pereme(random_events[numb_ques2].Answe, numb_ques2, 2);

                /*
                //Генерируем ответы на вопрос
                {
                    numb1_answer = rnd.Next(0, 4); //Первый ответ

                    //Второй ответ
                    numb2_answer = rnd.Next(0, 4);

                    while (numb1_answer != numb2_answer)
                    {
                        numb2_answer = rnd.Next(0, 4);
                    }

                    //третий ответ
                    numb3_answer = rnd.Next(0, 4);

                    while (numb3_answer != numb1_answer && numb3_answer != numb2_answer)
                    {
                        numb3_answer = rnd.Next(0, 4);
                    }

                    //четвертый ответ
                    numb4_answer = rnd.Next(0, 4);

                    while (numb4_answer != numb1_answer && numb4_answer != numb2_answer && numb4_answer != numb3_answer)
                    {
                        numb4_answer = rnd.Next(0, 4);
                    }



                }

                //Вывод ответов на этот вопрос
                variant += "\n" + random_events[numb_ques2].Answers(numb1_answer);
                variant += "\n" + random_events[numb_ques2].Answers(numb2_answer);
                variant += "\n" + random_events[numb_ques2].Answers(numb3_answer);
                variant += "\n" + random_events[numb_ques2].Answers(numb4_answer);

                //Выводим правильный номер в ответ
                if (random_events[numb_ques2].Answers(numb1_answer) == random_events[numb_ques2].Corect_answerStr) otvet += "\n1. " + numb1_answer;
                if (random_events[numb_ques2].Answers(numb2_answer) == random_events[numb_ques2].Corect_answerStr) otvet += "\n1. " + numb2_answer;
                if (random_events[numb_ques2].Answers(numb3_answer) == random_events[numb_ques2].Corect_answerStr) otvet += "\n1. " + numb3_answer;
                if (random_events[numb_ques2].Answers(numb4_answer) == random_events[numb_ques2].Corect_answerStr) otvet += "\n1. " + numb4_answer;

                */
            }



            //Генерируем третий вопрос
            {
                numb_ques3 = random_events_num[2];

               

                variant += ("\n3. " + random_events[numb_ques3].Question); //Описание третий вопроса

                Pereme(random_events[numb_ques3].Answe, numb_ques3, 3);
                /*
                //Генерируем ответы на вопрос
                {
                    numb1_answer = rnd.Next(0, 4); //Первый ответ

                    //Второй ответ
                    numb2_answer = rnd.Next(0, 4);

                    while (numb1_answer != numb2_answer)
                    {
                        numb2_answer = rnd.Next(0, 4);
                    }

                    //третий ответ
                    numb3_answer = rnd.Next(0, 4);

                    while (numb3_answer != numb1_answer && numb3_answer != numb2_answer)
                    {
                        numb3_answer = rnd.Next(0, 4);
                    }

                    //четвертый ответ
                    numb4_answer = rnd.Next(0, 4);

                    while (numb4_answer != numb1_answer && numb4_answer != numb2_answer && numb4_answer != numb3_answer)
                    {
                        numb4_answer = rnd.Next(0, 4);
                    }



                }

                //Вывод ответов на этот вопрос
                variant += "\n" + random_events[numb_ques3].Answers(numb1_answer);
                variant += "\n" + random_events[numb_ques3].Answers(numb2_answer);
                variant += "\n" + random_events[numb_ques3].Answers(numb3_answer);
                variant += "\n" + random_events[numb_ques3].Answers(numb4_answer);

                //Выводим правильный номер в ответ
                if (random_events[numb_ques3].Answers(numb1_answer) == random_events[numb_ques3].Corect_answerStr) otvet += "\n1. " + numb1_answer;
                if (random_events[numb_ques3].Answers(numb2_answer) == random_events[numb_ques3].Corect_answerStr) otvet += "\n1. " + numb2_answer;
                if (random_events[numb_ques3].Answers(numb3_answer) == random_events[numb_ques3].Corect_answerStr) otvet += "\n1. " + numb3_answer;
                if (random_events[numb_ques3].Answers(numb4_answer) == random_events[numb_ques3].Corect_answerStr) otvet += "\n1. " + numb4_answer;
                */
            }



            //Генерируем четвертый вопрос 
            {
                numb_ques4 = random_variables_num[0];

                variant += ("\n4. " + random_variables[numb_ques4].Question); //описание четвертого вопроса

                Pereme_2(random_variables[numb_ques4].Answe, numb_ques4, 4);

                /*
                //Генерируем ответы на вопрос
                {
                    numb1_answer = rnd.Next(0, 4); //Первый ответ

                    //Второй ответ
                    numb2_answer = rnd.Next(0, 4);

                    while (numb1_answer != numb2_answer)
                    {
                        numb2_answer = rnd.Next(0, 4);
                    }

                    //третий ответ
                    numb3_answer = rnd.Next(0, 4);

                    while (numb3_answer != numb1_answer && numb3_answer != numb2_answer)
                    {
                        numb3_answer = rnd.Next(0, 4);
                    }

                    //четвертый ответ
                    numb4_answer = rnd.Next(0, 4);

                    while (numb4_answer != numb1_answer && numb4_answer != numb2_answer && numb4_answer != numb3_answer)
                    {
                        numb4_answer = rnd.Next(0, 4);
                    }



                }

                //Вывод ответов на этот вопрос
                variant += "\n" + random_variables[numb_ques4].Answers(numb1_answer);
                variant += "\n" + random_variables[numb_ques4].Answers(numb2_answer);
                variant += "\n" + random_variables[numb_ques4].Answers(numb3_answer);
                variant += "\n" + random_variables[numb_ques4].Answers(numb4_answer);

                //Выводим правильный номер в ответ
                if (random_variables[numb_ques4].Answers(numb1_answer) == random_variables[numb_ques4].Corect_answerStr) otvet += "\n1. " + numb1_answer;
                if (random_variables[numb_ques4].Answers(numb2_answer) == random_variables[numb_ques4].Corect_answerStr) otvet += "\n1. " + numb2_answer;
                if (random_variables[numb_ques4].Answers(numb3_answer) == random_variables[numb_ques4].Corect_answerStr) otvet += "\n1. " + numb3_answer;
                if (random_variables[numb_ques4].Answers(numb4_answer) == random_variables[numb_ques4].Corect_answerStr) otvet += "\n1. " + numb4_answer;

                */
            }



            //Генерируем второй вопрос
            {
                numb_ques5 = random_variables_num[1];


                variant += ("\n5. " + random_variables[numb_ques5].Question);

                Pereme_2(random_variables[numb_ques5].Answe, numb_ques5, 5);

                /*
                //Генерируем ответы на вопрос
                {
                    numb1_answer = rnd.Next(0, 4); //Первый ответ

                    //Второй ответ
                    numb2_answer = rnd.Next(0, 4);

                    while (numb1_answer != numb2_answer)
                    {
                        numb2_answer = rnd.Next(0, 4);
                    }

                    //третий ответ
                    numb3_answer = rnd.Next(0, 4);

                    while (numb3_answer != numb1_answer && numb3_answer != numb2_answer)
                    {
                        numb3_answer = rnd.Next(0, 4);
                    }

                    //четвертый ответ
                    numb4_answer = rnd.Next(0, 4);

                    while (numb4_answer != numb1_answer && numb4_answer != numb2_answer && numb4_answer != numb3_answer)
                    {
                        numb4_answer = rnd.Next(0, 4);
                    }



                }

                //Вывод ответов на этот вопрос
                variant += "\n" + random_variables[numb_ques5].Answers(numb1_answer);
                variant += "\n" + random_variables[numb_ques5].Answers(numb2_answer);
                variant += "\n" + random_variables[numb_ques5].Answers(numb3_answer);
                variant += "\n" + random_variables[numb_ques5].Answers(numb4_answer);

                //Выводим правильный номер в ответ
                if (random_variables[numb_ques5].Answers(numb1_answer) == random_variables[numb_ques5].Corect_answerStr) otvet += "\n1. " + numb1_answer;
                if (random_variables[numb_ques5].Answers(numb2_answer) == random_variables[numb_ques5].Corect_answerStr) otvet += "\n1. " + numb2_answer;
                if (random_variables[numb_ques5].Answers(numb3_answer) == random_variables[numb_ques5].Corect_answerStr) otvet += "\n1. " + numb3_answer;
                if (random_variables[numb_ques5].Answers(numb4_answer) == random_variables[numb_ques5].Corect_answerStr) otvet += "\n1. " + numb4_answer;

                */
            }



            //Генерируем третий вопрос
            {
                numb_ques6 = random_variables_num[2];

                
                variant += ("\n6. " + random_variables[numb_ques6].Question);

                Pereme_2(random_variables[numb_ques6].Answe, numb_ques6, 6);

                /*
                //Генерируем ответы на вопрос
                {
                    numb1_answer = rnd.Next(0, 4); //Первый ответ

                    //Второй ответ
                    numb2_answer = rnd.Next(0, 4);

                    while (numb1_answer != numb2_answer)
                    {
                        numb2_answer = rnd.Next(0, 4);
                    }

                    //третий ответ
                    numb3_answer = rnd.Next(0, 4);

                    while (numb3_answer != numb1_answer && numb3_answer != numb2_answer)
                    {
                        numb3_answer = rnd.Next(0, 4);
                    }

                    //четвертый ответ
                    numb4_answer = rnd.Next(0, 4);

                    while (numb4_answer != numb1_answer && numb4_answer != numb2_answer && numb4_answer != numb3_answer)
                    {
                        numb4_answer = rnd.Next(0, 4);
                    }



                }

                //Вывод ответов на этот вопрос
                variant += "\n" + random_variables[numb_ques6].Answers(numb1_answer);
                variant += "\n" + random_variables[numb_ques6].Answers(numb2_answer);
                variant += "\n" + random_variables[numb_ques6].Answers(numb3_answer);
                variant += "\n" + random_variables[numb_ques6].Answers(numb4_answer);

                //Выводим правильный номер в ответ
                if (random_variables[numb_ques6].Answers(numb1_answer) == random_variables[numb_ques6].Corect_answerStr) otvet += "\n1. " + numb1_answer;
                if (random_variables[numb_ques6].Answers(numb2_answer) == random_variables[numb_ques6].Corect_answerStr) otvet += "\n1. " + numb2_answer;
                if (random_variables[numb_ques6].Answers(numb3_answer) == random_variables[numb_ques6].Corect_answerStr) otvet += "\n1. " + numb3_answer;
                if (random_variables[numb_ques6].Answers(numb4_answer) == random_variables[numb_ques6].Corect_answerStr) otvet += "\n1. " + numb4_answer;

                */
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            otvet = ""; //Ответов пока нет
            int count_variants = int.Parse(textBox1.Text); //Считали количество вариантов
            
            for(int i = 0; i < count_variants; i++)
            {
                variant = ""; //Варианта пока нет
                Quest(i);
            }

            MessageBox.Show(variant);
            MessageBox.Show(otvet);
            //Вывод ответов на тест


        }
     

        private void Test_Load(object sender, EventArgs e)
        {
            AddQuestions();//Добавили вопросы
       
        }

    }
}
