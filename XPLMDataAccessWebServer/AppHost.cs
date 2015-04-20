using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Web;

using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;

namespace XPLMDataAccessWebServer
{
    public class AppHost : AppHostHttpListenerBase
    {
        

        public AppHost() : base("XPLMDataAccess WebServer started", typeof(XPLMDataAccessService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            Routes
                .Add<XPLMDataAccess>("/XPLMDataAccess")
                .Add<XPLMFindDataRef>("/XPLMDataAccess/XPLMFindDataRef")
                .Add<XPLMFindDataRef>("/XPLMDataAccess/XPLMFindDataRef/{XPLMDataRefName}")
                //XPLMCanWriteDataRef
                .Add<XPLMCanWriteDataRef>("/XPLMDataAccess/XPLMCanWriteDataRef")
                .Add<XPLMCanWriteDataRef>("/XPLMDataAccess/XPLMCanWriteDataRef/{XPLMDataRefName}")
                .Add<XPLMCanWriteDataRef>("/XPLMDataAccess/XPLMCanWriteDataRef/{XPLMDataRefHandle}")
                //XPLMGetDataRefTypes
                .Add<XPLMGetDataRefTypes>("/XPLMDataAccess/XPLMGetDataRefTypes")
                .Add<XPLMGetDataRefTypes>("/XPLMDataAccess/XPLMGetDataRefTypes/{XPLMDataRefName}")
                .Add<XPLMGetDataRefTypes>("/XPLMDataAccess/XPLMGetDataRefTypes/{XPLMDataRefHandle}")
                //XPLMGetDatai
                .Add<XPLMGetDatai>("/XPLMDataAccess/XPLMGetDatai")
                .Add<XPLMGetDatai>("/XPLMDataAccess/XPLMGetDatai/{XPLMDataRefName}")
                .Add<XPLMGetDatai>("/XPLMDataAccess/XPLMGetDatai/{XPLMDataRefHandle}")
                //XPLMSetDatai
                .Add<XPLMSetDatai>("/XPLMDataAccess/XPLMSetDatai")
                .Add<XPLMSetDatai>("/XPLMDataAccess/XPLMSetDatai/{XPLMDataRefName}/{value}")
                .Add<XPLMSetDatai>("/XPLMDataAccess/XPLMSetDatai/{XPLMDataRefHandle}/{value}")
                //XPLMGetDataf
                .Add<XPLMGetDataf>("/XPLMDataAccess/XPLMGetDataf")
                .Add<XPLMGetDataf>("/XPLMDataAccess/XPLMGetDataf/{XPLMDataRefName}")
                .Add<XPLMGetDataf>("/XPLMDataAccess/XPLMGetDataf/{XPLMDataRefHandle}")
                //XPLMSetDataf
                .Add<XPLMSetDataf>("/XPLMDataAccess/XPLMSetDataf")
                .Add<XPLMSetDataf>("/XPLMDataAccess/XPLMSetDataf/{XPLMDataRefName}/{value}")
                .Add<XPLMSetDataf>("/XPLMDataAccess/XPLMSetDataf/{XPLMDataRefHandle}/{value}")
                //XPLMGetDatad
                .Add<XPLMGetDatad>("/XPLMDataAccess/XPLMGetDatad")
                .Add<XPLMGetDatad>("/XPLMDataAccess/XPLMGetDatad/{XPLMDataRefName}")
                .Add<XPLMGetDatad>("/XPLMDataAccess/XPLMGetDatad/{XPLMDataRefHandle}")
                //XPLMSetDatad
                .Add<XPLMSetDatad>("/XPLMDataAccess/XPLMSetDatad")
                .Add<XPLMSetDatad>("/XPLMDataAccess/XPLMSetDatad/{XPLMDataRefName}/{value}")
                .Add<XPLMSetDatad>("/XPLMDataAccess/XPLMSetDatad/{XPLMDataRefHandle}/{value}")

                 //XPLMGetDatavi
                .Add<XPLMGetDatavi>("/XPLMDataAccess/XPLMGetDatavi")
                .Add<XPLMGetDatavi>("/XPLMDataAccess/XPLMGetDatavi/{XPLMDataRefName}")
                .Add<XPLMGetDatavi>("/XPLMDataAccess/XPLMGetDatavi/{XPLMDataRefHandle}")
                 //XPLMSetDatavi
                .Add<XPLMSetDatavi>("/XPLMDataAccess/XPLMSetDatavi")
                .Add<XPLMSetDatavi>("/XPLMDataAccess/XPLMSetDatavi/{XPLMDataRefName}/{values}")
                .Add<XPLMSetDatavi>("/XPLMDataAccess/XPLMSetDatavi/{XPLMDataRefHandle}/{values}")
                 //XPLMGetDatavf
                .Add<XPLMGetDatavf>("/XPLMDataAccess/XPLMGetDatavf")
                .Add<XPLMGetDatavf>("/XPLMDataAccess/XPLMGetDatavf/{XPLMDataRefName}")
                .Add<XPLMGetDatavf>("/XPLMDataAccess/XPLMGetDatavf/{XPLMDataRefHandle}")
                 //XPLMSetDatavf
                .Add<XPLMSetDatavf>("/XPLMDataAccess/XPLMSetDatavf")
                .Add<XPLMSetDatavf>("/XPLMDataAccess/XPLMSetDatavf/{XPLMDataRefName}/{values}")
                .Add<XPLMSetDatavf>("/XPLMDataAccess/XPLMSetDatavf/{XPLMDataRefHandle}/{values}")
                 //XPLMGetDatab
                .Add<XPLMGetDatab>("/XPLMDataAccess/XPLMGetDatab")
                .Add<XPLMGetDatab>("/XPLMDataAccess/XPLMGetDatab/{XPLMDataRefName}")
                .Add<XPLMGetDatab>("/XPLMDataAccess/XPLMGetDatab/{XPLMDataRefHandle}")
                 //XPLMSetDatab
                .Add<XPLMSetDatab>("/XPLMDataAccess/XPLMSetDatab")
                .Add<XPLMSetDatab>("/XPLMDataAccess/XPLMSetDatab/{XPLMDataRefName}/{values}")
                .Add<XPLMSetDatab>("/XPLMDataAccess/XPLMSetDatab/{XPLMDataRefHandle}/{values}");
        }



    }
}
