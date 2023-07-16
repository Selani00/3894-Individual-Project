using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Student_Registration_System
{
    public partial class Add_Edit_WindowVM: ObservableObject 
    {

        [ObservableProperty]
        public string title; 

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public string dateofbirthday;

        [ObservableProperty]
        public string contactno;

        [ObservableProperty]
        public string address;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public Student studentobject;

        public Action CloseAction { get; internal set; }

        public Add_Edit_WindowVM(Student s)
        {
            studentobject = s;
            firstname= studentobject.FirstName; 
            lastname= studentobject.LastName;
            dateofbirthday = studentobject.DateOfBirthday;
            contactno= studentobject.ContactNo;
            address= studentobject.Address;
            gpa = studentobject.GPA;
            selectedImage = studentobject.Image;
        }

        public Add_Edit_WindowVM()
        {
            
        }

        
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.bmp;  *.jpg; *.Gif;*.Jpegs;*.Bitmaps";
            
            if (dialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Image successfuly uploded");
            }
        }


        [RelayCommand]
        public void Save()
        {
            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA Value must be in between 0-4", "Error");
                return;
            }


            if (studentobject == null)
            {
                studentobject= new Student(firstname, lastname, dateofbirthday, contactno, address, gpa, selectedImage);
            }

            else
            {
                studentobject.FirstName= firstname;
                studentobject.LastName= lastname;
                studentobject.DateOfBirthday= dateofbirthday;
                studentobject.ContactNo=contactno;
                studentobject.Address= address;
                studentobject.GPA= gpa;
                studentobject.Image = selectedImage;
            }

            if(studentobject.FirstName != null || studentobject.LastName != null)
            {
                CloseAction();
                Application.Current.MainWindow.Show();
            }
            else
            {
                MessageBox.Show("First Name and Last Name are requried","Error");
            }         
        }

        
    }
}
