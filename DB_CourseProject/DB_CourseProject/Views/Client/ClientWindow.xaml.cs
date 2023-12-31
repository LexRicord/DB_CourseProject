using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using DB_CourseProject.Views.Employee;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace DB_CourseProject.Views.Client
{
    public partial class ClientWindow : Window
    {
        private Thread thread;
        public float tr = 0;
        public CurrentClient currentClient;
        static PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
        static string instance = performanceCounterCategory.GetInstanceNames()[1];
        PerformanceCounter performanceCounterSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);
        PerformanceCounter performanceCounterReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", instance);

        public ClientWindow(CurrentClient cc)
        {
            InitializeComponent();

            currentClient = cc;
            this.Loaded += ClientWindow_Loaded;
        }
        private void currClientData()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = Convert.ToString(currentClient.Id)
                    };
                    OracleParameter curs = new OracleParameter
                    {
                        ParameterName = "curs",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getClientData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id, curs });

                        using (var reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            foreach (DataRow row in dt.Rows)
                            {
                                currentClient.Id = Convert.ToInt32(row["id"]);
                                currentClient.PhoneNumber = row["PhoneNumber"].ToString();
                                currentClient.Email = row["Email"].ToString();
                                currentClient.Balance = (double)Convert.ToDecimal(row["Balance"]);
                                currentClient.Role = row["Role"].ToString();
                            }
                        }
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClientWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClientDataAndSetVisibility();
        }

        private void homePage_Click(object sender, RoutedEventArgs e)
        {
            LoadClientDataAndSetVisibility();
        }

        private void LoadClientDataAndSetVisibility()
        {
            currClientData();

            myPhoneNumber.Content = $"Номер: {currentClient.PhoneNumber}";
            myBalance.Content = $"Баланс: {currentClient.Balance}";

            personalData.Visibility = Visibility.Visible;
            changeTariffSP.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
        }


        private void ChangeService()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.Id)
                    };
                    OracleParameter tar = new OracleParameter
                    {
                        ParameterName = "in_servic",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = tariffsText.Text
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.changeServicePack", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id, tar });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Пакет услуг был изменен успешно");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void changeService_Click(object sender, RoutedEventArgs e)
        {
            tariffsText.Items.Clear();
            changeTariffSP.Visibility = Visibility.Visible;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter services = new OracleParameter
                    {
                        ParameterName = "services",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.getServices"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { services });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            tariffsText.Items.Add(row["Name"].ToString());
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void balanceReplenishment_Click(object sender, RoutedEventArgs e)
        {
            changeTariffSP.Visibility = Visibility.Collapsed;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Visible;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
        }

        private void changePass_Click(object sender, RoutedEventArgs e)
        {
            EditPasswordWindow editPass = new EditPasswordWindow(currentClient);
            editPass.Show();
        }

        private void replenishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = Convert.ToString(currentClient.Id)
                    };
                    OracleParameter sum = new OracleParameter
                    {
                        ParameterName = "in_summ",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Decimal,
                        Value = double.Parse(summReplenishText.Text)
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.balanceReplenishment"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id, sum });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Пополнение прошло успешно");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void changeTariffButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeService();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            CurrentClient currentClient2 = currentClient;
            CreateOrderClient createContractWindow = new CreateOrderClient(currentClient2);
            createContractWindow.Show();
            this.Close();
        }

        private void ClientOrders_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
