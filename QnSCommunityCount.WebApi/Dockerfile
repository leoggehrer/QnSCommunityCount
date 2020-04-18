#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["QnSCommunityCount.WebApi/QnSCommunityCount.WebApi.csproj", "QnSCommunityCount.WebApi/"]
COPY ["QnSCommunityCount.Logic/QnSCommunityCount.Logic.csproj", "QnSCommunityCount.Logic/"]
COPY ["QnSCommunityCount.Contracts/QnSCommunityCount.Contracts.csproj", "QnSCommunityCount.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["QnSCommunityCount.Transfer/QnSCommunityCount.Transfer.csproj", "QnSCommunityCount.Transfer/"]
RUN dotnet restore "QnSCommunityCount.WebApi/QnSCommunityCount.WebApi.csproj"
COPY . .
WORKDIR "/src/QnSCommunityCount.WebApi"
RUN dotnet build "QnSCommunityCount.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QnSCommunityCount.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QnSCommunityCount.WebApi.dll"]