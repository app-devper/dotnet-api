using System.Collections.Generic;

namespace WebApi.Helpers
{
    public class Paging<TOption>
    {
        public long Count { get; set; }
        public List<TOption> Results { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}