namespace Tamga.Service
{
    using System.Collections.Generic;
    using Tamga.Models;
    public interface IUserService
    {
        void SaveUsers(List<UserViewModel> userList);
        List<UserViewModel> GetUsers();
    }
}
