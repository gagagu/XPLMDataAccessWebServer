## XPLMDataAccessWebServer
The XPLMDataAccess Web Server is an extension of my XPLMDataAccess Plug-In project. All XPLMDataAccess API methods will be provided over a webserver, created by ServiceStack framework.

## Installation


1) Extrakt XPLMDataAccess_{version}.zip

2) Copy the folder "DotNetDataRefConnector" into the x-plane folder {X-PLANE}/Resources/plugins/ Please copy the folder not only the content.

3) Start the file XPLMDataAccessWebServer.exe from WebServer directory with administration rights.

4) Start a web browser and locate to following URL: "http://localhost:1337/XPLMDataAccess"

5) Get further information of the loaded side of the web browser.

 

## Important Information:
•The web server must be stared on the same system where x-plate starts.
•The default port (1337) can be changed by start the XPLMDataAccessWebServer.exe via shell (or batch) with the number of desired port.
 Example: XPLMDataAccessWebServer.exe 4444
•The web server must be run with administrator privileges (especially important for Win7/8)

 

Use for your own risk!


## Licensing
 
MIT
