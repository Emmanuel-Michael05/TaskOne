using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.ENTITIES;
using TaskOne.HELPER;

namespace TaskOne.SERVICES
{
    public class GradingService
    {
        public static void Calculate(Student student)
        {
            double gpa = (double)student.TotalWeightPoints / student.TotalCourseUnits;

            PrintTable.Print(student, gpa);
        }
    }

}
