FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7020

ENV ASPNETCORE_URLS=http://+:7020

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/kubernetes.dotnet.presentation/kubernetes.dotnet.presentation.csproj", "src/kubernetes.dotnet.presentation/"]
RUN dotnet restore "src/kubernetes.dotnet.presentation/kubernetes.dotnet.presentation.csproj"
COPY . .
WORKDIR "/src/src/kubernetes.dotnet.presentation"
RUN dotnet build "kubernetes.dotnet.presentation.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "kubernetes.dotnet.presentation.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "kubernetes.dotnet.presentation.dll"]
