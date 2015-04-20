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

    public class XPLMSetDatad
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
        public double value { get; set; }
    }

    public class XPLMSetDatadService : Service
    {
        public object Any(XPLMSetDatad request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatad(request.XPLMDataRefName, request.value);
                    return new XPLMSetDatadResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatadResponse { Result = ex.Message };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try{
                    XPConnector.GetInstance().DataConnector.XPLMSetDatad(request.XPLMDataRefHandle, request.value);
                    return new XPLMSetDatadResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatadResponse { Result = ex.Message };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMSetDatad:</b>" + "<br>");
            retstr.Append("Write a double precision floating point data ref." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("value [double]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatad?XPLMDataRefName={DataRefName}&value={value}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("value [double]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatad?DataRefHandle={DataRefHandle}&value={value}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("result [string] (empty when ok)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);

        }
    }

    public class XPLMSetDatadResponse
    {
        public string Result { get; set; }
    }
}
