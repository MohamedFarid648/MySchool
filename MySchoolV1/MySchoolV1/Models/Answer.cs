using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolV1.Models
{
    public class Answer
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public int Score { get; set; }

        public int RightAnswer { get; set; }//0 true,1 false

        public int QuestionID { get; set; }


    }
}
