using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.ENTITIES;

namespace TaskOne.SERVICES
{
    public class StudentService
    {
        public void AddCourses(Student student, string[] input)
        {
            foreach (string entry in input)
            {
                //split entry, create course instance, add to student's courses
                string[] courseArray = entry.Split(' ');
                var course = new Course(courseArray[0], int.Parse(courseArray[1]), int.Parse(courseArray[2]));
                student.Courses.Add(course);

                student.TotalCourseUnits += course.CourseUnits;
                student.TotalWeightPoints += course.WeightPoint;
                if (course.StudentGrade != 0) student.TotalCourseUnitsPassed += course.CourseUnits;
            }
        }
    }
}
