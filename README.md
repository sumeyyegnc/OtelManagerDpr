# OtelManagerDpr (Otel Yönetim Sistemi)

OtelManagerDpr, ASP.NET Core MVC ve Dapper kullanılarak geliştirilmiş modern bir otel yönetim sistemidir. Otel içerisindeki müşteri (misafir), oda ve rezervasyon işlemlerinin hızlı ve güvenli bir şekilde yönetilmesini sağlar. Ayrıca Excel ve PDF formatında gelişmiş raporlama desteği sunar.

## Özellikler

- **Kullanıcı Yönetimi ve Güvenlik**: Sisteme güvenli giriş yapılması (Şifrelerin hashlenerek saklanması, yetkilendirme).
- **Müşteri (Misafir) Yönetimi**: Misafir kayıtlarının oluşturulması, detaylarının görüntülenmesi, güncellenmesi ve takibi.
- **Oda Yönetimi**: Oteldeki odaların listelenmesi, durumlarının (dolu, boş, bakımdaki vs.) ve özelliklerinin yönetimi.
- **Rezervasyon İşlemleri**: Müşteriler için belirli tarih aralıklarında oda rezervasyonu yapma ve süreç takibi.
- **Gelişmiş Raporlama**: 
  - **Excel Çıktısı**: Kayıtların Microsoft Excel formatında dışa aktarılması (EPPlus).
  - **PDF Çıktısı**: Kayıtların ve detay sayfalarının profesyonel PDF dökümanları haline getirilmesi (QuestPDF).
- **Yüksek Performans**: Micro-ORM aracı Dapper ile hızlı ve efektif veritabanı etkileşimi.

## Kullanılan Teknolojiler

- **Backend Araçları**: .NET 10.0, ASP.NET Core MVC
- **Veritabanı & ORM**: Microsoft SQL Server, Dapper, Microsoft.Data.SqlClient
- **Döküman & Raporlama**: 
  - [EPPlus](https://github.com/EPPlusSoftware/EPPlus) (Excel Raporları)
  - [QuestPDF](https://www.questpdf.com/) (PDF Dökümanları)
- **Frontend Teknolojileri**: Razor Pages, HTML5, CSS, Bootstrap, JavaScript/jQuery

## Kurulum ve Çalıştırma

Projeyi yerel geliştirme ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

1. **Projeyi İndirin/Klonlayın**:
   ```bash
   git clone <repo-url>
   cd OtelManagerDpr
   ```

2. **Bağlantı Dizesini Ayarlayın**:
   `OtelManagerDpr/appsettings.json` (veya `appsettings.Development.json`) dosyası içerisinde bulunan `ConnectionStrings` ayarlarını kendi yerel veya uzak SQL Server bilginize göre güncelleyin.

3. **Veritabanı Hazırlığı**:
   Projede Entity Framework Code-First yerine Dapper kullanılmaktadır. Bu yüzden SQL tablolarının (`Musteriler`, `Odalar`, `Rezervasyonlar`, `Kullanicilar` vb.) oluşturulması gereklidir. Proje klasöründe bulunan veritabanı scriptlerini (varsa) SQL Server'da çalıştırın.

4. **Projeyi Çalıştırın**:
   * Visual Studio 2022+ kullanıyorsanız `OtelManagerDpr.slnx` çözüm dosyasını açıp projenin başlatma tuşuna (F5) basabilirsiniz.
   * Alternatif olarak .NET CLI ile terminal üzerinden çalıştırabilirsiniz:
     ```bash
     dotnet restore
     dotnet run --project OtelManagerDpr/OtelManagerDpr.csproj
     ```

## Proje Klasör Yapısı

- **`Controllers/`**: Uygulamanın HTTP isteklerini işleyen, iş mantığını yönlendiren (AccountController, MusteriController vb.) denetleyiciler.
- **`Models/`**: Dapper ile veritabanı tablolarının maplendiği model sınıfları ve yardımcı araçlar (PasswordHelper vs.).
- **`Views/`**: Kullanıcıya sunulan Razor arayüz sayfaları.
- **`wwwroot/`**: CSS, JS, kütüphaneler (lib) ve resim dosyaları gibi statik kaynaklar.

## Lisans

Projede kullanılan [QuestPDF Community Lisansı](https://www.questpdf.com/license.html) ve EPPlus lisans kuralları göz önünde bulundurulmalıdır. Genel proje kodları için dilediğiniz gibi kullanım sağlayabilirsiniz.