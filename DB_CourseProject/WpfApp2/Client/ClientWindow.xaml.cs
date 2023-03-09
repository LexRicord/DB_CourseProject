using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using Microsoft.Web.WebView2.Wpf;
using WpfApp2.DataBase;
using WpfApp2.Users;

namespace WpfApp2.Client
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private Thread thread;
        public float tr=0;
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
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();

                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
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
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            currentClient.phoneNumber = row["PHONENUMBER"].ToString();
                            currentClient.balance = double.Parse(row["Balance"].ToString());
                            currentClient.minutes = row["RMinutes"].ToString();
                            currentClient.sms = row["RSMS"].ToString();
                        }
                    }

                    myPhoneNumber.Content = "Логин/Номер: " + currentClient.phoneNumber;
                    myBalance.Content = "Баланс: " + Convert.ToString(currentClient.balance)+" руб.";
                    myMins.Content = "Минуты: " + currentClient.minutes;
                    mySMS.Content = "Отправить СМС: " + currentClient.sms;
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClientWindow_Loaded(object sender, RoutedEventArgs e)
        {
           currClientData();
           personalData.Visibility = Visibility.Visible;
           changeTariffSP.Visibility = Visibility.Collapsed;
           balanceReplenishmentSP.Visibility = Visibility.Collapsed;
           moneyTransferSP.Visibility = Visibility.Collapsed;
           callSP.Visibility = Visibility.Collapsed;
        }

        private void homePage_Click(object sender, RoutedEventArgs e)
        {
            currClientData();
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
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();

                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
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
            changeTariffSP.Visibility =  Visibility.Visible;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
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

        private void MoneyTransfer()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();

                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
                    };
                    OracleParameter summ = new OracleParameter
                    {
                        ParameterName = "in_summ",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Decimal,
                        Value = double.Parse(summTransferText.Text)
                    };
                    OracleParameter num = new OracleParameter
                    {
                        ParameterName = "in_phone",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = numTransferText.Text
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.moneyTransfer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id, summ, num});
                        command.ExecuteNonQuery();
                        MessageBox.Show("Операция проведена успешно");
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

        private void moneyTransfer_Click(object sender, RoutedEventArgs e)
        {
            changeTariffSP.Visibility = Visibility.Collapsed;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Visible;
            callSP.Visibility = Visibility.Collapsed;

        }

        private void balanceReplenishment_Click(object sender, RoutedEventArgs e)
        {
            changeTariffSP.Visibility = Visibility.Collapsed;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Visible;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Collapsed;
        }

        private void replenishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();
                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
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
                        command.Parameters.AddRange(new OracleParameter[] {id,sum });
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

        private void transferButton_Click(object sender, RoutedEventArgs e)
        {
            MoneyTransfer();
        }

        private void smsSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();
                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.sendSMS"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id});
                        command.ExecuteNonQuery();
                        MessageBox.Show("Операция завершена успешно");
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




        private void callButt_Click(object sender, RoutedEventArgs e)
        {
            changeTariffSP.Visibility = Visibility.Collapsed;
            personalData.Visibility = Visibility.Collapsed;
            balanceReplenishmentSP.Visibility = Visibility.Collapsed;
            moneyTransferSP.Visibility = Visibility.Collapsed;
            callSP.Visibility = Visibility.Visible;
        }

        private void Call()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();
                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
                    };

                    OracleParameter phone = new OracleParameter
                    {
                        ParameterName = "in_phone",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = interlocNumText.Text
                    };
                    using (OracleCommand command = new OracleCommand("GAE_1.startCall"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id, phone });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Связь установлена");
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
        private void callButton_Click(object sender, RoutedEventArgs e)
        {
            Call();
        }
        private void ThrowCall()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.clientConn))
                {
                    connection.Open();
                    OracleParameter id = new OracleParameter
                    {
                        ParameterName = "in_id",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = Convert.ToString(currentClient.id)
                    };

                    using (OracleCommand command = new OracleCommand("GAE_1.endCall"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { id});
                        command.ExecuteNonQuery();
                        MessageBox.Show("Звонок завершен");
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
        private void throwCallButton_Click(object sender, RoutedEventArgs e)
        {
            ThrowCall();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "1";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "2";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "3";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "0";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "4";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "5";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "6";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "+";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "7";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "8";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            interlocNumText.Text += "9";
        }

        private void changePass_Click(object sender, RoutedEventArgs e)
        {
            EditPasswordWindow editPass = new EditPasswordWindow(currentClient);
            editPass.Show();
        }
    }
}
