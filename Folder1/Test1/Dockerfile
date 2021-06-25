FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Test1.csproj", "Test1/"]
RUN dotnet restore "Test1/Test1.csproj"
WORKDIR "/src/Test1"
COPY . .
RUN dotnet build "Test1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test1.csproj"  -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTest1.dll"]
