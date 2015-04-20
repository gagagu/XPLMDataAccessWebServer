using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPLMDataAccessWebServer
{
    public class XPLMDataType
    {
        /// <summary>
        /// Typelist; defines the datatype in data buffer
        /// </summary>
        public enum XPLMDataTypeList : byte
        {
            dtype_int = 0x00,
            dtype_float = 0x01,
            dtype_double = 0x02,
            dtype_handle = 0x03,
            dtype_float_array = 0x04,
            dtype_int_array = 0x05,
            dtype_byte_array = 0x06
        }
    }
}
