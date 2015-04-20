using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPLMDataAccessWebServer
{
    /// <summary>
    /// connection to X-Plane as thread safe singleton to save time
    /// </summary>
    public sealed class XPConnector
    {

        private DotNetDataRefConnector.XPLMDataAccess da;

        XPConnector()
        {
            da = new DotNetDataRefConnector.XPLMDataAccess();
            da.Open();
        }

        ~ XPConnector()
        {
            da.Close();
        }

        public DotNetDataRefConnector.XPLMDataAccess DataConnector
        {
            get
            {
                return da;
            }
        }

        public static XPConnector GetInstance()
        {
            return NestedSingleton.singleton;
        }

        class NestedSingleton
        {
            internal static readonly XPConnector singleton = new XPConnector();
            
            static NestedSingleton()
            {
            }
        }

    }
}
