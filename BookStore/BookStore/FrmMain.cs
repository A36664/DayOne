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
using BookStore.Service;

namespace BookStore
{
    public partial class FrmMain : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IMainHandler _mainHandler;
        public FrmMain(ICustomerService customerService,IBookService bookService,IAuthorService authorService,ICategoryService categoryService,IMainHandler mainHandler)
        {
            _customerService = customerService;
            _authorService = authorService;
            _bookService = bookService;
            _categoryService = categoryService;
            _mainHandler= mainHandler;
            InitializeComponent();
        }

        private void BookClickEventHandler(object sender, EventArgs e)
        {
            BookUc bookUC = new BookUc(_mainHandler);
            bookUC.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUC);
        }

        private void CustomerClickEventHandler(object sender, EventArgs e)
        {
            CustomerUC customerUC = new CustomerUC(_mainHandler);
            customerUC.Dock= DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(customerUC);
        }

        private void AuthorClickEventHandler(object sender, EventArgs e)
        {
            AuthorUC authorUC = new AuthorUC(_authorService);
            authorUC.Dock= DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(authorUC);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BookUc bookUC = new BookUc(_mainHandler);
            bookUC.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUC);
        }

        private void CategoryClickEnvenHandler(object sender, EventArgs e)
        {
            CategoryUC categoryUC = new CategoryUC(_categoryService);
            categoryUC.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(categoryUC);
        }
    }
}
