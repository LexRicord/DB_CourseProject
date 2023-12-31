using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows;

namespace DB_CourseProject.Views.Client
{
    public partial class EditPasswordWindow : Window
    {
        private CurrentClient currentClient2;
        public EditPasswordWindow(CurrentClient currentClient)
        {
            InitializeComponent();
            currentClient2 = currentClient;
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter clientId = new OracleParameter
                    {
                        ParameterName = "in_cliendid",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = Convert.ToString(currentClient2.Id)
                    };
                    OracleParameter oldPass = new OracleParameter
                    {
                        ParameterName = "in_oldpass",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = oldPassword.Password
                    };
                    OracleParameter newPass = new OracleParameter
                    {
                        ParameterName = "in_newpass",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = newPassword.Password
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.changePassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { clientId, oldPass, newPass });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Пароль успешно изменён");
                        this.Close();
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
