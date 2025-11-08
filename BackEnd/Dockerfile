FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

COPY BackEnd.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

RUN apt-get update && apt install curl -y # needed for health check

COPY --from=build /app ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "BackEnd.dll"]
