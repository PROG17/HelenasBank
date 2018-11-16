using HelenasBank.Classes;
using HelenasBank.Models;
using HelenasBank.Repo;
using System;
using Xunit;

namespace BankTest
{
    public class BankTest
    {
        [Fact]
        public void Test_Transfer_Amount_Not_Lower_Than_Balance()
        {
            //Arrange
            var transferingAccount = new Account
            {
                AccountNo = "123",
                Balance = 100
            };

            var receivingAccount = new Account()
            {
                AccountNo = "321",
                Balance = 0
            };

            //Act
            var result = transferingAccount.TransferFromAccount(receivingAccount, 100);

            //Assert
            Assert.True(result);

        }


        [Fact]
        public void Test_Transfer_Betweeen_Accounts()
        {
            //Arrange
            var transferingAccount = new Account
            {
                AccountNo = "123",
                Balance = 100
            };

            var receivingAccount = new Account()
            {
                AccountNo = "321",
                Balance = 0
            };

            //Act

            var result = transferingAccount.TransferFromAccount(receivingAccount, 100);

            Assert.True(100 == receivingAccount.Balance && 0 == transferingAccount.Balance);
            

        }

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
