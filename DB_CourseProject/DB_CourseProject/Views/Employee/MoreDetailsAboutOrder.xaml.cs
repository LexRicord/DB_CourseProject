using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System;
using System.Windows;
using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using System.Security.Cryptography;
using DB_CourseProject.ViewModels;

namespace DB_CourseProject.Views.Employee
{
    public partial class MoreDetailsAboutOrder : Window
    {
        private int orderId;
        private Info detailsOfOrder;

        public MoreDetailsAboutOrder(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loginText.IsReadOnly = true;
            OrderDescription.IsReadOnly = true;
            LoadOrderDetails();
            LoadServiceByServicePackOrder();
            LoadType();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadOrderDetails()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter ord = new OracleParameter
                    {
                        ParameterName = "p_orderId",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = orderId
                    };

                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "p_curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand getOrderByOrderIdCommand = new OracleCommand("getOrderByOrderId", connection))
                    {
                        getOrderByOrderIdCommand.CommandType = CommandType.StoredProcedure;
                        getOrderByOrderIdCommand.Parameters.AddRange(new OracleParameter[] { ord, curs });

                        getOrderByOrderIdCommand.ExecuteNonQuery();
                        OracleDataReader reader = ((OracleRefCursor)getOrderByOrderIdCommand.Parameters["p_curs"].Value).GetDataReader();

                        if (reader.Read())
                        {
                            detailsOfOrder = new Info(
                                Convert.ToInt32(reader["id"]),
                                reader["Email"].ToString(),
                                Convert.ToInt32(reader["orderprice"]),
                                reader["ServicePackOrder"].ToString(),
                                reader["OrderRegDate"].ToString(),
                                reader["ORDERCOMPLDATE"].ToString(),
                                reader["StateDescription"].ToString(),
                                reader["OrderDescription"].ToString(),
                                reader["MODEL"].ToString(),
                                Convert.ToInt32(reader["EID"])
                            );
                        }
                        reader.Close();
                        loginText.Text = detailsOfOrder.ClientEmail;
                        Model.Text = detailsOfOrder.Model;
                        OrderDescription.Text = detailsOfOrder.OrderDescription;
                        Price.Text = detailsOfOrder.OrderPrice.ToString();
                    }
                }
                MessageBox.Show("Детали заказа успешно взяты");
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadType()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter modelParam = new OracleParameter
                    {
                        ParameterName = "p_model",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Model.Text.ToString()
                    };

                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand getTypeByModelCommand = new OracleCommand("getTypeByModel", connection))
                    {
                        getTypeByModelCommand.CommandType = CommandType.StoredProcedure;
                        getTypeByModelCommand.Parameters.AddRange(new OracleParameter[] { modelParam, curs });

                        OracleDataReader reader = getTypeByModelCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            typeAppliance.Text = reader["typename"].ToString();
                        }
                        reader.Close();     
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadServiceByServicePackOrder()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter servicePackOrder = new OracleParameter
                    {
                        ParameterName = "in_servicepackorder",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = detailsOfOrder.ServicePackOrder
                    };

                    OracleParameter cursor = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    try
                    {
                        using (OracleCommand command = new OracleCommand("GAE_1.getServicesByServicePackOrder"))
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[]
                            { servicePackOrder, cursor });

                            int r = command.ExecuteNonQuery();

                            using (var reader = ((OracleRefCursor)cursor.Value).GetDataReader())
                            {
                                while (reader.Read())
                                {
                                    Services serviceItem = new Services(
                                        reader["Name"].ToString(),
                                        reader["Price"].ToString(),
                                        Convert.ToInt32(reader["EstimCompTime"]),
                                        reader["typename"].ToString(),
                                        Convert.ToInt32(reader["Id"])
                                    );
                                    serviceDG.Items.Add(serviceItem);
                                }
                            }

                            MessageBox.Show("Добавление прошло успешно");
                        }
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
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
