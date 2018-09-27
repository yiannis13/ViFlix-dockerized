FROM microsoft/dotnet:2.1-sdk-alpine AS build

WORKDIR /app/src/Service
COPY ./Service /app/src/Service
RUN ["dotnet", "restore"]

WORKDIR /app/src/Common 
COPY ./Common /app/src/Common 
RUN ["dotnet", "restore"]

WORKDIR /app/src/Persistence 
COPY ./Persistence /app/src/Persistence 
RUN ["dotnet", "restore"]

WORKDIR /app/src/Service
RUN dotnet publish -o output -c release
ENTRYPOINT ["dotnet", "output/Service.dll"]