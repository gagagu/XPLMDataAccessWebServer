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

    public class XPLMGetDatab
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
    }

    public class XPLMGetDatabResponse
    {
        public byte[] Result { get; set; }
    }

    public class XPLMGetDatabService : Service
    {
        public object Any(XPLMGetDatab request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    byte[] res = new byte[1] { 0 };
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatab(request.XPLMDataRefName);
                    return new XPLMGetDatabResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatabResponse { Result = new byte[1] { 0 } };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    byte[] res = new byte[1] { 0 };
                    res = XPConnector.GetInstance().DataConnector.XPLMGetDatab(request.XPLMDataRefHandle);
                    return new XPLMGetDatabResponse { Result = res };
                }
                catch
                {
                    return new XPLMGetDatabResponse { Result = new byte[1] { 0 } };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMGetDatab:</b>" + "<br>");
            retstr.Append("Read a part of an array of bytes. Returns number of ints returned." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatab?XPLMDataRefName={DataRefName}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMGetDatab?DataRefHandle={DataRefHandle}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("values [byte[]] (one 0 on error)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }
}
