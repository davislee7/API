using System;
using System.Net;

namespace API
{

    public class WebTools
    {
        private const string BaseURL = "http://testing.shippingapis.com/ShippingAPITest.dll";
        private WebClient wsClient = new WebClient();
        public string USPS_UserID = "064MEDAL7966";
        public WebTools() { }
        public WebTools(string New_UserID)
        {
            USPS_UserID = New_UserID;
        }

        private string GetDataFromSite(string USPS_Request)
        {
            string strResponse = "";

            //Send the request to USPS. 
            byte[] ResponseData = wsClient.DownloadData(USPS_Request);

            //Convert byte stream to string data. 
            foreach (byte oItem in ResponseData)
            {
                strResponse += (char)oItem;
            }

            return strResponse;

        }

        public string AddressValidateRequest(string Address1,

                                     string Address2,

                                     string City,

                                     string State,

                                     string Zip5,

                                     string Zip4)

        {

            //http://production.shippingapis.com/ShippingAPITest.dll?API=Verify 

            //  &XML=<AddressValidateRequest USERID="xxxxxxx"><Address ID="0"><Address1></Address1> 

            //  <Address2>6406 Ivy Lane</Address2><City>Greenbelt</City><State>MD</State> 

            //  <Zip5></Zip5><Zip4></Zip4></Address></AddressValidateRequest> 



            string strResponse = "", strUSPS = "";

            strUSPS = BaseURL + "?API=Verify&XML=<AddressValidateRequest USERID=\"" + USPS_UserID + "\">";

            strUSPS += "<Address ID=\"0\">";

            strUSPS += "<Address1>" + Address1 + "</Address1>";

            strUSPS += "<Address2>" + Address2 + "</Address2>";

            strUSPS += "<City>" + City + "</City>";

            strUSPS += "<State>" + State + "</State>";

            strUSPS += "<Zip5>" + Zip5 + "</Zip5>";

            strUSPS += "<Zip4>" + Zip4 + "</Zip4>";

            strUSPS += "</Address></AddressValidateRequest>";

            //Send the request to USPS. 

            strResponse = GetDataFromSite(strUSPS);

            return strResponse;

        }
        public string CityStateLookupRequest(string ZipCode)
        {
            //http://production.shippingapis.com/ShippingAPITest.dll?API=CityStateLookup 

            //  &XML=<CityStateLookupRequest USERID="xxxxxxx"><ZipCode ID= "0"> 

            //  <Zip5>90210</Zip5></ZipCode></CityStateLookupRequest> 

            string strResponse = "", strUSPS = "";

            strUSPS = BaseURL + "?API=CityStateLookup&XML=<CityStateLookupRequest USERID=\"" + USPS_UserID + "\">";

            strUSPS += "<ZipCode ID=\"0\">";

            strUSPS += "<Zip5>" + ZipCode + "</Zip5>";

            strUSPS += "</ZipCode></CityStateLookupRequest>";

            //Send the request to USPS. 

            strResponse = GetDataFromSite(strUSPS);

            return strResponse;
        }
    }
}
