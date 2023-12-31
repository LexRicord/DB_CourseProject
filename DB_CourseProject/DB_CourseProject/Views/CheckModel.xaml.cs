using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace DB_CourseProject.Views
{
    public partial class CheckModel : Window
    {
        private Model model1;
        public BindingList<Model> modelsList = new BindingList<Model>();
        public CheckModel()
        {
            InitializeComponent();
            GetModels();
            models.ItemsSource = modelsList;
        }

        private void GetModels()
        {
            modelsList.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter model_text = new OracleParameter
                    {
                        ParameterName = "in_model",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = ""
                    };
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "servpacks",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor,
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.GETMODELSWITHTYPEANDPRODUCER"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { model_text, curs });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            model1 = new Model(row["Model"].ToString(), row["Name"].ToString(), row["Producer"].ToString());
                            modelsList.Add(model1);
                        }
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
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter model_text = new OracleParameter
                    {
                        ParameterName = "in_model",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = ModelText.ToString()
                    };
                    OracleParameter servPacks = new OracleParameter
                    {
                        ParameterName = "servpacks",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.GETMODELSWITHTYPEANDPRODUCER"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { model_text, servPacks });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        modelsList.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            model1 = new Model(row["Model"].ToString(), row["Name"].ToString(), row["Producer"].ToString());
                            modelsList.Add(model1);
                        }
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
