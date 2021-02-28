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

        private IncomeTaxDLL.IncomeAndSalary obj;
        private double _setBasicDA;
        private double _setHRA;
        private double _BonusCommission;
        private double _OtherAllowances;
        private double _BusinessAmount;
        private double _ProfessionAmount;
        private double _STCGNormalRates;
        private double _STCG15;
        private double _LTCG15;
        private double _LTCG20;
        private double _SavingBankAcc;
        private double _FixedDeposit;
        private double _OtherSources;
        

        public UserIncomeAndSalary()
        {
            obj = new IncomeAndSalary();
        }


        /// <summary>
        /// Setting income through Basi and Dearness Allowance
        /// </summary>
        public double SetBasicDA
        {
            get
            {
                return _setBasicDA;
            }
            set
            {
                _setBasicDA = value;
            }
        }

        /// <summary>
        /// Setting income throught House rental allowance
        /// </summary>
        public double SetHRA
        {
            get
            {
                return _setHRA;
            }
            set
            {
                _setHRA = value;
            }
        }

        /// <summary>
        /// Setting income through Bonus or commission
        /// </summary>
        public double BonusCommission
        {
            get
            {
                return _BonusCommission;
            }
            set
            {
                _BonusCommission = value;
            }
        }

        /// <summary>
        /// Setting income throught other allowances
        /// </summary>
        public double OtherAllowances
        {
            get
            {
                return _OtherAllowances;
            }
            set
            {
                _OtherAllowances = value;
            }
        }

        /// <summary>
        /// Setting income through Business 
        /// </summary>
        public double BusinessAmount
        {
            get
            {
                return _BusinessAmount;
            }
            set
            {
                _BusinessAmount = value;
            }
        }

        /// <summary>
        /// Setting income through Profession Amount
        /// </summary>
        public double ProfessionAmount
        {
            get
            {
                return _ProfessionAmount;
            }
            set
            {
                _ProfessionAmount = value;
            }
        }


        /// <summary>
        /// Setting income through short term capital gains at normal rates
        /// </summary>
        public double STCGNormalRates
        {
            get
            {
                return _STCGNormalRates;
            }
            set
            {
                _STCGNormalRates = value;
            }
        }

        /// <summary>
        /// Setting income through short term capital gains at 15 % rate
        /// </summary>
        public double STCG15
        {
            get
            {
                return _STCG15;
            }
            set
            {
                _STCG15 = value;
            }
        }

        /// <summary>
        /// Setting income through Long term capital gain at 10% rate
        /// </summary>
        public double LTCG10
        {
            get
            {
                return _LTCG15;
            }
            set
            {
                _LTCG15 = value;
            }
        }

        /// <summary>
        /// Setting income through long term capital gain at 20% rate
        /// </summary>
        public double LTCG20
        {
            get
            {
                return _LTCG20;
            }
            set
            {
                _LTCG20 = value;
            }
        }

        /// <summary>
        /// Setting income through savings bank account
        /// </summary>
        public double SavingBankAcc
        {
            get
            {
                return _SavingBankAcc;
            }
            set
            {
                _SavingBankAcc = value;
            }
        }

        /// <summary>
        /// Setting income through Fixed deposits
        /// </summary>
        public double FixedDeposit
        {
            get
            {
                return _FixedDeposit;
            }
            set
            {
                _FixedDeposit = value;
            }
        }

        /// <summary>
        /// Setting income through Other sources
        /// </summary>
        public double OtherSources
        {
            get
            {
                return _OtherSources;
            }
            set
            {
                _OtherSources = value;
            }
        }


        /// <summary>
        /// Return the total income through salary
        /// </summary>
        /// <returns></returns>
        public double getTotlaSalary()
        {
            return (_setBasicDA + _setHRA + _BonusCommission + _OtherAllowances );
        }

        
    }
}
