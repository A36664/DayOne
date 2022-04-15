using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UserControlls
{
    public partial class MenuHelperUc : UserControl
    {
        public MenuHelperUc()
        {
            InitializeComponent();
        }
        public MenuHelperUc(string controlVisible)
        {
            InitializeComponent();

            //Check fomrmat string
            bool formatOk = true;
            foreach (var control in controlVisible)
                if (control != '0' && control != '1')
                {
                    formatOk = false;
                    break;
                }

            //If format Ok
            if (!formatOk || controlVisible.Length != 12) return;
            for (var index = 0; index < controlVisible.Length; index++)
            {
                var btnFind = this.Controls.Find("btnF" + (index + 1).ToString(), true).FirstOrDefault() as Button;
                if (btnFind != null)
                {
                    btnFind.Enabled = (controlVisible[index] == '1') ? true : false;
                    btnFind.Text = (controlVisible[index] == '1') ? btnFind.Text : string.Empty;
                }
            }
        }


        #region Interface event click or press F{0-12}

        //Control pointer F{0-12}
        public Delegate UserControlPointerF1;
        public Delegate UserControlPointerF2;
        public Delegate UserControlPointerF3;
        public Delegate UserControlPointerF4;
        public Delegate UserControlPointerF5;
        public Delegate UserControlPointerF6;
        public Delegate UserControlPointerF7;
        public Delegate UserControlPointerF8;
        public Delegate UserControlPointerF9;
        public Delegate UserControlPointerF10;
        public Delegate UserControlPointerF11;
        public Delegate UserControlPointerF12;

        /// <summary>
        /// Interface event click or press F1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF1_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF1.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF2_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF2.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF3_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF3.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF4_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF4.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF5_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF5.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF6_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF6.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF7_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF7.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF8_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF8.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF9_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF9.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF10_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF10.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF11_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF11.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF12_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            UserControlPointerF12.DynamicInvoke(arr);
        }

        #endregion

    }
}
