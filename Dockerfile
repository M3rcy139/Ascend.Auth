FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Consolidate all local NuGet packages into one directory
COPY nuget.config .
COPY Ascend.Common.Packages/nupkgs/                           local-packages/
COPY Ascend.Person.Service/nupkgs/                            local-packages/
COPY Ascend.Person.Service/Ascend.Person.Client/nupkgs/       local-packages/
COPY Ascend.Person.Service/Ascend.Person.Client.Abstractions/nupkgs/ local-packages/
COPY Ascend.Person.Service/Ascend.Person.Domain/nupkgs/       local-packages/

COPY Ascend.Auth.Service/ Ascend.Auth.Service/
RUN rm Ascend.Auth.Service/NuGet.config

RUN dotnet restore Ascend.Auth.Service/Ascend.Auth.Service.sln

RUN dotnet publish Ascend.Auth.Service/Ascend.Auth.Presentation.REST/Ascend.Auth.Presentation.REST.csproj \
    -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=5000

ENTRYPOINT ["dotnet", "Ascend.Auth.Presentation.REST.dll"]