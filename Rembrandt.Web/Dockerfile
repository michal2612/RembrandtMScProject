FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 5003
WORKDIR /app
COPY bin/Release/netcoreapp3.1/publish/ .
ENTRYPOINT ["dotnet", "Rembrandt.Web.dll"]