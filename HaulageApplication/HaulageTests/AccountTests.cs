using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage.BaseClasses.BillingHandler;

namespace HaulageTests
{
    public class AccountTests
    {
        [Fact]
        public void Account_Initialization_ShouldSetDefaultValues()
        {
            // Arrange & Act
            var account = new Account();

            // Assert
            Assert.Equal(Guid.Empty, account.accountID);
            Assert.Equal(Guid.Empty, account.personID);
            Assert.Null(account.billingDetails);
        }

        [Fact]
        public void Account_SetValues_ShouldReflectInProperties()
        {
            // Arrange
            var account = new Account();
            var testAccountId = Guid.NewGuid();
            var testPersonId = Guid.NewGuid();
            var testBillingDetails = "Sample billing details";

            // Act
            account.accountID = testAccountId;
            account.personID = testPersonId;
            account.billingDetails = testBillingDetails;

            // Assert
            Assert.Equal(testAccountId, account.accountID);
            Assert.Equal(testPersonId, account.personID);
            Assert.Equal(testBillingDetails, account.billingDetails);
        }
    }
}
