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

    public class XPLMGetDataf
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDatafResponse
    {
        public float Result { get; set; }
    }

    public class XPLMGetDatafService : Service
    {
        public object Any(XPLMGetDataf request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    float res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDataf(request.XPLMDataRefName);
                    return new XPLMGetDatafResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatafResponse { Result = -999 };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    float res = 0;
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDataf(request.XPLMDataRefHandle);
                    return new XPLMGetDatafResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatafResponse { Result = -999 };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDataf:</b>" + "<br>");
            retstr.Append("Read a single precision floating point (float) data ref. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDataf?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDataf?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("value [float] (-999 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }
}
