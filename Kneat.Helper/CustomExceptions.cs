using System;
using System.Collections.Generic;
using System.Text;

namespace Kneat.Helper
{
    public class CustomExceptions
    {
        #region Input Exception
        public class InputNegativeValueException : Exception
        {
            public InputNegativeValueException(string message)
               : base(message)
            {
            }
        }

        public class InputNotANumberException : Exception
        {
            public InputNotANumberException(string message)
               : base(message)
            {
            }
        }
        #endregion

        #region API Exception
        public class NullSpaceshipShipURLException : Exception
        {
            public NullSpaceshipShipURLException(string message)
               : base(message)
            {
            }
        }
        #endregion

        #region Consumables Exception
        public class ConsumableWrongFormatException : Exception
        {
            public ConsumableWrongFormatException(string message)
               : base(message)
            {
            }
        }

        public class ConsumableFirstValueNotANumberException : Exception
        {
            public ConsumableFirstValueNotANumberException(string message)
               : base(message)
            {
            }
        }

        public class ConsumableSecondValueNotRecognizedException : Exception
        {
            public ConsumableSecondValueNotRecognizedException(string message)
               : base(message)
            {
            }
        }
        #endregion
    }
}
