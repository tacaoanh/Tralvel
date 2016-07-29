using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace travel.ViewModels
{
    public class TourViewModelV1 : SyndicationFeed
    {
        public TourViewModelV1(string title, string description, Uri link, List<TourViewModel> feedItems)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.feedItems = feedItems;
        }

        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public List<TourViewModel> feedItems { get; set; }
    }
}