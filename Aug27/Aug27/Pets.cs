using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aug27
{
    public class Pets
    {
        [PrimaryKey, AutoIncrement]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public DateTime birthDate { get; set; }
    }
}
