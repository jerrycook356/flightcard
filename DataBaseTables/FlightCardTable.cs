using System;
using System.Data.SqlTypes;
using SQLite;
namespace practice2
{
    public class FlightCardTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime dateOut { get; set; }
        public string dateIn { get; set; }
        public string destination { get; set; }
        public  string hobbsIn { get; set; }
        public string hobbsOut { get; set; }
        public string hobbsTotal { get; set; }
        public string cashSpent { get; set; }
        public string flightType { get; set; }
        public string leaseName { get; set; }
        public string pilotName { get; set; }
        public string planeType { get; set; }
        public string passenger1 { get; set; }
        public string passenger2 { get; set; }
        public string passenger3 { get; set; }
        public string passenger4 { get; set; }
        public string passenger5 { get; set; }
        public string passenger6 { get; set; }
        public string passenger7 { get; set; }
        public string passenger8 { get; set; }
        public string passenger9 { get; set; }
        public string passenger10 { get; set; }
        public string passenger11 { get; set; }
        public string passenger12 { get; set; }
        public string passenger13 { get; set; }
        public string passenger14 { get; set; }
        public string passenger15 { get; set; }
        public string passenger16 { get; set; }
        public string passenger17 { get; set; }
        public string passenger18 { get; set; }
        public string passenger19 { get; set; }
        public string passenger20 { get; set; }
        public string passenger21 { get; set; }
        public string passenger22 { get; set; }
        public string passenger23 { get; set; }
        public string passenger24 { get; set; }


    }

}