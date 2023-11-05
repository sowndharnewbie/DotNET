using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class StudentRecordManager
    {
        public void studentManager()
        {
            int selectedNo = 0;
            List<Student> studentsList = new List<Student>();
            while (true)
            {
                Console.WriteLine("->Enter 1 to add student data");
                Console.WriteLine("->Enter 2 to fetch the user data");
                Console.WriteLine("->Enter 3 to exit");
                String enteredNumber = Console.ReadLine();
                selectedNo = Convert.ToInt32(enteredNumber);
                if (selectedNo == 3) break;
                else if (selectedNo == 2)
                {
                    Console.WriteLine("Enter the rollno");
                    string userId = Console.ReadLine();
                    int index = findIndex(studentsList, userId);
                    if (index == -1)
                    {
                        Console.WriteLine("Rollno Doesnt Exist!");
                        continue;
                    }
                    Student res = studentsList[index];
                    Console.WriteLine($"\nName:{res.Name},RollNo:{res.Id}and Dept:{res.Dept}\n");
                }
                else if (selectedNo == 1)
                {
                    Console.WriteLine("Enter the student name");
                    string sName = Console.ReadLine();
                    Console.WriteLine("Enter the student rollno");
                    string sRollNo = Console.ReadLine();
                    Console.WriteLine("Enter the student dept");
                    string sDept = Console.ReadLine();
                    Student student = new Student()
                    {
                        Name = sName,
                        Id = sRollNo,
                        Dept = sDept
                    };
                    studentsList.Add(student);
                    Console.WriteLine("\nStudent details added successfully\n");
                }
                else
                {
                    Console.WriteLine("please enter a valid number");
                }
            }
        }
        public static int findIndex(List<Student> studentsList, string userId)
        {
            int index = 0;
            foreach (var i in studentsList)
            {
                if (i.Id.Equals(userId)) return index;
                index++;
            }
            return -1;
        }
    }
}
