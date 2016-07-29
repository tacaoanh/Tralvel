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
    public class TourManager:BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TourManager));
        private static TourManager _instance;

        private TourManager()
        {
        }

        public static TourManager Instance
        {
            get {
                return _instance ?? (_instance = new TourManager()); 
            }
        }

        public List<TourViewModel> TourGetLatestTour(int top)
        {
            try
            {
                var rowMapper = MapBuilder<TourViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourGetLatestTour, rowMapper, top).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public List<TopTourViewModel> TourGetTop(int top)
        {
            try
            {
                var rowMapper = MapBuilder<TopTourViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourGetTop, rowMapper, top).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public List<TopTourViewModel> TourByCategoryType(int type,int top)
        {
            try
            {
                var rowMapper = MapBuilder<TopTourViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.TourGetTourByCategoryType, rowMapper, type, top).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Tour by CategoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
 
        public List<TourListViewModel> GetTourByCategoryId(int categoryId, string search)
        {
            try
            {
                var rowMapper = MapBuilder<TourListViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.GetTourByCategoryId, rowMapper, categoryId, search).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public List<TourListViewModel> GetTourByProvinceId(int provinceId, string search)
        {
            try
            {
                var rowMapper = MapBuilder<TourListViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.GetTourByProvinceId, rowMapper, provinceId, search).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        // page tour 
    }
}