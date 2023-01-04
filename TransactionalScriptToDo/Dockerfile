#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TransactionalScriptToDo/TransactionalScriptToDo.csproj", "TransactionalScriptToDo/"]
RUN dotnet restore "TransactionalScriptToDo/TransactionalScriptToDo.csproj"
COPY . .
WORKDIR "/src/TransactionalScriptToDo"
RUN dotnet build "TransactionalScriptToDo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransactionalScriptToDo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionalScriptToDo.dll"]