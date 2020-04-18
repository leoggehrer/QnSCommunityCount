#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["QnSCommunityCount.AspMvc/QnSCommunityCount.AspMvc.csproj", "QnSCommunityCount.AspMvc/"]
COPY ["QnSCommunityCount.Adapters/QnSCommunityCount.Adapters.csproj", "QnSCommunityCount.Adapters/"]
COPY ["QnSCommunityCount.Logic/QnSCommunityCount.Logic.csproj", "QnSCommunityCount.Logic/"]
COPY ["QnSCommunityCount.Contracts/QnSCommunityCount.Contracts.csproj", "QnSCommunityCount.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["QnSCommunityCount.Transfer/QnSCommunityCount.Transfer.csproj", "QnSCommunityCount.Transfer/"]
RUN dotnet restore "QnSCommunityCount.AspMvc/QnSCommunityCount.AspMvc.csproj"
COPY . .
WORKDIR "/src/QnSCommunityCount.AspMvc"
RUN dotnet build "QnSCommunityCount.AspMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QnSCommunityCount.AspMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QnSCommunityCount.AspMvc.dll"]