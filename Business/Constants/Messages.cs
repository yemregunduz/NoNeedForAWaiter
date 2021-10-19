using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductsListedByCurrentCategory = "Ürünler seçilen kategoriye göre listelendi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string CategoryAdded = "Kategori eklendi.";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoriesListed = "Kategoriler listelendi.";
        public static string CategoryUpdated = "Kategori güncellendi.";
        public static string RestaurantAdded = "Restoran eklendi.";
        public static string RestaurantDeleted = "Restoran silindi.";
        public static string RestaurantListed = "Restoranlar listelendi.";
        public static string RestaurantUpdated = "Restoran güncellendi.";
        public static string OrderDeleted = "Sipariş iptal edildi";
        public static string OrdersListedByTableId = "Masanın siparişleri listelendi.";
        public static string OrderAdded = "Sipariş alındı.";
        public static string OrdersListed = "Siparişler listelendi.";
        public static string OrderUpdated = "Sipariş güncellendi.";
        public static string OrderDetailCreated = "Sipariş detayı oluşturuldu.";
        public static string OrderDetailDeleted = "Sipariş detayı silindi.";
        public static string OrderDetailUpdated = "Sipariş detayı güncellendi.";
        public static string TableUpdated = "Masa güncellendi.";
        public static string TableDeleted = "Masa silindi.";
        public static string TableAdded = "Masa eklendi.";
        public static string TablesListedByRestaurantId = "Restorana ait tüm masalar listelendi.";
        public static string AuthorizationDenied = "Bu operasyona yetkiniz yok.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string ClaimsListed = "Kullanıcının yetkileri listelendi.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string UserAlreadyExist = "Kullanıcı zaten sisteme kayıtlı.";
        public static string UserNotFound = "Sisteme kayıtlı böyle bir kullanıcı yok.";
        public static string PasswordError = "Girdiğiniz şifre hatalı.";
        public static string SuccessfulLogin = "Giriş başarılı!";
        public static string UserRegistered = "Kayıt başarılı!";
    }
}
