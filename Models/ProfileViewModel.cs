using PolyBook.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PolyBook.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel(string ID, string Name, string Surname, string Email, string Image) {
            UserID = ID;
            UserName = Name;
            UserSurname = Surname;
            UserEmail = Email;
            UserImage = Image;
        }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserImage { get; set; }

    }
}
