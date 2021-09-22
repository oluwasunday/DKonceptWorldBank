#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app 
EXPOSE 80
EXPOSE 443

# copy and restore all projects
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY AbimMall/*.csproj AbimMall/
COPY AbimMall.Models/*.csproj AbimMall.Models/
COPY AbimMall.Data/*.csproj AbimMall.Data/
COPY AbimMall.Core/*.csproj AbimMall.Core/

RUN dotnet restore AbimMall/*.csproj

COPY . .
WORKDIR /src/AbimMall
RUN dotnet build

FROM build AS publish
WORKDIR /src/AbimMall
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /src/AbimMall/wwwroot/jsons/category.json jsons/
COPY --from=publish /src/AbimMall/wwwroot/jsons/product.json jsons/

#ENTRYPOINT ["dotnet", "AbimMall.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AbimMall.dll