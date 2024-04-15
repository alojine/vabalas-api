# VABALAS-API
### A robust backend REST API built using ASP.NET Core and C#, Vabalas stands as a freelance and job-finding platform facilitating seamless job postings. Users can share job opportunities within the platform, extend personalized job offers, and provide feedback through reviews on freelancers' work quality. Vabalas empowers users with statistical tools to showcase top performers and gain insights into overall job distribution trends within the platform.
![zamzamzam.png](/Readme/OggyAndTheCockroaches.png)

# Requirements
* [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* [MySQL](https://www.mysql.com/downloads/)

# Getting started
### 1. Clone the project
```bash
git clone https://github.com/alojine/vabalas-api.git
cd vabalas-api
```
### 2. Build and run the project
```bash
dotnet restore
dotnet build
dotnet run
```

# Environment
* Create ***.env*** at the root of the project and insert environment variables.
```bash
DB_SERVER=<HOST_NAME>
DB_NAME=<DATABASE_NAME>
DB_USER=<DATABASE_USERNAME>
DB_USER=<DATABASE_PASSWORD>

JWT_SECRET=<SECRET_KEY>

EXPOSE_URL=<HOST_TO_EXPOSE>
```
