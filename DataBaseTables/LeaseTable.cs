using System;
using SQLite;
namespace practice2
{
    public class LeaseTable{
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }

        public string leaseName { get; set; }

    }
}
