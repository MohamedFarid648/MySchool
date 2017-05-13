using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolV1.Models
{
    public class UserType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static string returnUserTypeName(int UserTypeID)
        {
            DBContextClass db = new DBContextClass();
            UserType UserType = db.UserTypes.Single(u => u.ID == UserTypeID);
            return UserType.Name;

        }
    }
}
