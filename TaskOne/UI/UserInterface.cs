using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskOne.ENTITIES;
using TaskOne.SERVICES;

namespace TaskOne.UI
{
    internal class UserInterface
    {
        public static void Run()
        {
            WriteLine(" ___________________________________________________________");
            WriteLine("|                                                           |");
            WriteLine("|        Grade Point Average (GPA) calculator               |");
            WriteLine("|___________________________________________________________|");
            WriteLine();
            WriteLine("Welcome!!!!!\n To calculate your GPA, enter your course details in this format:");
            WriteLine(" 1-course-code\n 2-course-unit \n 3-course-score");
            WriteLine("Eg: MTH101    5     74, or ENG103     4    60");

            
            ReadLine();

            var student = new Student();
            var studentService = new StudentService();

            bool invalid = true;
            bool checking = true;

            while (checking)
            {
            start:
                while (invalid)
                {
                    Write("\nCourse Details: ");
                    string[] input = ReadLine().Split(", ");
                   
                        try
                        {
                            studentService.AddCourses(student, input);
                            invalid = false;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine($"\n{e.Message}");
                            student = new Student();
                            goto start;
                        }
                    
                }

               
                WriteLine("\nCalculating your GPA. Please wait ...\n");
                Thread.Sleep(3000);

                GradingService.Calculate(student);

                Write("\nCheck again? (Y/N): ");
                string answer = ReadLine().ToUpper();

                if (answer == "Y")
                {
                    student = new Student();
                    invalid = true;
                    goto start;
                }
                else
                {
                    checking = false;
                }
            }
        }

    }
}
