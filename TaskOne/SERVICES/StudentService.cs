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
                
                Course course = null; // Declare course outside the try block
                bool isValid = false; // Flag to track if the input is valid

                while (!isValid)
                {
                    try
                    {
                        Console.WriteLine("Enter course details in the format: <CourseName> <CourseUnits> <CourseScore>");
                        string userInput = Console.ReadLine(); // Use a different variable name for input

                        if (string.IsNullOrWhiteSpace(userInput))
                        {
                            throw new ArgumentException("The entry string is null or empty.");
                        }

                        string[] courseArray = userInput.Split(' ');

                        if (courseArray.Length < 3)
                        {
                            throw new ArgumentException("The entry does not contain enough information to create a course.");
                        }

                        string courseName = courseArray[0];

                        if (!int.TryParse(courseArray[1], out int courseUnit))
                        {
                            throw new FormatException("Course Unit must be a valid integer.");
                        }
                        if (courseUnit < 1 || courseUnit > 5)
                        {
                            throw new ArgumentOutOfRangeException("Course Unit must be between 1 and 5.");
                        }

                        if (!int.TryParse(courseArray[2], out int courseScore))
                        {
                            throw new FormatException("Course Score must be a valid integer.");
                        }
                        if (courseScore < 0 || courseScore > 100)
                        {
                            throw new ArgumentOutOfRangeException("Course Score must be between 0 and 100.");
                        }

                        course = new Course(courseName, courseUnit, courseScore);

                        if (student?.Courses == null)
                        {
                            throw new NullReferenceException("Student or their courses list is null.");
                        }

                        student.Courses.Add(course);
                        isValid = true; // Input is valid, exit the loop
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Input error: {ex.Message}");
                        Console.WriteLine("Please try again.");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Data format error: {ex.Message}");
                        Console.WriteLine("Please try again.");
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine($"Object error: {ex.Message}");
                        Console.WriteLine("Please try again.");
                    }
                    catch (Exception ex)
                    {
                        // Catch-all for any unexpected errors
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        Console.WriteLine("Please try again.");
                    }
                }

                // Update totals after successful course creation
                if (course != null)
                {
                    student.TotalCourseUnits += course.CourseUnits;
                    student.TotalWeightPoints += course.WeightPoint;
                    if (course.StudentGrade != 0) student.TotalCourseUnitsPassed += course.CourseUnits;
                }

            }
        }
    }
}