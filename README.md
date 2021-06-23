# MobirollerHomework
## İlk Adım Proje oluşturuldu.

## Program dökümanı eklerdedir.
#### Api dökümanına https://documenter.getpostman.com/view/16365424/TzecCQfJ adresi üzerinden ulaşabilirsiniz.
#### Postman collection link: https://www.getpostman.com/collections/a441d0e763a01859f089
#### Veri çekerken hata alırsanız eğer TurkishEventManager ve ItalianEventManager içerisindeki url bölümünü güncelleyiniz.

### Proje ilk github'a yüklendiği sıradaki yapılan işlemler.
1. Veritabanı oluşturuldu.
2. Proje katmanları oluşturuldu. Business-Core-DataAccess-Entities-WebAPI
3. EntityFramework altyapısı oluşturuldu.
4. Dependency Resolver işlemleri için Autofac kuruldu.
5. Kullanıcıların yaptıkları işlemlerin olumlu veya olumsuz sonuç doğurduğunu gösterecek Results işlemleri Core katmanına eklendi. Sabit mesajların bir kısmı oluşturuldu.
6. Json üzerinden gelen verileri boş veritabanı tablosuna ekleme işlemleri yapıldı.
7. Direk Json verileri linkten okuyacak sistem oluşturuldu.
8. 6 ve 7 maddedeki olaylar sadece türkçe veriler için yapıldı.

## Ödev hakkında yorumlarım ve Programımdaki beni rahatsız eden durumlar
1. Çok eğlenceleydi bir projeydi. Oldukça keyif aldım.
2. Bir sürü yeni bilgi edindim. Bu açıdan teşekkür ederim.
3. Exception yönetimini ilk defa kullandım ve çok içime sinmemiş olsa da çalışıyor. İçime sinmeme sebebi StatusCode hep 500 döndürüyorum. Onu dinamik hale getiremedim.
4. RequestLocalization kısmını hallettim IP adresine göre konum buluyor, konuma göre veri gösteriyor. İlerleyen zamanlarda bu işlemleri yaptığım EventsController içerisindeki kodları Business içerisine taşıyacağım. Olurda MVC gibi farklı bir yapıya geçmek istersek aynı kodları tekrardan yazmamış olurum.

