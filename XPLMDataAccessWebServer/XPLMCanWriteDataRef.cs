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
    public class XPLMCanWriteDataRef
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMCanWriteDataRefService : Service
    {
        public object Any(XPLMCanWriteDataRef request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try{
                    int res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMCanWriteDataRef(request.XPLMDataRefName);
                    return new XPLMCanWriteDataRefResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }
            else if (request.XPLMDataRefHandle>0)
            {
                try{
                    int res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMCanWriteDataRef(request.XPLMDataRefHandle);
                    return new XPLMCanWriteDataRefResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMCanWriteDataRef:</b>" + "<br>");
            retstr.Append("This routine returns 1 if you can successfully set the data, 0 otherwise. Some datarefs are read-only. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMCanWriteDataRef?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMCanWriteDataRef?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("value [int] (-1 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);


        }
    }

    public class XPLMCanWriteDataRefResponse
    {
        public int Result { get; set; }
    }
}
