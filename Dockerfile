FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Expense.csproj", "."]
RUN dotnet restore "./Expense.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Expense.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Expense.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Expense.dll