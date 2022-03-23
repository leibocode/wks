#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WKS_API.csproj", "WKS_API/"]
RUN dotnet restore "WKS_API.csproj"
COPY . .
WORKDIR "/src/WKS_API"
RUN dotnet build "WKS_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WKS_API.csproj" -c Release -o /app/publish

#设置时间为中国上海
ENV TZ=Asia/Shanghai
ENV DEBIAN_FRONTEND noninteractive
 
# 设置包源为阿里
RUN  sed -i s@/archive.ubuntu.com/@/mirrors.aliyun.com/@g  /etc/apt/sources.list \
&& apt-get clean

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WKS_API.dll"]