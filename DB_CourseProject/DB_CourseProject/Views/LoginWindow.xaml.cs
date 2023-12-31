using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using DB_CourseProject.Views.Admin;
using DB_CourseProject.Views.Client;
using DB_CourseProject.Views.Employee;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows;

namespace DB_CourseProject.Views
{
    public partial class Window1 : Window
    {
        public CurrentEmployee currentEmployee;
        public CurrentClient currentClient;
        public string adminPos = "admin";
        public string employeePos = "employee";
        public string clientPos = "client";
        public bool check = false;

        public Window1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            currentEmployee = new CurrentEmployee();
            currentClient = new CurrentClient();
            check = false;

            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "in_login",
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
                    OracleParameter user = new OracleParameter
                    {
                        ParameterName = "user_cur",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.findUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { login, password, user });

                        using (var reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            foreach (DataRow row in dt.Rows)
                            {
                                check = true;
                                currentEmployee.id = Convert.ToInt32(row["Id"]);
                                currentEmployee.email = row["Email"].ToString();
                                currentEmployee.name = row["Name"].ToString();
                                currentEmployee.surname = row["Surname"].ToString();
                                currentEmployee.secondname = row["SecondName"].ToString();
                                currentEmployee.role = row["Role"].ToString();
                            }
                        }
                    }

                    if (check && currentEmployee.role == adminPos)
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else if (check && currentEmployee.role == employeePos)
                    {
                        MasterWindow mw = new MasterWindow(currentEmployee);
                        mw.Show();
                        this.Close();
                    }
                    else if (!check || (check == true && currentEmployee.role == clientPos))
                    {
                        using (OracleCommand command = new OracleCommand("GAE_1.findClient", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[] { login, password, user });

                            using (var reader = command.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);

                                foreach (DataRow row in dt.Rows)
                                {
                                    check = true;
                                    currentClient.Id = Convert.ToInt32(row["id"]);
                                    currentClient.PhoneNumber = row["PhoneNumber"].ToString();
                                    currentClient.Email = row["Email"].ToString();
                                    currentClient.Balance = (double)Convert.ToDecimal(row["Balance"]);
                                    currentClient.Role = row["Role"].ToString();
                                }
                            }

                            if (currentClient.Id == 0) currentClient.Id = currentEmployee.id;

                            if (check)
                            {
                                ClientWindow clientWindow = new ClientWindow(currentClient);
                                clientWindow.Show();
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}