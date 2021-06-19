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
        public static string AddedDataSuccessful = "Veri ekleme işlemi başarılı";
        public static string AddedDataFailed = "Veri ekleme işlemi başarısız";
        public static string DeletedDataSuccessful = "Veri silme işlemi başarılı";
        public static string DeletedDataFailed = "Veri silme işlemi başarısız";
        public static string UpdatedDataSuccessful = "Veri güncelleme işlemi başarılı";
        public static string UpdatedDataFailed = "Veri güncelleme işlemi başarısız";

        //AddRange - DeletedRange - UpdateRange
        public static string AddedDataInTurkishSuccessful = "Türkçe veriler eklendi. İşlem Başarılı.";
        public static string AddedDataInTurkishFailed = "Türkçe veriler eklenemedi. İşlem Başarısız.";
        public static string AddedDataInItalianSuccessful = "İtalyanca veriler eklendi. İşlem Başarılı.";
        public static string AddedDataInItalianFailed = "İtalyanca veriler eklenemedi. İşlem Başarısız.";
    }
}
