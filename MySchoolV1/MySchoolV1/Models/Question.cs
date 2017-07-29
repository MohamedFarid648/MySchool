using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MySchoolV1.Models
{
    public class Question
    {
       public int ID { get; set; }
       public int userID{ get; set; }
        [AllowHtml]
        public string Text{ get; set; }

    }
}
