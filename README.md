# DGII.PruebaTecnica.Contribuyentes

WebApi para la prueba tecnica de Analista Programador de la DGII


## Authors

- [@rafael-rosa-quintino](https://github.com/rafael-rosa-quintino)


## DataBase Installation

En la carpeta del proyecto se encuentra dos archivos 

**MSSQL.sql**  Para la instalaccion de la base de datos en MS SQL Server
**MySqlScripts.sql**  Para la instalaccion de la base de datos en MySql
## Environment Variables

Para corre este proyecto se necesita agregar los siguientes valores en el archivo appsetting.json

`"DataBaseServer : """`

La propiedad *DataBaseServer* puede ser configurada con los siguientes valores

-**MySql** Si su servidor de base de datos es de MySql

-**MSSQL** Si su servidor de base de datos es de MS SQL Server

`"ConnectionStrings" : {"DGII" : ""} `

Esta propiedad se debe de colocar la conexion a la base de datos, segun la que haya especificado en la propiedad *DataBaseServer*