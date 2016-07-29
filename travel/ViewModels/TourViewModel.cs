using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travel.Common;
namespace travel.ViewModels
{
    public class TourViewModel
    {
        public Guid Id { get; set; }
        public int TourId { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public byte[] Anh { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public string AnhSrc
        {
            get
            {
                return "anh-tour-category/" + TieuDe.ToSeoUrl() + "-" + Id + ".jpg";
            }
        }
        public string AltImg
        {
            get
            {
                return TieuDe.ToSeoUrl();
            }
        }
        public int TongSoThich { get; set; }
        public int TongSoBinhLuan { get; set; }
        public int LuotXem { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string NgayTao { get; set; }
        //public string LinkDetail
        //{
        //    get
        //    {
        //        string hostUrl = Request.Url.Scheme + "://" + Request.Url.Host;
        //        var url = hostUrl + "/tour/" + TieuDe.ToSeoUrl() + "-" + TourId;
        //        return url;
        //    }
        //}
    }
}