using BookStore.Model.Entities;
using BookStore.Service.Services;
using Microsoft.VisualStudio.Utilities.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UserControlls
{
    public partial class CustomerUC : UserControl
    {
        private readonly ICustomerService _customerService;
        public CustomerUC(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();

           
        }

        private void CustomerUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            List<Customer> customers = _customerService.GetAll().ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Mã khách hàng", typeof(int));
            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            dataTable.Columns.Add("Số điện thoại", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
           
            foreach (Customer customer in customers)
            {
                
                dataTable.Rows.Add(customer.Id, customer.Name, customer.PhoneNumber,customer.Email);
                
            }
            
            dgdCustomer.DataSource = dataTable;
        }

        private void dgdCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfContent = e.RowIndex;
            DataGridViewRow dataGridViewRow = dgdCustomer.Rows[indexOfContent];
            if (dataGridViewRow != null)
            {
                txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
                txtPhone.Text = dataGridViewRow.Cells[2].Value.ToString();
                txtEmail.Text = dataGridViewRow.Cells[3].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập tên Khách hàng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (txtEmail.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập Email ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtPhone.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if(MessageBox.Show("Thêm sách","Chú ý",MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    var customer = new Customer()
                    {
                        Email = txtEmail.Text,
                        Name = txtName.Text,
                        PhoneNumber = txtPhone.Text
                    };
                    _customerService.Add(customer);
                    _customerService.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ngoại lệ: " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           

        }
    }
}
