using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel.Session
{
    [Serializable]
    public class SettingSession
    {
        public int ProvinceId { get; set; }       
        public string ProvinceName { get; set; }
      
    }
}