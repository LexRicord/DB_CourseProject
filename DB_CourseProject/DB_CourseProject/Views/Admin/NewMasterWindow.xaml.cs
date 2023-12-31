using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using DB_CourseProject.DataBase;
using Oracle.ManagedDataAccess.Client;

namespace DB_CourseProject.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для NewMasterWindow.xaml
    /// </summary>
    public partial class NewMasterWindow : Window
    {
        public NewMasterWindow()
        {
            InitializeComponent();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter employees = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getWorkers"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { employees });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            employeeSur.Items.Add(row["Surname"].ToString());
                        }
                    }
                    OracleParameter types = new OracleParameter
                    {
                        ParameterName = "types",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getTypesOfAppliancesNames"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { types });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            typeAppliances.Items.Add(row["Name"].ToString());
                        }
                    }
                }


            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter surname = new OracleParameter
                    {
                        ParameterName = "in_surname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = employeeSur.Text
                    };
                    OracleParameter name = new OracleParameter
                    {
                        ParameterName = "in_name",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = emplName.Text
                    };
                    OracleParameter secondname = new OracleParameter
                    {
                        ParameterName = "in_secondname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = secondName.Text
                    };
                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "in_empllogin",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = loginEmpl.Text
                    };
                    OracleParameter typename = new OracleParameter
                    {
                        ParameterName = "in_typename",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = typeAppliances.Text
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.addMaster", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { name, surname, secondname, login, typename });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Мастер добавлен успешно");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void typeAppliances_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter employees = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "in_emplogin",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = loginEmpl.Text
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.getEmployeesByLogin"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { login, employees });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            emplName.Text = row["Name"].ToString();
                            secondName.Text = row["SecondName"].ToString();
                        }
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void employeeSur_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter employees = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    OracleParameter surname = new OracleParameter
                    {
                        ParameterName = "in_empsurname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = employeeSur.SelectedValue
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.getEmployeesBySurname"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { surname, employees });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            loginEmpl.Text = row["Email"].ToString();
                        }
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loginEmpl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}

