using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {
        //Listing
        public static string ListingFromDatabaseSuccessful = "Veritabanından yapılan listeleme başarılı.";
        public static string ListingFromSourceSuccessful = "Ana kaynak linkten yapılan listeleme işlemi başarılı.";
        public static string ListingFromDatabaseFailed = "Veritabanından yapılan listeleme başarısız.";
        public static string ListingFromSourceFailed = "Ana kaynak linkten yapılan listeleme işlemi başarısız.";

        //Add - Delete - Update
        public static string AddedDataFromDatabaseSuccessfull = "Veri ekleme işlemi başarılı";
        public static string AddedDataFromDatabaseFailed = "Veri ekleme işlemi başarısız";
        public static string DeletedDataFromDatabaseSuccessfull = "Veri silme işlemi başarılı";
        public static string DeletedDataFromDatabaseFailed = "Veri silme işlemi başarısız";
        public static string UpdatedDataFromDatabaseSuccessful = "Veri güncelleme işlemi başarılı";
        public static string UpdatedDataFromDatabaseFailed = "Veri güncelleme işlemi başarısız";

        //AddRange - DeletedRange - UpdateRange
        public static string AddedDataFromSourceSuccessfull = "Uzak sunucudaki veriyi veritabanına ekleme işlemi başarılı oldu";
        public static string AddedDataFromSourceFailed = "Uzak sunucudaki veriyi veritabanına ekleme işlemi başarısız oldu. ";
        public static string DeletedDataFromSourceSuccessful = "Veritabanında bulunan verilerin silinme işlemi başarılı oldu.";
        public static string DeletedDataFromSourceFailed = "Veritabanında bulunan verilerin silinme işlemi başarısız oldu.";
        public static string UpdatedDataFromSourceSuccessful = "Uzak sunucudaki verilerle veritabanındaki verilerin eşleştirme işlemi başarılı oldu.";
        public static string UpdatedDataFromSourceFailed = "Uzak sunucudaki verilerle veritabanındaki verilerin eşleştirme işlemi başarısız oldu.";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Yanlış";
        
        public static string SuccessfullLogin = "Kullanıcı girişi başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt edildi.";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";

        public static object LocalIpInformation = "LocalIP üzerinden işlem yapmaktasınız. api/turkishevents/readjson veya api/italianevents/readjson uzantılarını kullanarak verileri alabilirsin";
        internal static string DataCountExceeded = "Maksimum veri sayısını aştınız.";
    }
}
