using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolV1.Models
{
    public class CustomRangeDateValidationAttribute : RangeAttribute
    {
        public CustomRangeDateValidationAttribute(string minimumValue) : base(typeof(DateTime), minimumValue, DateTime.Now.ToShortDateString())
        {
            /*base keyword to invoke base class(Range Attribute) constructor
             * 
             * Constructor with empty body*/
        }
    }
}
