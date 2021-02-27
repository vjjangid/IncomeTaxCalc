using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeTaxDLL;

namespace IncomeTaxCalculator
{
    class UserIncomeAndSalary
    {
        IncomeTaxDLL.IncomeAndSalary obj;

        public UserIncomeAndSalary()
        {
            obj = new IncomeAndSalary();
        }

        public void setBasicDA(double basicDAAmount)
        {
            obj.BasicDAAmount = basicDAAmount;
        }

        public void setHRA(double HRAmount)
        {
            obj.HRA_Amount = HRAmount;
        }

        public void showBasic()
        {
            Console.WriteLine(obj.BasicDAAmount);
        }
    }
}
