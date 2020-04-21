#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API-XL-OMS/API-XL-OMS.csproj", "API-XL-OMS/"]
RUN dotnet restore "API-XL-OMS/API-XL-OMS.csproj"
COPY . .
WORKDIR "/src/API-XL-OMS"
RUN dotnet build "API-XL-OMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API-XL-OMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API-XL-OMS.dll"]