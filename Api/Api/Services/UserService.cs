using Api.Data;
using Api.Models;
using Api.Models.Requests;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Api.Services
{
    public class UserService
    {
        private readonly DatabaseContext _dbContext;


        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        private bool IsUserDataCorrect(CreateUserRequest userToAdd)
        {
            if (userToAdd == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(userToAdd.Nick))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(userToAdd.Email) || !IsValidEmail(userToAdd.Email))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(userToAdd.Password))
            {
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private Users CreateNewUser(CreateUserRequest userToAdd)
        {
            Users user = new Users
            {
                Email = userToAdd.Email,
                Nick = userToAdd.Nick,
                Password = BCrypt.Net.BCrypt.HashPassword(userToAdd.Password),
                CreatedAt = DateTime.Now,
                Points = 0
            };
            return user;
        }
        private async Task<bool> CheckEmailExistence(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<bool> AddUser(CreateUserRequest userToAdd)
        {
            try 
            {
                if (IsUserDataCorrect(userToAdd))
                {
                    if(await CheckEmailExistence(userToAdd.Email))
                    {
                        return false;
                    }
                    Users newUser = CreateNewUser(userToAdd);
                    await _dbContext.AddAsync(newUser);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured during adding user to database");
            }
        }
    }
}
