FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/DevJJGR.App/Donouts.Presentation.csproj", "src/DevJJGR.App/"]
COPY ["src/DevJJGR.Application/Donouts.Application.csproj", "src/DevJJGR.Application/"]
COPY ["src/DevJJGR.Domain/Donouts.Domain.csproj", "src/DevJJGR.Domain/"]
COPY ["src/DevJJGR.Infrastructure/Donouts.Infrastructure.csproj", "src/DevJJGR.Infrastructure/"]
COPY ["src/DevJJGR.Persistence/Donouts.Persistance.csproj", "src/DevJJGR.Persistence/"]
RUN dotnet restore "src/DevJJGR.App/Donouts.Presentation.csproj"
COPY . .
WORKDIR "/src/src/DevJJGR.App"
RUN dotnet build "Donouts.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Donouts.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Donouts.Presentation.dll"]
