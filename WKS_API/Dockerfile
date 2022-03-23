#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#容器中系统工作空间
WORKDIR /WKS_API
#拷贝当前文件夹下的文件到容器中系统的工作空间（注意：“.”后面有空格）
COPY . ./ 
#对外提供的端口号
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

#设置时间为中国上海
ENV TZ=Asia/Shanghai
ENV DEBIAN_FRONTEND noninteractive
 
# 设置包源为阿里
RUN  sed -i s@/archive.ubuntu.com/@/mirrors.aliyun.com/@g  /etc/apt/sources.list \
&& apt-get clean
 
# 安装 tzdata 软件包
RUN apt-get update \
&& apt-get install -y tzdata \
&& ln -fs /usr/share/zoneinfo/$TZ  /etc/localtime \
&& rm -rf /var/lib/apt/lists/ \
&& dpkg-reconfigure -f noninteractive tzdata

ENV ASPNETCORE_URLS http://+:5001
 
#容器中使用 ["dotnet","系统启动的dll"] 来运行应用程序
ENTRYPOINT ["dotnet", "WKS_API.dll"]