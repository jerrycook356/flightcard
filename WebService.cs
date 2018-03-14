using System;
namespace practice2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using ModernHttpClient;

    //webservice

    public class WebService
    {
        //at home
        // string baseUrl = "http://192.168.178.1:8080/FlightCardWebService/rest/WebService";
        //at work
        // String baseUrl = "http://192.168.2.3:8080/FlightCardWebService/rest/WebService";
        //amazon aws
        String baseUrl = " http://flightcard2.n32nbxmg3t.us-east-2.elasticbeanstalk.com/rest/WebService";
        public WebService()
        {

        }


        public List<FlightCards> FillFromService()
        {
            List<FlightCards> cardList = new List<FlightCards>();
            var url = baseUrl + "/GetFromFlightTable/";
            using (WebClient webclient = new WebClient())
            {
                try
                {
                    var content = webclient.DownloadString(url);
                    cardList = JsonConvert.DeserializeObject<List<FlightCards>>(content);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }

            }

            return cardList;

        }


        public async void SaveToServiceAsync(FlightCards card)
        {


            var url = baseUrl + "/addToFlightCard";
            var content = JsonConvert.SerializeObject(card);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpRequest = await httpClient.PostAsync(url, httpContent);
            }

        }
        public async void DeleteAsync(FlightCards card)
        {

            var url = baseUrl + "/delete";
            var content = JsonConvert.SerializeObject(card);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpMessage = await httpClient.PostAsync(url, httpContent);

            }
        }
        async public void updateFlightCard(FlightCards card)
        {
            var url = baseUrl + "/update";
            var content = JsonConvert.SerializeObject(card);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpMessage = await httpClient.PutAsync(url, httpContent);

            }
        }
        //get the pilots stored in remote database
        public List<Pilot> getPilots()
        {
            List<Pilot> pilotList = new List<Pilot>();
            var url = baseUrl + "/getFromPilotTable";
            using (WebClient webclient = new WebClient())
            {
                try
                {
                    var content = webclient.DownloadString(url);
                    pilotList = JsonConvert.DeserializeObject<List<Pilot>>(content);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }
            }
            return pilotList;
        }


        //get planes from the remote database
        public List<Plane> getPlanes()
        {
            List<Plane> planeList = new List<Plane>();
            var url = baseUrl + "/getFromPlaneTable";
            using (WebClient webclient = new WebClient())
            {
                try
                {
                    var content = webclient.DownloadString(url);
                    planeList = JsonConvert.DeserializeObject<List<Plane>>(content);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }

            }

            return planeList;

        }
        //get the lease names from the remote database
        public List<Lease> getLeases()
        {
            List<Lease> leaseList = new List<Lease>();
            var url = baseUrl + "/getFromLeaseTable";
            using (WebClient webclient = new WebClient())
            {
                try
                {
                    var content = webclient.DownloadString(url);
                    leaseList = JsonConvert.DeserializeObject<List<Lease>>(content);

                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }

            }

            return leaseList;

        }
        //add pilot to remote database
        public async void addPilot(Pilot pilot)
        {

            var url = baseUrl + "/addPilot";
            var content = JsonConvert.SerializeObject(pilot);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpRequest = await httpClient.PostAsync(url, httpContent);
            }

        }
        //delete pilot from remote database
        public async void deletePilot(Pilot pilot)
        {

            var url = baseUrl + "/deletePilot";
            var content = JsonConvert.SerializeObject(pilot);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpMessage = await httpClient.PostAsync(url, httpContent);

            }
        }
        // add plane to remote database
        public async void addPlane(Plane plane)
        {


            var url = baseUrl + "/addPlane";
            var content = JsonConvert.SerializeObject(plane);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpRequest = await httpClient.PostAsync(url, httpContent);
            }

        }
        //delete plane from remote database
        public async void deletePlane(Plane plane)
        {

            var url = baseUrl + "/deletePlane";
            var content = JsonConvert.SerializeObject(plane);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpMessage = await httpClient.PostAsync(url, httpContent);

            }
        }
        //add lease to remote database
        public async void addLease(Lease lease)
        {

            var url = baseUrl + "/addLease";
            var content = JsonConvert.SerializeObject(lease);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpRequest = await httpClient.PostAsync(url, httpContent);
            }

        }
        //delete lease from remote database
        public async void deleteLease(Lease lease)
        {

            var url = baseUrl + "/deleteLease";
            var content = JsonConvert.SerializeObject(lease);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpMessage = await httpClient.PostAsync(url, httpContent);

            }
        }
    }
}
       
    

