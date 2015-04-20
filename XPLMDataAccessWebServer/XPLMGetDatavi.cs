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

    public class XPLMGetDatavi
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDataviResponse
    {
        public Int16[] Result { get; set; }
    }

    public class XPLMGetDataviService : Service
    {
        public object Any(XPLMGetDatavi request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    Int16[] res = new Int16[1] { 0 };
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatavi(request.XPLMDataRefName);
                    return new XPLMGetDataviResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataviResponse { Result = new Int16[1] { -1 } };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    Int16[] res = new Int16[1] { 0 };
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatavi(request.XPLMDataRefHandle);
                    return new XPLMGetDataviResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDataviResponse { Result = new Int16[1] {-1} };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDatavi:</b>" + "<br>");
            retstr.Append("Read a part of an array of integers. Returns number of ints returned." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatavi?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatavi?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("values [int[]] (one -1 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }
}
