using BookStore.Service.Services;
using BookStore.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class FrmMain : Form
    {
        private readonly ICustomerService _customerService;
        public FrmMain(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void BookClickEventHandler(object sender, EventArgs e)
        {
            BookUC bookUC = new BookUC();
            bookUC.Dock = DockStyle.Fill;
            panelMain.Controls.Add(bookUC);
        }

        private void CustomerClickEventHandler(object sender, EventArgs e)
        {
            CustomerUC customerUC = new CustomerUC();
            customerUC.Dock= DockStyle.Fill;
            panelMain.Controls.Add(customerUC);
        }

        private void AuthorClickEventHandler(object sender, EventArgs e)
        {
            AuthorUC authorUC = new AuthorUC();
            authorUC.Dock= DockStyle.Fill;
            panelMain.Controls.Add(authorUC);
        }
    }
}
