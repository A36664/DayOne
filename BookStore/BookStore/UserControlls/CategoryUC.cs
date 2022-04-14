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
    public partial class CategoryUC : UserControl
    {
        private readonly ICategoryService _categoryService;
        public CategoryUC(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            InitializeComponent();
        }

        private void CategoryUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var categories = _categoryService.GetAll().ToList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(CategoryFields.CategoryId, typeof(int));
            dataTable.Columns.Add(CategoryFields.CategoryName, typeof(string));
          

            foreach (Category book in categories)
            {

                dataTable.Rows.Add(book.Id, book.Name);

            }

            dgdCategory.DataSource = dataTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }
          



            if (MessageBox.Show("Thêm danh mục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    var author = new Category()
                    {
                        Name = txtName.Text,
                       
                    };
                    _categoryService.Add(author);
                    _categoryService.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ngoại lệ: " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgdCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfContent = e.RowIndex;
            DataGridViewRow dataGridViewRow = dgdCategory.Rows[indexOfContent];
            if (dataGridViewRow != null)
            {
                txtId.Text = dataGridViewRow.Cells[0].Value.ToString();
                txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
            }
        }
    }
}
