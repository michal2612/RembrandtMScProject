FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 5001
WORKDIR /app
COPY bin/Release/netcoreapp3.1/publish/ .
ENTRYPOINT ["dotnet", "Rembrandt.Dataset.Api.dll"]