using System.Linq;

namespace TKPartnersV2.Models
{
    public interface INewsRepository
    {
        IQueryable<News> NewsRepo { get; }

        void SaveNews(News news);

        News DeleteNews(int newsID);
    }
}
