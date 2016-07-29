using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travel.Common;
using travel.ViewModels;

namespace travel.Manager
{
    public class ProvinceManager:BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ProvinceManager));
        private static ProvinceManager _instance;

        private ProvinceManager()
        {
        }

        public static ProvinceManager Instance
        {
            get {
                return _instance ?? (_instance = new ProvinceManager()); 
            }
        }
        public TinhViewModel GetTinh(int id)
        {
            try
            {
                var rowMapperBlogDetail = MapBuilder<TinhViewModel>.MapAllProperties().Build();
                var detail = Database.ExecuteSprocAccessor(Constants.StoredProcedure.GetTinh, rowMapperBlogDetail, id).FirstOrDefault();
                return detail;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
       
    }
}