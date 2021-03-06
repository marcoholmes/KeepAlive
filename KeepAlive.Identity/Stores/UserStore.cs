﻿using Microsoft.AspNet.Identity;
using System;
using KeepAlive.Core.Contracts.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using KeepAlive.Core.Domain;

namespace KeepAlive.Identity
{
    public class UserStore : IUserStore<IdentityUser, int>,
                             IUserPasswordStore<IdentityUser, int>,
                             IUserEmailStore<IdentityUser, int>,
                             IUserLockoutStore<IdentityUser, int>,
                             IUserTwoFactorStore<IdentityUser, int>,
                             IUserPhoneNumberStore<IdentityUser, int>,
                             IUserLoginStore<IdentityUser, int>

    {
        private IAccountService _accountService;

        public UserStore(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Task CreateAsync(IdentityUser identityUser)
        {
            User user = CreateUserFromIdentityUser(identityUser);
            bool val = _accountService.CreateUser(user);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing) { }

        public void Dispose()
        {
            //Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
        }

        public Task<IdentityUser> FindByIdAsync(int userId)
        {
            return Task.FromResult(new IdentityUser(1));
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            var user = _accountService.FindByName(userName);

            IdentityUser identityUser = CreateIdentityUser(user);

            return Task.FromResult(identityUser);
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            User user = _accountService.FindByEmail(email);

            IdentityUser identityUser = CreateIdentityUser(user);

            return Task.FromResult(identityUser);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            return Task.FromResult("AJHHjhJreLnyLHhHq8tZIj7K2SK2U2stk/sVwrX1U7KzJhONMKzFAu7GFqz3sMGqAA==");
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            return Task.FromResult("k@k.it");
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {

            return Task.FromResult(default(DateTimeOffset));
        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            return Task.FromResult(true);
        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.CompletedTask;
        }

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(false);
        }

        public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        private IdentityUser CreateIdentityUser(User user)
        {
            IdentityUser identityUser = null;
            if (user != null)
            {
                identityUser = new IdentityUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    PasswordHash = user.PasswordHash
                };
            }

            return identityUser;
        }

        private User CreateUserFromIdentityUser(IdentityUser identityUser)
        {
            User user = new User
            {
                Id = identityUser.Id,
                UserName = identityUser.UserName,
                Email = identityUser.Email,
                Password = identityUser.Password,
                PasswordHash = identityUser.PasswordHash
            };

            return user;
        }
    }
}