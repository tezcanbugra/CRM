
## CRM Application project - BSM 311

<p> Proje kapsamında bir CRM(Customer Relation Management) web uygulaması geliştirilmiştir. “Company” objelerinin oluşturulması, güncellenmesi ve silinmesi işlemlerinin gerçekleştirilmesini sağlar. Uygulama geliştirilirken .NET 7 frameworkü kullanılmıştır. Uygulama Database ile iletişim kuran bir Web API ve Web API’a çağrılar yapan bir web uygulamasından oluşmaktadır. Web API’ın iletişim kurduğu database Docker üzerinde çalışan Azure SQL Edge tabanlı MS SQL Serverdır. Web Uygulaması MVC yapısında geliştirilmiştir. Kullanıcı kaydı, kullanıcı girişi, Company objelerinin oluşturulması, güncellenmesi ve silinmesi işlemlerini gerçekleştirir. Web Uygulaması Web API’a GET, POST, PUT ve DELETE methodlarını kullanarak HTTP istekleri yapar ve API Database sorguları ile bu işlemleri gerçekleştirir.  </p>

### Web API (CRMApi)

WEB API .NET 7 kullanılarak geliştirilmiş bir REST API niteliğindedir. 5 farklı çağrı tipini desteklemektedir. Bu işlemler “ GET: api/Company, GET: api/Company/{id}, PUT: api/Company/{id}, POST: api/Company, DELETE: api/Company/{id}” dir. 

![image](https://user-images.githubusercontent.com/32716552/210177099-041a4f5c-f90e-47cf-9c41-3e9ab7b29092.png)

### Web Application(CRMWebApp):

Web uygulaması, Web API’a çağrılar göndererek Company objelerinin oluşturulması, görüntülenmesi, düzenlenmesi ve silinmesini gerçekleştirir. Kullanıcı kaydı ve kullanıcı girişi de bu uygulama üzerinden gerçekleştirilir ve Database üzerinde kullanıcı kayıtları tutulur. 

Web uygulaması MVC( Model-View-Controller) mimarisinde geliştirilmiştir. Company objesinin kullanılabilmesi için gerekli Company modeli tanımı “Models/Company.cs” sınıfında tanımlanmıştır. Company objesinin oluşturulması, görüntülenmesi, düzenlenmesi ve silinmesi için WebApi’a yapılan çağrıların tanımlandığı sınıf “Controllers/CompanyController.cs” sınıfıdır. Bu sınıfta WebApi URL’ine yapılacak olan HTTP istekleri tanımlanmıştır. 

![image](https://user-images.githubusercontent.com/32716552/210177131-8eba9b0c-fc61-48aa-a8d6-a91b5037c7a1.png)

### Database: 

![image](https://user-images.githubusercontent.com/32716552/210177142-0873f637-e362-41db-b89f-c66c54a880e4.png)

![image](https://user-images.githubusercontent.com/32716552/210177147-e9b6a9ec-f857-4305-925c-4e176142fafa.png)
