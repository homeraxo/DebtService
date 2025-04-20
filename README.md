# DebtService

Servicio RESTful en .NET 8 C# ybase de datos en MySQL que permite consultar el historial de deudas y comportamiento financiero de los usuarios de la plataforma Watts by Vemo. Incluye autenticación por email con JWT, endpoints de consulta de billetera, transacciones y métricas de deuda, y un health check.

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
- 📄 Documentación con Postman

---

## 🧱 Arquitectura

- **Capa de presentación:** Controladores con validación y seguridad JWT
- **Capa de aplicación:** Servicios que encapsulan la lógica de negocio
- **Capa de infraestructura:** EF Core con Pomelo para acceso a datos
- **Base de datos:** MySQL: https://dbdiagram.io/d/Debt-History-67fe2a929cea640381c500c9
  
  ![imagen](https://github.com/user-attachments/assets/c627297f-6c8b-47d9-add5-21d4ce6da225)

---

## 🧪 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker + Docker Compose](https://www.docker.com/)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

---

## 📦 Cómo levantar el proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/homeraxo/DebtService.git
   cd DebtService

2. Docker
   ```bash
   docker-compose up --build

3. Abrir el explorador e ingresar la URL: 
    http://localhost:5039/swagger/index.html
  
5. Postman dentro de la solución se encuentra la colección y las variables

    - https://masters-8882.postman.co/workspace/Masters-Workspace~4c6a2275-f2f0-4157-8917-274cdfd19f90/collection/15120044-ff3e435a-f977-4169-acb9-c24cd7fc5bf6?action=share&creator=15120044&active-environment=15120044-efaf95c4-f133-4fbd-af65-b51bcf322ab0

    - Endpoints de la API: VemoDebtHistory.postman_collection.json
   
    - Ambiente de variables: Vemo Debt.postman_environment.json
