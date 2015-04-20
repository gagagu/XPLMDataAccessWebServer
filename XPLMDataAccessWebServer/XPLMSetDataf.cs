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

    public class XPLMSetDataf
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
        public float value { get; set; }
    }

    public class XPLMSetDatafService : Service
    {
        public object Any(XPLMSetDataf request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDataf(request.XPLMDataRefName, request.value);
                    return new XPLMSetDatafResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatafResponse { Result = ex.Message };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try{
                    XPConnector.GetInstance().DataConnector.XPLMSetDataf(request.XPLMDataRefHandle, request.value);
                    return new XPLMSetDatafResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatafResponse { Result = ex.Message };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMSetDataf:</b>" + "<br>");
            retstr.Append("Write a single precision floating point (float) data ref." + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("value [float]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDataf?XPLMDataRefName={DataRefName}&value={value}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("value [float]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDataf?DataRefHandle={DataRefHandle}&value={value}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("result [string] (empty when ok)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);

        }
    }

    public class XPLMSetDatafResponse
    {
        public string Result { get; set; }
    }
}
