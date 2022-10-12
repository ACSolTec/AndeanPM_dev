using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Andeanpm.Server.Services.OurPeopleService
{
    public class OurPeopleService : IOurPeopleService
    {
        private readonly AndeampDBContext context;
        public OurPeopleService(AndeampDBContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<Person>> Create(Person member)
        {
            context.People.Add(member);
            await context.SaveChangesAsync();

            return new ServiceResponse<Person> { Data = member };
        }

        public async Task<ServiceResponse<bool>> Delete(int id)
        {
            var db = await context.People.FindAsync(id);
            if (db == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Member not found."
                };
            }

            context.People.Remove(db);
            await context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<Person>> GetMember(int id)
        {
            var response = new ServiceResponse<Person>();
            try
            {
                response.Data = await context.People.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<ServiceResponse<List<Person>>> GetPeople()
        {
            var response = new ServiceResponse<List<Person>>();
            try
            {
                var people = await context.People.ToListAsync();
                response.Data = people;
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

        public async Task<PagedList<Person>> GetPeople(PaginationParameters paginationParameters, string team)
        {
            var result = await context.People.Where(x => x.Team.Equals(team)).ToListAsync();
            return PagedList<Person>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<ServiceResponse<Person>> Update(Person member)
        {
            context.People.Update(member);
            await context.SaveChangesAsync();
            return new ServiceResponse<Person> { Data = member };
        }

    }
}
