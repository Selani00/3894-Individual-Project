using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Student_Registration_System
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectStudent = null;

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));

            students.Add(new Student("Selani", "Didulani", "04/12/2000", "0714256398", "Kottawa", 3.2, image1));
            students.Add(new Student("bchkd", "Didulani", "04/12/2000", "0714256398", "Kottawa", 3.2, image2));
            students.Add(new Student("Selani", "gudw", "04/12/2000", "0714256398", "Kottawa", 3.2, image3));
            students.Add(new Student("Dinuk", "Pathiraj", "04/12/2000", "0711570452", "Mathugama", 4, image4));
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectStudent != null)
            {
                string name = selectStudent.FirstName;
                students.Remove(selectStudent);               
                MessageBox.Show($"{name} is Deleted successfuly.");

            }
            else
            {
                MessageBox.Show("Please select a student", "Error");


            }

        }

        [RelayCommand]
        public void AddStudent()
        {
            var addvm = new Add_Edit_WindowVM();
            addvm.title = "Add Student Menu";

            Add_Edit_Window addwindow = new Add_Edit_Window(addvm);
            Application.Current.MainWindow.Hide();
            addwindow.ShowDialog();

            if (addvm.studentobject != null)
            {
                students.Add(addvm.studentobject);
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (selectStudent != null)
            {
                var editvm = new Add_Edit_WindowVM(selectStudent);
                editvm.title = "Edit Student Menu";

                var editwindow = new Add_Edit_Window(editvm);
                Application.Current.MainWindow.Hide();
                editwindow.ShowDialog();

                int index = students.IndexOf(selectStudent);
                students.RemoveAt(index);
                students.Insert(index, editvm.studentobject);

            }
            else
            {
                MessageBox.Show("Please Select the student");
            }
        }

    }
}
