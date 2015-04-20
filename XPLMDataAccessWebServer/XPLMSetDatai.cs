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

    public class XPLMSetDatai
    {
        public string XPLMDataRefName { get; set; }
        public uint XPLMDataRefHandle { get; set; }
        public short value { get; set; }
    }

    public class XPLMSetDataiService : Service
    {
        public object Any(XPLMSetDatai request)
        {
            if (!string.IsNullOrEmpty(request.XPLMDataRefName))
            {
                try
                {
                    XPConnector.GetInstance().DataConnector.XPLMSetDatai(request.XPLMDataRefName, request.value);
                    return new XPLMSetDataiResponse { Result = string.Empty };
                }catch(Exception ex){
                    return new XPLMSetDataiResponse { Result = ex.Message };
                }
            }
            else if (request.XPLMDataRefHandle > 0)
            {
                try{
                    XPConnector.GetInstance().DataConnector.XPLMSetDatai(request.XPLMDataRefHandle, request.value);
                    return new XPLMSetDataiResponse { Result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new XPLMSetDataiResponse { Result = ex.Message };
                }
            }

            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>XPLMSetDatai:</b>" + "<br>");
            retstr.Append("Write a single integer data ref. " + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Parameter:</b>" + "<br>");
            retstr.Append("DataRefName [string]" + "<br>");
            retstr.Append("value [short]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatai?XPLMDataRefName={DataRefName}&value={value}" + "<br>");
            retstr.Append("<b>or</b>" + "<br>");
            retstr.Append("XPLMDataRefHandle [uint] (getting from XPLMFindDataRef routine)" + "<br>");
            retstr.Append("value [short]" + "<br>");
            retstr.Append("http://{yourserver_and_port}/XPLMDataAccess/XPLMSetDatai?DataRefHandle={DataRefHandle}&value={value}" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<b>Return:</b>" + "<br>");
            retstr.Append("result [string] (empty when ok)" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);

        }
    }

    public class XPLMSetDataiResponse
    {
        public string Result { get; set; }
    }
}
