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
    public class NationalManager:BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(NationalManager));
        private static NationalManager _instance;

        private NationalManager()
        {
        }

        public static NationalManager Instance
        {
            get {
                return _instance ?? (_instance = new NationalManager()); 
            }
        }
        public List<NationalViewModel> NationalSelect()
        {
            try
            {
                var rowMapper = MapBuilder<NationalViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.NationalSelect, rowMapper, 1).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}