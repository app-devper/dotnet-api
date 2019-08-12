using System;
using System.Linq;
using MongoDB.Driver;
using WebApi.Context;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMemberService
    {
        Paging<Member> GetMembers(int offset, int limit);
    }

    public class MemberService : IMemberService
    {
        private readonly IAppContext _context;

        public MemberService(IAppContext context)
        {
            _context = context;
        }

        public Paging<Member> GetMembers(int currentPage, int limit)
        {
            double count = _context.Members.Find(item => true).CountDocuments();
            var totalPages = Math.Ceiling(count / limit);
            var results = _context.Members.Find(item => true).Skip((currentPage - 1) * limit).Limit(limit).ToList();
            var paging = new Paging<Member>();
            paging.Page = currentPage;
            paging.Results = results;
            paging.Count = Convert.ToInt64(count);
            paging.TotalPages = Convert.ToInt32(totalPages);
            return paging;
        }
    }
}