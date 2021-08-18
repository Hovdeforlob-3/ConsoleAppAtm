using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppAtm;
using Xunit;

/// <summary>
/// [Fact] // a singe run whit one set of data
/// [Theory] // allow my to use InlineData
/// [InlineData] // allow to run multiple times whit defrent data
/// </summary>
namespace ConsoleAppAtm.Tests
{
    public class BankTests
    {
        [Theory]
        [InlineData(1234, true)]
        [InlineData(3476, true)]
        [InlineData(0000, false)]
        public void CheakPin_TwoNumbersShouldEqlues(int usrTypedPin, bool expected)
        {
            // Actual
            bool actual = Bank.CheakPin(usrTypedPin);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheakPin_TwoNumbersShouldEqluesTrue()
        {
            // Actual
            bool actual = Bank.CheakPin(1234);

            // Assert
            Assert.True(actual);

        }

        [Fact]
        public void AddNewkonto_ShouldWork()
        {           
            // Arrange
            List<Bankakont> bankakontslst = new List<Bankakont>();
            Bankakont newKonto = new Bankakont(1123, "kej", 100);

            // Actual
            Bank.AddNewkonto(bankakontslst, newKonto);
            // Assert
            Assert.True(bankakontslst.Count == 1);
            Assert.Contains<Bankakont>(newKonto, bankakontslst);

        }

        [Theory]
        [InlineData("", "Name")]
        public void AddNewkonto_ShouldFail(string name, string parameter)
        {
            // Actual
            List<Bankakont> bankakontslst = new List<Bankakont>();
            Bankakont newKonto = new Bankakont(1123, name, 100);

            // Assert
            Assert.Throws<ArgumentException>(parameter, () => Bank.AddNewkonto(bankakontslst, newKonto));
        }


        [Theory]
        [InlineData(50, 50)]
        [InlineData(101,-1)]
        public void ExtratMonny_ShouldWolk(int usrNo, int expeced)
        {
            // Actual
            Bankakont newKonto = new Bankakont(1123, "CJ", 100);
            Bank.ExtratMonny(newKonto, usrNo);

            // Assert
            Assert.Equal(expeced, newKonto.KontoValue);
        }

        [Fact]
        public void FindKonto_ShouldWork()
        {
            // Arrange
            Bankakont expeced = Bank.bKonto[0];
            // Actual
            var actual = Bank.FindKonto(1234);

            // Assert
            Assert.Equal(expeced, actual);
        }

        [Fact]
        public void CheakMonnyIsEnough_ShouldGiveTrue()
        {
            // Arrange
            bool expeced = true;
 
            // Actual
            Bankakont newKonto = new Bankakont(1100, "JJ", 100);
            bool actual = Bank.CheakMonnyIsEnough(newKonto, 50);

            // Assert
            Assert.Equal(expeced, actual);
        }
    }
}
