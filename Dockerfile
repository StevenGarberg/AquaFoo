FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build-env
WORKDIR /app

COPY . ./

ARG GIT_USERNAME
ARG GIT_PERSONAL_ACCESS_TOKEN

RUN dotnet restore ./AquaFoo.App
#RUN dotnet test ./AquaFoo.App/AquaFoo.App.Tests.csproj
RUN dotnet publish ./AquaFoo.App/AquaFoo.App.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim

#NEW RELIC STUFF HERE

ARG COMMIT_SHA
ENV COMMIT_SHA=$COMMIT_SHA

WORKDIR /app
COPY --from-build-env /apt/out .
ENTRYPOINT ["dotnet", "AquaFoo.App.dll"]