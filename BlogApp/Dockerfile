FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /src
COPY *.sln .
COPY Blog.Tests/*.csproj Blog.Tests/
COPY Blog.Presentation/*.csproj Blog.Presentation/

RUN dotnet restore

COPY . .

#Testing
FROM base AS testing
WORKDIR /src/Blog.Presentation

RUN dotnet build
WORKDIR /src/Blog.Tests
RUN dotnet test

#Publishing
FROM base AS publish
WORKDIR /src/Blog.Presentation
RUN dotnet publish -c Release -o /src/publish

#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .



#ENTRYPOINT ["dotnet", "AnimalFarmsMarket.Core.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Blog.Presentation.dll