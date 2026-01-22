# 🚇 Metro Line Management API
---

## 📌 Description
A RESTful ASP.NET Core Web API for managing metro lines and their stations using Entity Framework Core.

---

## 🛠 Technologies
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Dependency Injection

---

## 🧱 Architecture
Layered Architecture:
- Controller
- Service
- Repository

---

## 🔗 API Endpoints

### Metro Lines
- `GET /api/lines`
- `GET /api/lines/{id}`
- `POST /api/lines`

### Stations
- `POST /api/stations`
- `GET /api/stations/{id}`
- `GET /api/stations/line/{id}`

---

## ⚙ Configuration

Maximum stations per line depend on the environment.


