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
    public class TourDetailManager:BaseManager
    {
         private static readonly ILog Logger = LogManager.GetLogger(typeof(TourDetailManager));
        private static TourDetailManager _instance;

        private TourDetailManager()
        {
        }

        public static TourDetailManager Instance
        {
            get {
                return _instance ?? (_instance = new TourDetailManager()); 
            }
        }
        public TourDetailViewModel TourGetDetail(int tourId)
        {
            try
            {
                var rowMapperBlogDetail = MapBuilder<TourDetailViewModel>.MapAllProperties().Build();
                var blogDetail = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourGetDetail, rowMapperBlogDetail, tourId).FirstOrDefault();
                return blogDetail;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}