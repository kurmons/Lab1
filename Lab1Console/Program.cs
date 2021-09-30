using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studData = new StudentsData();
                studData.Load(StudentsData.DefaultFilename);
                foreach (var stud in studData.Students)
                    System.Console.WriteLine(stud);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            System.Console.ReadLine();
        }
    }
}
