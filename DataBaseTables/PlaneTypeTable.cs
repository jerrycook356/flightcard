using System;
using SQLite;
namespace practice2
{
    public class PlaneTypeTable
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }

       public string planeType { get; set; }
    }
}
