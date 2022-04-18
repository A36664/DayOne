using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BookStore.Model.Entities;
using BookStore.Service;
using BookStore.Shared;
using BookStore.Shared.Helpers;
using log4net;
using Microsoft.VisualStudio.Utilities.Internal;
using static BookStore.Shared.Constants;

namespace BookStore.UserControls
{
    public partial class AuthorUc :UserControl
    {
        private readonly IMainHandler _mainHandler;
        private static readonly ILog Log = LogHelper.GetLogger();
        public AuthorUc(IMainHandler mainHandler)
        {
            _mainHandler = mainHandler;
            InitializeComponent();
        }
        /// <summary>
        /// Load first run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// Load list authors for data gird view
        /// </summary>
        /// <param name="search"></param>
       private void LoadData(string search=null)
        {
            Log.Info("Begin: LoadData");
            var dataTable = new DataTable();
            dataTable.Columns.Add(AuthorFields.AuthorId, typeof(int));
            dataTable.Columns.Add(AuthorFields.AuthorName, typeof(string));
            dataTable.Columns.Add(AuthorFields.PhoneNumber, typeof(string));
            dataTable.Columns.Add(AuthorFields.Email, typeof(string));
            var authors = new List<Author>();
            if(search == null)
            {
                authors= _mainHandler.Handle(null, StatusTypes.Author, ActionTypes.GetAll) as List<Author>;

            }
            else
            {
                if (_mainHandler.Handle(search, StatusTypes.Author, ActionTypes.GetByAlias) is IEnumerable<Author> results) authors.AddRange(results);
            }

            if (authors != null)
                foreach (var author in authors)
                {
                    dataTable.Rows.Add(author.Id, author.Name, author.PhoneNumber, author.Email);
                }

            dgdAuthor.DataSource = dataTable;
            Log.Info("End: LoadData");
        }
        /// <summary>
        /// click add a author
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Log.Info("Begin: btnAdd_Click");

            if (StringExtensions.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(Commons.Messages.Author.MessageOne, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (StringExtensions.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show(Commons.Messages.Author.MessageTwo, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }
            if (StringExtensions.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show(Commons.Messages.Author.MessageThree, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }


            if (MessageBox.Show(Commons.Messages.Author.MessageFour, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning) !=
                DialogResult.OK) return;
            try
            {
                var author = new Author()
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhone.Text,
                };

                _mainHandler.Handle(author, StatusTypes.Author, ActionTypes.Add);
                _mainHandler.Handle(author, StatusTypes.Author, ActionTypes.SaveChanges);
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error("btnAdd_Click: "+ex.Message);
            }
            Log.Info("End: btnAdd_Click");
        }

        private void dgdAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var indexOfContent = e.RowIndex;
            DataGridViewRow dataGridViewRow = dgdAuthor.Rows[indexOfContent];
            txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
            txtPhone.Text = dataGridViewRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridViewRow.Cells[3].Value.ToString();
        }
        /// <summary>
        /// event click search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Log.Info("Begin: btnSearch_Click");
            if (StringExtensions.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show(Commons.Messages.MessageSearch, Commons.Messages.MessageWarring, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            LoadData(txtSearch.Text);
            Log.Info("End: btnSearch_Click");
        }
        /// <summary>
        /// event click reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text=null;
            txtPhone.Text = null;
            txtEmail.Text = null;
            LoadData();
        }
    }
}
