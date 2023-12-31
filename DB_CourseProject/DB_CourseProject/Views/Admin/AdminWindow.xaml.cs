using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using DB_CourseProject.ViewModels;
using Oracle.ManagedDataAccess.Client;

namespace DB_CourseProject.Views.Admin
{
    public partial class AdminWindow : Window
    {
        private Services tars;
        private Types types;
        private Masters mast;
        public BindingList<Services> tarsList = new BindingList<Services>();
        public BindingList<Types> typesList = new BindingList<Types>();
        public BindingList<Masters> mastList = new BindingList<Masters>();
        private CurrentEmployee empl;
        public BindingList<CurrentEmployee> emplList = new BindingList<CurrentEmployee>();
        public AdminWindow()
        {
            InitializeComponent();
            GetEmployees();
            employees.ItemsSource = emplList;
            GetTars();
            tarsDG.ItemsSource = tarsList;
            GetTypes();
            typesDG.ItemsSource = typesList;
            GetMasters();
            mastDG.ItemsSource = mastList;
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployee = new AddEmployeeWindow();
            addEmployee.Show();
        }

        private void addService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow AddService = new AddServiceWindow();
            AddService.Show();
        }
        private void addTypesOfAppliance_Click(object sender, RoutedEventArgs e)
        {
            AddTypeWindow addType = new AddTypeWindow();
            addType.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void GetTars()
        {
            tarsList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "cur",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getServices"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            tars = new Services(row["Name"].ToString(), row["Price"].ToString(), 
                                row["typename"].ToString());
                            tarsList.Add(tars);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetTypes()
        {
            typesList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "types",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getTypesOfAppliances"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            types = new Types( 
                                row["Name"].ToString(), row["NUM"].ToString(), row["COUNT"].ToString()
                            );
                            typesList.Add(types);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetEmployees()
        {
            emplList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };

                    using (OracleCommand command = new OracleCommand("getEmployees"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            empl = new CurrentEmployee(row["Email"].ToString(), row["Surname"].ToString(), row["Name"].ToString(),
                                 row["SecondName"].ToString(), row["Role"].ToString());
                            emplList.Add(empl);
                        }

                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void GetMasters()
        {
            mastList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };

                    using (OracleCommand command = new OracleCommand("getMasters"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            mast = new Masters(row["Email"].ToString(), row["Surname"].ToString(), row["NUMBEROFCOMPLETEDORDERS"].ToString(), 
                                row["NUMBEROFRETURNEDORDERS"].ToString(), row["TYPENAME"].ToString());
                            mastList.Add(mast);
                        }

                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void GetSpec()
        {
            mastList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };

                    using (OracleCommand command = new OracleCommand("getMasters"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            mast = new Masters(row["Email"].ToString(), row["Surname"].ToString(), row["NUMBEROFCOMPLETEDORDERS"].ToString(),
                                row["NUMBEROFRETURNEDORDERS"].ToString(), row["TYPENAME"].ToString());
                            mastList.Add(mast);
                        }

                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            emplList.Clear();
            tarsList.Clear();
            GetTars();
            tarsDG.ItemsSource = tarsList;
            GetEmployees();
            employees.ItemsSource = emplList;
        }

        private void addMaster_Click(object sender, RoutedEventArgs e)
        {
            NewMasterWindow addMaster = new NewMasterWindow();
            addMaster.Show();
        }

        private void tarsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}