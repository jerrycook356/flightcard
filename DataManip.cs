using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using MessageUI;
using UIKit;
using Foundation;
using System.Data.SqlTypes;
using practice2.UpdateTables;


namespace practice2
{
    public class DataManip
    {
        WebService ws = new WebService();


        public static List<string> tempInfo = new List<string>();
        public static List<string> passengerList = new List<string>();
        public List<FlightCards> flightCards = new List<FlightCards>();
        public static List<FlightCards> delCards = new List<FlightCards>();
        //public static FlightCards delCard;

        private string pathToDatabase;
        public static bool isUpdate = false;
        public static bool isTemp = false;
        public static FlightCards editCard;

        public DataManip()
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            pathToDatabase = Path.Combine(documentsFolder, "FlightCard.db");//location database

            //check if tables exist in sqlite database if not create them and insert default data.
            using(var connection = new SQLiteConnection(pathToDatabase)){
                var info = connection.GetTableInfo("AddTable");
                if (!info.Any()){
                    connection.CreateTable<AddTable>();
                }
            }
            using (var connection = new SQLiteConnection(pathToDatabase)){
                var info = connection.GetTableInfo("UpdateTable");
                if (!info.Any()){
                    connection.CreateTable<UpdateTable>();
                }
            }
            using(var connection = new SQLiteConnection(pathToDatabase)){
                var info = connection.GetTableInfo("DeleteTable");
                if (!info.Any()){
                    connection.CreateTable<DeleteTable>();
                }
            }

            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                
                var info = connection.GetTableInfo("leaseTable");
                if (!info.Any())
                {

                    connection.CreateTable<LeaseTable>();
                    connection.Insert(new LeaseTable() { leaseName = "SRW, Inc." });
                    connection.Insert(new LeaseTable() { leaseName = "Northstar Bank" });
                    connection.Insert(new LeaseTable() { leaseName = "NFGCI" });
                    connection.Insert(new LeaseTable() { leaseName = "WMCB" });
                    connection.Insert(new LeaseTable() { leaseName = "Deland Financial Services" });
                    connection.Insert(new LeaseTable() { leaseName = "Gemini Group, Inc." });
                }


            };
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var info = connection.GetTableInfo("PilotsTable");
                if (!info.Any())
                {
                    connection.CreateTable<PilotsTable>();
                    connection.Insert(new PilotsTable() { pilotName = "Trever Engler" });
                    connection.Insert(new PilotsTable() { pilotName = "Ryan Walter" });
                }
            };
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var info = connection.GetTableInfo("PlaneTypeTable");
                if (!info.Any())
                {
                    connection.CreateTable<PlaneTypeTable>();
                    connection.Insert(new PlaneTypeTable() { planeType = "Jet" });
                    connection.Insert(new PlaneTypeTable() { planeType = "Navajo" });
                    connection.Insert(new PlaneTypeTable() { planeType = "CaravanB" });
                    connection.Insert(new PlaneTypeTable() { planeType = "Caravan" });
                    connection.Insert(new PlaneTypeTable() { planeType = "Baron" });
                }

            };

            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var info = connection.GetTableInfo("FlightCardTable");
                if (!info.Any())
                {
                    connection.CreateTable<FlightCardTable>();
                }
            }


        }



        //set if updating flightcard or creating new one
        public static void SetIsUpdate(bool update)
        {
            isUpdate = update;
        }
        //return if update or not
        public static bool GetIsUpdate()
        {
            return isUpdate;
        }

        //set if card is being edited
        public static void SetEditCard(FlightCards card)
        {
            editCard = card;
        }
        //return the editcard to be displayed on view for editing.
        public static FlightCards GetEditCard()
        {
            return editCard;
        }

        public static void SetIsTemp(bool temp)
        {
            isTemp = temp;
        }
        public static bool GetIsTemp()
        {
            return isTemp;
        }

        public static void AddToTemp(string temp)
        {
            tempInfo.Add(temp);
        }
        public static List<string> GetTemp()
        {
            return tempInfo;
        }
        public static void ClearTempInfo()
        {
            tempInfo = new List<string>();
        }
        //add a passenger to the passenger list
        //called on at a time when passenger saved in viewController

        public void addPassengerToList(String passenger)
        {
            passengerList.Add(passenger);

        }
        //Return the list containing the passenger data. 
        public static List<string> returnPassengerList()
        {
            var count = passengerList.Count;

            return passengerList;
        }
        // clear the list containing passengers
        public static void clearPassengerList()
        {
            passengerList = new List<string>();
        }
        //return size of passenger List, used to fill passengers in view
        public int returnListCount()
        {

            return passengerList.Count;
        }
        //update passenger list if passenger added or deleted in review passenger view
        public static void updatePassengerList(List<string> newList)
        {
            passengerList = newList;
        }
        //Save a flight card to the array after entered using add flight card
        public void SaveFlightCard(FlightCards card)
        {
            flightCards.Add(card);

        }
        //fill the pilot picker from the database table 
        public List<string> FillPilotPicker()
        {
            List<PilotsTable> pilots = new List<PilotsTable>();
            List<string> pilotsNames = new List<string>();
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var query = connection.Table<PilotsTable>();

                foreach (PilotsTable pilot in query)
                {
                    pilots.Add(pilot);
                }

            };
            for (int i = 0; i < pilots.Count; i++)
            {
                string pilotName = pilots[i].pilotName;
                pilotsNames.Add(pilotName);
            }
            return pilotsNames;
        }
        //fill lease picker from the database
        public List<string> FillLeasePicker()
        {
            List<LeaseTable> leaseTableNames = new List<LeaseTable>();
            List<string> leaseNames = new List<string>();

            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var query = connection.Table<LeaseTable>();

                foreach (LeaseTable lease in query)
                {
                    leaseTableNames.Add(lease);
                }

            };
            for (int i = 0; i < leaseTableNames.Count; i++)
            {
                string leaseName = leaseTableNames[i].leaseName;
                leaseNames.Add(leaseName);
            }
            return leaseNames;
        }

        //fill plane picker from database
        public List<string> FillPlanePicker()
        {
            List<PlaneTypeTable> planes = new List<PlaneTypeTable>();
            List<string> planeNames = new List<string>();
           
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var query = connection.Table<PlaneTypeTable>();

                foreach (PlaneTypeTable plane in query)
                {
                    planes.Add(plane);
                }

            };
            for (int i = 0; i < planes.Count; i++)
            {
                string planeName = planes[i].planeType;
                planeNames.Add(planeName);
            }
            return planeNames;
        }
        public void saveAll()//helper method to save flightcards.
        {
            SaveFlightCardTotal(flightCards);
        }
        //save the list of flightcards to the database.

        public void SaveFlightCardTotal(List<FlightCards> cards)
        {
           
            foreach (FlightCards card in cards)
            {


                List<string> passengers = card.getPassengers();


                string svDateIn = card.dateIn;
                DateTime svDateOut = card.dateOut;
                string svDestination = card.destination;
                string svHobbsIn = card.hobbsIn;
                string svHobbsOut = card.hobbsOut;
                string svTotalHobbs = card.totalHobbs;
                string svCashSpent = card.cashSpent;
                string svFlightType = card.flightType;
                string svPilot = card.pilot;
                string svPlaneType = card.planeType;
                string svLease = card.leaseName;
                string svPassenger1 = card.passenger1;
                string svPassenger2 = card.passenger2;
                string svPassenger3 = card.passenger3;
                string svPassenger4 = card.passenger4;
                string svPassenger5 = card.passenger5;
                string svPassenger6 = card.passenger6;
                string svPassenger7 = card.passenger7;
                string svPassenger8 = card.passenger8;
                string svPassenger9 = card.passenger9;
                string svPassenger10 = card.passenger10;
                string svPassenger11 = card.passenger11;
                string svPassenger12 = card.passenger12;
                string svPassenger13 = card.passenger13;
                string svPassenger14 = card.passenger14;
                string svPassenger15 = card.passenger15;
                string svPassenger16 = card.passenger16;
                string svPassenger17 = card.passenger17;
                string svPassenger18 = card.passenger18;
                string svPassenger19 = card.passenger19;
                string svPassenger20 = card.passenger20;
                string svPassenger21 = card.passenger21;
                string svPassenger22 = card.passenger22;
                string svPassenger23 = card.passenger23;
                string svPassenger24 = card.passenger24;




                using (var connection = new SQLiteConnection(pathToDatabase))
                {
                    connection.Insert(new FlightCardTable()
                    {

                        dateOut = svDateOut,
                        dateIn = svDateIn,
                        destination = svDestination,
                        hobbsIn = svHobbsIn,
                        hobbsOut = svHobbsOut,
                        hobbsTotal = svTotalHobbs,
                        cashSpent = svCashSpent,
                        flightType = svFlightType,
                        leaseName = svLease,
                        pilotName = svPilot,
                        planeType = svPlaneType,
                        passenger1 = svPassenger1,
                        passenger2 = svPassenger2,
                        passenger3 = svPassenger3,
                        passenger4 = svPassenger4,
                        passenger5 = svPassenger5,
                        passenger6 = svPassenger6,
                        passenger7 = svPassenger7,
                        passenger8 = svPassenger8,
                        passenger9 = svPassenger9,
                        passenger10 = svPassenger10,
                        passenger11 = svPassenger11,
                        passenger12 = svPassenger12,
                        passenger13 = svPassenger13,
                        passenger14 = svPassenger14,
                        passenger15 = svPassenger15,
                        passenger16 = svPassenger16,
                        passenger17 = svPassenger17,
                        passenger18 = svPassenger18,
                        passenger19 = svPassenger19,
                        passenger20 = svPassenger20,
                        passenger21 = svPassenger21,
                        passenger22 = svPassenger22,
                        passenger23 = svPassenger23,
                        passenger24 = svPassenger24
                    });
                }
            }
            cards.Clear();
        }
        //add to this table when updating and no internt connection, for later use to update remote database when connection 
        //changes.

        internal void AddtoUpdateTable(FlightCards newCard)
        {

            using(var connection = new SQLiteConnection(pathToDatabase)){

                connection.Insert(new UpdateTable()
                {
                    dateOut = newCard.dateOut,dateIn = newCard.dateIn,destination= newCard.destination,
                    hobbsIn = newCard.hobbsIn,hobbsOut = newCard.hobbsOut,hobbsTotal = newCard.totalHobbs,
                    cashSpent = newCard.cashSpent,flightType = newCard.flightType,pilotName =newCard.pilot,
                    planeType = newCard.planeType,leaseName = newCard.leaseName,passenger1 = newCard.passenger1,
                    passenger2 = newCard.passenger2,passenger3 = newCard.passenger3,passenger4 = newCard.passenger4,
                    passenger5 = newCard.passenger5, passenger6 = newCard.passenger6, passenger7 = newCard.passenger7,
                    passenger8 = newCard.passenger8,passenger9 = newCard.passenger9, passenger10 = newCard.passenger10,
                    passenger11 = newCard.passenger11, passenger12 = newCard.passenger12, passenger13 = newCard.passenger13,
                    passenger14 = newCard.passenger14, passenger15 = newCard.passenger15, passenger16 = newCard.passenger16,
                    passenger17 = newCard.passenger17, passenger18 = newCard.passenger19, passenger20 = newCard.passenger20,
                    passenger21 = newCard.passenger21, passenger22 = newCard.passenger22, passenger23 = newCard.passenger23,
                    passenger24 = newCard.passenger24
                });
            }
                
        }
        //add to this table when there is no internet,for later use to add to remote database when connection changes.

        internal void AddToAddTable(FlightCards newCard){
            using (var connection = new SQLiteConnection(pathToDatabase))
            {

                connection.Insert(new AddTable()
                {
                    dateOut = newCard.dateOut,
                    dateIn = newCard.dateIn,
                    destination = newCard.destination,
                    hobbsIn = newCard.hobbsIn,
                    hobbsOut = newCard.hobbsOut,
                    hobbsTotal = newCard.totalHobbs,
                    cashSpent = newCard.cashSpent,
                    flightType = newCard.flightType,
                    pilotName = newCard.pilot,
                    planeType = newCard.planeType,
                    leaseName = newCard.leaseName,
                    passenger1 = newCard.passenger1,
                    passenger2 = newCard.passenger2,
                    passenger3 = newCard.passenger3,
                    passenger4 = newCard.passenger4,
                    passenger5 = newCard.passenger5,
                    passenger6 = newCard.passenger6,
                    passenger7 = newCard.passenger7,
                    passenger8 = newCard.passenger8,
                    passenger9 = newCard.passenger9,
                    passenger10 = newCard.passenger10,
                    passenger11 = newCard.passenger11,
                    passenger12 = newCard.passenger12,
                    passenger13 = newCard.passenger13,
                    passenger14 = newCard.passenger14,
                    passenger15 = newCard.passenger15,
                    passenger16 = newCard.passenger16,
                    passenger17 = newCard.passenger17,
                    passenger18 = newCard.passenger19,
                    passenger20 = newCard.passenger20,
                    passenger21 = newCard.passenger21,
                    passenger22 = newCard.passenger22,
                    passenger23 = newCard.passenger23,
                    passenger24 = newCard.passenger24
                });
            }
        }

        //add to thise table when no internect connetion, for later use to delte from remote database when connection changes.
        public static void  AddToDeleteTable(FlightCards newCard){
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var pathToDatabase = Path.Combine(documentsFolder, "FlightCard.db");//location database

            using (var connection = new SQLiteConnection(pathToDatabase))
            {

                connection.Insert(new DeleteTable()
                {
                    dateOut = newCard.dateOut,
                    dateIn = newCard.dateIn,
                    destination = newCard.destination,
                    hobbsIn = newCard.hobbsIn,
                    hobbsOut = newCard.hobbsOut,
                    hobbsTotal = newCard.totalHobbs,
                    cashSpent = newCard.cashSpent,
                    flightType = newCard.flightType,
                    pilotName = newCard.pilot,
                    planeType = newCard.planeType,
                    leaseName = newCard.leaseName,
                    passenger1 = newCard.passenger1,
                    passenger2 = newCard.passenger2,
                    passenger3 = newCard.passenger3,
                    passenger4 = newCard.passenger4,
                    passenger5 = newCard.passenger5,
                    passenger6 = newCard.passenger6,
                    passenger7 = newCard.passenger7,
                    passenger8 = newCard.passenger8,
                    passenger9 = newCard.passenger9,
                    passenger10 = newCard.passenger10,
                    passenger11 = newCard.passenger11,
                    passenger12 = newCard.passenger12,
                    passenger13 = newCard.passenger13,
                    passenger14 = newCard.passenger14,
                    passenger15 = newCard.passenger15,
                    passenger16 = newCard.passenger16,
                    passenger17 = newCard.passenger17,
                    passenger18 = newCard.passenger19,
                    passenger20 = newCard.passenger20,
                    passenger21 = newCard.passenger21,
                    passenger22 = newCard.passenger22,
                    passenger23 = newCard.passenger23,
                    passenger24 = newCard.passenger24
                });
            }
        }
        // method to update remote database from the update, add, delete tables
        public void QueryUpdateTables(){
            
            using (var connection = new SQLiteConnection(pathToDatabase)){
                var selectQuery = "SELECT * FROM AddTable  ";
                var query = connection.Query<AddTable>(selectQuery);
                foreach (var card in query){
                    FlightCards addCard = new FlightCards(card.dateOut, card.dateIn, card.destination, card.hobbsIn, card.hobbsOut,
                                                         card.hobbsTotal, card.cashSpent, card.flightType, card.pilotName, card.planeType,
                                                         card.leaseName, card.passenger1, card.passenger2, card.passenger3, card.passenger4,
                                                         card.passenger5, card.passenger6, card.passenger7, card.passenger8, card.passenger9,
                                                         card.passenger10, card.passenger11, card.passenger12, card.passenger13, card.passenger14,
                                                         card.passenger15, card.passenger16, card.passenger17, card.passenger18, card.passenger19,
                                                          card.passenger20, card.passenger21, card.passenger22, card.passenger23, card.passenger24);
                    ws.SaveToServiceAsync(addCard);
                }
                var selectQuery2 = "SELECT * FROM UpdateTable ";
                var query2 = connection.Query<UpdateTable>(selectQuery2);
                foreach (var card in query2)
                {
                    FlightCards updateCard = new FlightCards(card.dateOut, card.dateIn, card.destination, card.hobbsIn, card.hobbsOut,
                                                         card.hobbsTotal, card.cashSpent, card.flightType, card.pilotName, card.planeType,
                                                         card.leaseName, card.passenger1, card.passenger2, card.passenger3, card.passenger4,
                                                         card.passenger5, card.passenger6, card.passenger7, card.passenger8, card.passenger9,
                                                         card.passenger10, card.passenger11, card.passenger12, card.passenger13, card.passenger14,
                                                         card.passenger15, card.passenger16, card.passenger17, card.passenger18, card.passenger19,
                                                          card.passenger20, card.passenger21, card.passenger22, card.passenger23, card.passenger24);
                    ws.updateFlightCard(updateCard);
                }
                var selectQuery3 = "SELECT * FROM DeleteTable";
                var query3 = connection.Query<DeleteTable>(selectQuery3);
                foreach (var card in query3)
                {
                    FlightCards deleteCard = new FlightCards(card.dateOut, card.dateIn, card.destination, card.hobbsIn, card.hobbsOut,
                                                         card.hobbsTotal, card.cashSpent, card.flightType, card.pilotName, card.planeType,
                                                         card.leaseName, card.passenger1, card.passenger2, card.passenger3, card.passenger4,
                                                         card.passenger5, card.passenger6, card.passenger7, card.passenger8, card.passenger9,
                                                         card.passenger10, card.passenger11, card.passenger12, card.passenger13, card.passenger14,
                                                         card.passenger15, card.passenger16, card.passenger17, card.passenger18, card.passenger19,
                                                         card.passenger20, card.passenger21, card.passenger22, card.passenger23, card.passenger24);
                    ws.DeleteAsync(deleteCard);
                }
            }
            using(var connection = new SQLiteConnection(pathToDatabase)){
                var deleteQuery1 = "DELETE FROM AddTable";
                connection.Execute(deleteQuery1);
                var deleteQuery2 = "DELETE FROM UpdateTable";
                connection.Execute(deleteQuery2);
                var deleteQuery3 = "DELETE FROM DeleteTable";
                connection.Execute(deleteQuery3);
                
            }

        }

        //try new class save from remote database.
        public void SaveTransferIn(List<FlightCards> cards)
        {

            foreach (var card in cards)
            {


                List<string> passengers = card.getPassengers();


                string svDateIn = card.dateIn;
                DateTime svDateOut = card.dateOut;
                string svDestination = card.destination;
                string svHobbsIn = card.hobbsIn;
                string svHobbsOut = card.hobbsOut;
                string svTotalHobbs = card.totalHobbs;
                string svCashSpent = card.cashSpent;
                string svFlightType = card.flightType;
                string svPilot = card.pilot;
                string svPlaneType = card.planeType;
                string svLease = card.leaseName;
                string svPassenger1 = card.passenger1;
                string svPassenger2 = card.passenger2;
                string svPassenger3 = card.passenger3;
                string svPassenger4 = card.passenger4;
                string svPassenger5 = card.passenger5;
                string svPassenger6 = card.passenger6;
                string svPassenger7 = card.passenger7;
                string svPassenger8 = card.passenger8;
                string svPassenger9 = card.passenger9;
                string svPassenger10 = card.passenger10;
                string svPassenger11 = card.passenger11;
                string svPassenger12 = card.passenger12;
                string svPassenger13 = card.passenger13;
                string svPassenger14 = card.passenger14;
                string svPassenger15 = card.passenger15;
                string svPassenger16 = card.passenger16;
                string svPassenger17 = card.passenger17;
                string svPassenger18 = card.passenger18;
                string svPassenger19 = card.passenger19;
                string svPassenger20 = card.passenger20;
                string svPassenger21 = card.passenger21;
                string svPassenger22 = card.passenger22;
                string svPassenger23 = card.passenger23;
                string svPassenger24 = card.passenger24;
                //int Id = card.Id;



               
                using (var connection = new SQLiteConnection(pathToDatabase))
                {
                    connection.Insert(new FlightCardTable()
                    {
                       // ID = Id,
                        dateOut = svDateOut,
                        dateIn = svDateIn,
                        destination = svDestination,
                        hobbsIn = svHobbsIn,
                        hobbsOut = svHobbsOut,
                        hobbsTotal = svTotalHobbs,
                        cashSpent = svCashSpent,
                        flightType = svFlightType,
                        leaseName = svLease,
                        pilotName = svPilot,
                        planeType = svPlaneType,
                        passenger1 = svPassenger1,
                        passenger2 = svPassenger2,
                        passenger3 = svPassenger3,
                        passenger4 = svPassenger4,
                        passenger5 = svPassenger5,
                        passenger6 = svPassenger6,
                        passenger7 = svPassenger7,
                        passenger8 = svPassenger8,
                        passenger9 = svPassenger9,
                        passenger10 = svPassenger10,
                        passenger11 = svPassenger11,
                        passenger12 = svPassenger12,
                        passenger13 = svPassenger13,
                        passenger14 = svPassenger14,
                        passenger15 = svPassenger15,
                        passenger16 = svPassenger16,
                        passenger17 = svPassenger17,
                        passenger18 = svPassenger18,
                        passenger19 = svPassenger19,
                        passenger20 = svPassenger20,
                        passenger21 = svPassenger21,
                        passenger22 = svPassenger22,
                        passenger23 = svPassenger23,
                        passenger24 = svPassenger24
                    });
                }
            }
        } 
        //fills array from local db
        internal List<FlightCards> LoadArray(string startRange)
        {

            //fill offline database from webservice
            String range = startRange;
            if(range == ""){
                range = DateTime.Now.ToString("MM/dd/yyyy");
            }

            if (!Reachability.IsHostReachable("http://google.com"))
            {

                Console.Out.WriteLine("connected to network");
            }
            else
            {
                ToastIOS.Toast.MakeText("Internet Unavailabe, cannot update with remote database,using offline database");
            }



            List<FlightCards> fCards = new List<FlightCards>();
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            using (var connection = new SQLiteConnection(pathToDatabase))
            {

                var beginRange = DateTime.Parse(range).ToString("MM/dd/yyyy");
                var endRange = DateTime.Parse(range).AddDays(-60).ToString("MM/dd/yyyy");
                DateTime begin = DateTime.Parse(beginRange).AddDays(1);
                 
                DateTime end = DateTime.Parse(endRange).AddDays(-60);
               
                 var Selectquery = "SELECT * FROM FlightCardTable ORDER BY dateOut DESC";

                var query = connection.Query<FlightCardTable>(Selectquery);
                List<string> passengers = new List<string>();
                foreach (var card in query)
                {

                    int svId = card.ID;

                    string svDateIn = card.dateIn;
                    DateTime svDateOut = card.dateOut;
                    string svDestination = card.destination;
                    string svHobbsIn = card.hobbsIn;
                    string svHobbsOut = card.hobbsOut;
                    string svTotalHobbs = card.hobbsTotal;
                    string svCashSpent = card.cashSpent;
                    string svFlightType = card.flightType;
                    string svPilot = card.pilotName;
                    string svPlaneType = card.planeType;
                    string svLease = card.leaseName;
                    string svPassenger1 = card.passenger1;
                    string svPassenger2 = card.passenger2;
                    string svPassenger3 = card.passenger3;
                    string svPassenger4 = card.passenger4;
                    string svPassenger5 = card.passenger5;
                    string svPassenger6 = card.passenger6;
                    string svPassenger7 = card.passenger7;
                    string svPassenger8 = card.passenger8;
                    string svPassenger9 = card.passenger9;
                    string svPassenger10 = card.passenger10;
                    string svPassenger11 = card.passenger11;
                    string svPassenger12 = card.passenger12;
                    string svPassenger13 = card.passenger13;
                    string svPassenger14 = card.passenger14;
                    string svPassenger15 = card.passenger15;
                    string svPassenger16 = card.passenger16;
                    string svPassenger17 = card.passenger17;
                    string svPassenger18 = card.passenger18;
                    string svPassenger19 = card.passenger19;
                    string svPassenger20 = card.passenger20;
                    string svPassenger21 = card.passenger21;
                    string svPassenger22 = card.passenger22;
                    string svPassenger23 = card.passenger23;
                    string svPassenger24 = card.passenger24;
                    passengers.Add(svPassenger1);
                    passengers.Add(svPassenger2);
                    passengers.Add(svPassenger3);
                    passengers.Add(svPassenger4);
                    passengers.Add(svPassenger5);
                    passengers.Add(svPassenger6);
                    passengers.Add(svPassenger7);
                    passengers.Add(svPassenger8);
                    passengers.Add(svPassenger9);
                    passengers.Add(svPassenger10);
                    passengers.Add(svPassenger11);
                    passengers.Add(svPassenger12);
                    passengers.Add(svPassenger13);
                    passengers.Add(svPassenger14);
                    passengers.Add(svPassenger15);
                    passengers.Add(svPassenger16);
                    passengers.Add(svPassenger17);
                    passengers.Add(svPassenger18);
                    passengers.Add(svPassenger19);
                    passengers.Add(svPassenger20);
                    passengers.Add(svPassenger21);
                    passengers.Add(svPassenger22);
                    passengers.Add(svPassenger23);
                    passengers.Add(svPassenger24);
                    FlightCards fCard = new FlightCards(svDateOut, svDateIn, svDestination, svHobbsIn,
                                                       svHobbsOut, svTotalHobbs, svCashSpent,
                                                       svFlightType, svPilot, svPlaneType, svLease,
                                                        svPassenger1, svPassenger2, svPassenger3, svPassenger4, svPassenger5, svPassenger6,
                                                        svPassenger7, svPassenger8, svPassenger9, svPassenger10,
                                                       svPassenger11, svPassenger12, svPassenger13, svPassenger14, svPassenger15,
                                                       svPassenger16, svPassenger17, svPassenger18, svPassenger19,
                                                        svPassenger20, svPassenger21, svPassenger22, svPassenger23, svPassenger24);



                    if (fCard.dateOut <= begin && fCard.dateOut >= end){
                        fCards.Add(fCard);
                    }
                }
                return fCards;
            }

        }
        //delete row from local db

        public static void deleteRecordFromFlightCards(FlightCards card)
        {
            WebService ws = new WebService();
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string pathToDatabase = Path.Combine(documentFolder, "FlightCard.db");
            var delDateOut = card.dateOut;
            var delDateIn = card.dateIn;
            var delPilot = card.pilot;
            var deldestination = card.destination;
            var delHobbsIn = card.hobbsIn;
            var delHobbsOut = card.hobbsOut;
            var delHobbsTotal = card.totalHobbs;
            var delCashSpent = card.cashSpent;
            var delLease = card.leaseName;

            var deleteQuery = string.Format("DELETE FROM FlightCardTable WHERE dateOut='" + delDateOut + "'" +
                                      "AND dateIn='" + delDateIn + "'" +
                                           "AND pilotName='" + delPilot + "'" +
                                         "AND destination='" + deldestination + "'" +
                                            "AND hobbsIn='" + delHobbsIn + "'" +
                                            "AND hobbsOut='" + delHobbsOut + "'" +
                                            "And hobbsTotal='" + delHobbsTotal + "'" +
                                            "AND cashSpent='" + delCashSpent + "'" +
                                            "AND leaseName='" + delLease + "'");

            using (var connection = new SQLiteConnection(pathToDatabase))
            {

                connection.Execute(deleteQuery);
            }
            AddToDeleteTable(card);
          /*  Reachability.InternetConnectionStatus();
            Reachability.LocalWifiConnectionStatus();
            Reachability.RemoteHostStatus(); 
            if (!Reachability.IsHostReachable("http://www.google.com"))
            {

                ws.DeleteAsync(card);
            }
            else{
               AddToDeleteTable(card);
            }*/
               

        }
        //save to database when flight card updated
        public void updateFlightCardTable(FlightCards card)
        {




            List<string> passengers = card.getPassengers();
            string svDateIn = card.dateIn;
            SqlDateTime svDateOut = card.dateOut;
            string svDestination = card.destination;
            string svHobbsIn = card.hobbsIn;
            string svHobbsOut = card.hobbsOut;
            string svTotalHobbs = card.totalHobbs;
            string svCashSpent = card.cashSpent;
            string svFlightType = card.flightType;
            string svPilot = card.pilot;
            string svPlaneType = card.planeType;
            string svLease = card.leaseName;
            string svPassenger1 = card.passenger1;
            string svPassenger2 = card.passenger2;
            string svPassenger3 = card.passenger3;
            string svPassenger4 = card.passenger4;
            string svPassenger5 = card.passenger5;
            string svPassenger6 = card.passenger6;
            string svPassenger7 = card.passenger7;
            string svPassenger8 = card.passenger8;
            string svPassenger9 = card.passenger9;
            string svPassenger10 = card.passenger10;
            string svPassenger11 = card.passenger11;
            string svPassenger12 = card.passenger12;
            string svPassenger13 = card.passenger13;
            string svPassenger14 = card.passenger14;
            string svPassenger15 = card.passenger15;
            string svPassenger16 = card.passenger16;
            string svPassenger17 = card.passenger17;
            string svPassenger18 = card.passenger18;
            string svPassenger19 = card.passenger19;
            string svPassenger20 = card.passenger20;
            string svPassenger21 = card.passenger21;
            string svPassenger22 = card.passenger22;
            string svPassenger23 = card.passenger23;
            string svPassenger24 = card.passenger24;

          
            var UpdateQuery = string.Format("UPDATE  FlightCardTable SET dateOut='" + card.dateOut + "'" +
                                            ",dateIn='" + svDateIn + "'" +
                                            ",destination='" + card.destination + "'" +
                                            ",hobbsIn='" + card.hobbsIn + "'" +
                                            ",hobbsOut='" + card.hobbsOut + "'" +
                                            ",hobbsTotal='" + card.totalHobbs + "'" +
                                            ",cashSpent='" + card.cashSpent + "'" +
                                            ",flightType='" + card.flightType + "'" +
                                            ",pilotName='" + card.pilot + "'" +
                                            ",flightType='" + card.flightType + "'" +
                                            ",planeType='" + card.planeType + "'" +
                                            ",leaseName='" + card.leaseName + "'" +
                                            ",passenger1='" + svPassenger1 + "'" +
                                            ",passenger2='" + svPassenger2 + "'" +
                                            ",passenger3='" + svPassenger3 + "'" +
                                            ",passenger4='" + svPassenger4 + "'" +
                                            ",passenger5='" + svPassenger5 + "'" +
                                            ",passenger6='" + svPassenger6 + "'" +
                                            ",passenger7='" + svPassenger7 + "'" +
                                            ",passenger8='" + svPassenger8 + "'" +
                                            ",passenger9='" + svPassenger9 + "'" +
                                            ",passenger10='" + svPassenger10 + "'" +
                                            ",passenger11='" + svPassenger11 + "'" +
                                            ",passenger12='" + svPassenger12 + "'" +
                                            ",passenger13='" + svPassenger13 + "'" +
                                            ",passenger14='" + svPassenger14 + "'" +
                                            ",passenger15='" + svPassenger15 + "'" +
                                            ",passenger16='" + svPassenger16 + "'" +
                                            ",passenger17='" + svPassenger17 + "'" +
                                            ",passenger18='" + svPassenger18 + "'" +
                                            ",passenger19='" + svPassenger19 + "'" +
                                            ",passenger20='" + svPassenger20 + "'" +
                                            ",passenger21='" + svPassenger21 + "'" +
                                            ",passenger22='" + svPassenger22 + "'" +
                                            ",passenger23='" + svPassenger23 + "'" +
                                            ",passenger24='" + svPassenger24 + "'" +
                                            "WHERE dateOut='" + card.dateOut + "'" +
                                            "AND dateIn='" + editCard.dateIn + "'" +
                                            "AND pilotName='" + editCard.pilot + "'" +
                                            "AND destination='" + editCard.destination + "'" +
                                            "AND hobbsIn='" + editCard.hobbsIn + "'" +
                                            "AND hobbsOut='" + editCard.hobbsOut + "'" +
                                            "And hobbsTotal='" + editCard.totalHobbs + "'" +
                                            "AND cashSpent='" + editCard.cashSpent + "'" +
                                            "AND leaseName='" + editCard.leaseName + "'");



            using (var connection = new SQLiteConnection(pathToDatabase))
            {

                connection.Execute(UpdateQuery);
            }
        }
        public void DeletePilot(string name)
        {
            Pilot pilot = new Pilot(name);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var deleteQuery = string.Format("DELETE FROM pilotsTable WHERE pilotName='" +
                                           name + "'");
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                connection.Execute(deleteQuery);
            }
            if (Reachability.IsHostReachable("http://www.google.com"))
            {
                ws.deletePilot(pilot);
            }
            else
            {
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus();
                Reachability.ReachabilityChanged += delegate
                {
                    if (Reachability.IsHostReachable("http://www.google.com"))
                    {
                        ws.deletePilot(pilot);
                    }
                };
            }

        }
        public void AddPilot(string name)
        {
            Pilot pilot = new Pilot(name);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                connection.Insert(new PilotsTable()
                {
                    pilotName = name
                });
            }
            if (Reachability.IsHostReachable("https://www.google.com"))
            {
                ws.addPilot(pilot);
            }
            else
            {
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus();
                Reachability.ReachabilityChanged += delegate
                {

                    if (Reachability.IsHostReachable("http:www.google.com"))
                    {
                        ws.addPilot(pilot);
                    }
                };

            }
        }
        public void DeleteLease(string name)
        {
            Lease lease = new Lease(name);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var deleteQuery = string.Format("DELETE FROM leaseTable WHERE leaseName='" +
                                              name + "'");
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                connection.Execute(deleteQuery);
            }
            if (Reachability.IsHostReachable("http://www.google.com"))
            {
                ws.deleteLease(lease);
            }
            else
            {
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus();
                Reachability.ReachabilityChanged += delegate
                {
                    if (Reachability.IsHostReachable("http://www.google.com"))
                    {
                        ws.deleteLease(lease);
                    }
                };
            }
        }
        public void AddLease(string name)
        {
            Lease lease = new Lease(name);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                connection.Insert(new LeaseTable()
                {
                    leaseName = name
                });
            }
            if (Reachability.IsHostReachable("http://www.gogole.com"))
            {
                ws.addLease(lease);
            }
            else
            {
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus();
                Reachability.ReachabilityChanged += delegate
                {
                    if (Reachability.IsHostReachable("http://www.google.com"))
                    {
                        ws.addLease(lease);
                    }
                };
            }

        }

        public void DeletePlane(string name)
        {
            Plane plane = new Plane(name);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var deleteQuery = string.Format("DELETE FROM planeTypeTable WHERE planeType='" +
                                              name + "'");
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                connection.Execute(deleteQuery);
            }
            if (Reachability.IsHostReachable("http://www.google.com"))
            {
                ws.deletePlane(plane);
            }
            else
            {
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus();
                Reachability.ReachabilityChanged += delegate
                {
                    if (Reachability.IsHostReachable("http://www.google.com"))
                    {
                        ws.deletePlane(plane);
                    }
                };
            }
        }
        public void AddPlane(string name)
        {
            Plane plane = new Plane(name);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                connection.Insert(new PlaneTypeTable()
                {
                    planeType = name
                });
            }
            if (Reachability.IsHostReachable("http://www.google.com"))
            {
                ws.addPlane(plane);
            }
            else
            {
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus();
                Reachability.ReachabilityChanged += delegate
                {
                    if (Reachability.IsHostReachable("http://www.google.com"))
                    {
                        ws.addPlane(plane);
                    }
                };
            }

        }
       
        //method downloads info from remote database and stores in list
        //gets data from local database and stores in list
        //both lists are compared and calls method to update remote database
        //with data it is missing. 

        public void updateLocalFromRemote()
        {
            /*  using (var connection = new SQLiteConnection(pathToDatabase))
              {
                  String sql = "DROP TABLE FlightCardTable";
                  connection.Execute(sql);
                  connection.CreateTable<FlightCardTable>();
              }*/

            List<FlightCards> remoteCards = new List<FlightCards>();
            List<FlightCards> localCards = new List<FlightCards>();
            List<FlightCards> differentCards = new List<FlightCards>();
            localCards = LoadArray("");


            if (localCards.Count == 0)//if local database empty
            {
                remoteCards = ws.FillFromService();
                Console.Out.WriteLine("local cards empty");
                SaveTransferIn(remoteCards);

            }
            else
            {
                if (remoteCards.Count != 0)
                {
                    if (localCards.Count > remoteCards.Count)
                    {
                        var difference = localCards.Count - remoteCards.Count;
                        for (int i = difference; i < localCards.Count; i++)
                        {
                            ws.SaveToServiceAsync(localCards[i]);
                        }
                    }
                }

                remoteCards = ws.FillFromService();

                using (var connection = new SQLiteConnection(pathToDatabase))
                {

                    String sql = "DROP TABLE FlightCardTable";
                    connection.Execute(sql);
                    connection.CreateTable<FlightCardTable>();
                }
                if (remoteCards != null)
                {
                    SaveTransferIn(remoteCards);
                }
            }
        }
        //method downloads info from remote database and stores in list
        //gets data from local database and stores in list
        //both lists are compared and calls method to update remote database
        //with data it is missing. 
        public void updatePilotFromRemote()
        {
            List<Pilot> remotePilots = new List<Pilot>();
            List<Pilot> localPilots = new List<Pilot>();
            List<string> pickerString = new List<string>();
            pickerString = FillPilotPicker();
            foreach (var pString in pickerString)
            {
                Pilot pilot = new Pilot(pString);
                localPilots.Add(pilot);
            }
            remotePilots = ws.getPilots();
            if(remotePilots.Count() == 0 ){
                foreach(var pilot in localPilots){
                    ws.addPilot(pilot);
                }
                
            }
            foreach (var pilot in remotePilots)
            {
                if (!localPilots.Contains(pilot))
                {
                    AddPilot(pilot.pilotName);
                }
            }
            foreach (var pilot in localPilots)
            {
                if (!remotePilots.Contains(pilot))
                {
                    DeletePilot(pilot.pilotName);
                }
            }


        }





        //method downloads info from remote database and stores in list
        //gets data from local database and stores in list
        //both lists are compared and calls method to update remote database
        //with data it is missing. 
        public void updatePlaneFromRemote()
        {
            List<Plane> remotePlanes = new List<Plane>();
            List<Plane> localPlanes = new List<Plane>();
            List<string> pickerString = new List<string>();

            pickerString = FillPlanePicker();
            foreach (var pString in pickerString)
            {
                Plane plane = new Plane(pString);
                localPlanes.Add(plane);
            }
            remotePlanes = ws.getPlanes();
            if(remotePlanes.Count()==0 ){
                foreach(var plane in localPlanes){
                    ws.addPlane(plane);
                }
            }

            foreach (var plane in remotePlanes)
            {
                if (!localPlanes.Contains(plane))
                {
                    AddPlane(plane.name);
                }
            }
            foreach (var plane in localPlanes)
            {
                if (!remotePlanes.Contains(plane))
                {
                    DeletePlane(plane.name);
                }
            }


        }


        //method downloads info from remote database and stores in list
        //gets data from local database and stores in list
        //both lists are compared and calls method to update remote database
        //with data it is missing. 
        public void updateLeaseFromRemote()
        {
            List<Lease> remoteLease = new List<Lease>();
            List<Lease> localLease = new List<Lease>();
            List<string> pickerString = new List<string>();

            pickerString = FillLeasePicker();
            foreach (var pString in pickerString)
            {
                Lease lease = new Lease(pString);
                localLease.Add(lease);
            }
            remoteLease = ws.getLeases();
            if(remoteLease.Count()==0 ){
                foreach(var lease in localLease){
                    ws.addLease(lease);
                }
            }
            foreach (var lease in remoteLease)
            {
                if (!localLease.Contains(lease))
                {
                    AddLease(lease.name);
                }
            }
            foreach (var lease in localLease)
            {
                if (!remoteLease.Contains(lease))
                {
                    DeleteLease(lease.name);
                }
            }

        }
        public String FillHobbsIn(string name)
        {
            List<string> hobbs = new List<string>();
            var selectQuery = "SELECT * FROM FlightCardTable WHERE planeType ='" + name + "' ORDER BY ID DESC";
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var query = connection.Query<FlightCardTable>(selectQuery);
                foreach (var card in query)
                {
                    var hobb = card.hobbsOut;
                    if (hobb != "")
                    {
                        hobbs.Add(hobb);
                    }
                }
            }
            if (hobbs.Count > 0)
            {
                return hobbs[0];
            }
            else
                return null;
        }
        //query local database for batch print
        public List<FlightCards> BatchEmail(string startDate, string endDate)

        {

               
            var startDate2 = DateTime.Parse(startDate).ToString("MM/dd/yyyy");
            var endDate2 = DateTime.Parse(endDate).ToString("MM/dd/yyyy");

            DateTime start = DateTime.Parse(startDate2);
            DateTime end = DateTime.Parse(endDate2);

            List<FlightCards> flightCard = new List<FlightCards>();

            var selectQuery = "SELECT * FROM FlightCardTable ORDER BY planeType";
            using (var connection = new SQLiteConnection(pathToDatabase))
            {
                var query = connection.Query<FlightCardTable>(selectQuery);
                foreach (var card in query)
                {
                    FlightCards fcard = new FlightCards(card.dateOut, card.dateIn, card.destination, card.hobbsIn, card.hobbsOut,
                                                       card.hobbsTotal, card.cashSpent, card.flightType, card.pilotName, card.planeType,
                                                      card.leaseName, card.passenger1, card.passenger2, card.passenger3, card.passenger4, card.passenger5,
                                                      card.passenger6, card.passenger7, card.passenger8, card.passenger9, card.passenger10,
                                                      card.passenger11, card.passenger12, card.passenger13, card.passenger14, card.passenger15,
                                                      card.passenger16, card.passenger17, card.passenger18, card.passenger19, card.passenger20,
                                                       card.passenger21, card.passenger22, card.passenger23, card.passenger24);


                    if(card.dateOut >= start && card.dateOut <= end){
                        Console.Out.WriteLine("inside batch email in datamanip card.DateOut = " + card.dateOut);
                        flightCard.Add(fcard);
                    }


                }
                return flightCard;
            }
        }
          
    }
}


    



