#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
#������ϵͳ�����ռ�
WORKDIR /DDI_Monitor_API
#������ǰ�ļ����µ��ļ���������ϵͳ�Ĺ����ռ䣨ע�⣺��.�������пո�
COPY . ./ 
#�����ṩ�Ķ˿ں�
EXPOSE 80 443

#����ʱ��Ϊ�й��Ϻ�
ENV TZ=Asia/Shanghai
ENV DEBIAN_FRONTEND noninteractive
 
# ���ð�ԴΪ����
RUN  sed -i s@/archive.ubuntu.com/@/mirrors.aliyun.com/@g  /etc/apt/sources.list \
&& apt-get clean
 
# ��װ tzdata ������
RUN apt-get update \
&& apt-get install -y tzdata \
&& ln -fs /usr/share/zoneinfo/$TZ  /etc/localtime \
&& rm -rf /var/lib/apt/lists/ \
&& dpkg-reconfigure -f noninteractive tzdata
 
#������ʹ�� ["dotnet","ϵͳ������dll"] ������Ӧ�ó���
ENTRYPOINT ["dotnet", "WKS.UserAPI.dll"]