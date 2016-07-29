using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel.ViewModels
{
    public class TourDetailViewModel
    {
        public Guid Id{get;set;}
		public int TourId{get;set;}
        public string TieuDe{get;set;}
        public string NoiDung{get;set;}
        public string MoTa{get;set;}
        public string GhiChu{get;set;}
        public byte HieuLuc{get;set;}
        public double Gia{get;set;}
        public string GiamGia{get;set;}
        public int TongSoThich{get;set;}
        public int TongSoBinhLuan{get;set;}
        public string TitleMeta{get;set;}
        public string DescriptionMeta{get;set;}
        public string KeywordMeta{get;set;}
        public string KeySearch{get;set;}
        public int LuotXem{get;set;}
        public string NguoiDungId{get;set;}
        public DateTime NgayBatDau{get;set;}
        public DateTime NgayKetThuc{get;set;}
        public DateTime NgayTao{get;set;}
		public int OrderBy{get;set;}
        public double DanhGia{get;set;}
		
    }
}