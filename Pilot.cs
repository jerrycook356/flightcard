using System;
namespace practice2
{
    public class Pilot
    {
        public string pilotName { get; set; }
        public Pilot()
        {
        }
        public Pilot(String name){
            this.pilotName = name;
        }
      
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Pilot);
        }
        public bool Equals(Pilot other)
        {
            if (other == null)
                return false;
            return this.pilotName.Equals(other.pilotName);
        }
    }
}
