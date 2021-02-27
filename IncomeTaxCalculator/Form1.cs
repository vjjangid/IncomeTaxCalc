using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IncomeTaxDLL;

namespace IncomeTaxCalculator
{
    public partial class Form1 : Form
    {

        #region

        public Form1()
        {
            InitializeComponent();
            InitialCustomization(); 
        }

        #endregion

        #region Customizing form

        private void InitialCustomization()
        {
            panelHome.Visible = true;
            panelTaxProfille.Visible = false;
            panelIncomeAndExpense.Visible = false;
        }

        #endregion

        #region Menu Bar
        /// <summary>
        /// Close button functionality (exit the application)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Button for minimizing window
        /// </summary>
        /// <param name="sender">The even sender</param>
        /// <param name="e">The event parameters</param>
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        /// <summary>
        /// Side Nav Tax Profile finctionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTaxProfile_Click(object sender, EventArgs e)
        {
            panelFloatBar.Height = ButtonTaxProfile.Height;
            panelFloatBar.Top = ButtonTaxProfile.Top;

            

            //On click of tax profile button just show 
            panelTaxProfille.Visible = true;

            

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelFloatBar.Height = buttonHome.Height;
            panelFloatBar.Top = buttonHome.Top;

            //Show home panel
            panelHome.Visible = true;

            //and hide other panels
            panelTaxProfille.Visible = false;

        }

        /// <summary>
        /// Tax Profile submit button functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            panelIncomeAndExpense.Visible = true;
        }

        private void labelBasicDA_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
