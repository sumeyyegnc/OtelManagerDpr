namespace OtelManagerDpr.Models
{
    public class RezervasyonModel
    {
        public int RezervasyonNo { get; set; }
        public int MusteriNo { get; set; }
        public int OdaNo { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Durum { get; set; }

        // ViewAll/ViewByNo join sonucu
        public string MusteriAdSoyad { get; set; }
        public string OdaKodu { get; set; }
    }
}
