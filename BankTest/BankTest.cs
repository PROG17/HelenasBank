using HelenasBank.Classes;
using HelenasBank.Repo;
using System;
using Xunit;

namespace BankTest
{
    public class BankTest
    {

        [Fact]
        public void PerformDeposit_CorrectBalance_True()
        {
            var repos = new BankHelper();
            Assert.Equal(500, repos.PerformDeposit(400, 100));
        }

        [Fact]
        public void PerformWithdrawal_CorrectBalance_True()
        {
            var repos = new BankHelper();
            Assert.Equal(300, repos.PerformWithdrawal(400, 100));
        }

        [Fact]
        public void PerformWithdrawal_TooBigWithdraw()
        {
            var repos = new BankHelper();
            Assert.Equal(400, repos.PerformWithdrawal(400, 500));
        }
    }
}
