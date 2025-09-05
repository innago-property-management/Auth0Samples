#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG TARGETARCH
WORKDIR /src
 
ARG NUGET_SOURCE_NAME
ARG NUGET_SOURCE_URL
ARG NUGET_USERNAME
 
RUN --mount=type=secret,id=nuget_password,target=/run/secrets/nuget_password \
    if [ -n "$NUGET_SOURCE_URL" ] && [ -n "$NUGET_USERNAME" ]; then \
        NUGET_PASSWORD_FROM_SECRET=$(cat /run/secrets/nuget_password); \
        dotnet nuget add source \
            --name "$NUGET_SOURCE_NAME" \
            --username "$NUGET_USERNAME" \
            --password "$NUGET_PASSWORD_FROM_SECRET" \
            --store-password-in-clear-text \
            "$NUGET_SOURCE_URL"; \
    fi

COPY ./.editorconfig .
COPY src .

WORKDIR /src
COPY ["src/IdpServiceFacade/IdpServiceFacade.csproj", "IdpServiceFacade/"]
COPY ["src/Abstractions/Abstractions.csproj", "Abstractions/"]
COPY ["src/Auth0Client/Auth0Client.csproj", "Auth0Client/"]

ARG TARGETPLATFORM
ARG BUILDPLATFORM

RUN dotnet restore "./IdpServiceFacade/IdpServiceFacade.csproj" --arch $TARGETARCH
RUN dotnet publish ./IdpServiceFacade/IdpServiceFacade.csproj \
    --no-restore \
    --configuration Release \
    --output /app \
    --self-contained false \
    --arch $TARGETARCH \
    -p:SKIP_OPENAPI_GENERATION=true

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS app
 
LABEL vendor="Innago"
LABEL com.innago.image="Innago.Auth0ServiceFacade"

RUN addgroup --gid 10001 notroot \
    && adduser --uid 10001 --ingroup notroot notroot --disabled-password --no-create-home

WORKDIR /app
COPY --from=build /app .

USER notroot:notroot
ENV ASPNETCORE_URLS="http://+:8080"
ENV DOTNET_EnableDiagnostics=1
ENV DOTNET_EnableDiagnostics_IPC=0
ENV DOTNET_EnableDiagnostics_Debugger=0
ENV DOTNET_EnableDiagnostics_Profiler=1
ENV ASPNETCORE_HOSTBUILDER_RELOADCONFIGONCHANGE="false"

ENTRYPOINT ["dotnet", "Innago.Security.IdpServiceFacade.dll"]
