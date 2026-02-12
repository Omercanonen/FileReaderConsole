# FileReaderConsole
.NET Framework kullanılarak geliştirilmiş, metin tabanlı dosyaları analiz eden modüler konsol uygulaması.

## Özellikler:
- **Birden fazla metin formatını destekler (desteklenen metin formatları çoğaltılabilecek mimari ile geliştirilmiştir).**
- **Desteklenen Metin Formatları:**
	- .txt
	- docx
	- .pdf
- **Kelime Analizi:**
	- Toplam farklı kelime analizi
	- Tekrar eden kelimeler ve sayıları
		- Bağlaçlar tekrar eden kelime sayısına dahil değildir.
- **Noktalama İşaretleri Analizi:**
	- Tüm noktalama işaretleri sayılır ve her birinin kaç kez kullanıldığı raporlanır.
- **Hata Yönetimi ve Loglama:**
	- Alınan hatalar Logs dosyasına kaydedilir.

## Mimari:
- **Core:** Arayüzlerin bulunduğu katmandır (IFileReader,Ilogger burada bulunur).
- **Model:** Nesnelerin tanımlandığı katmandır (AnalysisResult burada bulunur, analiz sonuçlarını tutar).
- **Services:** İş mantığının bulunduğu katmandır.
	- **FileReaders:** Dosya okuma işlemlerinin yapıldığı sınıf. Okunması istenilen dosya formatına göre genişletilebilir.
	- **Logging:** Loglama işlemlerinin yapıldığı sınıf.
	- **FileReader:** Dosya tiplerinin analiz edildiği sınıf.
	- **TextAnalyzer:** Dosyaların içerisindeki metinlerin analiz edildiği sınıf.

## Kullanılan Teknolojiler:
- .NET Framework 4.8
- C#
- **NuGet paketleri:**
	- DocumentFormat.OpenXML https://github.com/dotnet/Open-XML-SDK (Word Dosyaları)
	- PdfPig https://www.nuget.org/packages/PdfPig/ (PDF Dosyaları)

## Kurulum:
- Repoyu klonlayın
	 `git clone https://github.com/Omercanonen/FileReaderConsole`
- Projeyi Visual Studio 2022 ile açın
- Gerekli NuGet paketlerini indirin
- Projeyi başlatın

## Klasör Yapısı:
```
FileAnalyzer/  
├── Core/  
│ ├── FileReader.cs  
│ └── ILogger.cs  
├── Model/  
│ └── AnalysisResult.cs  
├── Services/  
│ ├── FileReaders/  
│ │ ├── DocxFileReader.cs  
│ │ ├── PdfFileReader.cs  
│ │ └── TxtFileReader.cs  
│ └── Logging/  
│ └── FileLogger.cs  
├── FileReader.cs  
├── TextAnalyzer.cs  
└── Program.cs
```
