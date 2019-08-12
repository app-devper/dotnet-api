using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WebApi.Context;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        User AuthenticateAsync(string username, string password);
        IEnumerable<User> GetAll();
        Paging<User> GetUsers(int offset, int limit);
        User GetUser(string id);
    }

    public class UserService : IUserService
    {
        private readonly IAppContext _context;

        public UserService(IAppContext context)
        {
            _context = context;
        }

        public User AuthenticateAsync(string username, string password)
        {
            var user = _context.Users.Find<User>(item => item.Username == username && item.Password == password).FirstOrDefault();
            // return null if user not found
            if (user == null) return null;
            // remove password before returning
            user.Password = null;
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.Find(item => true).ToList();
            // return users without passwords
            return users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public Paging<User> GetUsers(int currentPage, int limit)
        {
            double count = _context.Users.Find(item => true).CountDocuments();
            var totalPages = Math.Ceiling(count / limit);
            var users = _context.Users.Find(item => true).Skip((currentPage - 1) * limit).Limit(limit).ToList();

            var paging = new Paging<User>();
            paging.Page = currentPage;
            paging.Results = users.Select(x =>
            {
                x.Password = null;
                return x;
            }).ToList();
            paging.Count = Convert.ToInt64(count);
            paging.TotalPages = Convert.ToInt32(totalPages);
            return paging;
        }
        
        public User GetUser(string id) => _context.Users.Find(user => user.Id == id).FirstOrDefault();
    }
}