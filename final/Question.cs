using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Question
    {
        string questionText;
        string choice1;
        string choice2;
        string choice3;
        string choice4;
        string correctChoice;

        public Question(string questionText, string choice1, string choice2, string choice3, string choice4, string correctChoice)
        {
            this.questionText = questionText;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
            this.choice4 = choice4;
            this.correctChoice = correctChoice;
        }

        public string getquestionText()
        {
            return this.questionText;
        }
        public string getchoice1()
        {
            return this.choice1;
        }
        public string getchoice2()
        {
            return this.choice2;
        }
        public string getchoice3()
        {
            return this.choice3;
        }
        public string getchoice4()
        {
            return this.choice4;
        }
        public string getcorrectChoice()
        {
            return this.correctChoice;
        }
    }
}
