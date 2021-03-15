using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public class Messages
    {
        public static string Updated = "The item has been updated!!";
        public static string Deleted = "The item has been removed!!";
        public static string NameInvalid = "Innvalid Name!!";
        public static string Added = "The item has been added!!";
        public static string ReturnDateInvalid = "The car is not able to use.";
        public static string Listed = "The items has been listed !";
        public static string CarIsNotAbleToRent = "The Car is not able to rent right now !";
        public static string CarNumberHasbeenReached = "The photos of the car has been reached! ";
        public static string CarImageNumError = "The car number is invalid !";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserRegistered = "Kayıt oldu!";
        public static string UserNotFound = "Kullanıcı bulunamadı !";
        public static string SuccessfulLogin = "Giriş başarılı! ";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu!";
        public static string PasswordError = "Parola hatası!";
    }
}
