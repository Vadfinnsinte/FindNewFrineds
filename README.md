# Find Friends

We all know that creating friendships has become harder in today’s society. We don’t meet people in the same ways we used to.

This is the beginning of the backend for an app that will (hopefully) help solve this problem.

## Tech Stack & Architecture

This project is built using a clean and scalable backend architecture with separation of concerns and modern .NET practices.

The system follows a layered architecture with **Domain**, **Application**, and **Infrastructure** layers, ensuring clear responsibility boundaries and maintainability.

### Core Architecture
- Implements **CQRS (Command Query Responsibility Segregation)** with **MediatR**
- Commands and Queries are fully separated in the Application layer
- Handlers are organized in dedicated `Commands/` and `Queries/` folders
- All controller actions communicate through MediatR (no direct service calls)

### Data Layer
- Built with **Entity Framework Core**
- Uses **Repository Pattern** with a shared `IRepository` abstraction
- Repository implementations are placed in the Infrastructure layer
- Configured with **SQL Server / SQL Express**
- Database is managed using **EF Core Migrations** 

### Models & CRUD
- At least two entities with relational mapping (e.g. one-to-many or many-to-many)
- Full **CRUD functionality** implemented for at least one entity
- Clean domain modelling with proper relationships

### Mapping & Validation
- Uses **AutoMapper** for object-to-object mapping
- Implements **FluentValidation** for request validation
- Includes a **MediatR Pipeline Behavior** for validation handling

### Authentication & Authorization
- Implements **JWT Bearer Authentication**
- Login endpoint returns a signed JWT token
- Secure endpoints require valid authentication via `[Authorize]`
- Includes **Role-Based Access Control (RBAC)** for authorization

## API Endpoints

### Authentication

| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| POST | /api/auth/login | Logs in a user and returns a JWT token | Public |
| POST | /api/auth/register | Registers a new user | Public |
| POST | /api/auth/register-admin | Registers a new admin user | Admin only |

---

### Events

| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | /api/events | Retrieves all events | Authenticated |
| POST | /api/events | Creates a new event | Authenticated |
| PUT | /api/events/{id} | Updates an existing event | Authenticated (Owner/Admin) |
| DELETE | /api/events/{id} | Deletes an event | Authenticated (Owner/Admin) |
| POST | /api/events/{id}/join | Join an event as participant | Authenticated |
| DELETE | /api/events/{id}/leave | Leave an event | Authenticated |
| GET | /api/events/my-events | Gets events the user participates in | Authenticated |

---

### Likes

| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| POST | /api/likes/{toUserId} | Likes another user | Authenticated |

---

### Matches

| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | /api/matches | Retrieves all matches for the user | Authenticated |
| DELETE | /api/matches/{matchId} | Deletes a match | Authenticated |

---

### Users

| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | /api/users/discover | Gets users for discovery/swiping | Authenticated |

