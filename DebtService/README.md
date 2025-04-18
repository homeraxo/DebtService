# DebtService

Servicio RESTful en .NET 8 que permite consultar el historial de deudas y comportamiento financiero de los usuarios de la plataforma Watts. Incluye autenticación por email con JWT, endpoints de consulta de billetera, transacciones y métricas de deuda, y un health check.

---

## 🚀 Características

- 🔐 Autenticación por Email + JWT
- 💼 Endpoints:
  - `GET /get-wallet-by-email`
  - `GET /get-current-balance`
  - `GET /get-transaction-history`
  - `POST /auth/login` → devuelve token JWT
  - `GET /debt-metrics` → historial de deuda y tiempo promedio de liquidación
  - `GET /health` → estado del servicio
- 🐘 MySQL 8 como base de datos
- 📦 Docker y Docker Compose para orquestación
- 🧪 Tests Unitarios
- 📄 Documentación con Swagger

---

## 🧱 Arquitectura

- **Capa de presentación:** Controladores con validación y seguridad JWT
- **Capa de aplicación:** Servicios que encapsulan la lógica de negocio
- **Capa de infraestructura:** EF Core con Pomelo para acceso a datos
- **Base de datos:** MySQL con migraciones automáticas vía `dotnet ef`

---

## 🧪 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker + Docker Compose](https://www.docker.com/)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

---

## 📦 Cómo levantar el proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu_usuario/DebtService.git
   cd DebtService
