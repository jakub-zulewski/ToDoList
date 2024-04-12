FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ToDoList.Web/ToDoList.Web.csproj", "src/ToDoList.Web/"]
COPY ["src/ToDoList.Application/ToDoList.Application.csproj", "src/ToDoList.Application/"]
COPY ["src/ToDoList.Domain/ToDoList.Domain.csproj", "src/ToDoList.Domain/"]
COPY ["src/ToDoList.Infrastructure/ToDoList.Infrastructure.csproj", "src/ToDoList.Infrastructure/"]
RUN dotnet restore "./src/ToDoList.Web/ToDoList.Web.csproj"
COPY . .
WORKDIR "/src/src/ToDoList.Web"
RUN dotnet build "./ToDoList.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToDoList.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.Web.dll"]