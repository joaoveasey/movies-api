
  <h1>movie-api</h1>
  <p>Welcome to my Movie API project! This API was developed to practice and apply concepts learned in college and various courses, such as:</p>
  
  * C#
  * .NET 8
  * ASP.NET Web API
  * Entity Framework
  * MySQL
  * Dependency Injection
  * Repository Pattern
  * Generic Repository
  * Unit of Work
  

## Instructions

### Prerequisites

Ensure you have the following packages installed:

```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.7" />
<PackageReference Include="MySqlConnector.DependencyInjection" Version="2.3.6" />
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.2" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
```

### Configuration
Update the connection string in your appsettings.json file to match your MySQL database configuration:

```json
"ConnectionStrings": {
  "Default": "Server={your_server};Port={your_port};User ID=root;Password={your_password};Database=movie_db"
}
```

### Database Setup (MySQL)
To set up the database and the table, execute the following SQL commands:

```sql
-- creating the database
CREATE DATABASE movie_db;

-- using database we created
USE movie_db;

-- creating the movies table
CREATE TABLE tb_Movies (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    ano_lancamento INT NOT NULL, 
    diretor VARCHAR(200),
    genero VARCHAR(50),
    duracao_em_minutos INT,
    nota FLOAT
);
```

### Running the API
* Clone the repository to your local machine.
* Open the project in Visual Studio 2022.
* Ensure your NuGet packages are installed.
* Ensure your MySQL server is running and the connection string is correctly configured.
* Run the application.

### Built With
* C#
* .NET 8
* Entity Framework Core
* MySQL

