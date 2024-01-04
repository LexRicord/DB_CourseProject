using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DB_CourseProject.DataBase;
using DB_CourseProject.Models;
using Oracle.ManagedDataAccess.Client;

namespace DB_CourseProject.Views.Employee
{
    public partial class MasterWindow : Window
    {
        private CurrentEmployee currentEmployee1;
        public BindingList<Info> accepted = new BindingList<Info>();
        public BindingList<Info> ready = new BindingList<Info>();
        public BindingList<Info> notAccepted = new BindingList<Info>();
        Info info, selectedInfo;
        public MasterWindow(CurrentEmployee currentEmployee)
        {
            InitializeComponent();
            currentEmployee1 = currentEmployee;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            readyButt.Height = 50;
            try
            {
                NotAcceptedOrders();
                notAcceptedOrders.ItemsSource = notAccepted;
            }
            catch (Exception) { }
            try
            {
                AcceptedOrders();
                acceptedOrders.ItemsSource = accepted;
            }
            catch (Exception) { }
            try
            {
                ReadyOrders();
                readyOrders.ItemsSource = ready;
            }
            catch (Exception) { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            readyButt.Height = 50;
        }

        private void TabItem_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            readyButt.Height = 0;
        }

        private void TabItem_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            readyButt.Height = 0;
        }
        private void pickOrderButt_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddOrderInReady(int order_id)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    OracleParameter ord = new OracleParameter
                    {
                        ParameterName = "in_orderid",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.NVarchar2,
                        Value = order_id
                    };
                    connection.Open();
                    using (OracleCommand command = new OracleCommand("GAE_1.ReadyOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { ord });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Заказ успешно выполнен!");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editPassword_Click(object sender, RoutedEventArgs e)
        {
            EditPasswordWindow editPass = new EditPasswordWindow(currentEmployee1);
            editPass.Show();
        }
        private void leaveAccount_Click(object sender, RoutedEventArgs e)
        {
        }
        private void NotAcceptedOrders()
        {
            CurrentEmployee currentEmployee2 = currentEmployee1;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    string queryString1 = "select * from table(GAE_1.ORDERS_PKG.GET_NOT_ACCEPTED_ORDERS)";

                    using (OracleCommand command = new OracleCommand(queryString1, connection))
                    {
                        command.Connection = connection;
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        //dt.Load(reader);

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
                                if (order_id != null)
                                {
                                    info = new Info(order_id, clientEmail, orderPrice, servicePackOrder,
                                        regDate, compDate, orderState, orderDescription, model);
                                    notAccepted.Add(info);
                                }
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
        private void AcceptedOrders()
        {
            CurrentEmployee currentEmployee2 = currentEmployee1;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    string queryString1 = "select * from table(GAE_1.ORDERS_PKG.GET_ACCEPTED_ORDERS)";

                    using (OracleCommand command = new OracleCommand(queryString1, connection))
                    {
                        command.Connection = connection;
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        //dt.Load(reader);

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
                                int eid = reader.GetInt32(9);
                                if (currentEmployee1.id == eid)
                                {
                                    info = new Info(order_id, clientEmail, orderPrice, servicePackOrder,
                                        regDate, compDate, orderState, orderDescription, model, eid);
                                    accepted.Add(info);
                                }
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

        private void ReadyOrders()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();
                    string queryString1 = "select * from table(GAE_1.ORDERS_PKG.GET_READY_ORDERS)";

                    using (OracleCommand command = new OracleCommand(queryString1, connection))
                    {
                        command.Connection = connection;
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        //dt.Load(reader);

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
                                int eid = reader.GetInt32(9);
                                if (currentEmployee1.id == eid)
                                {
                                    info = new Info(order_id, clientEmail, orderPrice, servicePackOrder,
                                        regDate, compDate, orderState, orderDescription, model, eid);
                                    ready.Add(info);
                                }
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

        private void moreNotAccepted_Click(object sender, RoutedEventArgs e)
        {

        }

        private void moreAccepted_Click(object sender, RoutedEventArgs e)
        {

        }

        private void moreReady_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MasterWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                acceptedOrders.Height = masterWnd.ActualHeight - 70;
                readyOrders.Height = masterWnd.ActualHeight - 70;
            }
            catch (Exception) { }
        }

        private void readyOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void readyButt_Click(object sender, RoutedEventArgs e)
        {
            ReadyOrderWindow ready = new ReadyOrderWindow(selectedInfo);
            ready.Show();
        }

        private void acceptedOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            CurrentEmployee CurrentEmployee2 = currentEmployee1;
            CreateOrderWindow createContractWindow = new CreateOrderWindow(CurrentEmployee2);
            createContractWindow.Show();
            this.Close();
        }

        private void notAcceptedOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (notAcceptedOrders.SelectedItem != null)
            {
                var selectedOrder = (Info)notAcceptedOrders.SelectedItem;

                int orderId = selectedOrder.Order_id;

                MoreDetailsAboutOrder detailsWindow = new MoreDetailsAboutOrder(orderId);
                detailsWindow.Show();
            }
        }

        private void acceptedOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (acceptedOrders.SelectedItem != null)
            {
                var selectedOrder = (Info)acceptedOrders.SelectedItem;

                int orderId = selectedOrder.Order_id;

                MoreDetailsAboutOrder detailsWindow = new MoreDetailsAboutOrder(orderId);
                detailsWindow.Show();
            }
        }

        private void readyOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (readyOrders.SelectedItem != null)
            {
                var selectedOrder = (Info)readyOrders.SelectedItem;

                int orderId = selectedOrder.Order_id;

                MoreDetailsAboutOrder detailsWindow = new MoreDetailsAboutOrder(orderId);
                detailsWindow.Show();
            }
        }

        private void takeOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.adminConn))
                {
                    connection.Open();

                    using (OracleCommand addEmployeeToOrderCommand = new OracleCommand("addEmployeeToOrder", connection))
                    {
                        addEmployeeToOrderCommand.CommandType = CommandType.StoredProcedure;

                        addEmployeeToOrderCommand.Parameters.Add("p_orderId", OracleDbType.Int32).Value = selectedInfo.Order_id;
                        addEmployeeToOrderCommand.Parameters.Add("p_employeeId", OracleDbType.Int32).Value = currentEmployee1.id;

                        addEmployeeToOrderCommand.ExecuteNonQuery();
                        MessageBox.Show("Работник успешно добавлен!");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void notAcceptedOrders_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (notAcceptedOrders.SelectedItem != null && e.ChangedButton == MouseButton.Left)
            {
                selectedInfo = (Info)notAcceptedOrders.SelectedItem;

                info = new Info(selectedInfo.Order_id, selectedInfo.ClientEmail, selectedInfo.OrderPrice, selectedInfo.ServicePackOrder,
                                selectedInfo.OrderRegDate, selectedInfo.OrderEndDate, selectedInfo.OrderState, selectedInfo.OrderDescription, selectedInfo.Model);
            }
        }

        private void acceptedOrders_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (acceptedOrders.SelectedItem != null && e.ChangedButton == MouseButton.Left)
            {
                selectedInfo = (Info)acceptedOrders.SelectedItem;

                info = new Info(selectedInfo.Order_id, selectedInfo.ClientEmail, selectedInfo.OrderPrice, selectedInfo.ServicePackOrder,
                                selectedInfo.OrderRegDate, selectedInfo.OrderEndDate, selectedInfo.OrderState, selectedInfo.OrderDescription, selectedInfo.Model);
            }
        }
    }
}
