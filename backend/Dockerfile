# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura dependências
COPY *.sln .
COPY backend/*.csproj ./backend/
RUN dotnet restore

# Copia todo o código
COPY backend/. ./backend/
WORKDIR /src/backend

# Publica o projeto
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta que a API vai rodar
EXPOSE 5000

# Define o entrypoint
ENTRYPOINT ["dotnet", "backend.dll"]
