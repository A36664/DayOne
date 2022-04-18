using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using BookStore.Service;
using BookStore.Shared;
using Microsoft.VisualStudio.Utilities.Internal;
using static BookStore.Shared.Constants;

namespace BookStore.UserControls
{
    public partial class BookUc : UserControl
    {

        private Category _selectCategory;


        private Author _selectAuthor;
        private  readonly  IMainHandler _mainHandler;
        /// <summary>
        /// initial constructor and DI for MainHandler 
        /// </summary>
        /// <param name="mainHandler"></param>
        public BookUc(IMainHandler mainHandler)
        {
            _mainHandler= mainHandler;
            InitializeComponent();
        }
        /// <summary>
        /// Load first run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookUC_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCategories();
            LoadAuthors();
        }
        /// <summary>
        /// Load data books for data grid view
        /// </summary>
        private void LoadData()
        {
            var books = _mainHandler.Handle(null, StatusTypes.Book, ActionTypes.GetAllBooks) as IEnumerable<BookViewModel>;

            var dataTable = new DataTable();
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
        /// <summary>
        /// Load all categories
        /// </summary>
        private void LoadCategories()
        {
            var categories =  _mainHandler.Handle(null, StatusTypes.Category, ActionTypes.GetAll) as IEnumerable<Category>;
            cbxCategory.DisplayMember = "Name";
            if (categories != null) cbxCategory.DataSource = categories.ToList();
        }
        /// <summary>
        /// Load all authors
        /// </summary>
        private void LoadAuthors()
        {
            var authors = _mainHandler.Handle(null, StatusTypes.Author, ActionTypes.GetAll) as IEnumerable<Author>;
            cbxAuthor.DisplayMember = "Name";
            if (authors != null) cbxAuthor.DataSource = authors.ToList();
        }

      /// <summary>
      /// event combobox category select change
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;
            var selectedValue = (Category)cmb.SelectedValue;

            _selectCategory = selectedValue;
        }
        /// <summary>
        /// event combobox author when select change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;
            var selectedValue = (Author)cmb.SelectedValue;

            _selectAuthor = selectedValue;
        }
        /// <summary>
        /// event click add a book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Book.MessageOne, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (txtPrice.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Book.MessageTwo, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (txtStock.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Book.MessageThree, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (txtOriginPrice.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Commons.Messages.Book.MessageFour, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }


            if (MessageBox.Show(Commons.Messages.Book.MessageFive, Commons.Messages.MessageWarring,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning) != DialogResult.OK) return;
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
                MessageBox.Show(Commons.Messages.MessageError + ex.Message, Commons.Messages.MessageError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// event click on cell of data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgdBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var indexOfContent = e.RowIndex;
            var dataGridViewRow = dgdBook.Rows[indexOfContent];
            txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
            txtStock.Text = dataGridViewRow.Cells[2].Value.ToString();
            txtPrice.Text = dataGridViewRow.Cells[3].Value.ToString();
               
            cbxAuthor.Text = dataGridViewRow.Cells[4].Value.ToString();
            cbxCategory.Text = dataGridViewRow.Cells[5].Value.ToString();
        }
    }
}
