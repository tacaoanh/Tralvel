using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travel.Common;
namespace travel.ViewModels
{
    public class AnhViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Caption { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
        public string AnhSrc
        {
            get
            {
                return "anh-slide/" + Name.ToSeoUrl() + "-" + Id + ".jpg";
            }
        }
        public string AltImg
        {
            get
            {
                return Name.ToSeoUrl();
            }
        }
    }
}