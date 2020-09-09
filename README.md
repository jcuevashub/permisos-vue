# permisos

> A Vue.js project

## Build Setup

```bash

#User Test
user:74ck502@dev-928406.com
pass:@Sa123456

# install dependencies
npm install

# serve with hot reload at localhost:8080
npm run dev

#Create the msql-docker container if you are using Mac
sudo docker pull microsoft/mssql-server-linux:2017-latest
docker run -e ‘HOMEBREW_NO_ENV_FILTERING=1’ -e ‘ACCEPT_EULA=Y’ -e ‘SA_PASSWORD=sa(!)1234’ -p 1433:1433 -d microsoft/mssql-server-linux

#Api conection string
"Server=localhost,1433\\Catalog=PermisosDB;User=sa;Password=sa(!)1234;"

#Create a database called
PermisosDB

#Update migrations
dotnet ef database update

# run the api on the foder Permisos.Api
dotnet watch run
```
