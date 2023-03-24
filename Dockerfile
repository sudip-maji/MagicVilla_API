FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5145

ENV ASPNETCORE_URLS=http://+:5145

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MagicVilla_VillaAPI/MagicVilla_VillaAPI.csproj", "MagicVilla_VillaAPI/"]
RUN dotnet restore "MagicVilla_VillaAPI\MagicVilla_VillaAPI.csproj"
COPY . .
WORKDIR "/src/MagicVilla_VillaAPI"
RUN dotnet build "MagicVilla_VillaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagicVilla_VillaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagicVilla_VillaAPI.dll"]
