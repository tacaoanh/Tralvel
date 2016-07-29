using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travel.Session;
namespace travel.Common
{
    public class Setting
    {

        public static int ProvinceId
        {
            get
            {
                var provinceId = CookiesHelper.GetValue(Constants.Cookies.ProvinceId);
                if (!string.IsNullOrEmpty(provinceId))
                {
                    return Convert.ToInt32(provinceId);
                }

                return 1;
            }
            set
            {
                CookiesHelper.SetValue(Constants.Cookies.ProvinceId, string.Format("{0}", value));
            }
        }   

        public static string ProvinceName
        {
            get
            {
                var provinceName = "Hà Nội";

                switch (ProvinceId)
                {
                    case 0:
                        provinceName = "- Chọn tỉnh -";
                        break;
                    case 1:
                        provinceName = "Hà Nội";
                        break;
                    case 2:
                        provinceName = "TP. HCM";
                        break;
                    case 3:
                        provinceName = "Nam Định";
                        break;
                }

                return provinceName;
            }
            set
            {
                var settingSession = SessionHelper<SettingSession>.GetValue(Constants.Session.Setting) ?? new SettingSession();

                settingSession.ProvinceName = value;
                SessionHelper<SettingSession>.SetValue(Constants.Session.Setting, settingSession);
            }
        }
    }
}