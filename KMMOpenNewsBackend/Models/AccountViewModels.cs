﻿using System;
using System.Collections.Generic;

namespace KMMOpenNewsBackend.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string userName { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }

        public UserType UserType { get; set; }

        public int UserTypeId { get; set; }

        public ICollection<NewsPost> NewsPosts { get; set; }

        public ICollection<UserComment> UserComments { get; set; }
    }

    public class UserInfo {
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public ICollection<NewsPost> NewsPosts { get; set; }
        public ICollection<UserComment> UserComments { get; set; }
        public string Username { get; set; }

        public static UserInfo FromAppUser(ApplicationUser user) {
            var info = new UserInfo
            {
                Email = user.Email,
                UserType = user.UserType,
                NewsPosts = user.NewsPosts,
                UserComments = user.UserComments,
                Username = user.UserName
            };
            return info;
        }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
