FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CleanArchCqrs.Api/CleanArchCqrs.Api.csproj", "CleanArchCqrs.Api/"]
COPY ["CleanArchCqrs.Application/CleanArchCqrs.Application.csproj", "CleanArchCqrs.CleanArchCqrs/"]
COPY ["CleanArchCqrs.Domain/CleanArchCqrs.Domain.csproj", "CleanArchCqrs.Domain/"]
COPY ["CleanArchCqrs.Infra.Data/CleanArchCqrs.Infra.Data.csproj", "CleanArchCqrs.Infra.Data/"]
COPY ["CleanArchCqrs.Infra.IoC/CleanArchCqrs.Infra.IoC.csproj", "CleanArchCqrs.Infra.IoC/"]
COPY ["CleanArchCqrs.Infra.Sqs/CleanArchCqrs.Infra.Sqs.csproj", "CleanArchCqrs.Infra.Sqs/"]
RUN dotnet restore "CleanArchCqrs.Api/CleanArchCqrs.Api.csproj"
COPY . .
WORKDIR "/src/CleanArchCqrs.Api"
RUN dotnet build "CleanArchCqrs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CleanArchCqrs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM build as migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT dotnet-ef database update --project /src/CleanArchCqrs.Infra.Data/ --startup-project /src/CleanArchCqrs.Api/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchCqrs.Api.dll"]