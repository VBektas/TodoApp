# TodoApp

TodoApp, .NET 8 ve MSSQL veritabanı kullanan bir RESTful Web API projesidir.
Uygulama, Docker Compose aracılığıyla çalıştırılır ve Swagger UI üzerinden test edilebilir.

## 🐳 Docker ile Uygulamanın Çalıştırılması

1. Terminal veya PowerShell üzerinden `Docker` klasörüne geçiş yapın:

2. Docker Compose komutu ile tüm servisleri başlatın:
 - docker-compose up --build
Bu işlem aşağıdaki servisleri başlatır:

api: .NET 8 Web API (port: 5000)
mssql: SQL Server 2022 instance (port: 1433)

🌐 API Kullanımı
Uygulama başarıyla başlatıldığında Swagger UI üzerinden API'yi test edebilirsiniz:

📎 Swagger URL:
http://127.0.0.1:5000/swagger/index.html
