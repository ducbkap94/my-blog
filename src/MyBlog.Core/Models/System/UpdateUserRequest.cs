﻿using AutoMapper;
using MyBlog.Core.Domain.Identity;

namespace MyBlog.Core.Models.System
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string? Avatar { get; set; }
        public bool IsActive { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<UpdateUserRequest, AppUser>();
            }
        }
    }
}