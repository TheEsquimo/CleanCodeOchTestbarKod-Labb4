#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CleanCodeOchTestbarKod-Labb4.csproj", ""]
RUN dotnet restore "./CleanCodeOchTestbarKod-Labb4.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CleanCodeOchTestbarKod-Labb4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanCodeOchTestbarKod-Labb4.csproj" -c Release -o /app/publish

FROM base AS final
RUN sudo apt-get -y update
RUN sudo apt-get -y upgrade
RUN sudo apt-get install -y sqlite3 libsqlite3-dev
RUN mkdir /db
RUN /usr/bin/sqlite3 /db/test.db
CMD /bin/bash
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanCodeOchTestbarKod-Labb4.dll"]