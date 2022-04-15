# Get the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.sln .
COPY UrlsParser/*.csproj ./UrlsParser/
COPY UrlsParser.Tests/*.csproj ./UrlsParser.Tests/
RUN dotnet restore

COPY . ./
RUN dotnet build

FROM build-env AS testrunner
WORKDIR /app/UrlsParser.Tests
RUN dotnet test


FROM build-env AS publish
WORKDIR /app/UrlsParser
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=publish /app/UrlsParser/out .
ENTRYPOINT ["dotnet", "UrlsParser.dll"]
