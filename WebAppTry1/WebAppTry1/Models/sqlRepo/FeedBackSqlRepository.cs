using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Models.sqlRepo
{
    public class FeedBackSqlRepository : IFeedBackReopsitory
    {
        private readonly ApplicationDbContext context;

        public FeedBackSqlRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        public FeedBack AddFeedBack(FeedBack feedback)
        {
            //context.Add<FeedBack>(feedback);
            //context.
            throw new NotImplementedException();
        }

        public FeedBack DeleteFeedBack(int id)
        {
            throw new NotImplementedException();
        }

        public FeedBack GetFeedBack(int id)
        {
            //return context.Find<FeedBack>(id);
            //return context.FeedBacks.Find(id);
            throw new NotImplementedException();

        }

        public IEnumerable<FeedBack> GetFeedBacks()
        {
            throw new NotImplementedException();
        }

        public FeedBack UpdateFeedBack(FeedBack feedback)
        {
            throw new NotImplementedException();
        }

        
    }
}
