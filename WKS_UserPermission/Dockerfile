#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WKS_UserPermission/WKS_UserPermission.csproj", "WKS_UserPermission/"]
RUN dotnet restore "WKS_UserPermission/WKS_UserPermission.csproj"
COPY . .
WORKDIR "/src/WKS_UserPermission"
RUN dotnet build "WKS_UserPermission.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WKS_UserPermission.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WKS_UserPermission.dll"]