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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using WpfApp2.DataBase;
using WpfApp2.Users;

namespace WpfApp2.Employee
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    /// 

    public partial class CreateOrderWindow : Window
    {
        private CurrentEmployee currentEmployee;
        private Services tars;
        public BindingList<Services> tarsList = new BindingList<Services>();
        private int с;

        public CreateOrderWindow(CurrentEmployee currentEmployee)
        {
            InitializeComponent();
            this.currentEmployee = currentEmployee;
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
                    
                    using (OracleCommand command = new OracleCommand("GAE_1.getTypes"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] {types});
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
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void typesText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                {
                    connection.Open();

                    OracleParameter servPacks = new OracleParameter
                    {
                        ParameterName = "service",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    OracleParameter types_text = new OracleParameter
                    {
                        ParameterName = "in_types",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = typeAppliance.SelectedValue
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.getServices2"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { types_text, servPacks });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            servicePack.Items.Add(row["Name"].ToString());
                        }
                    }
                    OracleParameter servPacks2 = new OracleParameter
                    {
                        ParameterName = "servpacks",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    OracleParameter type_text = new OracleParameter
                    {
                        ParameterName = "in_type",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = typeAppliance.SelectedValue
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getModels"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { type_text, servPacks2 });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            Model.Items.Add(row["Model"].ToString());
                        }
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetTars(String s, String s2)
        {
            tarsList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                {
                    connection.Open();
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "cur",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };
                    OracleParameter service = new OracleParameter
                    {
                        ParameterName = "in_service",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = s
                    };
                    OracleParameter type = new OracleParameter
                    {
                        ParameterName = "in_type",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = s2
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getServicesByName"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            tars = new Services(row["Name"].ToString(), row["Price"].ToString(), row["EstimCompTime"].ToString(), row["TypeName"].ToString());
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
        private void servicePack_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                {
                    connection.Open();

                    OracleParameter servPacks = new OracleParameter
                    {
                        ParameterName = "servs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    OracleParameter servPack_text = new OracleParameter
                    {
                        ParameterName = "in_service",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = servicePack.SelectedValue
                    };
                    OracleParameter type_text = new OracleParameter
                    {
                        ParameterName = "in_type",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = typeAppliance.SelectedValue
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getPrice"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { servPack_text,type_text ,servPacks });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            Price.Text = row["Price"].ToString();
                        }
                    }

                    //GetTars(servPack_text.Value, type_text.Value);
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTars(object value, object selectedValue)
        {
            throw new NotImplementedException();
        }

        private void Model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void CreateOrderWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                {
                    connection.Open();

                    OracleParameter number = new OracleParameter
                    {
                        ParameterName = "in_login",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = loginText.Text
                    };
                    OracleParameter servicePack1 = new OracleParameter
                    {
                        ParameterName = "in_services",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = servicePack.SelectedValue
                    };
                    
                    OracleParameter employeeid = new OracleParameter
                    {
                        ParameterName = "in_emplid",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = currentEmployee.id
                    };
                    OracleParameter modelName = new OracleParameter
                    {
                        ParameterName = "in_modelName",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Model.SelectedValue
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.addOrders"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[]
                        {
                            number, servicePack1, employeeid, modelName
                        });
                        int r = command.ExecuteNonQuery();
                        MessageBox.Show("Добавление прошло успешно");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow main = new MasterWindow(currentEmployee);
            main.Show();
            this.Close();
        }

        private void pserviceName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tarDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.employeeConn))
                {
                    connection.Open();

                    OracleParameter servPacks = new OracleParameter
                    {
                        ParameterName = "servs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    OracleParameter servPack_text = new OracleParameter
                    {
                        ParameterName = "in_service",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = servicePack.SelectedValue
                    };
                    OracleParameter type_text = new OracleParameter
                    {
                        ParameterName = "in_type",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = typeAppliance.SelectedValue
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.addServicePackInfo"))
                    {
                        int c = 0;
                        String s;
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { servPack_text, type_text });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        s = Price.Text;
                        с += int.Parse(s);
                        Price.Text = c.ToString();
                    }

                    GetTars(servPack_text.Value, type_text.Value);
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}