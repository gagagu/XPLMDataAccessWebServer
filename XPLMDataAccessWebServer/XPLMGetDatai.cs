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

    public class XPLMGetDatai
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDataiResponse
    {
        public int Result { get; set; }
    }

    public class XPLMGetDataiService : Service
    {
        public object Any(XPLMGetDatai request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    int res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatai(request.XPLMDataRefName);
                    return new XPLMGetDataiResponse { Result = res };
                }
                catch {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try{
                    int res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatai(request.XPLMDataRefHandle);
                    return new XPLMGetDataiResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataiResponse { Result = -1 };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDatai:</b>" + "<br>");
            retstr.Append("Read a single integer data ref. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatai?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatai?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("value [int] (-1 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }
}
