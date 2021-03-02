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

        private double TotalExemptions = 0;
        private double TotalTaxUnderOldRegime = 0;
        private int UserAge;
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
            panelHome.BackgroundImage = Image.FromFile("E:\\IncomeTaxCalculator\\Images\\Croped2975891.jpg");
            panelHome.Visible = true;
            panelTaxProfille.Visible = false;
            panelIncomeAndExpense.Visible = false;
            textBoxStandardDeduction.Text = "50000";
            textBoxStandardDeduction.Enabled = false;
            textBoxOutputOldTax.Enabled = false;
            textBoxOutputNewTaxRegime.Enabled = false;
            textBoxOutputOldTax.Text = "Rs ";
            textBoxOutputNewTaxRegime.Text = "Rs ";
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

            bool conditionsMet = true;

            if(!radioButtonSalariedNo.Checked && !radioButtonSalariedYes.Checked)
            {
                conditionsMet = false;
                MessageBox.Show("Are you salaried or not ?", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if( !radioButtonMetroYes.Checked && !radioButtonMetroNo.Checked )
            {
                conditionsMet = false;
                MessageBox.Show("Do you resides in metro city ?", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if( !radioButtonMale.Checked && !radioButtonFemale.Checked && !radioButtonOther.Checked)
            {
                conditionsMet = false;
                MessageBox.Show("Gender ?", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //conditionsMet = true;
            }

            
            if(conditionsMet)
            {
                var today = DateTime.Today;

                UserAge = today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > today.AddYears(UserAge))
                    UserAge--;

                Console.WriteLine("The user age is :: " +UserAge);
                panelTaxProfille.Visible = false;
                panelIncomeAndExpense.Visible = true;
            }
           
        }

        private void labelBasicDA_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            
            //Taking care of inputs from income And Salary

            IncomeTaxDLL.IncomeAndSalary userIncome = new IncomeAndSalary();

            userIncome.BasicDAAmount = CheckInputValidity(textBoxBasicDA.Text);
            userIncome.HRA_Amount = CheckInputValidity(textBoxHRA.Text);
            userIncome.BonusCommissionAmount = CheckInputValidity(textBoxBonusComm.Text);
            userIncome.OtherAllowancesAmount = CheckInputValidity(textBoxOtherAllowance.Text);
            userIncome.BusinessAmount = CheckInputValidity(textBoxBusiness.Text);
            userIncome.ProfessionAmount = CheckInputValidity(textBoxProfession.Text);
            userIncome.ShortTermCGNormalRates = CheckInputValidity(textBoxSTGNM.Text);
            userIncome.ShortTermCG15 = CheckInputValidity(textBoxSTCG15.Text);
            userIncome.LongTermCG10 = CheckInputValidity(textBoxLTCG10.Text);
            userIncome.LongTermCG20 = CheckInputValidity(textBoxLTCG20.Text);
            userIncome.InterestFixedDeposits = CheckInputValidity(textBoxFD.Text);
            userIncome.InterestSavingsBankAccounts = CheckInputValidity(textBoxSavingsAcc.Text);
            userIncome.OtherSources = CheckInputValidity(textBoxOtherSources.Text);

            double TotalIncome = userIncome.BasicDAAmount + userIncome.HRA_Amount + userIncome.BonusCommissionAmount + userIncome.OtherAllowancesAmount +
                                   userIncome.BusinessAmount + userIncome.ProfessionAmount + userIncome.ShortTermCGNormalRates + userIncome.ShortTermCG15 +
                                   userIncome.LongTermCG10 + userIncome.LongTermCG20 + userIncome.InterestFixedDeposits + userIncome.InterestSavingsBankAccounts
                                   + userIncome.OtherSources;

            IncomeTaxDLL.ExcemtionsAndDeductions userExemptions = new ExcemtionsAndDeductions();
            userExemptions.StandardDeductionAmount = CheckInputValidity(textBoxStandardDeduction.Text);
            //userExmeptions.BusinessAmount = CheckInputValidity(textBoxBus)
            //userExemptions.Deduction80DDAmount = CheckInputValidity(textBox80DD.Text);
            userExemptions.Deduction80EEBAmount = CheckInputValidity(textBox80EEB.Text);
            //userExmeptions.DeductionTTA_Amount = CheckInputValidity(t)
            userExemptions.FoodCouponsAmount = CheckInputValidity(textBoxFoodCoupons.Text);
            userExemptions.I80C_EPFAmount = CheckInputValidity(textBoxEPF.Text);
            userExemptions.I80C_EquityLinkedAmount = CheckInputValidity(textBoxEquity.Text);
            userExemptions.I80C_HousingLoanPrincipalAmount = CheckInputValidity(textBoxHousingLoanPrincipal.Text);
            userExemptions.I80C_LifeInsuranceAmount = CheckInputValidity(textBoxLifeInsurance.Text);
            userExemptions.I80C_NationalPensionSchemeAmount = CheckInputValidity(textBoxNPS.Text);
            userExemptions.I80C_ProvidentFundAmount = CheckInputValidity(textBoxPPF.Text);
            userExemptions.I80C_TuitionFeesAmount = CheckInputValidity(textBoxTuition.Text);
            userExemptions.IDeduction80EEA_Amount = CheckInputValidity(textBox80EEEA.Text);
            userExemptions.IDeduction80U_Amount = CheckInputValidity(textBox80U.Text);
            userExemptions.Deduction80DDAmount = CheckInputValidity(textBox80DD.Text);
            userExemptions.IDeductionSection_24BAmount = CheckInputValidity(textBoxSection24B.Text);
            userExemptions.IDeduction80GGAAmount = CheckInputValidity(textBox80GG.Text);
            

            Console.WriteLine("BEfore total Exemptions :: " +TotalExemptions);

            //Setting the maximum exemption you can have in 80C which is 150000 Rs
            double total80C = userExemptions.I80C_ProvidentFundAmount + userExemptions.I80C_EquityLinkedAmount + userExemptions.I80C_EPFAmount + userExemptions.I80C_HousingLoanPrincipalAmount + userExemptions.I80C_LifeInsuranceAmount + userExemptions.I80C_NationalPensionSchemeAmount + userExemptions.I80C_TuitionFeesAmount + userExemptions.I80C_OthersAmount; 
            if(total80C > 150000)
            {
                total80C = 150000;
            }

            //Setting the maximum Professional tax which is Rs 2500
            double totalProfessionalTax = 0;
            if (userExemptions.ProfessionAmount > 2500)
                totalProfessionalTax = 25000;
            else
                totalProfessionalTax = userExemptions.ProfessionAmount;

            //Setting the limit of exemption that you can get under 80DD
            if (userExemptions.Deduction80DDAmount > 125000)
                userExemptions.Deduction80DDAmount = 125000;

            //Setting the limit under 80EEB 
            if (userExemptions.Deduction80EEBAmount > 150000)
                userExemptions.Deduction80EEBAmount = 150000;

            //Setting the limit under Food Coupons you can get
            if (userExemptions.FoodCouponsAmount > 26400)
                userExemptions.FoodCouponsAmount = 26400;

            //Setting the limit under 80EEA
            if (userExemptions.IDeduction80EEA_Amount > 150000)
                userExemptions.IDeduction80EEA_Amount = 150000;

            //Setting the limit under 80U
            if (userExemptions.IDeduction80U_Amount > 125000)
                userExemptions.IDeduction80U_Amount = 125000;

            //Setting the limit under 80DD
            if (userExemptions.Deduction80DDAmount > 125000)
                userExemptions.Deduction80DDAmount = 125000;

            //Setting the limit under Section 24B
            if (userExemptions.IDeductionSection_24BAmount > 200000)
                userExemptions.IDeductionSection_24BAmount = 200000;

            TotalExemptions = userExemptions.IDeductionSection_24BAmount + userExemptions.Deduction80DDAmount + userExemptions.IDeduction80U_Amount +
                                userExemptions.IDeduction80EEA_Amount + userExemptions.FoodCouponsAmount + userExemptions.Deduction80EEBAmount +
                                userExemptions.Deduction80DDAmount + total80C + totalProfessionalTax + 50000;


            #region Calculate OLD Tax 

            Console.WriteLine("Total income is :: " + TotalIncome);
            Console.WriteLine("Total exemptions is :: " +TotalExemptions);
            Console.WriteLine("Total Hra Exemption is " + CalculateHRA(userIncome.HRA_Amount, userIncome.BasicDAAmount, userExemptions.IDeduction80GGAAmount, radioButtonMetroYes.Checked));
            Console.WriteLine("Total Rent paid is :: " +userExemptions.IDeduction80GGAAmount);
            double totalGrossSalaryOldRegime = TotalIncome - TotalExemptions - CalculateHRA(userIncome.HRA_Amount, userIncome.BasicDAAmount, userExemptions.IDeduction80GGAAmount, radioButtonMetroYes.Checked);
            Console.WriteLine("Total Gross Salary :: " + totalGrossSalaryOldRegime);

            double totalGrossSalaryNewRegime = TotalIncome;

            if(UserAge < 60)
            {

                TotalTaxUnderOldRegime = CalcualteGeneralSlabTaxOldRegime(totalGrossSalaryOldRegime);
                TotalTaxUnderOldRegime += Cess4(TotalTaxUnderOldRegime);
                Console.WriteLine("Total tax in the end is now :: " +TotalTaxUnderOldRegime);
                textBoxOutputOldTax.AppendText(TotalTaxUnderOldRegime.ToString());

            }
            else if(UserAge >=60 && UserAge<80)
            {
                TotalTaxUnderOldRegime = CalcualteSeniorSlabTaxOldRegime(totalGrossSalaryOldRegime);
                TotalTaxUnderOldRegime += Cess4(TotalTaxUnderOldRegime);
                Console.WriteLine("Total tax now :: " + TotalTaxUnderOldRegime);
                textBoxOutputOldTax.AppendText(TotalTaxUnderOldRegime.ToString());
            }
            else
            {
                TotalTaxUnderOldRegime = CalcualteSuperSeniorSlabTaxOldRegime(totalGrossSalaryOldRegime);
                TotalTaxUnderOldRegime += Cess4(TotalTaxUnderOldRegime);
                Console.WriteLine("Total tax now :: " + TotalTaxUnderOldRegime);
                textBoxOutputOldTax.AppendText(TotalTaxUnderOldRegime.ToString());
            }

            #endregion

            #region Calculate New Tax

            double TotalNewRegimeTax = NewRegimeAllCategoryTax(totalGrossSalaryNewRegime);
            TotalNewRegimeTax += Cess4(TotalNewRegimeTax);
            textBoxOutputNewTaxRegime.AppendText(TotalNewRegimeTax.ToString());

            #endregion
            Console.WriteLine("Exemption under Section 24B :: " + userExemptions.IDeductionSection_24BAmount);
            Console.WriteLine("Exemption under 80DD :: " + userExemptions.Deduction80DDAmount);
            Console.WriteLine("Exemption under 80U :: " + userExemptions.IDeduction80U_Amount);
            Console.WriteLine("Exemption under 80EEA :: " + userExemptions.IDeduction80EEA_Amount);
            Console.WriteLine("Exemption under Food coupons :: " + userExemptions.FoodCouponsAmount);
            Console.WriteLine("Exemption under 80EEB :: " + userExemptions.Deduction80EEBAmount);
            Console.WriteLine("Exemption under 80DDD :: " + userExemptions.Deduction80DDAmount);
            Console.WriteLine("Exemption under 80C :: " + total80C);
            Console.WriteLine("Exemption under 80C :: " + totalProfessionalTax);

            

            buttonGo.Enabled = false;
        }


        /// <summary>
        /// Calculating House rental allowance deduction
        /// </summary>
        /// <param name="HRAAmount">Actual Amount received from the company</param>
        /// <param name="BasicDA">Actual Basic dearness allowance received</param>
        /// <param name="rentPaid">Actual Rent Paid</param>
        /// <param name="metroStatus">metro status of the user</param>
        /// <returns></returns>
        private double CalculateHRA(double HRAAmount, double BasicDA, double rentPaid, bool metroStatus)
        {
            //Least of the following conditions amount will be taken into consideration
            //1. Actual HRA received
            //2. Actual Rent Paid - 10% of BAsic DA
            //3. 50 percent of basic for metro user / 4o percent for non metro user

            double secondCond = rentPaid - (BasicDA * 0.1);

            double thirdCond;

            if(metroStatus)
            {
                thirdCond = 0.5 * BasicDA;
            }
            else
            {
                thirdCond = 0.4 * BasicDA;
            }

            return ( Math.Min(HRAAmount, Math.Min(secondCond, thirdCond)) );
        }

        /// <summary>
        /// 4 percent cess for health benefits
        /// </summary>
        /// <param name="totalTaxUnderOldRegime"></param>
        /// <returns></returns>
        private double Cess4(double totalTaxUnderOldRegime)
        {
            return (totalTaxUnderOldRegime * 0.04);
        }

        /// <summary>
        /// Caluclating tax for general age category which <=60
        /// </summary>
        /// <param name="totalGrossSalary">Total gross income</param>
        /// <returns></returns>
        private double CalcualteGeneralSlabTaxOldRegime(double totalGrossSalary)
        {
            double totalTax = 0;
            //No tax upto 250000
            if (totalGrossSalary <= 250000)
                return totalTax;

            //No tax upto 250000
            totalGrossSalary -= 250000;
            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //Five percent tax for next 250000;
            if(totalGrossSalary - 250000 <= 0)
            {
                Console.WriteLine("5 percent if");
                totalTax += totalGrossSalary *(0.05);
                return totalTax;
            }
            else
            {
                Console.WriteLine("5 percent else");
                totalTax =  (250000 * 0.05);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //20 percent tax for next  5 lakhs
            if (totalGrossSalary - 500000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.2);
                Console.WriteLine("Total Tax :: " +totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 500000 * (0.2);
                totalGrossSalary = totalGrossSalary - 500000;
            }

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //30 percent tax for remaining amount
            totalTax += totalGrossSalary * (0.3);

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);
            return totalTax;

        }

        /// <summary>
        /// Calculating tax for senior citizen category
        /// </summary>
        /// <param name="totalGrossSalary">the total gross income</param>
        /// <returns></returns>
        private double CalcualteSeniorSlabTaxOldRegime(double totalGrossSalary)
        {
            double totalTax = 0;
            //No tax upto 300000
            if (totalGrossSalary <= 300000)
                return totalTax;

            //No tax upto 300000
            totalGrossSalary -= 300000;
            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //Five percent tax for next 200000;
            if (totalGrossSalary - 200000 <= 0)
            {
                Console.WriteLine("5 percent if");
                totalTax += totalGrossSalary * (0.05);
                return totalTax;
            }
            else
            {
                Console.WriteLine("5 percent else");
                totalTax = (200000 * 0.05);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //20 percent tax for next  5 lakhs
            if (totalGrossSalary - 500000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.2);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 500000 * (0.2);
                totalGrossSalary = totalGrossSalary - 500000;
            }

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //30 percent tax for remaining amount
            totalTax += totalGrossSalary * (0.3);

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);
            return totalTax;

        }

        /// <summary>
        /// Calculate tax for super senior citizen
        /// </summary>
        /// <param name="totalGrossSalary"></param>
        /// <returns></returns>
        private double CalcualteSuperSeniorSlabTaxOldRegime(double totalGrossSalary)
        {
            double totalTax = 0;
            //No tax upto 500000
            if (totalGrossSalary <= 500000)
                return totalTax;

            //No tax upto 500000
            totalGrossSalary -= 500000;
            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);


            //20 percent tax for next  5 lakhs
            if (totalGrossSalary - 500000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.2);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 500000 * (0.2);
                totalGrossSalary = totalGrossSalary - 500000;
            }

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //30 percent tax for remaining amount
            totalTax += totalGrossSalary * (0.3);

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);
            return totalTax;

        }

        private double NewRegimeAllCategoryTax(double totalGrossSalary)
        {
            double totalTax = 0;
            //No tax upto 500000
            if (totalGrossSalary <= 250000)
                return totalTax;

            //No tax upto 500000
            totalGrossSalary -= 250000;
            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            if (totalGrossSalary - 500000 <= 0)
            {
                Console.WriteLine("5 percent if");
                totalTax += totalGrossSalary * (0.05);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("5 percent else");
                totalTax += 500000 * (0.05);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            //10 percent tax for next  2.5 lakhs
            if (totalGrossSalary - 250000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.1);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 250000 * (0.2);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            //15 percent for next 2.5 lakh
            if (totalGrossSalary - 250000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.15);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 250000 * (0.15);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            //20 percent for next 2.5 lakh
            if (totalGrossSalary - 250000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.20);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 250000 * (0.20);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            //25 percent for next 2.5 lakh
            if (totalGrossSalary - 250000 <= 0)
            {
                Console.WriteLine("20 percent if");
                totalTax += totalGrossSalary * (0.25);
                Console.WriteLine("Total Tax :: " + totalTax);
                return totalTax;
            }
            else
            {
                Console.WriteLine("20 percent else");
                totalTax += 250000 * (0.25);
                totalGrossSalary = totalGrossSalary - 250000;
            }

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);

            //30 percent tax for remaining amount
            totalTax += totalGrossSalary * (0.3);

            Console.WriteLine("total Gross Salary is :: " + totalGrossSalary);
            Console.WriteLine("Total tax till now is :: " + totalTax);
            return totalTax;
        }

        private double CheckInputValidity(string input)
        {
            double number;
            if( String.IsNullOrEmpty(input) )
            {
                return 0;
            }
            else
            {
                if( Double.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    MessageBox.Show("Amount can't be in string format", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    throw new ArgumentException("Amount can't be in string format");
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBox80D.Clear();
            textBox80DD.Clear();
            textBox80DDB.Clear();
            textBox80EEB.Clear();
            textBox80EEEA.Clear();
            textBox80GG.Clear();
            textBox80GGA.Clear();
            textBox80U.Clear();
            textBoxBasicDA.Clear();
            textBoxBonusComm.Clear();
            textBoxBusiness.Clear();
            textBoxEPF.Clear();
            textBoxEquity.Clear();
            textBoxFD.Clear();
            textBoxFoodCoupons.Clear();
            textBoxHousingLoanPrincipal.Clear();
            textBoxHRA.Clear();
            textBoxLifeInsurance.Clear();
            textBoxLTCG10.Clear();
            textBoxLTCG20.Clear();
            textBoxNPS.Clear();
            textBoxOtherAllowance.Clear();
            textBoxOtherExemptions.Clear();
            textBoxOthers.Clear();
            textBoxOtherSources.Clear();
            textBoxPPF.Clear();
            textBoxProfession.Clear();
            textBoxSavingsAcc.Clear();
            textBoxSection24B.Clear();
            textBoxSTCG15.Clear();
            textBoxSTGNM.Clear();
            textBoxTuition.Clear();
            buttonGo.Enabled = true;

            textBoxOutputNewTaxRegime.Text = "Rs ";
            textBoxOutputOldTax.Text = "Rs ";
        }
    }
}
