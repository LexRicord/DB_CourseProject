using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using Oracle.ManagedDataAccess.Client;

namespace DB_CourseProject.Views.Employee
{
    public partial class ReadyOrderWindow : Window
    {
        private Info selectedInfo;

        public ReadyOrderWindow(Info info)
        {
            InitializeComponent();
            selectedInfo = info;
        }

        private void addTypesButton_Click(object sender, RoutedEventArgs e)
        {
            if (orderId.Text == String.Empty)
                MessageBox.Show("Проверьте введенные данные");
            else
                try
                {
                    using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
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
                            MessageBox.Show("Заказ готов!");
                            this.Close();
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                orderId.Text = selectedInfo.Order_id.ToString();
            }
            catch (Exception) { }
        }

        private void typesText1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
