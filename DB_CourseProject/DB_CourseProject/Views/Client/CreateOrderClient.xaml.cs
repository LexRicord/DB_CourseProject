using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using DB_CourseProject.ViewModels;
using DB_CourseProject.Views.Employee;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DB_CourseProject.Views.Client
{
    public partial class CreateOrderClient : Window
    {
        private CurrentClient currentClient;
        private Services services;
        public BindingList<Services> servicesList = new BindingList<Services>();
        private int с;

        public CreateOrderClient(CurrentClient currentCli)
        {
            InitializeComponent();
            this.currentClient = currentCli;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
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
                            typeAppliance.Items.Add(row["Name"].ToString());
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.servicesList = servicesList;
        }

        private void typesText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
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
                    using (OracleCommand command = new OracleCommand("GAE_1.getServicesByTypeName"))
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
            servicesList.Clear();
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
                            services = new Services(row["Name"].ToString(), row["Price"].ToString(),
                                row["typename"].ToString());
                            servicesList.Add(services);
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
        }

        private void Model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CreateOrderWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (currentClient != null && !string.IsNullOrEmpty(currentClient.Email))
            {
                loginText.Text = currentClient.Email;
            }
            else
            {
                MessageBox.Show("Email отсутствует у текущего клиента.");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter serviceName = new OracleParameter
                    {
                        ParameterName = "in_serviceName",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = servicePack.SelectedItem
                    };

                    OracleParameter typeApplianceName = new OracleParameter
                    {
                        ParameterName = "in_type",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = typeAppliance.SelectedItem
                    };

                    OracleParameter cursor = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    try
                    {
                        using (OracleCommand command = new OracleCommand("GAE_1.getServiceByTypeAndName"))
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[]
                            {
                        serviceName, typeApplianceName, cursor
                            });

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
                                    UpdateTotalPrice(serviceItem);
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

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow main = new ClientWindow(currentClient);
            main.Show();
            this.Close();
        }

        private void serviceDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var editedItem = e.Row.Item;
                UpdateTotalPrice(editedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in CellEditEnding: {ex.Message}");
            }
        }

        private void UpdateTotalPrice(object editedItem)
        {
            try
            {
                double totalPrice = 0;

                foreach (var item in serviceDG.Items)
                {
                    var priceColumn = serviceDG.Columns.FirstOrDefault(c => c.Header.ToString() == "Цена") as DataGridTextColumn;
                    if (priceColumn != null)
                    {
                        var priceCellContent = priceColumn.GetCellContent(item);
                        if (priceCellContent != null && priceCellContent is TextBlock)
                        {
                            var priceText = (priceCellContent as TextBlock).Text;
                            double priceValue;
                            if (double.TryParse(priceText, out priceValue))
                            {
                                totalPrice += priceValue;
                            }
                        }
                    }
                }
                if (editedItem != null)
                {
                    var editedItemPrice = GetPriceFromEditedItem(editedItem);
                    totalPrice += editedItemPrice;
                }

                Price.Text = totalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating total price: {ex.Message}");
            }
        }

        private double GetPriceFromEditedItem(object editedItem)
        {
            if (editedItem is Services editedService)
            {
                double editedPrice;
                if (double.TryParse(editedService.Price, out editedPrice))
                {
                    return editedPrice;
                }
            }
            return 0;
        }

        private void AddServicesToServicePacks()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    foreach (var service in serviceDG.Items.OfType<DB_CourseProject.ViewModels.Services>())
                    {
                        int serviceId = service.ServiceId;

                        OracleParameter serviceIdParam = new OracleParameter
                        {
                            ParameterName = "in_service_id",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Int32,
                            Value = serviceId
                        };

                        OracleParameter orderNumberParam = new OracleParameter
                        {
                            ParameterName = "in_order_number",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Int32,
                            Value = GetMaxOrderId(connection)
                        };

                        using (OracleCommand addServicesCommand = new OracleCommand("AddServicesToServicePacks", connection))
                        {
                            addServicesCommand.CommandType = CommandType.StoredProcedure;
                            addServicesCommand.Parameters.AddRange(new OracleParameter[] { serviceIdParam, orderNumberParam });
                            addServicesCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Добавление услуг в ServicePacks прошло успешно");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetMaxOrderId(OracleConnection connection)
        {
            using (OracleCommand cmd = new OracleCommand("SELECT NVL(MAX(Id), 0) FROM Orders", connection))
            {
                int maxOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                return maxOrderId;
            }
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
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

                    OracleParameter modelname = new OracleParameter
                    {
                        ParameterName = "in_modelname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Model.SelectedItem.ToString()
                    };

                    OracleParameter price = new OracleParameter
                    {
                        ParameterName = "in_price",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = Convert.ToInt32(Price.Text)
                    };

                    OracleParameter description = new OracleParameter
                    {
                        ParameterName = "in_descr",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = OrderDescription.Text
                    };

                    using (OracleCommand addOrdersCommand = new OracleCommand("addOrdersWithoutMaster", connection))
                    {
                        addOrdersCommand.CommandType = CommandType.StoredProcedure;
                        addOrdersCommand.Parameters.AddRange(new OracleParameter[] { login, modelname, price, description });
                        addOrdersCommand.ExecuteNonQuery();
                    }
                    AddServicesToServicePacks();
                    MessageBox.Show("Добавление заказа прошло успешно");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}