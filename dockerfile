# Usa una imagen base de .NET 9.0 SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia los archivos de proyecto y restaura las dependencias
COPY *.csproj .
RUN dotnet restore

# Copia el resto del código fuente y construye la aplicación
COPY . .
RUN dotnet publish -c Release -o out

# Usa una imagen base de .NET 9.0 Runtime para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia la aplicación publicada desde el contenedor de construcción
COPY --from=build /app/out .

# Expone el puerto 80 (puedes cambiarlo si es necesario)
EXPOSE 80

# Establece el comando para ejecutar la API cuando el contenedor se inicie
ENTRYPOINT ["dotnet", "randominfo.dll"]
