﻿using WebApi.Models;

namespace WebApi.Models
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
