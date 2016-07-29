using System;
using System.Collections.Generic;
using System.Linq;
using travel.Common;
using travel.ViewModels;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace travel.Manager
{
    public class PhotoManager:BaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PhotoManager));
        private static PhotoManager _instance;

        private PhotoManager()
        {
        }

        public static PhotoManager Instance
        {
            get {
                return _instance ?? (_instance = new PhotoManager()); 
            }
        }
        public byte[] GetPhotoNguoiDungByReviewId(string tenIMG)
        {
            try
            {
                tenIMG = tenIMG.Split('.')[0];
                var words = tenIMG.Split('-');
                int id;
                int.TryParse(words[words.Length - 1], out id);
                var photo = (byte[])Database.ExecuteScalar(Constants.StoredProcedure.NguoiDungAvataByReviewId, id);

                return photo;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        public byte[] GethotoTourCategory(string tenIMG)
        {
            try
            {
                tenIMG = tenIMG.Split('.')[0];
                var words = tenIMG.Split('-');
                int id;
                int.TryParse(words[words.Length - 1], out id);
                var photo = (byte[])Database.ExecuteScalar(Constants.StoredProcedure.GetCategoryImageByCategoryId, id);

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