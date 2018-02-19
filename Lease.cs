using System;
namespace practice2
{
    public class Lease
    {
        public string name { get; set; }
        public Lease()
        {
        }
        public Lease(string name){
            this.name = name;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Lease);
        }
        public bool Equals(Lease other)
        {
            if (other == null)
                return false;
            return this.name==(other.name);
        }
    }
}
