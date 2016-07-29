using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travel.Common;

namespace travel.ViewModels
{
    public class TourCategoryViewModel
    {
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string AnhSrc
        {
            get
            {
                return "anh-tour-category/" + Title.ToSeoUrl() + "-" + CategoryId + ".jpg";
            }
        }
        public string AltImg
        {
            get
            {
                return Title.ToSeoUrl();
            }
        }
        public int TourCount { get; set; }
        public string Title { get; set; }
        //public byte[] Anh { get; set; }
    }
}