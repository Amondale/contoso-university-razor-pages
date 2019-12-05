using System;
using System.Collections.Generic;
using ContosoUniversity.Common.Extensions;
using Xunit;

namespace ContosoUniversity.Common.Tests.Extensions.DateTimeExtensions
{
    public class TruncateMinutesAndSecondsTests
    {
        public TruncateMinutesAndSecondsTests()
        {
            
        }

        [Fact]
        public void TruncateMinutesAndSeconds_Fact_Succeeds()
        {
            //Arrange 
            var myActualDate = new DateTime(2001, 12, 25, 15, 30, 14);
            var myExpectedDate = new DateTime(2001, 12, 25, 15, 0, 0);

            //Act
            myActualDate = myActualDate.TruncateMinutesAndSeconds();

            //Assert
            Assert.Equal(myExpectedDate, myActualDate);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TruncateMinutesAndSeconds_Theory_Succeeds(DateTime actual, DateTime expected)
        {
            //Act
            actual = actual.TruncateMinutesAndSeconds();

            //Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new DateTime(2001, 12, 25, 15, 30, 14), new DateTime(2001, 12, 25, 15, 0, 0) },
                new object[] { new DateTime(2002, 02, 15, 12, 01, 35), new DateTime(2002, 02, 15, 12, 0, 0) },
                new object[] { new DateTime(2003, 03, 14, 18, 15, 03), new DateTime(2003, 03, 14, 18, 0, 0) }
            };
    }
}
