using Entities.Concrete;
using Entities.Dtos.BannedUsers;
using Entities.Dtos.BusinessPanel;
using Entities.Dtos.UnnecessaryInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public class Messages
    {
        //UserAddDto
        public static string UserNotFoundInList = "Kullanıcılar listesinde veri bulunamadı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UnknownError = "Bilinmeyen Hata";
        public static string UserAdded = "Kullanıcının üyeliği oluşturuldu.";
        public static string UserAlreadyExists = "Kullanıcı zaten üye.";
        public static string UserDeleted = "Kullanıcının üyeliği silindi.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi.";
        public static string PhoneNumberError = "Telefon numarası 10 haneden fazla olamaz.";
        public static string IdentityNumberError = "Tc kimlik numarası 11 haneden fazla olamaz.";
        //BookAddDto
        public static string bookAdded = "Kitap kütüphaneye eklendi.";
        public static string BookAlreadyExists = "Kitap zaten mevcut.";
        public static string bookUpdated = "Kitap güncellendi.";
        public static string bookDeleted = "Kitap kütüphaneden kaldırıldı.";
        public static string bookNotFound = "Kitap bulunamadı.";
        public static string BookNotFoundInList = "Kütüphanede kitap bulunamadı.";
        //BusinessPanelManager
        public static string ThisUserAlreadyBorrowed = "Kullanıcı bu kitabı zaten ödünç aldı.";
        public static string BookIsLoanedOut = "Bu kitabı başka bir kullanıcı ödünç almış.";
        public static string BookBorrowedToUser = "Kitap kullanıcıya ödünç verildi.";
        public static string bookIsReceived = "Kitap iadesi alındı.";
        public static string NotFoundHistory = "Daha önce yapılmış bir işlem gözükmüyor. Lütfen kontrol edin.";
        public static string borrowNotfoundInList = "Aktif işlem yok.";
        public static string userIsBanned = "Kullanıcı uzaklaştırıldı.";
        public static string userAlreadyBanned = "Kullanıcı zaten yasaklı.";
        public static string BlockedUser = "Bu kullanıcı yasaklı.";
        public static string notBannedUser = "Kullanıcı yasaklı değil.";
        public static string RemovedBannedUser = "Kullanıcının yasağı kaldırıldı.";
        public static string BannedUserNotFound = "Yasaklı kullanıcı bulunamadı.";
        public static string notFoundInReadBook = "Henüz okunmuş kitap bulunmamakta.";
        //Writer
        public static string NotFoundWriter = "Yazar bulunamadı.";
        //Publisher
        public static string NotFoundPublisher = "Yayın evi bulunamadı.";
    }
}
