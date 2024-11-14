#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Karim_eShop/Karim_eShop.csproj", "Karim_eShop/"]
COPY ["Business/api.Karim_eshop.Business.DTOs/api.Karim_eshop.Business.DTOs.csproj", "Business/api.Karim_eshop.Business.DTOs/"]
COPY ["Data/api.Karim_eshop.Data.Entity/api.Karim_eshop.Data.Entity.csproj", "Data/api.Karim_eshop.Data.Entity/"]
COPY ["Business/api.Karim_eshop.Business.Service.Contract/api.Karim_eshop.Business.Service.Contract.csproj", "Business/api.Karim_eshop.Business.Service.Contract/"]
COPY ["Common/api.Karim_eshop.Common/api.Karim_eshop.Common.csproj", "Common/api.Karim_eshop.Common/"]
COPY ["Data/api.Karim_eshop.Data.Context/api.Karim_eshop.Data.Context.csproj", "Data/api.Karim_eshop.Data.Context/"]
COPY ["Data/api.Karim_eshop.Data.Context.Contract/api.Karim_eshop.Data.Context.Contract.csproj", "Data/api.Karim_eshop.Data.Context.Contract/"]
COPY ["Business/api.Karim_eshop.Business.Service/api.Karim_eshop.Business.Service.csproj", "Business/api.Karim_eshop.Business.Service/"]
COPY ["Data/api.Karim_eshop.Data.Repository.Contract/api.Karim_eshop.Data.Repository.Contract.csproj", "Data/api.Karim_eshop.Data.Repository.Contract/"]
COPY ["Data/api.Karim_eshop.Data.Repository/api.Karim_eshop.Data.Repository.csproj", "Data/api.Karim_eshop.Data.Repository/"]
COPY ["IoC/api.Karim_eshop.IoC.Application/api.Karim_eshop.IoC.Application.csproj", "IoC/api.Karim_eshop.IoC.Application/"]
COPY ["IoC/api.Karim_eshop.IoC.Tests/api.Karim_eshop.IoC.Tests.csproj", "IoC/api.Karim_eshop.IoC.Tests/"]
COPY ["Tests/api.Karim_eshop.Tests.Common/api.Karim_eshop.Tests.Common.csproj", "Tests/api.Karim_eshop.Tests.Common/"]
# COPY ["Tests/api.Karim_eshop.Tests.integra/api.Karim_eshop.Tests.integra.csproj", "Tests/api.Karim_eshop.Tests.integra/"]
COPY ["Tests/api.Karim_eshop.Tests.Unitaire/api.Karim_eshop.Tests.Unitaire.csproj", "Tests/api.Karim_eshop.Tests.Unitaire/"]
RUN dotnet restore "./Karim_eShop/./Karim_eShop.csproj"
COPY . .
WORKDIR "/src/Karim_eShop"
RUN dotnet build "./Karim_eShop.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Karim_eShop.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Karim_eShop.dll"]