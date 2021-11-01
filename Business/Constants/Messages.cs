﻿using Core.Entities.Concrete;
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
        public static string CategoryNameIsRequired = "Kategori adı girilmelidir.";
        public static string TableIdIsRequired = "Masa numarası girilmelidir.";
        public static string OrderDateIsNotValid = "Geçmişe dönük sipariş verilemez.";
        public static string OrderDateIsRequired = "Sipariş tarihi girilmelidir.";
        public static string ProductIsRequired = "Ürün girmek zorunludur.";
        public static string QuantityIsRequired = "Sipariş detayında miktar girmek zorunludur.";
        public static string OrderIdIsRequired = "Sipariş detayı bir siparişe ait olmalıdır.";
        public static string CategoryIdIsRequired = "Ürünün kategorisini girmek zorunludur.";
        public static string ProductNameIsRequired = "Ürün adı boş bırakılamaz.";
        public static string ProductNameIsNotValid = "Ürün adı en az 2 en fazla 100 karakter olmalıdır.";
        public static string UnitPriceIsRequired = "Ürünün birim fiyatı boş bırakılamaz.";
        public static string UnitPriceIsNotValid = "Ürünün birim fiyatı sıfırdan büyük olmalıdır.";
        public static string ProductDescriptionIsNotValid = "Ürün açıklaması en az 250 karakter olmalıdır.";
        public static string StockIsNotValid = "Stok eksi değer alamaz.";
        public static string RestaurantIdIsRequired = "Ürünün hangi restorana ait olduğu girilmelidir.";
        public static string QuantityIsNotValid = "Miktar sıfırdan büyük olmalıdır.";
        public static string TaxNumberIsRequired = "Vergi numarası girmek zorunludur.";
        public static string RestaurantNameIsNotValid = "Restoran adı maksimum 100 karakter olmalıdır.";
        public static string TableNoIsRequired = "Masa mumarası girilmelidir";
        public static string FirstNameIsRequired = "İsim alanı boş bırakılamaz.";
        public static string FirstNameIsNotValid = "İsim 50 karakterden uzun olamaz.";
        public static string LastNameIsRequired = "Soyad alanı boş bırakılamaz.";
        public static string LastNameIsNotValid = "Soyad 50 karakterden uzun olamaz.";
        public static string RestaurantIsRequired = "Kullanıcının çalıştığı restoran girilmelidir.";
        public static string EmailIsRequired = "Kullanıcının emaili girilmelidir.";
        public static string EmailIsNotValid = "Lütfen geçerli bir email adresi giriniz.";
        public static string PasswordIsRequired = "Şifre alanı boş bırakılamaz.";
        public static string PasswordIsNotValid = "Şifreniz en az bir büyük harf,bir sayı,bir özel karakterden oluşmalı ve en az 8 karakter olmalıdır.";
        public static string UserStatusIsInactive = "Kullanıcının durumu pasif.";
        public static string UserStatusUpdated = "Kullanıcı durumu güncellendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string TitleAdded = "Ünvan eklendi";
        public static string TitleDeleted = "Ünvan silindi";
        public static string TitleListed = "Ünvanlar listelendi.";
        public static string TitleUpdated = "Ünvan güncellendi.";
        public static string UserDetailsListed = "Kullanıcı detayı listelendi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserImagePathUpdated = "Kullanıcının fotoğrafı güncellendi.";
        public static string UserImageAdded = "Fotoğraf kullanıcıya eklendi.";
        public static string ImageNotFound = "Fotoğraf bulunamadı.";
        public static string UserImageDeleted = "Kullanıcın fotoğrafı silindi.";
        public static string UserImageLimitExceeded = "Bir kullanıcıya ait fotoğraf sayısı 5'i geçemez.";
        public static string UserImageUpdated = "Kullanıcının fotoğrafı güncellendi.";
        public static string ProductImageDeleted = "Ürün fotoğrafı silindi.";
        public static string ProductImageAdded = "Ürün fotoğrafı eklendi.";
        public static string ProductImagePathIsRequired = "Resim linki alınamadı.";
        public static string UserImagePathIsRequired = "Resim linki alınamadı.";
        public static string UserIdIsRequired = "Kullanıcı bilgisi alınamadı.";
    }
}
