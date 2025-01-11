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
                
                Course course = null; 
                bool isValid = false; 

                while (!isValid)
                {
                    try
                    {
                        Console.WriteLine("Enter all course details separated by commas.");
                        Console.WriteLine("Each course detail should be in the format: <CourseCode> <CourseUnits> <CourseScore>");
                        Console.WriteLine("For example: MTH101 5 74, ENG103 4 60, PHY102 3 85");
                        string userInput = Console.ReadLine(); 

                        if (string.IsNullOrWhiteSpace(userInput))
                        {
                            throw new ArgumentException("The entry string is null or empty.");
                        }

                        // Split the input into individual course batches
                        string[] courseBatches = userInput.Split(',');

                        foreach (string batch in courseBatches)
                        {
                            string trimmedBatch = batch.Trim(); 
                            string[] courseArray = trimmedBatch.Split(' ');

                            if (courseArray.Length < 3)
                            {
                                throw new ArgumentException($"The entry '{trimmedBatch}' does not contain enough information to create a course.");
                            }

                            string courseCode = courseArray[0];

                            if (!int.TryParse(courseArray[1], out int courseUnit))
                            {
                                throw new FormatException($"Course Unit in '{trimmedBatch}' must be a valid integer.");
                            }
                            if (courseUnit < 1 || courseUnit > 5)
                            {
                                throw new ArgumentOutOfRangeException($"Course Unit in '{trimmedBatch}' must be between 1 and 5.");
                            }

                            if (!int.TryParse(courseArray[2], out int courseScore))
                            {
                                throw new FormatException($"Course Score in '{trimmedBatch}' must be a valid integer.");
                            }
                            if (courseScore < 0 || courseScore > 100)
                            {
                                throw new ArgumentOutOfRangeException($"Course Score in '{trimmedBatch}' must be between 0 and 100.");
                            }
                            course = new Course(courseCode, courseUnit, courseScore);

                            if (student?.Courses == null)
                            {
                                throw new NullReferenceException("Student or their courses list is null.");
                            }

                            student.Courses.Add(course);

                            // Update totals for each course
                            student.TotalCourseUnits += course.CourseUnits;
                            student.TotalWeightPoints += course.WeightPoint;
                            if (course.StudentGrade != 0)
                            {
                                student.TotalCourseUnitsPassed += course.CourseUnits;
                            }
                        }

                        // If we successfully process all batches, set the flag to exit the loop
                        isValid = true;
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
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        Console.WriteLine("Please try again.");
                    }
                }

            }
        }
    }
}