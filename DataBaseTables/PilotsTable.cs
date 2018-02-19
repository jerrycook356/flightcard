using System;
using SQLite;
namespace practice2
{
    public class PilotsTable
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }

       public string pilotName { get; set; }
    }
}
