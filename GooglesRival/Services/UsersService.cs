﻿// <copyright file="UsersService.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GooglesRival.Controllers;
    using GooglesRival.Models;
    using GooglesRival.Services.Iservices;

    /// <summary>
    /// Users Service.
    /// </summary>
    /// <seealso cref="GooglesRival.Services.Iservices.IUsersService" />
    public class UsersService : IUsersService
    {
        /// <summary>
        /// The data source.
        /// </summary>
        private readonly IDataSource dataSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        public UsersService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService" /> class.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        public UsersService(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The Object.</returns>
        public List<User> GetAllUsers()
        {
            return this.dataSource.GetUsers();
        }

        /// <summary>
        /// Verifies the username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The Object.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// username
        /// or
        /// password.
        /// </exception>
        public bool VerifyUsernameAndPassword(string username, string password)
        {
            var users = this.dataSource.GetUsers();
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            else if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            else if (users.Any(x => x.Username.Contains(username) && x.Password == password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>The Object.</returns>
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var users = this.dataSource.GetUsers();
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == oldPassword)
                {
                    return this.dataSource.UpdateUser(username, newPassword);
                }
            }

            return false;
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The Object.</returns>
        public bool AddNewUser(string username, string password)
        {
            if (!this.DoesUserExist(username))
            {
                var output = this.dataSource.AddUser(username, password);
                return output;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Doeses the user exist.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The Object.</returns>
        private bool DoesUserExist(string username)
        {
            try
            {
                var users = this.dataSource.GetUsers();
                return users.Any(x => x.Username == username);
            }
            catch
            {
                return false;
            }
        }
    }
}
