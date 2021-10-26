using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{

    public class Vet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string VetId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public string Telephone { get; set; }
        public string Resume { get; set; }
        public string Workday { get; set; }

    }
}
