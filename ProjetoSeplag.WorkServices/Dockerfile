#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProjetoSeplag.WorkServices/ProjetoSeplag.WorkServices.csproj", "ProjetoSeplag.WorkServices/"]
RUN dotnet restore "ProjetoSeplag.WorkServices/ProjetoSeplag.WorkServices.csproj"
COPY . .
WORKDIR "/src/ProjetoSeplag.WorkServices"
RUN dotnet build "ProjetoSeplag.WorkServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoSeplag.WorkServices.csproj" -c Release -o /app/publish
RUN ls
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoSeplag.WorkServices.dll"]