﻿namespace Api.Models.Requests
{
    public class CreateUserRequest
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
