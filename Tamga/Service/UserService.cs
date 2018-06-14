namespace Tamga.Service
{
    using AutoMapper;
    using DB.Model;
    using DB.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tamga.Models;

    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        static UserService()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserViewModel, User>());
        }

        public List<UserViewModel> GetUsers()
        {
            var users = _unitOfWork.Repository<User>().All().Select(t => Mapper.Map<User, UserViewModel>(t)).ToList();
            return users;
        }

        public void SaveUsers(List<UserViewModel> userList)
        {
            foreach (var item in userList)
            {
                if (_unitOfWork.Repository<User>().Find(t=>t.Id==item.Id)!=null)
                {
                    _unitOfWork.Repository<User>().Update(Mapper.Map<UserViewModel, User>(item));
                }
                else
                {
                    _unitOfWork.Repository<User>().Add(Mapper.Map<UserViewModel, User>(item));
                }
            }
            _unitOfWork.Save();
        }
    }
}