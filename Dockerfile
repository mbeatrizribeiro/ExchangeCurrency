FROM microsoft/dotnet:5.0-aspnetcore:runtime

LABEL version="1.0" maintainer="BeatrizRibeiro"

WORKDIR /app

COPY ./src/ExchangeCurrency/dist .

ENTRYPOINT [ "dotnet", "ExchangeCurrency.Api.dll" ]