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
    public class InformationManager:BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(InformationManager));
        private static InformationManager _instance;

        private InformationManager()
        {
        }

        public static InformationManager Instance
        {
            get {
                return _instance ?? (_instance = new InformationManager()); 
            }
        }
        /// <summary>
        ///  lấy danh sánh Mục by Code: 
        ///  Introduce key : introduce
        /// about key : about
        /// </summary>
        /// <returns></returns>
        public List<InformationViewModel> ListInformationGetByCode(string code)
        {
            try
            {
                var rowMapper = MapBuilder<InformationViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.InformationGetByCode, rowMapper, code).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Get Detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InformationViewModel InformationGetDetail(int id)
        {
            try
            {
                var rowMapperBlogDetail = MapBuilder<InformationViewModel>.MapAllProperties().Build();
                var blogDetail = Database.ExecuteSprocAccessor(Constants.StoredProcedure.InformationGetById, rowMapperBlogDetail, id).FirstOrDefault();
                return blogDetail;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        // Introduce key : introduce
        // about key : about
        public InformationViewModel InformationGetByCode(string code)
        {
            try
            {
                var rowMapperBlogDetail = MapBuilder<InformationViewModel>.MapAllProperties().Build();
                var blogDetail = Database.ExecuteSprocAccessor(Constants.StoredProcedure.InformationGetByCode, rowMapperBlogDetail, code).FirstOrDefault();
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