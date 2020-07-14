using Microsoft.VisualBasic;
using System;

namespace ViewModel
{
    public class AllStudentsRecordRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
