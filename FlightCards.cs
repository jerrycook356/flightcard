using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace practice2
{
    public class FlightCards
    {


        public DateTime dateOut;
        public string dateIn;
        public string destination;
        public string hobbsIn;
        public string hobbsOut;
        public string totalHobbs;
        public string cashSpent;
        public string flightType;
        public string pilot;
        public string planeType;
        public string leaseName;
        public string passenger1;
		public string passenger2;
		public string passenger3;
		public string passenger4;
		public string passenger5;
		public string passenger6;
		public string passenger7;
		public string passenger8;
		public string passenger9;
		public string passenger10;
        public string passenger11;
		public string passenger12;
		public string passenger13;
		public string passenger14;
		public string passenger15;
		public string passenger16;
		public string passenger17;
		public string passenger18;
		public string passenger19;
		public string passenger20;
		public string passenger21;
		public string passenger22;
		public string passenger23;
		public string passenger24;



		
		public FlightCards(
                           DateTime dateOut, string dateIn, string destination,

						 string hobbsIn, string hobbsOut, string totalHobbs,
						 string cashSpent, string flightType, string pilot,
						  string planeType,string leaseName, string passenger1,string passenger2,
                          string passenger3,string passenger4,string passenger5,string passenger6,
                          string passenger7, string passenger8, string passenger9,string passenger10,
                          string passenger11, string passenger12, string passenger13,string passenger14,
                          string passenger15,string passenger16, string passenger17, string passenger18,
                          string passenger19, string passenger20, string passenger21, string passenger22,
                           string passenger23, string passenger24)

		{

			this.dateIn = dateIn;
			this.dateOut = dateOut;
			this.destination = destination;
			this.hobbsIn = hobbsIn;
			this.hobbsOut = hobbsOut;
			this.totalHobbs = totalHobbs;
			this.cashSpent = cashSpent;
			this.flightType = flightType;
			this.pilot = pilot;
            this.planeType = planeType;
			this.leaseName = leaseName;
            this.passenger1 = passenger1;
            this.passenger2 = passenger2;
            this.passenger3 = passenger3;
            this.passenger4 = passenger4;
            this.passenger5 = passenger5;
            this.passenger6 = passenger6;
            this.passenger7 = passenger7;
            this.passenger8 = passenger8;
            this.passenger9 = passenger9;
            this.passenger10 = passenger10;
            this.passenger11 = passenger11;
            this.passenger12 = passenger12;
            this.passenger13 = passenger13;
            this.passenger14 = passenger14;
            this.passenger15 = passenger15;
            this.passenger16 = passenger16;
            this.passenger17 = passenger17;
            this.passenger18 = passenger18;
            this.passenger19 = passenger19;
            this.passenger20 = passenger20;
            this.passenger21 = passenger21;
            this.passenger22 = passenger22;
            this.passenger23 = passenger23;
            this.passenger24 = passenger24;
		}
        public List<string> getPassengers(){
            List<string> passengers = new List<String>();
            passengers.Add(passenger1);
			passengers.Add(passenger2);
			passengers.Add(passenger3);
			passengers.Add(passenger4);
			passengers.Add(passenger5);
			passengers.Add(passenger6);
			passengers.Add(passenger7);
			passengers.Add(passenger8);
			passengers.Add(passenger9);
			passengers.Add(passenger10);
			passengers.Add(passenger11);
			passengers.Add(passenger12);
			passengers.Add(passenger13);
			passengers.Add(passenger14);
			passengers.Add(passenger15);
			passengers.Add(passenger16);
			passengers.Add(passenger17);
			passengers.Add(passenger18);
			passengers.Add(passenger19);
			passengers.Add(passenger20);
			passengers.Add(passenger21);
			passengers.Add(passenger22);
			passengers.Add(passenger23);
			passengers.Add(passenger24);


			return passengers;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as FlightCards);
        }
        public bool Equals(FlightCards other){
            if (other == null)
                return false;
            return this.dateOut.Equals(other.dateOut) && this.dateIn.Equals(other.dateIn);
        }
            

	}
}

