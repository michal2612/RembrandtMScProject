FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 5001
RUN dotnet publish -c Release
COPY bin/Release/netcoreapp3.1/publish/ .
ENTRYPOINT ["dotnet", "Rembrandt.Dataset.Api.dll"]