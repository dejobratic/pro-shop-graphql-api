﻿using ProShop.Auth.Domain.Models;

namespace ProShop.Auth.Domain.Tests.Unit.Fakes
{
    public static class MockUserCredentialsBuilder
    {
        public static UserCredentials Build(
            string email = "FirstName.LastName@example.com",
            string password = "password")
        {
            return new UserCredentials(
                email,
                password);
        }
    }
}
