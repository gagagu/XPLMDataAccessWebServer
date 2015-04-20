using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Common.Web;

using DotNetDataRefConnector;

namespace XPLMDataAccessWebServer
{
    public class XPLMGetDataRefTypes
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDataRefTypesService : Service
    {
        public object Any(XPLMGetDataRefTypes request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try{
                    int res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDataRefTypes(request.XPLMDataRefName);
                    return new XPLMGetDataRefTypesResponse { Result = res };
                }
                catch {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try{
                    int res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDataRefTypes(request.XPLMDataRefHandle);
                    return new XPLMGetDataRefTypesResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDataRefTypes:</b>" + "<br>");
            retstr.Append("This routine returns the types of the data ref for accessor use. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDataRefTypes?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDataRefTypes?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("value [int] (-1 on error)" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Meaning:</b>" + "<br>");
            retstr.Append("dtype_int = 0x00" + "<br>");
            retstr.Append("dtype_float = 0x01" + "<br>");
            retstr.Append("dtype_double = 0x02" + "<br>");
            retstr.Append("dtype_handle = 0x03" + "<br>");
            retstr.Append("dtype_float_array = 0x04" + "<br>");
            retstr.Append("dtype_int_array = 0x05" + "<br>");
            retstr.Append("dtype_byte_array = 0x06" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);


        }
    }

    public class XPLMGetDataRefTypesResponse
    {
        public int Result { get; set; }
    }
}
