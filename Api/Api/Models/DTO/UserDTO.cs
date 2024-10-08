﻿namespace Api.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Points { get; set; }
    }
}
