using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quiz
{
    public class Quiz
    {
       
        public List<Question> Questions { get; set; }
        public string filePath = @"D:\PROGRAMOWANIE\C#\C# kurs zaawansowany\CSharpAdvanced\CSharpAdvanced\questions.txt";
        public Player Player { get; set; }
        public Quiz()
        {           
            LoadQuestionsFromFile(filePath);
        }

        public void LoadQuestionsFromFile(string filePath)
        {
            Questions = new List<Question>();
            var lines = File.ReadAllLines(filePath);
            var Question = new Question();

            for (int i = 0; i < lines.Length / 6; i++)
            {
                Question.Title = lines[0 + (i * 6)];
                Question.AnswerA = lines[1 + (i * 6)];
                Question.AnswerB = lines[2 + (i * 6)];
                Question.AnswerC = lines[3 + (i * 6)];
                Question.AnswerD = lines[4 + (i * 6)];
                Question.RightAnswer = lines[5 + (i * 6)].Substring(0, 1);
                Question.Score = int.Parse(lines[5 + (i * 6)].Substring(1, 1));
                Questions.Add(Question);
                Question = new Question();               

            }
            
        }

        public void Start()
        {
            var Player = new Player();

            Console.WriteLine("Tell me Your name");

            Player.Name = Console.ReadLine();

            Player.Score = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                Player.Score += ShowQuestion(i + 1);
            }

            Console.WriteLine($"Quiz is done, Yours score is {Player.Score}");
        }

        public int ShowQuestion(int questionNmuber)
        {
            var currentQuestionToShow = Questions[questionNmuber - 1];

            Console.WriteLine($"Question :{currentQuestionToShow.Title}");
            Console.WriteLine($"Answer A: {currentQuestionToShow.AnswerA}");
            Console.WriteLine($"Answer B: {currentQuestionToShow.AnswerB}");
            Console.WriteLine($"Answer C: {currentQuestionToShow.AnswerC}");
            Console.WriteLine($"Answer D: {currentQuestionToShow.AnswerD}");

            Console.WriteLine("What is Your Answer?: ");
            var userResponse = Console.ReadLine().ToUpper();

            if (userResponse == currentQuestionToShow.RightAnswer)
            {
                Console.WriteLine("Good Answer!");
                return currentQuestionToShow.Score;
            }
            Console.WriteLine($"Wrong Answer - the correct is {currentQuestionToShow.RightAnswer}");
            return 0;
        }
    }
}


        //wersja z wykładów:

        //    public List<Question> Questions { get; set; }

        //    public Quiz()
        //    {
        //        LoadQuestionFromFile("questions.txt");
        //    }

        //    private void LoadQuestionFromFile(string filePath)
        //    {
        //        var lines = File.ReadAllLines(filePath);
        //        var counter = 0;
        //        Questions = new List<Question>();

        //        var currentQuestion = new Question();
        //        foreach (var line in lines)
        //        {
        //            if (counter == 6)
        //            {
        //                counter = 0;
        //            }
        //            if (counter == 0)
        //            {
        //                currentQuestion.Title = line;
        //            }
        //            if (counter == 1)
        //            {
        //                currentQuestion.AnswerA = line;
        //            }
        //            if (counter == 2)
        //            {
        //                currentQuestion.AnswerB = line;
        //            }
        //            if (counter == 3)
        //            {
        //                currentQuestion.AnswerC = line;
        //            }
        //            if (counter == 4)
        //            {
        //                currentQuestion.AnswerD = line;
        //            }
        //            if (counter == 5)
        //            {
        //                currentQuestion.RightAnswer = line[0].ToString();
        //                currentQuestion.Score = int.Parse(line[1].ToString());

        //                var newQuestion = new Question
        //                {
        //                    Title = currentQuestion.Title,
        //                    AnswerA = currentQuestion.AnswerA,
        //                    AnswerB = currentQuestion.AnswerB,
        //                    AnswerC = currentQuestion.AnswerC,
        //                    AnswerD = currentQuestion.AnswerD,
        //                    RightAnswer = currentQuestion.RightAnswer,
        //                    Score = currentQuestion.Score                     
        //                };

        //                Questions.Add(newQuestion);


        //            }

        //            counter++;
        //        }
        //    }
        //}

    //}
