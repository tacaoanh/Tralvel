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
    public class AnhManager : BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AnhManager));
        private static AnhManager _instance;

        private AnhManager()
        {
        }

        public static AnhManager Instance
        {
            get
            {
                return _instance ?? (_instance = new AnhManager());
            }
        }
        public List<AnhViewModel> GetAnhByType(int type)
        {
            try
            {
                var rowMapper = MapBuilder<AnhViewModel>.MapAllProperties().Build();
                var lstArticel = Database.ExecuteSprocAccessor(Constants.StoredProcedure.AnhSelectByType, rowMapper, type).ToList();
                return lstArticel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public byte[] GetAnhById(string tenIMG)
        {
            try
            {
                tenIMG = tenIMG.Split('.')[0];
                var words = tenIMG.Split('-');
                int id;
                int.TryParse(words[words.Length - 1], out id);
                var photo = (byte[])Database.ExecuteScalar(Constants.StoredProcedure.GetAnhById, id);

                return photo;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}