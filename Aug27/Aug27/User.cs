using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1
{
    public class User : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == name)
                    return;
                name = value;
                this.name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(GetName));
            }
        }
        public string GetName
        {
            get => $"You entered {Name}";
        }
        public string Password
        {
            get;
            set;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
