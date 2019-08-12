using System;
using MongoDB.Driver;
using WebApi.Context;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMemberService
    {
        Paging<Member> GetMembers(int offset, int limit);
        
        Member GetMember(string id);
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
            var paging = new Paging<Member>
            {
                Page = currentPage,
                Results = results,
                Count = Convert.ToInt64(count),
                TotalPages = Convert.ToInt32(totalPages)
            };
            return paging;
        }

        public Member GetMember(string id) => _context.Members.Find(member => member.Id == id).FirstOrDefault();
        
    }
}