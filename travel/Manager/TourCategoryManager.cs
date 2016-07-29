using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Mvc;
using travel.ViewModels;
using travel.Common;


namespace travel.Manager
{
    public class TourCategoryManager: BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TourCategoryManager));
        private static TourCategoryManager _instance;

        private TourCategoryManager()
        {
        }

        public static TourCategoryManager Instance
        {
            get {
                return _instance ?? (_instance = new TourCategoryManager()); 
            }
        }
        public TourCategoryViewModel InformationGetDetail(int id)
        {
            try
            {
                var rowMapperBlogDetail = MapBuilder<TourCategoryViewModel>.MapAllProperties().Build();
                var blogDetail = Database.ExecuteSprocAccessor(Constants.StoredProcedure.InformationGetById, rowMapperBlogDetail, id).FirstOrDefault();
                return blogDetail;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public List<TourCategoryViewModel> TourCategoryGetAll()
        {
            try
            {
                var rowMapper = MapBuilder<TourCategoryViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourCategoryGetAll, rowMapper).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public List<TopTourCategoryViewModel> TopTourCategory(int top)
        {
            try
            {
                var rowMapper = MapBuilder<TopTourCategoryViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourCategoryGetTop, rowMapper, top).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public List<TourCategoryViewModel> TourCategoryHot()
        {
            try
            {
                var rowMapper = MapBuilder<TourCategoryViewModel>.MapAllProperties().Build();
                var lst = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourCategoryGetTourHot, rowMapper).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public List<ReviewViewModel> ReviewGetTop(int top)
        {
            try
            {
                var rowMapper = MapBuilder<ReviewViewModel>.MapAllProperties().Build();
                var lst = Database.ExecuteSprocAccessor(Constants.StoredProcedure.ReviewGetTop, rowMapper, top).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public List<TopDestinationViewModel> TourProvinceGetTop(int top)
        {
            try
            {
                var rowMapper = MapBuilder<TopDestinationViewModel>.MapAllProperties().Build();
                var lst = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourProvinceGetTop, rowMapper, top).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        } 
    }
}