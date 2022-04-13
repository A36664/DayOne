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
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        public FrmMain(ICustomerService customerService,IBookService bookService,IAuthorService authorService,ICategoryService categoryService)
        {
            _customerService = customerService;
            _authorService = authorService;
            _bookService = bookService;
            _categoryService = categoryService;
            InitializeComponent();
        }

        private void BookClickEventHandler(object sender, EventArgs e)
        {
            BookUC bookUC = new BookUC(_bookService,_categoryService,_authorService);
            bookUC.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUC);
        }

        private void CustomerClickEventHandler(object sender, EventArgs e)
        {
            CustomerUC customerUC = new CustomerUC(_customerService);
            customerUC.Dock= DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(customerUC);
        }

        private void AuthorClickEventHandler(object sender, EventArgs e)
        {
            AuthorUC authorUC = new AuthorUC();
            authorUC.Dock= DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(authorUC);
        }
    }
}
