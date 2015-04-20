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

    public class XPLMGetDatavf
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDatavfResponse
    {
        public float[] Result { get; set; }
    }

    public class XPLMGetDatavfService : Service
    {
        public object Any(XPLMGetDatavf request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    float[] res = new float[1] { 0 };
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatavf(request.XPLMDataRefName);
                    return new XPLMGetDatavfResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatavfResponse { Result = new float[1] { -999 } };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    float[] res = new float[1] { 0 };
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatavf(request.XPLMDataRefHandle);
                    return new XPLMGetDatavfResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatavfResponse { Result = new float[1] { -999 } };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDatavf:</b>" + "<br>");
            retstr.Append("Read a part of an array of floats. Returns number of ints returned." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatavf?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatavf?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("values [float[]] (one -999 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }
}
