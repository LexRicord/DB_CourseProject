using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DB_CourseProject.Models;
using DB_CourseProject.DataBase;
using DB_CourseProject.Views.Client;
using DB_CourseProject.Views.Employee;
using DB_CourseProject.Views.Admin;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DB_CourseProject.Views
{
    public partial class RegistrationWindow : Window
    {
        public OracleConnection oracleConnection;
        public CurrentClient currentClient;
        public bool check = false;
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            currentClient = new CurrentClient();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "in_email",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = loginText.Text
                    };
                    OracleParameter password = new OracleParameter
                    {
                        ParameterName = "in_password",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = passwordText.Password
                    };
                    OracleParameter name = new OracleParameter
                    {
                        ParameterName = "in_name",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = nameInput.Text
                    };
                    OracleParameter surname = new OracleParameter
                    {
                        ParameterName = "in_surname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = surnameInput.Text
                    };
                    OracleParameter secondname = new OracleParameter
                    {
                        ParameterName = "in_secondname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = secondNameInput.Text
                    };
                    OracleParameter phonenumber = new OracleParameter
                    {
                        ParameterName = "in_phonenumber",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = phoneNumberInput.Text
                    };
                    OracleParameter passnum = new OracleParameter
                    {
                        ParameterName = "in_passportnumber",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = passNumInput.Text
                    };
                    using (OracleCommand command = new OracleCommand("registrationClient"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[]
                        {
                                login, password, name, surname, secondname, passnum, phonenumber
                        });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            check = true;
                            currentClient.Id = int.Parse(row["Id"].ToString());
                        }
                        MessageBox.Show("Регистрация прошла успешно");
                        connection.Close();
                        ClientWindow clientWindow = new ClientWindow(currentClient);
                        clientWindow.Show();
                        this.Close();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

