using System;
using System.Collections.Generic;
using System.Data;
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
using Oracle.ManagedDataAccess.Client;
using WpfApp2.DataBase;

namespace WpfApp2.Employee
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class ReadyOrderWindow : Window
    {
        public ReadyOrderWindow()
        {
            InitializeComponent();
        }

        private void addTypesButton_Click(object sender, RoutedEventArgs e)
        {
            if (orderId.Text == String.Empty)
                MessageBox.Show("Проверьте введенные данные");
            else
                try
                {
                    using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                    {
                        connection.Open();
                        OracleParameter types = new OracleParameter
                        {
                            ParameterName = "in_orderid",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = orderId.Text
                        };

                        using (OracleCommand command = new OracleCommand("GAE_1.readyOrder"))
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[] { types });
                            var reader = command.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);

                }
        }

        private void typesText1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        }    
}
