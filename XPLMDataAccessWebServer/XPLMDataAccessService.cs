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

namespace XPLMDataAccessWebServer
{
    public class XPLMDataAccess
    { 
    }

    public class XPLMDataAccessService:Service
    {
        public object Any(XPLMDataAccess request)
        {
            StringBuilder retstr = new StringBuilder();
            retstr.Append("<b>Webserver to Connect to X-Plane over Shared Memory</b>" + "<br>");
            retstr.Append("based on idea by: <b>Jason de la Cruz</b>" + "<br>");
            retstr.Append("<a href='https://github.com/delacruz/XplaneRestApi/wiki'>https://github.com/delacruz/XplaneRestApi/wiki<a>" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("redesigned by <b>A.Eckers</b>" + "<br>");
            retstr.Append("<a href='http://www.gagagu.de'>http://www.gagagu.de<a>" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("See <a href='http://www.xsquawkbox.net/xpsdk/docs/XPLMDataAccess.html'>http://www.xsquawkbox.net/xpsdk/docs/XPLMDataAccess.html<a/>" + "<br>");
            retstr.Append("for command information." + "<br>");
            retstr.Append("Following commands are implemented:" + "<br>");
            retstr.Append("" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMFindDataRef'>XPLMFindDataRef<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMCanWriteDataRef'>XPLMCanWriteDataRef<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDataRefTypes'>XPLMGetDataRefTypes<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDatai'>XPLMGetDatai<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMSetDatai'>XPLMSetDatai<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDataf'>XPLMGetDataf<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMSetDataf'>XPLMSetDataf<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDatad'>XPLMGetDatad<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMSetDatad'>XPLMSetDatad<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDatavi'>XPLMGetDatavi<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMSetDatavi'>XPLMSetDatavi<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDatavf'>XPLMGetDatavf<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMSetDatavf'>XPLMSetDatavf<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMGetDatab'>XPLMGetDatab<a/>" + "<br>");
            retstr.Append("<a href='../XPLMDataAccess/XPLMSetDatab'>XPLMSetDatab<a/>" + "<br>");
            retstr.Append("" + "<br>");

            return new HttpResult(retstr.ToString(), System.Net.HttpStatusCode.OK);
        }
    }

    public class XPLMDataAccessServiceResponse
    {
 
        public string Result { get; set; }
    }
}
