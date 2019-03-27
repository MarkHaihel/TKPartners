using System.Collections.Generic;
using TKPartnersV2.Models;

namespace TKPartnersV2.Models.ViewModels
{
    public class NewsListViewModel
    {
        public IEnumerable<News> NewsRepo { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}
