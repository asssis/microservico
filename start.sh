cd ./api_publicidade
dotnet restore
dotnet build
nohup dotnet run &

cd ../web_anuncios
dotnet restore
dotnet build
nohup dotnet run &
