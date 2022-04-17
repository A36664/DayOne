using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UserControls
{
    public partial class MenuHelperUc : UserControl
    {
        #region Init
        /// <summary>
        /// Init
        /// </summary>
        public MenuHelperUc()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Init control
        /// </summary>
        /// <param name="_controlVisible">Control Visibke</param>
        /// <param name="_menuPrevious">Menu Previous</param>
        public MenuHelperUc(string _controlVisible)
        {
            InitializeComponent();

            //Check fomrmat string
            bool formatOk = true;
            for (int index = 0; index < _controlVisible.Length; index++)
                if (_controlVisible[index] != '0' && _controlVisible[index] != '1')
                {
                    formatOk = false;
                    break;
                }
            //If format Ok
            if (formatOk && _controlVisible.Length == 12)
            {
                for (int index = 0; index < _controlVisible.Length; index++)
                {
                    Button btnFind = this.Controls.Find("btnF" + (index + 1).ToString(), true).FirstOrDefault() as Button;
                    btnFind.Enabled = (_controlVisible[index] == '1') ? true : false;
                    btnFind.Text = (_controlVisible[index] == '1') ? btnFind.Text : string.Empty;
                }
            }
        }
        #endregion

        #region Interface event click or press F{0-12}

        //Control pointer F{0-12}
        public Delegate userControlPointerF1;
        public Delegate userControlPointerF2;
        public Delegate userControlPointerF3;
        public Delegate userControlPointerF4;
        public Delegate userControlPointerF5;
        public Delegate userControlPointerF6;
        public Delegate userControlPointerF7;
        public Delegate userControlPointerF8;
        public Delegate userControlPointerF9;
        public Delegate userControlPointerF10;
        public Delegate userControlPointerF11;
        public Delegate userControlPointerF12;

        /// <summary>
        /// Interface event click or press F1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF1_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF1.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF2_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF2.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF3_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF3.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF4_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF4.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF5_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF5.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF6_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF6.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF7_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF7.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF8_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF8.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF9_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF9.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF10_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF10.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF11_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF11.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF12_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF12.DynamicInvoke(arr);
        }

        #endregion
    }
}
