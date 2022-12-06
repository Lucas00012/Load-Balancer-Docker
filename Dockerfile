FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["./Mvc1/Mvc1.csproj", "web/Mvc1/"]

RUN dotnet restore "web/Mvc1/Mvc1.csproj"
COPY ["./", "web"]
WORKDIR "web/Mvc1"
RUN dotnet build "Mvc1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mvc1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mvc1.dll"]