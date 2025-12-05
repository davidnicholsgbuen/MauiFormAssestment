using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiFormAssestment.Models
{
    public class Entry
    {
        [PrimaryKey, AutoIncrement]
        public int EntryID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Do not persist this to the DB, computed on demand
        [Ignore]
        public string DisplayText => $"{FirstName} {LastName} {GetAge()}, years old.";

        // helper to compute age as integer years
        private int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age >= 0 ? age : 0;
        }
    }
}

