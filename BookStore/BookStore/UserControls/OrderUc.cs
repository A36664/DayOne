using BookStore.Model.ViewModels;
using BookStore.Service;
using BookStore.Shared;
using BookStore.Shared.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BookStore.UserControls
{
    public partial class OrderUc : UserControl
    {

        private readonly IMainHandler _mainHandler;
        private static readonly ILog Log = LogHelper.GetLogger();
        public OrderUc(IMainHandler mainHandler)
        {
            _mainHandler = mainHandler;
            InitializeComponent();
        }

        /// <summary>
        /// Load data order for data gird view
        /// </summary>
        private void LoadData()
        {
            Log.Info("Begin: LoadData");
            var dataTable = new DataTable();
            dataTable.Columns.Add(Constants.OrderFields.OrderId, typeof(int));
            dataTable.Columns.Add(Constants.OrderFields.BookId, typeof(string));
            dataTable.Columns.Add(Constants.OrderFields.BookName, typeof(string));
            dataTable.Columns.Add(Constants.OrderFields.Quantity, typeof(int));
            dataTable.Columns.Add(Constants.OrderFields.Price, typeof(decimal));
            dataTable.Columns.Add(Constants.OrderFields.CustomerName, typeof(string));
            dataTable.Columns.Add(Constants.OrderFields.CustomerPhoneNumber, typeof(string));
            var orders = new List<OrderViewModel>();

            if (_mainHandler.Handle(null, Constants.StatusTypes.Order, Constants.ActionTypes.GetAll) is IEnumerable<OrderViewModel> results) orders.AddRange(results);

            foreach (var order in orders)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    dataTable.Rows.Add(order.OrderId, orderDetail.BookId, orderDetail.Book.Name, orderDetail.Quantity, orderDetail.Price, order.CustomerName, order.CustomerPhoneNumber);
                }


            }

            dgdOrder.DataSource = dataTable;
            Log.Info("End: LoadData");
        }
        /// <summary>
        /// Load for first run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderUc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
