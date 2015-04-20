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

    public class XPLMSetDatab
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
        public byte[] values { get; set; }
    }

    public class XPLMSetDatabService : Service
    {
        public object Any(XPLMSetDatab request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatab(request.XPLMDataRefName, request.values);
                    return new XPLMSetDatabResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatabResponse { Result = ex.Message };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatab(request.XPLMDataRefHandle, request.values);
                    return new XPLMSetDatabResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatabResponse { Result = ex.Message };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMSetDatab:</b>" + "<br>");
            retstr.Append("Write part or all of an array of bytes. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("values [byte[]]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatab?XPLMDataRefName={DataRefName}&values={values}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("values [byte[]]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatab?DataRefHandle={DataRefHandle}&values={values}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("result [string] (empty when ok)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);

        }
    }

    public class XPLMSetDatabResponse
    {
        public string Result { get; set; }
    }
}
