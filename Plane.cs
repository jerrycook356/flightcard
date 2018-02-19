using System;
namespace practice2
{
    public class Plane
    {
       public string name { get; set; }
        public Plane()
        {
        }
        public Plane(string name){
            this.name = name;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Plane);
        }
        public bool Equals(Plane other)
        {
            if (other == null)
                return false;
            return this.name.Equals(other.name);
        }
    }
}
