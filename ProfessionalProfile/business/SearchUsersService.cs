﻿using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    class SearchUsersService
    {
        public UserRepo UserRepo { get; }

        public SearchUsersService(UserRepo userRepo)
        {
            this.UserRepo = userRepo;
        }

        public List<User> SearchUsers(string search, int loggedUserId)
        {
            List<User> allUsers = UserRepo.GetAll();
            List<User> searchResults = allUsers.FindAll((user) =>
                (user.FirstName.ToLower().Contains(search) || 
                user.LastName.ToLower().Contains(search)) &&
                user.UserId != loggedUserId);

            return searchResults;
        }
    }
}
