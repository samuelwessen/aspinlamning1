using AutoMapper;
using SchoolClassApplication.Data;
using SchoolClassApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolClassApplication
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, CreateUserViewModel>();
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}
