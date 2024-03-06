﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string AddingSuccessful = "Ekleme İşlemi Başarılı";
        public static string DeletionSuccessful = "Silme İşlemi Başarılı";
        public static string UpdateSuccessful = "Güncelleme İşlemi Başarılı";
        public static string Successful = "Başarılı";
        public static string Unsuccessful = "Başarısız";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Yanlış";
        public static string AnErrorOccurredDuringTheUpdateProcess = "Güncelleme işleminde hata oluştu";
        internal static string AnErrorOccurredDuringTheDeleteProcess = "Silme işleminde hata oluştu";
        internal static string SuperUserCannotBeDeleted = "Super User silinemez";
        internal static string UserUpdated = "Kullanıcı Güncellendi";
        internal static string ThisOperationClaimAlreadyExists = "Bu rol zaten mevcut";
        internal static string UserRegistered = "Kullanıcı kayıtı başarılı.";
        public static string MissingOrIncorrectEntry = "Eksik Ya Da Hatalı Giriş";
        internal static string SuccessfulLogin = "Giriş Başarılı";
        internal static string AccessTokenCreated = "Erişim tokeni oluşturuldu.";
        internal static string CustomerRegistered = "Müşteri başarıyla kayıt oldu";
        internal static string AuthorizationDenied = "Erişim reddedildi";
    }
}
