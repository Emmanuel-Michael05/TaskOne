using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.ENTITIES;
using TaskOne.HELPER;

namespace TaskOne.SERVICES
{
    public class CourseService
    {
        public static void CheckGrade(Course course, int score)
        {
            if (score > 69)
            {
                course.StudentGrade = Grades.A;
                course.StudentGradeRemark = "Excellent";
            }
            else if (score > 59)
            {
                course.StudentGrade = Grades.B;
                course.StudentGradeRemark = "Very Good";
            }
            else if (score > 49)
            {
                course.StudentGrade = Grades.C;
                course.StudentGradeRemark = "Good";
            }
            else if (score > 44)
            {
                course.StudentGrade = Grades.D;
                course.StudentGradeRemark = "Fair";
            }
            else if (score > 39)
            {
                course.StudentGrade = Grades.E;
                course.StudentGradeRemark = "Pass";
            }
            else
            {
                course.StudentGrade = Grades.F;
                course.StudentGradeRemark = "Fail";
            }
        }
    }
}