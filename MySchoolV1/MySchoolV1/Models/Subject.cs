using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolV1.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static string returnSubjectName(int SubjectID)
        {
            DBContextClass db = new DBContextClass();
            Subject Subject = db.Subjects.Single(s => s.ID == SubjectID);
            return Subject.Name;

        }

    }
}
