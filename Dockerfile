# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
 
EXPOSE 5000 5001 5002 6379 9092

COPY . /storage 


WORKDIR /storage/web_anuncios
RUN dotnet restore
RUN dotnet build
CMD dotnet run

WORKDIR /storage/api_autenticacao
RUN dotnet restore
RUN dotnet build
CMD dotnet run

WORKDIR /storage/api_publicidade
RUN dotnet restore
RUN dotnet build
CMD dotnet run
