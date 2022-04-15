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
using BookStore.Service;
using static BookStore.Shared.Constants;

namespace BookStore.UserControlls
{
    public partial class BookUc : UserControl
    {

        private Category _selectCategory;


        private Author _selectAuthor;
        private  readonly  IMainHandler _mainHandler;

        public BookUc(IMainHandler mainHandler)
        {
            _mainHandler= mainHandler;
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
            var books = _mainHandler.Handle(null, StatusTypes.Book, ActionTypes.GetAllBooks) as IEnumerable<BookViewModel>;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(BookFields.BookId, typeof(int));
            dataTable.Columns.Add(BookFields.Name, typeof(string));
            dataTable.Columns.Add(BookFields.Stock, typeof(string));
            dataTable.Columns.Add(BookFields.Price, typeof(string));
            dataTable.Columns.Add(BookFields.AuthorName, typeof(string));
            dataTable.Columns.Add(BookFields.CategoryName, typeof(string));

            if (books != null)
                foreach (BookViewModel book in books.ToList())
                {
                    dataTable.Rows.Add(book.Id, book.Name, book.Stock, book.Price, book.AuthorName, book.CategoryName);
                }

            dgdBook.DataSource = dataTable;
        }

        private void LoadCategories()
        {
            var categories =  _mainHandler.Handle(null, StatusTypes.Category, ActionTypes.GetAll) as IEnumerable<Category>;
            cbxCategory.DisplayMember = "Name";
            if (categories != null) cbxCategory.DataSource = categories.ToList();
        }
        private void LoadAuthors()
        {
            var authors = _mainHandler.Handle(null, StatusTypes.Author, ActionTypes.GetAll) as IEnumerable<Author>;
            cbxAuthor.DisplayMember = "Name";
            if (authors != null) cbxAuthor.DataSource = authors.ToList();
        }

      
        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Category selectedValue = (Category)cmb.SelectedValue;

            _selectCategory = selectedValue;
        }

        private void cbxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Author selectedValue = (Author)cmb.SelectedValue;

            _selectAuthor = selectedValue;
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
                       AuthorId=_selectAuthor.Id,
                       CategoryId= _selectCategory.Id
                    };
                    _mainHandler.Handle(book, StatusTypes.Book, ActionTypes.Add);
                    _mainHandler.Handle(book, StatusTypes.Book, ActionTypes.SaveChanges);
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
            txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
            txtStock.Text = dataGridViewRow.Cells[2].Value.ToString();
            txtPrice.Text = dataGridViewRow.Cells[3].Value.ToString();
               
            cbxAuthor.Text = dataGridViewRow.Cells[4].Value.ToString();
            cbxCategory.Text = dataGridViewRow.Cells[5].Value.ToString();
        }
    }
}
