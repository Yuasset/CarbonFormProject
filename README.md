# 🌍 Karbon Ayakizi Formu

Bu proje, bireylerin ulaşım, ev enerjisi kullanımı ve tüketim alışkanlıklarını analiz etmek üzere bilgi toplayan, **ASP.NET Core** tabanlı modern bir web uygulamasıdır.

Proje, **N-Tier (Çok Katmanlı) Mimari** prensiplerine uygun olarak, kurumsal kod standartlarında geliştirilmiştir.

## 🚀 Öne Çıkan Özellikler

* **Sekme Bağımsızlığı:** Kullanıcı aynı tarayıcıda birden fazla sekme açarak birbirinden bağımsız formlar doldurabilir. Veriler karışmaz.
* **Client-Side State Management:** Form verileri, son aşamaya kadar sunucuda değil, tarayıcının `sessionStorage` alanında tutulur. Bu sayede sunucu performansı artırılır ve gereksiz veri tabanı kaydı oluşmaz.
* **Adım Adım (Wizard) Yapısı:** Kullanıcıyı yormayan, dinamik ve kullanıcı dostu 5 aşamalı form süreci.
* **Güçlü Validasyon:** Hem sunucu (FluentValidation) hem de istemci (JavaScript) tarafında veri doğrulama kuralları.
* **N-Tier Mimari:** Gevşek bağlı (Loosely Coupled) ve sürdürülebilir katmanlı yapı.

## 🏗️ Mimari Yapı

Proje, sorumlulukların ayrılması (SoC) ilkesine göre 5 ana katmana ayrılmıştır:

| Katman | Proje Adı | Görevi |
| :--- | :--- | :--- |
| **Web (UI)** | `CarbonForm.Web` | Kullanıcı arayüzü, Controller ve JavaScript (Session Manager) mantığı. |
| **Service** | `CarbonForm.Service` | İş mantığı (Business Logic), DTO dönüşümleri ve Validasyonlar. |
| **Data** | `CarbonForm.Data` | Veritabanı erişimi (EF Core), Repository ve UnitOfWork desenleri. |
| **Core** | `CarbonForm.Core` | Projenin çekirdeği. Entity sınıfları |
| **Common** | `CarbonForm.Common` | Tüm katmanların ortak kullandığı Enum, Sabitler ve Yardımcı sınıflar. |

## 🛠️ Kullanılan Teknolojiler ve Kütüphaneler

* **Framework:** .NET 8.0 (ASP.NET Core MVC)
* **Veritabanı:** MS SQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Mapping:** AutoMapper
* **Validation:** FluentValidation
* **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript (jQuery)
* **Veri Yönetimi:** Generic Repository & Unit of Work Pattern
