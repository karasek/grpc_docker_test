FROM microsoft/dotnet:2.1-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:sdk AS build
WORKDIR /src

COPY planner.api/*.csproj ./planner.api/
COPY planner/*.csproj ./planner/

RUN dotnet restore planner.api/planner.api.csproj
RUN dotnet restore planner/planner.csproj
COPY . .

WORKDIR /src/planner.api
RUN dotnet build -c Release -o /app

WORKDIR /src/planner
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

EXPOSE 5000
ENTRYPOINT ["dotnet", "planner.dll"]