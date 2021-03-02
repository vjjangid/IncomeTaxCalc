using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeTaxDLL;


namespace IncomeTaxCalculator
{
    class UserIncomeAndDeductions
    {

        private IncomeTaxDLL.ExcemtionsAndDeductions obj;
        private double _Deduction80CCD;

        public UserIncomeAndDeductions()
        {
            obj = new IncomeTaxDLL.ExcemtionsAndDeductions();
        }

        public double Deduction80CCD
        {
            get
            {
                return _Deduction80CCD;
            }
            set
            {
                _Deduction80CCD = value;
              
            }
        }
            
   
    }
}
