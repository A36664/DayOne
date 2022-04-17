using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BookStore.Model.Entities;
using BookStore.Service;
using BookStore.Shared;
using BookStore.Shared.Helpers;
using static BookStore.Shared.Constants;

namespace BookStore.UserControls
{
    public partial class CustomerUc : UserControl
    {
        private readonly IMainHandler _mainHandler;
        public CustomerUc(IMainHandler mainHandler)
        {
            _mainHandler = mainHandler;
            InitializeComponent();


        }

        private void CustomerUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData(string search = null)
        {

            var dataTable = new DataTable();
            dataTable.Columns.Add(CustomerFields.CustomerId, typeof(int));
            dataTable.Columns.Add(CustomerFields.CustomerName, typeof(string));
            dataTable.Columns.Add(CustomerFields.PhoneNumber, typeof(string));
            dataTable.Columns.Add(CustomerFields.Email, typeof(string));
            var customers = new List<Customer>();
            if (search != null)
            {
                var customer = _mainHandler.Handle(search, StatusTypes.Customer, ActionTypes.GetById) as Customer;
                customers.Add(customer);
            }
            else
            {
                if (_mainHandler.Handle(null, StatusTypes.Customer, ActionTypes.GetAll) is IEnumerable<Customer> results) customers = results.ToList();
            }

            foreach (var customer in customers)
            {

                dataTable.Rows.Add(customer.Id, customer.Name.Decrypt(EncryptionKey), customer.PhoneNumber.Decrypt(EncryptionKey), customer.Email.Decrypt(EncryptionKey));

            }

            dgdCustomer.DataSource = dataTable;
        }

        private void dgdCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var indexOfContent = e.RowIndex;
            var dataGridViewRow = dgdCustomer.Rows[indexOfContent];
            txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
            txtPhone.Text = dataGridViewRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridViewRow.Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Customer.MessageOne, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (txtEmail.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Customer.MessageTwo, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtPhone.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Customer.MessageThree, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (MessageBox.Show(Commons.Messages.Customer.MessageFour, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    var customer = new Customer()
                    {
                        Email = txtEmail.Text.Encrypt(EncryptionKey),
                        Name = txtName.Text.Encrypt(EncryptionKey),
                        PhoneNumber = txtPhone.Text.Encrypt(EncryptionKey)
                    };
                    _mainHandler.Handle(customer, StatusTypes.Customer, ActionTypes.Add);
                    _mainHandler.Handle(null,StatusTypes.Customer,ActionTypes.SaveChanges);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Commons.Messages.MessageError + ex.Message, Commons.Messages.MessageError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            LoadData(txtSearch.Text);
        }
    }
}
