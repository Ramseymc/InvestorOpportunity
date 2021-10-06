using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.User
{
    public static class _user
    {
        public const string Id = "Id";
        public const string Username = "Username";
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string Blocked = "Blocked";

        public const string PortalUserFrom = "PortalUserFrom";
        public const string PortalUserTo = "PortalUserTo";
    }

    public class UserModel : BaseModel
    {
        public long? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Blocked { get; set; }

        public UserModel()
        {
        }


        public UserModel(long? id, string username, string firstName, string lastName, bool blocked)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Blocked = blocked;
        }

        public UserModel(UserViewModel model)
        {
            Id = model.Id;
            Username = model.Username;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Blocked = model.Blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }



    }


    public class UserViewModel : BaseModel
    {
        public long? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Blocked { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(UserModel model)
        {
            Id = model.Id;
            Username = model.Username;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Blocked = model.Blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }

    }


    public class UserListModel
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string User { get; set; }
    }


}






