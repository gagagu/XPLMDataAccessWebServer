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

    public class XPLMSetDatavi
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
        public Int16[] values { get; set; }
    }

    public class XPLMSetDataviService : Service
    {
        public object Any(XPLMSetDatavi request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatavi(request.XPLMDataRefName, request.values);
                    return new XPLMSetDataviResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDataviResponse { Result = ex.Message };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatavi(request.XPLMDataRefHandle, request.values);
                    return new XPLMSetDataviResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDataviResponse { Result = ex.Message };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMSetDatavi:</b>" + "<br>");
            retstr.Append("Write part or all of an array of integers. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("values [Int16[]]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatavi?XPLMDataRefName={DataRefName}&values={values}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("values [int16[]]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatavi?DataRefHandle={DataRefHandle}&values={values}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("result [string] (empty when ok)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);

        }
    }

    public class XPLMSetDataviResponse
    {
        public string Result { get; set; }
    }
}
