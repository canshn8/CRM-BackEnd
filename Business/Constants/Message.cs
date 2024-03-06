using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string ProductAdded = "Ürün eklendi";
        public static string CompanyAdded = "Şirket eklendi";
        public static string CompanyDistAdded = "Distribütör Şirketi eklendi";
        public static string DealerAdded = "Bayi eklendi";


        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string CompanyNameInvalid = "Şirket ismi geçersiz";
        public static string CompanyDistNameInvalid = "Distribütör Şirket ismi geçersiz";
        public static string DealerNameInvalid = "Bayi ismi geçersiz";

        public static string MaintenanceTime = "Sistem bakımda";

        public static string ProductsListed = "Ürünler listelendi";
        public static string CompanyListed = "Şirketler listelendi";
        public static string CompanyDistListed = "Distribütör Şirketleri listelendi";
        public static string DealerListed = "Bayiler listelendi";


        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string CompanyCountOfCategoryError = "Bir kategoride en fazla 10 şirket olabilir";
        public static string CompanyDistCountOfCategoryError = "Bir kategoride en fazla 10 Distribütör Şirketi olabilir";
        public static string DealerCountOfCategoryError = "Bir kategoride en fazla 10 Bayi olabilir";

        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CompanyNameAlreadyExists = "Bu isimde zaten başka bir Şirket var";
        public static string CompanyDistNameAlreadyExists = "Bu isimde zaten başka bir Distribütör Şirketi var";
        public static string DealerNameAlreadyExists = "Bu isimde zaten başka bir Bayi var";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
