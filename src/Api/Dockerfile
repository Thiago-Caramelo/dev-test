FROM microsoft/aspnetcore-build:2.0.6-2.1.101 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:2.0.6
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS http://+:5001
EXPOSE 5001
ENTRYPOINT ["dotnet", "api.dll"]