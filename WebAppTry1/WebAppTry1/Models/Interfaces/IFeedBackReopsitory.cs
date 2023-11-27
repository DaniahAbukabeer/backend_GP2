namespace WebAppTry1.Models.Interfaces
{
    public interface IFeedBackReopsitory
    {
        FeedBack GetFeedBack(int id);
        IEnumerable<FeedBack> GetFeedBacks();
        FeedBack AddFeedBack(FeedBack feedback);
        FeedBack UpdateFeedBack(FeedBack feedback);
        FeedBack DeleteFeedBack(int id);
    }
}
