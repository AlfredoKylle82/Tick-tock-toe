using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class QuestionPool
    {
        List<Question> Questions = new List<Question>();
        public void addQuestion(Question question)
        {
            Questions.Add(question);
        }

        public List<Question> GetQuestions ()
        {
            return Questions;
        }
    }
}
