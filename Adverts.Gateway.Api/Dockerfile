#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Adverts.Gateway.Api/Adverts.Gateway.Api.csproj", "Adverts.Gateway.Api/"]
COPY ["RabbitMQ.Base/RabbitMQ.Base.csproj", "RabbitMQ.Base/"]
COPY ["Adverts.Application/Adverts.Application.csproj", "Adverts.Application/"]
COPY ["Adverts.Core/Adverts.Core.csproj", "Adverts.Core/"]
COPY ["Adverts.Application.Model/Adverts.Application.Model.csproj", "Adverts.Application.Model/"]
COPY ["RabbitMQ.Producer/RabbitMQ.Producer.csproj", "RabbitMQ.Producer/"]
COPY ["Adverts.Infrastructure/Adverts.Infrastructure.csproj", "Adverts.Infrastructure/"]
COPY ["Adverts.Common/Adverts.Common.csproj", "Adverts.Common/"]
COPY ["Adverts.Core.Mapping/Adverts.Core.Mapping.csproj", "Adverts.Core.Mapping/"]
RUN dotnet restore "Adverts.Gateway.Api/Adverts.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/Adverts.Gateway.Api"
RUN dotnet build "Adverts.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adverts.Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adverts.Gateway.Api.dll"]
