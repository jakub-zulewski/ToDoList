# To do App

### Welcome to To do App! To run this app, follow these simple steps:

---

#### 1. Run the Application:

- Open your terminal or command prompt.

- Type the following command to start the app:

  ```
  docker-compose up
  ```

- This will launch the necessary services and set up the environment.

#### 2. Access the Web Page:

- Open your web browser.

- Go to http://localhost:8080.

---

### Or

---

#### 1. Run the PostgreSQL Container

- Open your terminal or command prompt.

- Execute the following Docker command to start the PostgreSQL container:

```
docker run --name postgres -e POSTGRES_PASSWORD=zaq1@WSX -d -p 5432:5432 postgres

```

- This command will create a PostgreSQL container named “postgres” with the specified password and expose port 5432.

#### 2. Run the Application:

- Go to the directory where To do application startup code is located. In this case, it’s the `src/ToDoList.Web` directory.

- Inside the `src/ToDoList.Web` directory, execute the following command:

```
dotnet run
```

- Open your web browser.

- Go to http://localhost:5278.
