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

namespace WpfApp2.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
            using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
            {
                connection.Open();
                OracleParameter types = new OracleParameter
                {
                    ParameterName = "types",
                    Direction = ParameterDirection.Output,
                    OracleDbType = OracleDbType.RefCursor
                };

                using (OracleCommand command = new OracleCommand("GAE_1.getTypesOfAppliances"))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(new OracleParameter[] { types });
                    var reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    foreach (DataRow row in dt.Rows)
                    {
                        typeAppliance.Items.Add(row["TypeName"].ToString());
                    }
                }
            }
        }

        private void addServieeButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceNameText.Text == String.Empty || priceText.Text == String.Empty || double.Parse(priceText.Text) <= 0)
                MessageBox.Show("Проверьте введенные данные");
            else
                try
                {
                    using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                    {
                        connection.Open();
                        
                        OracleParameter servName = new OracleParameter
                        {
                            ParameterName = "in_name",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = serviceNameText.Text
                        };
                        OracleParameter price = new OracleParameter
                        {
                            ParameterName = "in_price",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Decimal,
                            Value = decimal.Parse(priceText.Text)
                        };
                        OracleParameter typename = new OracleParameter
                        {
                            ParameterName = "in_typename",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = typeAppliance.Text
                        };
                        OracleParameter time = new OracleParameter
                        {
                            ParameterName = "in_time",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = timeText.Text
                        };

                        using (OracleCommand command = new OracleCommand("GAE_1.addService", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[] { servName, price, typename,time });
                            command.ExecuteNonQuery();
                            MessageBox.Show("Пакет услуг добавлен успешно");
                        }
                        
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);

                }
        }

        private void typesText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void priceText_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }    
}
