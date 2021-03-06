﻿// <copyright file="IUsersService.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Services.Iservices
{
    using System.Collections.Generic;
    using GooglesRival.Models;

    /// <summary>
    /// The IUsersService Interface.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The Object.</returns>
        bool AddNewUser(string username, string password);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>The Object.</returns>
        bool ChangePassword(string username, string oldPassword, string newPassword);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The Object.</returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Verifies the username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The Object.</returns>
        bool VerifyUsernameAndPassword(string username, string password);
    }
}