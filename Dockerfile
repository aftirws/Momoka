FROM dhi.io/dotnet:10-sdk AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

FROM dhi.io/dotnet:10
WORKDIR /app
COPY --from=build /app .
COPY --from=build /src/appsettings.json .
ENTRYPOINT ["dotnet", "Momoka.Bot.dll"]
