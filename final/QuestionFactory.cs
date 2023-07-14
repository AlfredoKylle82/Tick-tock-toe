using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class QuestionFactory
    {
       
      public static Question createQuestion(string questionText, string choice1, string choice2, string choice3, string choice4, string correctChoice)
        {
            Question obj = new Question(questionText, choice1, choice2, choice3, choice4, correctChoice);
            return obj;
        }
    }
}
