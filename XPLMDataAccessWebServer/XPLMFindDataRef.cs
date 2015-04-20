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
    public class XPLMFindDataRef
    {
        public string XPLMDataRefName { get; set; }
    }

    public class XPLMFindDataRefService : Service
    {
        public object Any(XPLMFindDataRef request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try{
                    uint res = 0;
                    string name = request.XPLMDataRefName;
                    res = XPConnector.GetInstance().DataConnector.XPLMFindDataRef(request.XPLMDataRefName);
                    return new XPLMFindDataRefResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMFindDataRef:</b>" + "<br>");
            retstr.Append("Returns a uint handle from named data ref." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>NOTE:</b> this function is relatively expensive; save the XPLMDataRef this function returns for future use." + "<br>");
            retstr.Append("Do not look up your data ref by string every time you need to read or write it." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMFindDataRef?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("value [uint] (-1 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);


        }
    }

    public class XPLMFindDataRefResponse
    {
        public uint Result { get; set; }
    }
}
