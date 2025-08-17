FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY gerenciador-de-tarefas.sln .

COPY backend/*.csproj ./backend/

RUN dotnet restore gerenciador-de-tarefas.sln

COPY backend/. ./backend/

WORKDIR /src/backend

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5228
ENTRYPOINT ["dotnet", "backend.dll"]
