using System;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.Web.Configuration;
using System.Web;
using travel.Common;
namespace travel.Common
{
    public static class Utilities
    {
        public static bool IsServerDeveloper()
        {
            var isServerDeveloper = false;

            string value = GetValueByKey(Constants.WebSetting.IsServerDeveloper);

            if (!string.IsNullOrEmpty(value))
            {
                isServerDeveloper = Convert.ToBoolean(value);
            }

            return isServerDeveloper;
        }

        public static string GetAccessCode()
        {
            if (IsServerDeveloper())
            {
                return "1234";
            }

            const int length = 4;
            const string possibles = "0123456789";
            var passwords = new char[length];

            var rd = new Random();

            for (var i = 0; i < length; i++)
            {
                passwords[i] = possibles[rd.Next(0, possibles.Length)];
            }

            return new string(passwords);
        }

        public static string GetValueByKey(string key)
        {
            try
            {
                var value = WebConfigurationManager.AppSettings[key];
                return value;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private static readonly MD5 Md5Hash = MD5.Create();

        /// <summary>
        /// Determines if a nullable Guid (Guid?) is null or Guid.Empty
        /// </summary>
        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return (!guid.HasValue || guid.Value == Guid.Empty);
        }
        
        public static DateTime ConvertToDateTimeEn1(string startDate)
        {
            DateTime dateTime = DateTime.ParseExact(startDate, Constants.DateTime.FormatToDateTimeEn1, CultureInfo.InvariantCulture);
            return dateTime;
        }

        public static DateTime ConvertToDateTimeVn1(string startDate)
        {
            DateTime dateTime = DateTime.ParseExact(startDate, Constants.DateTime.FormatToDateTimeVn1, CultureInfo.InvariantCulture);
            return dateTime;
        }

        public static string GetMd5Hash(string input)
        {
            byte[] data = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static string GetProvinceNameById(int id)
        {
            var provinceName = "Hà Nội";
            
            switch (id)
            {

                case 0:
                    provinceName = "- Chọn tỉnh -";
                    break;
                case 1:
                    provinceName = "Hà Nội";
                    break;
                case 2:
                    provinceName = "TP.HCM";
                    break;
                case 3:
                    provinceName = "Nam Định";
                    break;
            }

            return provinceName;
        }
       

        /// <summary>
        /// 
        /// 
        /// Lấy tên controller hiện tại
        /// </summary>
        public static string GetCurrentController()
        {
            var controllerName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");
            return controllerName;
        }

    
        public static string GetFullTextSearch(string keySearch)
        {
            if (string.IsNullOrEmpty(keySearch))
            {
                return "\"\"";
            }

            var operatorOr = " Or ";
            var result = string.Format("\"{0}\"{1}", keySearch, operatorOr);
            var words = keySearch.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            result += string.Join(operatorOr, words);

            return result;
        }

        public static string GetClientIP()
        {
            var ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                var addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string GetUrlHost()
        {
            var request = HttpContext.Current.Request;

            var urlHost = string.Concat(request.Url.Scheme, Uri.SchemeDelimiter, request.Url.Host,
                   request.Url.Port != 80 && IsServerDeveloper() ? string.Concat(":", request.Url.Port) : string.Empty);

            return urlHost;
        }
    }
}