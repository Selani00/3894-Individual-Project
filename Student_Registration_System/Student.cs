using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Student_Registration_System
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirthday { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public double GPA { get; set; }

        public BitmapImage Image { get; set; }

           
        public Student(string firstName, string lastName, string dateOfBirthday, string contactNo, string address, double gPA, BitmapImage image)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;
            ContactNo = contactNo;
            Address = address;
            GPA = gPA;
            Image = image;
        }

        public Student()
        {

        }
    }
}
