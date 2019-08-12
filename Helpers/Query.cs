
namespace WebApi.Helpers
{
    public class Query
    {
        public Query()
        {
            Page = 1;
            Limit = 20;
        }
        public int Page { get; set; }
        public int Limit { get; set;}
    }
}