using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Common.Extensions;
using Xunit;

namespace ContosoUniversity.Common.Tests.Extensions.StringExtensions
{
    public class ToIntegerListTests
    {
        [Fact]
        public void ToIntegerList_WithNormalList_Succeeds_Returns_True()
        {
            //Arrange
            var listStr = "1,2,3,4,5,6";
            var listIntegers = new List<int>
            {
                1, 2, 3, 4, 5, 6
            };

            //Act
            var listNumbers = listStr.ToIntegerList();

            //Assert
            Assert.Contains(1, listNumbers);
            Assert.Contains(2, listNumbers);
            Assert.Contains(3, listNumbers);
            Assert.Contains(4, listNumbers);
            Assert.Contains(5, listNumbers);
            Assert.Contains(6, listNumbers);
        }

        [Fact]
        public void ToIntegerList_Succeeds_Returns_True()
        {
            //Arrange
            var listStr = "1,2,3";

            //Act
            var listNumbers = listStr.ToIntegerList();

            //Assert
            Assert.Contains(1, listNumbers);
            Assert.Contains(2, listNumbers);
            Assert.Contains(3, listNumbers);
        }
    }
}
