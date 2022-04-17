using BookStore.Service.Services;
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
using BookStore.UserControls;

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
            var bookUc = new BookUc(_mainHandler);
            bookUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUc);
        }

        private void CustomerClickEventHandler(object sender, EventArgs e)
        {
            var customerUc = new CustomerUc(_mainHandler);
            customerUc.Dock= DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(customerUc);
        }

        private void AuthorClickEventHandler(object sender, EventArgs e)
        {
            var authorUc = new AuthorUc(_mainHandler);
            authorUc.Dock= DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(authorUc);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var bookUc = new BookUc(_mainHandler);
            bookUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUc);
        }

       

        private void CategoryClickEnventHandler(object sender, EventArgs e)
        {

            CategoryUc categoryUc = new CategoryUc(_categoryService);
            categoryUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(categoryUc);
        }
    }
}
