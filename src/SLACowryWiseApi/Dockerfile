#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SLACowryWiseApi/SLACowryWiseApi.csproj", "src/SLACowryWiseApi/"]
COPY ["src/SLACowryWise.Domain/SLACowryWise.Domain.csproj", "src/SLACowryWise.Domain/"]
RUN dotnet restore "src/SLACowryWiseApi/SLACowryWiseApi.csproj"
COPY . .
WORKDIR "/src/src/SLACowryWiseApi"
RUN dotnet build "SLACowryWiseApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SLACowryWiseApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SLACowryWiseApi.dll"]