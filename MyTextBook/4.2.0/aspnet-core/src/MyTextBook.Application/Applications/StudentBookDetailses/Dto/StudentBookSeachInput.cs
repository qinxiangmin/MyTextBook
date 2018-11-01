using System;
using System.Collections.Generic;
using System.Text;

namespace MyTextBook.Applications.StudentBookDetailses.Dto
{
    public class StudentBookSeachInput
    {
        public string SeachBookName { get; set; }

        public string StudentNum { get; set; }

        public string StudentClassId { get; set; }

        public string AcademicYear { get; set; }

        public string Semester { get; set; }
    }
}
