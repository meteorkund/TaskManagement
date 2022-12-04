### TaskManagement
Backend w/OnionArchitecture - .NET7

## HAKKINDA
- Onion Architecture mimarisi kullanılarak tasarlanmış bir backend yönetimidir.
- Kullanıcının günlük, haftalık veya aylık görevler oluşturabileceği ve yönetecebileceği bir işleyiş mevcuttur.
- Veritabanı MSSql olarak seçilmiştir.
- Veritabanı ve kod yönetimi açısından ORM yaklaşımı ile beraber EntityFrameworkCore kullanılmıştır.
- Repository design pattern olarak generic repository design pattern kullanılmıştır.
- Kullanıcının veritabanına, veritabanını olumsuz etkileyecek bazı veriler göndermesi ise FluentValidator ile engellenmiştir.
- Mediator kütüphanesi ile CQRS pattern uygulanmıştır. Single responsibility principle korunmuştur ve daha düzenli bir controller sağlanmıştır. Bununla beraber, Dependency Injection Hell'den kaçılmıştır.

- Authentication sağlanması adına JWT kullanılmıştır ve kullanıcının token süresi bitiminde authorize devamlılığı adına refresh token kullanılmıştır.
- Sistemde oluşan info, warning ve error'lar için Serilog kütüphanesi kullanılmıştır. Oluşturulan log'lar hem veritabanı tarafında hem de fiziksel olarak saklanmıştır.

## KULLANILAN ARAÇLAR
* ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
* ![.NET](https://img.shields.io/badge/.NET%207-5C2D91.svg?style=for-the-badge&logo=.net&logoColor=white)
* ![ASP.NET CORE](https://img.shields.io/badge/ASP.NET%20CORE-5C2D91.svg?style=for-the-badge&logo=.net&logoColor=white)
* ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
* ![Swagger](https://img.shields.io/badge/-Swagger-%23239120.svg?style=for-the-badge&logo=swagger&logoColor=white)
* ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
* ![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)
* ![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-blue?style=for-the-badge)
* ![Fluent Validator](https://img.shields.io/badge/Fluent%20Validator-blue?style=for-the-badge)
* ![MediatR](https://img.shields.io/badge/MediatR-blue?style=for-the-badge)
* ![Serilog](https://img.shields.io/badge/MediatR-blue?style=for-the-badge)


## KURULUM
1. Repo'yu klonla
```bash
  git clone https://github.com/meteorkund/TaskManagement
```
2. NuGet paketlerini restore et.

3. MSSql Connection String'i appsettings.json üzerinden değiştir.

## :handshake: İLETİŞİM
Mete Orkun DEMIR - meteorkundemir@gmail.com

Proje Link: [https://github.com/meteorkund/TaskManagement](https://github.com/meteorkund/TaskManagement)
