FROM mcr.microsoft.com/dotnet/aspnet:5.0

LABEL version="1.0" maintainer="BeatrizRibeiro"

COPY ExchangeCurrency/bin/Release/net5.0/publish .

WORKDIR /App

ENTRYPOINT ["dotnet", "ExchangeCurrency.Api.dll"]