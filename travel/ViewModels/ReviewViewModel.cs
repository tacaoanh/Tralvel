using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travel.Common;

namespace travel.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public Guid NguoiDungId {get;set;}
        public double Rate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } 
        public string Date {get;set;}
        public string TenNguoiDung { get; set; }
        public string AnhNguoiDungSrc
        {
            get
            {
                return "anh-nguoi-dung/" + Title.ToSeoUrl() + "-" + Id + ".jpg";
            }
        }
        public string AltImg
        {
            get
            {
                return Title.ToSeoUrl()+"-"+Id ;
            }
        }
    }
}