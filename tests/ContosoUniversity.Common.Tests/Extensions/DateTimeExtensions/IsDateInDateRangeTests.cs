using System;
using System.ComponentModel;
using ContosoUniversity.Common.Extensions;
using Xunit;

namespace ContosoUniversity.Common.Tests.Extensions.DateTimeExtensions
{
    public class IsDateInDateRangeTests
    {
        public IsDateInDateRangeTests()
        {
            
        }

        [Fact]
        public void IsDateInDateRange_NoTimeComponent_Succeeds_Returns_True()
        {
            //Arrange
            var myDate = new DateTime(2016, 04, 26, 05, 29, 00);
            var myStartDate = new DateTime(2016, 04, 01); 
            var myEndDate = new DateTime(2016, 04, 30);

            //Act
            var isInDateRange = myDate.IsDateInDateRange(myStartDate, myEndDate, true);

            //Assert
            Assert.True(isInDateRange);
        }


        [Fact]
        public void IsDateInDateRange_NoTimeComponent_Succeeds_Returns_False()
        {
            //Arrange
            var myDate = new DateTime(2016, 04, 26, 05, 29, 00);
            var myStartDate = new DateTime(2016, 05, 01);
            var myEndDate = new DateTime(2016, 05, 31);

            //Act
            var isInDateRange = myDate.IsDateInDateRange(myStartDate, myEndDate, true);

            //Assert
            Assert.False(isInDateRange);
        }

        [Fact]
        public void IsDateInDateRange_Fails_Throws_Exception()
        {
            //Arrange
            var myDate = new DateTime(2016,04,26, 05,29,00);
            var myStartDate = new DateTime(2016, 04, 30);
            var myEndDate = new DateTime(2016, 04, 01);

            //Act & Assert Exception
            var exception =
                Assert.Throws<InvalidEnumArgumentException>(() => myDate.IsDateInDateRange(myStartDate, myEndDate));
        }

    }
}
