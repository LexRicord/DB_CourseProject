using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using DB_CourseProject.DataBase;
using Oracle.ManagedDataAccess.Client;

namespace DB_CourseProject.Views.Admin
{
    public partial class AddTypeWindow : Window
    {
        public AddTypeWindow()
        {
            InitializeComponent();
        }

        private void addTypesButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceNameText.Text == String.Empty)
                MessageBox.Show("Проверьте введенные данные");
            else
                try
                {
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
                    using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                    {
                        connection.Open();

                        OracleParameter servName = new OracleParameter
                        {
                            ParameterName = "in_name",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = serviceNameText.Text
                        };

                        using (OracleCommand command = new OracleCommand("GAE_1.addTypeOfAppliance", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[] { servName });
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

        private void typesText1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
