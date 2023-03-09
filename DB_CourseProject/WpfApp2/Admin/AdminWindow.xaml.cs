using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using WpfApp2.DataBase;
using WpfApp2.Users;

namespace WpfApp2.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
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
            AddService AddService = new AddService();
            AddService.Show();
        }
        private void addTypesOfAppliance_Click(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
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
                            tars = new Services(row["Name"].ToString(), row["Price"].ToString(), row["EstimCompTime"].ToString(),row["TypeName"].ToString());
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
                            types = new Types(row["TypeName"].ToString(),row["sum(MASTERSINCOME)"].ToString(), row["sum(NUMBEROFCOMPLETEDORDERS)"].ToString(), row["count(MASTERS.id)"].ToString());
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
                           empl = new CurrentEmployee(row["Login"].ToString(), row["Surname"].ToString(), row["Name"].ToString(),
                                row["SecondName"].ToString(), row["Post"].ToString());
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
                            mast = new Masters(row["Login"].ToString(), row["Surname"].ToString(), row["NUMBEROFCOMPLETEDORDERS"].ToString(),
                                 row["MASTERSINCOME"].ToString(), row["TYPENAME"].ToString());
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
                            mast = new Masters(row["Login"].ToString(), row["Surname"].ToString(), row["NUMBEROFCOMPLETEDORDERS"].ToString(),
                                 row["MASTERSINCOME"].ToString(), row["TYPENAME"].ToString());
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