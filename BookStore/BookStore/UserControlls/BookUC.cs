using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
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
using static BookStore.Shared.Constants;

namespace BookStore.UserControlls
{
    public partial class BookUC : UserControl
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;

        private Category _selectCategor;

        public Category SelectCategor { get => _selectCategor; set => _selectCategor = value; }
        public Author SelectAuthor { get => _selectAuthor; set => _selectAuthor = value; }

        private Author _selectAuthor;

        public BookUC(IBookService bookService,ICategoryService categoryService,IAuthorService authorService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService; 
            InitializeComponent();
        }

        private void BookUC_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCategories();
            LoadAuthors();
        }

        private void LoadData()
        {
            List<BookViewModel> books = _bookService.GetAllBooks();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(BookFields.BookId, typeof(int));
            dataTable.Columns.Add(BookFields.Name, typeof(string));
            dataTable.Columns.Add(BookFields.Stock, typeof(string));
            dataTable.Columns.Add(BookFields.Price, typeof(string));
            dataTable.Columns.Add(BookFields.AuthorName, typeof(string));
            dataTable.Columns.Add(BookFields.CategoryName, typeof(string));

            foreach (BookViewModel book in books)
            {

                dataTable.Rows.Add(book.Id, book.Name, book.Stock, book.Price,book.AuthorName,book.CategoryName);

            }

            dgdBook.DataSource = dataTable;
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetAll().ToList();
            cbxCategory.DisplayMember = "Name";
            cbxCategory.DataSource = categories;
        }
        private void LoadAuthors()
        {
            var authors = _authorService.GetAll().ToList();
            cbxAuthor.DisplayMember = "Name";
            cbxAuthor.DataSource = authors;
        }

      
        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Category selectedValue = (Category)cmb.SelectedValue;

            SelectCategor = selectedValue;
        }

        private void cbxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Author selectedValue = (Author)cmb.SelectedValue;

            SelectAuthor = selectedValue;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập tên sách", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (txtPrice.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập giá sách ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (txtStock.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập số lượng sách", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (txtOriginPrice.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập giá gốc", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }



            if (MessageBox.Show("Thêm sách", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    var book = new Book()
                    {
                       Name=txtName.Text,
                       Price=Convert.ToDecimal(txtPrice.Text),
                       Stock=Convert.ToInt32(txtStock.Text),
                       OriginalPrice=Convert.ToDecimal(txtOriginPrice.Text),
                       AuthorId=SelectAuthor.Id,
                       CategoryId=SelectCategor.Id
                    };
                    _bookService.Add(book);

                    

                    

                    _bookService.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ngoại lệ: " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgdBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfContent = e.RowIndex;
            DataGridViewRow dataGridViewRow = dgdBook.Rows[indexOfContent];
            if (dataGridViewRow != null)
            {
                txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
                txtStock.Text = dataGridViewRow.Cells[2].Value.ToString();
                txtPrice.Text = dataGridViewRow.Cells[3].Value.ToString();
               
                cbxAuthor.Text = dataGridViewRow.Cells[4].Value.ToString();
                cbxCategory.Text = dataGridViewRow.Cells[5].Value.ToString();

            }
        }
    }
}
