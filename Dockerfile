FROM dhi.io/dotnet:10-sdk AS build
WORKDIR /src
COPY Momoka.Bot/*.csproj .
RUN dotnet restore
COPY Momoka.Bot/* .
RUN dotnet publish -c Release -o /app

FROM dhi.io/dotnet:10 AS setup
CMD [ "dotnet tool install --global dotnet-ef --version 10" ]

FROM dhi.io/dotnet:10
WORKDIR /app
COPY --from=build /app .
COPY --from=build /src/appsettings.json .
CMD [ "dotnet ef database update" ]
ENTRYPOINT ["dotnet", "Momoka.Bot.dll"]
