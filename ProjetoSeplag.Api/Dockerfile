#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProjetoSeplag.Api/ProjetoSeplag.Api.csproj", "ProjetoSeplag.Api/"]
RUN dotnet restore "ProjetoSeplag.Api/ProjetoSeplag.Api.csproj"
COPY . .
WORKDIR "/src/ProjetoSeplag.Api"
RUN dotnet build "ProjetoSeplag.Api.csproj" -c Release -o /app/build
RUN ls
FROM build AS publish
RUN dotnet publish "ProjetoSeplag.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY cert-aspnetcore.pfx .
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoSeplag.Api.dll"]