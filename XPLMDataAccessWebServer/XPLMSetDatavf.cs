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

    public class XPLMSetDatavf
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
        public float[] values { get; set; }
    }

    public class XPLMSetDatavfService : Service
    {
        public object Any(XPLMSetDatavf request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatavf(request.XPLMDataRefName, request.values);
                    return new XPLMSetDatavfResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatavfResponse { Result = ex.Message };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatavf(request.XPLMDataRefHandle, request.values);
                    return new XPLMSetDatavfResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDatavfResponse { Result = ex.Message };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMSetDatavf:</b>" + "<br>");
            retstr.Append("Write part or all of an array of floats. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("values [float[]]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatavf?XPLMDataRefName={DataRefName}&values={values}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("values [float[]]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatavf?DataRefHandle={DataRefHandle}&values={values}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("result [string] (empty when ok)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);

        }
    }

    public class XPLMSetDatavfResponse
    {
        public string Result { get; set; }
    }
}
