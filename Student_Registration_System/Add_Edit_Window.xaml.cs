using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Registration_System
{
    /// <summary>
    /// Interaction logic for Add_Edit_Window.xaml
    /// </summary>
    public partial class Add_Edit_Window : Window
    {
        public Add_Edit_Window(Add_Edit_WindowVM vm)
        {
            InitializeComponent();
            DataContext=vm;
            vm.CloseAction = () => Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();

        }
    }
}
