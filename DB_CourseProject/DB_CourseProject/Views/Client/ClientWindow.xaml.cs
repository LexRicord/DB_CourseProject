using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using DB_CourseProject.Views.Employee;
using Oracle.ManagedDataAccess.Client;
using System;
using System.ComponentModel;
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
        public Info info;
        public BalanceHistory balanceHistoryItem;
        public BindingList<Info> clients = new BindingList<Info>();
        public BindingList<BalanceHistory> balanceHistoryList = new BindingList<BalanceHistory>();
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
            clientOrders.Visibility = Visibility.Collapsed;
            balanceHistory.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
        }


        private void changeService_Click(object sender, RoutedEventArgs e)
        {
            balanceHistoryList.Clear();
            balanceHistory.Visibility = Visibility.Visible;
            clientOrders.Visibility = Visibility.Collapsed;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand("GetBalanceHistoryForClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_clientId", OracleDbType.Int32).Value = currentClient.Id;
                        command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        command.Connection = connection;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int transactionId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                    int sumOfTransaction = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                    string typeOfTransaction = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                    int orderId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                                    balanceHistoryItem = new BalanceHistory(transactionId, sumOfTransaction, typeOfTransaction, orderId);
                                    balanceHistoryList.Add(balanceHistoryItem);
                                }
                            }
                            balanceHistory.ItemsSource = balanceHistoryList;
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
            balanceHistory.Visibility = Visibility.Collapsed;
            clientOrders.Visibility = Visibility.Collapsed;
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
            clients.Clear();
            clientOrders.Visibility = Visibility.Visible;
            balanceHistory.Visibility = Visibility.Collapsed;
            personalData.Visibility = Visibility.Collapsed; 
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand("getOrderByClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_clientid", OracleDbType.Int32).Value = currentClient.Id;
                        command.Parameters.Add("p_curs", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        command.Connection = connection;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int order_id = reader.GetInt32(0);
                                    string clientEmail = reader.GetString(1);
                                    int orderPrice = reader.GetInt32(2);
                                    string servicePackOrder = reader.GetString(3);
                                    string regDate = reader.GetDateTime(4).ToString();
                                    string compDate = reader.GetDateTime(5).ToString();
                                    string orderState = reader.GetString(6);
                                    string orderDescription = reader.GetString(7).ToString();
                                    string model = reader.GetString(8);

                                    int? eid = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9);

                                    if (currentClient.Email == clientEmail)
                                    {
                                        info = new Info(order_id, clientEmail, orderPrice, servicePackOrder,
                                            regDate, compDate, orderState, orderDescription, model, eid ?? 0);
                                        clients.Add(info);
                                    }
                                }
                            }
                            clientOrders.ItemsSource = clients;
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
