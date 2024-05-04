FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Peanuts.Woodstock.Web/Peanuts.Woodstock.Web.csproj", "Peanuts.Woodstock.Web/"]
RUN dotnet restore "Peanuts.Woodstock.Web/Peanuts.Woodstock.Web.csproj"
COPY /src .
WORKDIR "/src/Peanuts.Woodstock.Web"
RUN dotnet build "Peanuts.Woodstock.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Peanuts.Woodstock.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Peanuts.Woodstock.Web.dll" ]