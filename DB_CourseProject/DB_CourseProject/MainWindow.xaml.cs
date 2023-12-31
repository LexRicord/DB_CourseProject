using DB_CourseProject.Views;
using System.Windows;

namespace DB_CourseProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.ShowDialog();
            this.Close();
        }

        private void GoLogin_Click(object sender, RoutedEventArgs e)
        {
            Window1 lw = new Window1();
            lw.ShowDialog();
            this.Close();
        }

        private void GoCheckModel_Click(object sender, RoutedEventArgs e)
        {
            CheckModel cmw = new CheckModel();
            cmw.ShowDialog();
            this.Close();
        }
    }
}
