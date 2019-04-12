FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY IdentityServer/*.csproj ./IdentityServer

RUN dotnet restore IdentityServer

COPY . ./

RUN dotnet publish IdentityServer -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9 AS runtime

WORKDIR /app
COPY --from=build-env /app/IdentityServer/out .
COPY IdentityServer/aspid-user.db ./aspid-user.db
COPY IdentityServer/tempkey.rsa ./tempkey.rsa

RUN apk add tzdata && ln -sf /usr/share/zoneinfo/Asia/Taipei /etc/localtime && echo "Asia/Taipei" > /etc/timezone
ENTRYPOINT ["dotnet", "IdentityServer.dll"]

