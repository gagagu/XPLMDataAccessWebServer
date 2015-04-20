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

    public class XPLMGetDatad
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDatadResponse
    {
        public double Result { get; set; }
    }

    public class XPLMGetDatadService : Service
    {
        public object Any(XPLMGetDatad request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    double res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatad(request.XPLMDataRefName);
                    return new XPLMGetDatadResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatadResponse { Result = -999 };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    double res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatad(request.XPLMDataRefHandle);
                    return new XPLMGetDatadResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatadResponse { Result = -999 };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDatad:</b>" + "<br>");
            retstr.Append("Read a double precision floating point data ref. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatad?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatad?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("value [double] (-999 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }
}
