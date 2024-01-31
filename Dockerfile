FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY WebApiReact.csproj .
RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

CMD ["dotnet", "WebApiReact.dll"]