using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wingateCSharp.Validation;
using Xunit;


namespace WinGate.Test
{
    public class NotNullValidationTests
    {
        [Fact]
        //Unit test
        public void ValidatorWithCorrectInputReturnsCorrectResult()
        {
            //Aarrange
            var mockLogger = new Moq.Mock<Logger>();
            var sut = new NotNullValidation(mockLogger.Object);

            //Act 
            var res = sut.Validator("sd");

            //Assert
            Assert.True(res); 
        }
        [Fact]
        //Unit Test 
        public void ValidatorWrongInputReturnsCorrectResult()
        {
            //Aarrange
            var mockLogger = new Moq.Mock<Logger>();
            var sut = new NotNullValidation(mockLogger.Object);

            //Act 
            var res = sut.Validator("");

            //Assert
            Assert.False(res);
        }
    }

   
}
