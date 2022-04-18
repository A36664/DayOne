using BookStore.Service;
using BookStore.UserControls;
using System;
using System.Windows.Forms;

namespace BookStore
{
    public partial class FrmMain : Form
    {

        private readonly IMainHandler _mainHandler;
        public FrmMain(IMainHandler mainHandler)
        {
            _mainHandler = mainHandler;
            InitializeComponent();

            #region Init override event click
            FormControlPointerF1 += new ControlCall(btnF1_Click);
            FormControlPointerF2 += new ControlCall(btnF2_Click);
            FormControlPointerF3 += new ControlCall(btnF3_Click);
            FormControlPointerF4 += new ControlCall(btnF4_Click);
            FormControlPointerF5 += new ControlCall(btnF5_Click);
            FormControlPointerF6 += new ControlCall(btnF6_Click);
            FormControlPointerF7 += new ControlCall(btnF7_Click);
            FormControlPointerF8 += new ControlCall(btnF8_Click);
            FormControlPointerF9 += new ControlCall(btnF9_Click);
            FormControlPointerF10 += new ControlCall(btnF10_Click);
            FormControlPointerF11 += new ControlCall(btnF11_Click);
            FormControlPointerF12 += new ControlCall(btnF12_Click);
            menuHelperUc1.UserControlPointerF1 = FormControlPointerF1;
            menuHelperUc1.UserControlPointerF2 = FormControlPointerF2;
            menuHelperUc1.UserControlPointerF3 = FormControlPointerF3;
            menuHelperUc1.UserControlPointerF4 = FormControlPointerF4;
            menuHelperUc1.UserControlPointerF5 = FormControlPointerF5;
            menuHelperUc1.UserControlPointerF6 = FormControlPointerF6;
            menuHelperUc1.UserControlPointerF7 = FormControlPointerF7;
            menuHelperUc1.UserControlPointerF8 = FormControlPointerF8;
            menuHelperUc1.UserControlPointerF9 = FormControlPointerF9;
            menuHelperUc1.UserControlPointerF10 = FormControlPointerF10;
            menuHelperUc1.UserControlPointerF11 = FormControlPointerF11;
            menuHelperUc1.UserControlPointerF12 = FormControlPointerF12;
            #endregion
        }

        private void BookClickEventHandler(object sender, EventArgs e)
        {

        }

        private void CustomerClickEventHandler(object sender, EventArgs e)
        {

        }

        private void AuthorClickEventHandler(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var bookUc = new BookUc(_mainHandler);
            bookUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUc);

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(menuHelper1_KeyDown);
        }



        private void CategoryClickEnventHandler(object sender, EventArgs e)
        {


        }

        #region Declare pointer control
        public delegate void ControlCall(object sender, EventArgs e);
        private event ControlCall FormControlPointerF1;
        private event ControlCall FormControlPointerF2;
        private event ControlCall FormControlPointerF3;
        private event ControlCall FormControlPointerF4;
        private event ControlCall FormControlPointerF5;
        private event ControlCall FormControlPointerF6;
        private event ControlCall FormControlPointerF7;
        private event ControlCall FormControlPointerF8;
        private event ControlCall FormControlPointerF9;
        private event ControlCall FormControlPointerF10;
        private event ControlCall FormControlPointerF11;
        private event ControlCall FormControlPointerF12;

        #endregion

        #region Declare press key F{0-12}
        ///// <summary>
        ///// Add event press key on load form
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void mainForm_Load(object sender, EventArgs e)
        //{
        //    this.KeyPreview = true;
        //    this.KeyDown += new KeyEventHandler(menuHelper1_KeyDown);

        //}

        /// <summary>
        /// Action when press F{0-12}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelper1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F1": F1CLickOrPress(); break;
                case "F2": F2CLickOrPress(); break;
                case "F3": F3CLickOrPress(); break;
                case "F4": F4CLickOrPress(); break;
                case "F5": F5CLickOrPress(); break;
                case "F6": F6CLickOrPress(); break;
                case "F7": F7CLickOrPress(); break;
                case "F8": F8CLickOrPress(); break;
                case "F9": F9CLickOrPress(); break;
                case "F10": F10CLickOrPress(); break;
                case "F11": F11CLickOrPress(); break;
                case "F12": F12CLickOrPress(); break;
            }
        }

        #endregion
        #region Override event click from User Control
        /// <summary>
        /// Override F1 cLick
        /// </summary>
        /// <param name="sender"></param>

        private void btnF1_Click(object sender, EventArgs e)
        {
            F1CLickOrPress();
        }
        /// <summary>
        /// Override F2 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF2_Click(object sender, EventArgs e)
        {
            F2CLickOrPress();
        }
        /// <summary>
        /// Override F3 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF3_Click(object sender, EventArgs e)
        {
            F3CLickOrPress();
        }
        /// <summary>
        /// Override F4 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF4_Click(object sender, EventArgs e)
        {
            F4CLickOrPress();
        }
        /// <summary>
        /// Override F5 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF5_Click(object sender, EventArgs e)
        {
            F5CLickOrPress();
        }
        /// <summary>
        /// Override F6 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF6_Click(object sender, EventArgs e)
        {
            F6CLickOrPress();
        }
        /// <summary>
        /// Override F7 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF7_Click(object sender, EventArgs e)
        {
            F7CLickOrPress();
        }
        /// <summary>
        /// Override F8 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF8_Click(object sender, EventArgs e)
        {
            F8CLickOrPress();
        }
        /// <summary>
        /// Override F9 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF9_Click(object sender, EventArgs e)
        {
            F9CLickOrPress();
        }
        /// <summary>
        /// Override F10 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF10_Click(object sender, EventArgs e)
        {
            F10CLickOrPress();
        }

        /// <summary>
        /// Override F11 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF11_Click(object sender, EventArgs e)
        {
            F11CLickOrPress();
        }

        /// <summary>
        /// Override F12 cLick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF12_Click(object sender, EventArgs e)
        {
            F12CLickOrPress();
        }
        #endregion

        #region Action when click or press F{0-12}
        /// <summary>
        /// Click or press F1 open book
        /// </summary>
        public void F1CLickOrPress()
        {
            var bookUc = new BookUc(_mainHandler);
            bookUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(bookUc);
        }
        /// <summary>
        /// Click or press F2 open CustomerUc
        /// </summary>
        public void F2CLickOrPress()
        {
            var customerUc = new CustomerUc(_mainHandler);
            customerUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(customerUc);
        }
        /// <summary>
        /// Click or press F3 open AuthorUc
        /// </summary>
        public void F3CLickOrPress()
        {
            var authorUc = new AuthorUc(_mainHandler);
            authorUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(authorUc);
        }
        /// <summary>
        /// Click or press F4 open order OrderUc
        /// </summary>
        public void F4CLickOrPress()
        {
            var orderUc = new OrderUc(_mainHandler);
            orderUc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(orderUc);
        }
        /// <summary>
        /// Click or press F5
        /// </summary>
        public void F5CLickOrPress()
        {
            MessageBox.Show("Control F5");
        }
        /// <summary>
        /// Click or press F6
        /// </summary>
        public void F6CLickOrPress()
        {
            MessageBox.Show("Control F6");
        }
        /// <summary>
        /// Click or press F7
        /// </summary>
        public void F7CLickOrPress()
        {
            MessageBox.Show("Control F7");
        }
        /// <summary>
        /// Click or press F8
        /// </summary>
        public void F8CLickOrPress()
        {
            MessageBox.Show("Control F8");
        }
        /// <summary>
        /// Click or press F9
        /// </summary>
        public void F9CLickOrPress()
        {
            MessageBox.Show("Control F9");
        }
        /// <summary>
        /// Click or press F10
        /// </summary>
        public void F10CLickOrPress()
        {
            MessageBox.Show("Control F10");
        }

        /// <summary>
        /// Click or press F11
        /// </summary>
        public void F11CLickOrPress()
        {
            MessageBox.Show("Control F11");
        }

        /// <summary>
        /// Click or press F12
        /// </summary>
        public void F12CLickOrPress()
        {
            MessageBox.Show("Control F12");
        }

        #endregion
    }
}
