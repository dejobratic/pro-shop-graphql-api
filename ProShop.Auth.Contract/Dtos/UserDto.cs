﻿using System;

namespace ProShop.Auth.Contract.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public TokenDto Token { get; set; }
    }
}