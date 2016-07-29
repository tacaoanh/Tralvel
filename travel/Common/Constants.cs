namespace travel.Common
{
    public class Constants
    {
        public class WebSetting
        {
            public const string IsServerDeveloper = "IsServerDeveloper";
            public const string IsCdn = "IsCdn";
            public static bool IsPubNubDeveloper = true;
            public const string ChannelPastaxiAccessCode = "ChannelPastaxiAccessCode";
        }
        public class DateTime
        {
            public const string FormatToDateTimeEn1 = "yyyy/MM/dd HH:mm:ss";
            public const string FormatToDateTimeEn2 = "yyyy/MM/dd HH:mm";
            public const string FormatToDateTimeEn3 = "yyyy/MM/dd";
            public const string FormatToDateTimeVn1 = "dd/MM/yyyy HH:mm:ss";
            public const string FormatToDateTimeVn2 = "dd/MM/yyyy HH:mm";
            public const string FormatToDateTimeVn3 = "dd/MM/yyyy";
            public const string FormatToDateTimeVn4 = "HH:mm";
        }

        #region Session

        public class Session
        {
            public const string AccountRegister = "AccountRegister";
            public const string AccountForgotPassword = "AccountForgotPassword";
            public const string Setting = "Setting";
            public const string GameShow = "GameShow";
            public const string TagSave = "TagSave";
            public const string FilterModel = "FilterModel";
            public const string TabIndex = "TabIndex";
            public const string ViDo = "ViDo";
            public const string KinhDo = "KinhDo";
            public const string GiamGiaId = "GiamGiaId";
            public const string CateFilterId = "CateFilterId";
        }

        public class Cookies
        {
            public const string ProvinceId = "ProvinceId";
            public const string DistrictId = "DistrictId";
            public const string EventId = "EventId";
            public const string TypeSearch = "TypeSearch";
        }

        #endregion

        #region Repository

        public class UserRepository
        {
            public class StoredProcedure
            {
                public const string Insert = "NoDistance_UserModel_Insert";
                public const string Update = "NoDistance_UserModel_Update";
                public const string GetBySdt = "NoDistance_UserModel_GetBySdt";
                public const string VerifyMaKichHoat = "NoDistance_UserModel_VerifyMaKichHoat";
                public const string UpdateUserInfo = "NoDistance_UserInfoManager_Update";
                public const string ChangerPassword = "NoDistance_UserPasswordManager_Update";

                public const string InsertUserGameShow = "NoDistance_UserRegisterManager_InsertUserGameShow"; // --- Thêm mới game show của người dùng
                public const string CheckUserPlayGame = "NoDistance_UserRegisterManager_CheckUserPlayGame"; //--- Kiểm tra xem người dùng đó đã chơi game chưa
                public const string TangTheDatCho = "NoDistance_GiamGia_TaoTheDatChoNguoiDungMaster"; //--- Tặng thẻ cho người dùng chơi game
                public const string ValidateEmailUnique = "NoDistance_UserRegisterManager_ValidateEmailUnique"; // Kiểm tra email đã tồn tại chưa.
               
            }
        }

      
        #endregion 

        #region Manager
        public class StoredProcedure
        {
            public const string NationalSelect = "National_Select";
            public const string TourCategoryGetAll = "Cozi_TourCategory_GetAll";
            public const string TourCategoryGetById = "Cozi_TourCategory_GetById";
            public const string TourCategoryGetTourHot = "Cozi_TourCategory_GetTourHot";
            public const string ReviewGetTop = "Cozi_Review_GetTop";
            public const string NguoiDungAvataByReviewId = "Cozi_NguoiDung_GetAvataByReviewId";
            public const string GetCategoryImageByCategoryId = "GetCategoryImage_ByCategoryId";
            // top destination
            public const string TourProvinceGetTop = "Cozi_TourProvince_GetTop";
            // top Category
            public const string TourCategoryGetTop = "Cozi_TourCategory_GetTop";
            //Tour
            public const string TourGetLatestTour = "Cozi_Tour_GetLatestTour";
            public const string TourGetTop = "Cozi_Tour_GetTop";
            public const string InformationGetByCode = "Cozi_Information_GetByCode";
            public const string InformationGetById = "Cozi_Information_GetById";
            public const string TourGetTourByCategoryType = "Cozi_Tour_GetTourByCategoryType";
            public const string GetTourByProvinceId = "Cozi_GetTourByProvinceId";
            public const string TourGetDetail = "Cozi_Tour_GetDetail";
            //Province
            public const string GetTinh = "Cozi_GetTinh";
            // phần mới viết code trước
            // Tour by category
            public const string GetTourByCategoryId = "Cozi_GetTourByCategoryId";
            //Anh
            public const string AnhSelectByType = "Cozi_Anh_SelectByType";
            public const string GetAnhById = "Cozi_GetAnh_ById";
        }

        #endregion
    }
}