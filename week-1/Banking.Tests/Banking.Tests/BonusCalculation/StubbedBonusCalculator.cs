using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain;

namespace Banking.Tests.BonusCalculation;
public class StubbedBonusCalculator : ICalculateBonusesForBankAccounts
{
    public decimal CalculateBonusForDeposit(decimal currentBalance, TransactionAmount amountToDeposit)
    {
        if (currentBalance == 7000 & amountToDeposit == 100)
        {
            return 420.69M;
        }
        else
        {
            return 0;
        }

    }
}
