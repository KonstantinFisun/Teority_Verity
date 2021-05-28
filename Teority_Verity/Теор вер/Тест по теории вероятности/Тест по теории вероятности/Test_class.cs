using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тест_по_теории_вероятности
{
    public class RandomEvents
    {
        string question;
        string[] answers;
        int corect_answer_number;
        string corect_answer;
        public RandomEvents(string input_question, string[] input_answer, int correct)
        {
            this.answers = new string[4];
            for ( int i = 0; i < answers.Length; i++)
            {
                answers[i] = input_answer[i];
            }
            this.question = input_question;
            this.corect_answer_number = correct; //Записываем правильный ответ в виде номера
            this.corect_answer = input_answer[corect_answer_number-1]; //Записываем правильный ответ в виде текста
        }

        public string Question
        {
            get
            {
                return question;
            }
        }

        public string Answers(int index)
        {
            
             return answers[index];
            
        }
        public string[] Answe
        {
            get
            { 
                return answers;
            }

        }

        public string Corect_answerStr
        {
            get
            {
                return corect_answer;
            }
        }

        public int CorrectAnswer
        {
            get
            {
                return corect_answer_number;
            }
        }
    }
}
