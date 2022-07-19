#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BabysitterFy.UI.WebAPI/BabysitterFy.UI.WebAPI.csproj", "BabysitterFy.UI.WebAPI/"]
RUN dotnet restore "BabysitterFy.UI.WebAPI/BabysitterFy.UI.WebAPI.csproj"
COPY . .
WORKDIR "/src/BabysitterFy.UI.WebAPI"
RUN dotnet build "BabysitterFy.UI.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BabysitterFy.UI.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BabysitterFy.UI.WebAPI.dll"]