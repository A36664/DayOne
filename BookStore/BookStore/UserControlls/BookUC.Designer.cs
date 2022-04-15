namespace BookStore.UserControlls
{
    partial class BookUc
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOriginPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAuthor = new System.Windows.Forms.ComboBox();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTimSach = new System.Windows.Forms.TextBox();
            this.dgdBook = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdBook)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "Quản lý danh mục sách";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtOriginPrice);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtStock);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbxAuthor);
            this.panel1.Controls.Add(this.cbxCategory);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 323);
            this.panel1.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Giá gốc";
            // 
            // txtOriginPrice
            // 
            this.txtOriginPrice.Location = new System.Drawing.Point(87, 258);
            this.txtOriginPrice.Name = "txtOriginPrice";
            this.txtOriginPrice.Size = new System.Drawing.Size(159, 20);
            this.txtOriginPrice.TabIndex = 51;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 284);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(87, 214);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(159, 20);
            this.txtPrice.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Đơn giá";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(87, 174);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(159, 20);
            this.txtStock.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Số lượng";
            // 
            // cbxAuthor
            // 
            this.cbxAuthor.FormattingEnabled = true;
            this.cbxAuthor.Location = new System.Drawing.Point(87, 135);
            this.cbxAuthor.Name = "cbxAuthor";
            this.cbxAuthor.Size = new System.Drawing.Size(159, 21);
            this.cbxAuthor.TabIndex = 46;
            this.cbxAuthor.SelectedIndexChanged += new System.EventHandler(this.cbxAuthor_SelectedIndexChanged);
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(87, 92);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(159, 21);
            this.cbxCategory.TabIndex = 45;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 20);
            this.txtName.TabIndex = 42;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(87, 36);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(159, 20);
            this.txtId.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tên tác giả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Loại sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tên sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Mã sách";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtTimSach);
            this.groupBox1.Location = new System.Drawing.Point(479, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 164);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Sách";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(94, 118);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tên sách";
            // 
            // txtTimSach
            // 
            this.txtTimSach.Location = new System.Drawing.Point(24, 68);
            this.txtTimSach.Name = "txtTimSach";
            this.txtTimSach.Size = new System.Drawing.Size(159, 20);
            this.txtTimSach.TabIndex = 1;
            // 
            // dgdBook
            // 
            this.dgdBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdBook.Location = new System.Drawing.Point(6, 399);
            this.dgdBook.Name = "dgdBook";
            this.dgdBook.Size = new System.Drawing.Size(715, 239);
            this.dgdBook.TabIndex = 44;
            this.dgdBook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdBook_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 45;
            this.label9.Text = "Danh sách ";
            // 
            // BookUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgdBook);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Name = "BookUC";
            this.Size = new System.Drawing.Size(724, 643);
            this.Load += new System.EventHandler(this.BookUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxAuthor;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTimSach;
        private System.Windows.Forms.DataGridView dgdBook;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOriginPrice;
    }
}
