using System;
using System.Linq;

using System.Collections.Generic;

namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();
            Console.WriteLine("Ответьте на вопросы по Истории:\n");
            Random rnd = new Random();
            List<Question> j = new List<Question>();
            j.Add(new Question("Какое первое чудо света?", new string[] { "Египетские перамиды", "Висячие сады Семирамиды ", "Колосс Родосский", "Храм Артемиды Эфесской" }, 0));
            j.Add(new Question("На берегу, какой реки возник город Рим?", new string[] { "Ока", "Амур", "Тибр ", "Литмир" }, 2));
            j.Add(new Question(" Когда Русь приняла христианство?", new string[] { "в 1202 году", "в 988 году" }, 1));
            while (j.Count > 0)
            {
                Question current_question = j[rnd.Next(0, j.Count)];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(current_question.question);
                Console.ForegroundColor = ConsoleColor.Gray;
                string input = WriteAndGetAnswer(current_question);
                if (input.ToUpper() == "Q")
                    break;
                if (input == current_question.correct_answer.ToString())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Верный ответ!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неверно! Правильный ответ: {current_question.answers[current_question.correct_answer]}");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                j.Remove(current_question);
                Console.WriteLine();
            }
            Console.WriteLine("Окончание викторины!");
            Console.ReadKey();
        }

        private static string WriteAndGetAnswer(Question q)
        {
            Random rnd = new Random();
            List<string> s = new List<string>(q.answers);
            int len = s.Count + 1;
            int new_correct_answer = 0;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 1; i < len; i++)
            {
                string str = s[rnd.Next(0, s.Count)];
                if (str == q.answers[q.correct_answer])
                    new_correct_answer = i;
                Console.WriteLine($"{i}.{str}");
                s.Remove(str);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Введите номер ответа:");
            string input = Console.ReadLine();
            if (new_correct_answer.ToString() == input)
                return q.correct_answer.ToString();
            else
                return input;
        }
    }

    public class Question
    {
        public string question;
        public string[] answers;
        public int correct_answer;

        public Question(string question, string[] answers, int correct_answer)
        {
            this.question = question;
            this.answers = answers;
            this.correct_answer = correct_answer;
        }
    }
}