using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.AuthModel
{
    public class User : PropertyNotification
    {
        private string _first_name;
        private string _user_name;
        private string _last_name;
        private string _email;

        public int Id { get; set; }

        public string Token { get; set; }

        public string Firstname { get => _first_name; set { _first_name = value; OnPropertyChanged("FirstName"); } }

        public string Username { get => _user_name; set { _user_name = value; OnPropertyChanged("Username"); } }

        public string Lastname { get => _last_name; set { _last_name = value; OnPropertyChanged("LastName"); } }

        public string Email { get => _email; set { _email = value; OnPropertyChanged("Email"); } }

        public override string ToString()
        {
            return $"{this.Firstname} {this.Lastname}";
        }
    }
}
