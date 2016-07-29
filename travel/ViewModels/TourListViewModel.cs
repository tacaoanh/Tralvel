using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel.ViewModels
{
    public class TourListViewModel
    {
        public Guid Id{get;set;}
        public int TourId{get;set;}
        public string TieuDe{get;set;}
        public string NoiDung{get;set;}
        public string MoTa{get;set;}
        public string GhiChu{get;set;}
        public int LuotXem{get;set;}
        public double DanhGia{get;set;}
        public string ProvinceName { get; set; }
        public string NationalName { get; set; }
        public double Gia { get; set; }
    }
}