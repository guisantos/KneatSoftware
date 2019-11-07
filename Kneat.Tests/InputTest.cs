using Kneat.Business;
using Kneat.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kneat.Tests
{
    public class InputTest
    {
        [Fact]
        public void InputNegativeTest_ShouldThrowInputNegativeValueException()
        {
            Assert.Throws<CustomExceptions.InputNegativeValueException>(() 
                => CalculateMGLT.ValidMGLTInput("-10"));
        }

        [Fact]
        public void InputNegativeTest_ShouldThroewInputNotANumberException()
        {
            Assert.Throws<CustomExceptions.InputNotANumberException>(() 
                => CalculateMGLT.ValidMGLTInput("abcd"));
        }
    }
}
