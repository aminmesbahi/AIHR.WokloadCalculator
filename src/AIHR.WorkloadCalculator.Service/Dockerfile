#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AIHR.WorkloadCalculator.Service/AIHR.WorkloadCalculator.Service.csproj", "AIHR.WorkloadCalculator.Service/"]
RUN dotnet restore "AIHR.WorkloadCalculator.Service/AIHR.WorkloadCalculator.Service.csproj"
COPY . .
WORKDIR "/src/AIHR.WorkloadCalculator.Service"
RUN dotnet build "AIHR.WorkloadCalculator.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AIHR.WorkloadCalculator.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AIHR.WorkloadCalculator.Service.dll"]