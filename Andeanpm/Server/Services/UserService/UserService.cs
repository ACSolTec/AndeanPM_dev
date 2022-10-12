using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace Andeanpm.Server.Services.UserService
{
	public class UserService : IUserService
	{
        private readonly AndeampDBContext context;
        public UserService(AndeampDBContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<User>> Create(User user, string password)
		{

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new ServiceResponse<User> { Data = user };
        }

		public async Task<ServiceResponse<bool>> Delete(int id)
		{
            var db = await context.Users.FindAsync(id);
            if (db == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Member not found."
                };
            }

            context.Users.Remove(db);
            await context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

		public async Task<ServiceResponse<User>> Get(int id)
		{
            var response = new ServiceResponse<User>();
            try
            {
                response.Data = await context.Users.FindAsync(id);
                response.Success = true;
                response.Message = "Get Data Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"{ex.Message} - {ex.InnerException}";
            }
            return response;
        }

		public async Task<ServiceResponse<List<User>>> Get()
		{
            var response = new ServiceResponse<List<User>>();
            try
            {
                var data = await context.Users.ToListAsync();
                response.Data = data;
                response.Success = true;
                response.Message = "Get Data Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"{ex.Message} - {ex.InnerException}";
            }
            return response;
        }

		public async Task<PagedList<User>> Get(PaginationParameters paginationParameters)
		{
            var result = await context.Users.ToListAsync();
            return PagedList<User>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

		public async Task<ServiceResponse<User>> Update(User user, string password)
        { 
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            context.Users.Update(user);
            await context.SaveChangesAsync();
            return new ServiceResponse<User> { Data = user };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
