FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["03. Applications/App.Api/App.Api.csproj", "03. Applications/App.Api/"]
RUN dotnet restore "03. Applications/App.Api/App.Api.csproj"
COPY . .
WORKDIR "/src/03. Applications/App.Api"
RUN dotnet build "App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Api.dll"]