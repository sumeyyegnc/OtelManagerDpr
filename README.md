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

## ScreenShot
<img width="1920" height="1080" alt="Ekran Görüntüsü (126)" src="https://github.com/user-attachments/assets/0ef859c2-9e92-4e26-a06b-f1bf400d091c" />

<img width="1920" height="1080" alt="Ekran Görüntüsü (127)" src="https://github.com/user-attachments/assets/7d73e1aa-428b-4d4a-a709-77d724e3e63e" />

<img width="1920" height="1080" alt="Ekran Görüntüsü (128)" src="https://github.com/user-attachments/assets/34cc05db-7d13-467f-b405-17a9b44150ee" />

<img width="1920" height="1080" alt="Ekran Görüntüsü (129)" src="https://github.com/user-attachments/assets/d7d347e5-d8b2-42ac-81f1-f45eba13f7dc" />

<img width="1920" height="1080" alt="Ekran Görüntüsü (130)" src="https://github.com/user-attachments/assets/2e3ee190-de68-4336-9d7d-3e2ea3088234" />

<img width="1920" height="1080" alt="Ekran Görüntüsü (131)" src="https://github.com/user-attachments/assets/f60dacee-e128-4577-bd16-ee23ee533a04" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (132)" src="https://github.com/user-attachments/assets/2dda00a1-1180-45a2-9360-63288030b809" />



