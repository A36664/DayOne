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
using static BookStore.Shared.Constants;

namespace BookStore.UserControlls
{
    public partial class AuthorUC : UserControl
    {
        private readonly IAuthorService _authorService;
        public AuthorUC(IAuthorService authorService)
        {
            _authorService = authorService;
            InitializeComponent();
        }

        private void AuthorUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

       private void LoadData(string search=null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(AuthorFields.AuthorId, typeof(int));
            dataTable.Columns.Add(AuthorFields.AuthorName, typeof(string));
            dataTable.Columns.Add(AuthorFields.PhoneNumber, typeof(string));
            dataTable.Columns.Add(AuthorFields.Email, typeof(string));
            List<Author> authors = new List<Author>();
            if(search == null)
            {
                  authors = _authorService.GetAll().ToList();

            }
            else
            {
                authors.Add(_authorService.GetByAlias(search));
            }

            foreach (Author author in authors)
            {

                dataTable.Rows.Add(author.Id, author.Name, author.PhoneNumber, author.Email);

            }

            dgdAuthor.DataSource = dataTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập tên tác giả", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (txtPhone.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập số điện thoại ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }
            if (txtEmail.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập email", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }



            if (MessageBox.Show("Thêm tác giả", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    var author = new Author()
                    {
                        Name = txtName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                    };
                    _authorService.Add(author);
                    _authorService.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ngoại lệ: " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgdAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfContent = e.RowIndex;
            DataGridViewRow dataGridViewRow = dgdAuthor.Rows[indexOfContent];
            if (dataGridViewRow != null)
            {
                txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
                txtPhone.Text = dataGridViewRow.Cells[2].Value.ToString();
                txtEmail.Text = dataGridViewRow.Cells[3].Value.ToString();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text=null;
            txtPhone.Text = null;
            txtEmail.Text = null;
            LoadData();
        }
    }
}
