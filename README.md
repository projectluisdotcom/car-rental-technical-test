# Car Rental API

### Sumary

- A first code aproach with EF Core, no SQL will be found here.
- The server will try to migrate the DB everytime you launch the project without any other command other than running it.
- Dependecy Injection using Autofac.
- DDD layered aproach.
- Unit test.
- Integration test.
- SSL.
- DB non-root user & secure password.

### TODO

- ¡Migration fix Autofac can't load the FleetContext when running a migration!
- Improve with streams.
- CarRent could have a ref to car and avoid the IsFree writing everytime we return a car.
- Non happy path tests.
- Github actions CI/CD.
- Basic Auth.
- More features?

### Instructions

#### Notes

- This is tested on a MacOS Docker Desktop but it should work for both Windows and Linux host machines.

## Deploy

### Requeriments

- docker
- docker-composer
- dotnet core (local dev)

### To run

`docker-composer up`

### Watch dotnetcore logs

`docker logs -f car_rental_api_1`

### Manage DB docker

`docker exec -ti car_rental_db_1 bash`

Now inside the container you can login into the Mysql instance, password is root (see docker-composer.yml).
`mysql -u root -p`

## Develop

### Requeriments

- docker
- docker-compose
- dotnetcore
- A proper IDE will help

### Migrate DB

The project uses the CodeFirst approach. So the data base is managed just via code skipping SQL.

If you change the CarContext, the models inside it or add a new context you need to create a Database migration.

Install ef tools and execute migration.

`dotnet tool install --global dotnet-ef`

Api is the main Project for this solution, so you need to perform the tooling on this workdir.
`cd Api`
`dotnet ef migrations add YourMigrationName --verbose`

You just need to CREATE the migrations not EXECUTE them since the code will perform the migration for you.
