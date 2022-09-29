#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Documentacao/AVS.Documentacao.API/AVS.Documentacao.API.csproj", "src/Documentacao/AVS.Documentacao.API/"]
COPY ["src/Services/Infra/Data/AVS.Cadastro.Data/AVS.Cadastro.Data.csproj", "src/Services/Infra/Data/AVS.Cadastro.Data/"]
COPY ["src/Services/Domains/AVS.Cadastro.Domain/AVS.Cadastro.Domain.csproj", "src/Services/Domains/AVS.Cadastro.Domain/"]
COPY ["src/Core/AVS.Core/AVS.Core.csproj", "src/Core/AVS.Core/"]
COPY ["src/Services/Domains/AVS.Banda.Domain/AVS.Banda.Domain.csproj", "src/Services/Domains/AVS.Banda.Domain/"]
COPY ["src/Services/Infra/CrossCutting/AVS.Infra.CrossCutting/AVS.Infra.CrossCutting.csproj", "src/Services/Infra/CrossCutting/AVS.Infra.CrossCutting/"]
COPY ["src/Services/Infra/Data/AVS.Infra.Data/AVS.Infra.Data.csproj", "src/Services/Infra/Data/AVS.Infra.Data/"]
COPY ["src/Services/Applications/AVS.Cadastro.Application/AVS.Cadastro.Application.csproj", "src/Services/Applications/AVS.Cadastro.Application/"]
COPY ["src/Services/Applications/AVS.Banda.Application/AVS.Banda.Application.csproj", "src/Services/Applications/AVS.Banda.Application/"]
COPY ["src/Services/Infra/Data/AVS.Banda.Data/AVS.Banda.Data.csproj", "src/Services/Infra/Data/AVS.Banda.Data/"]
RUN dotnet restore "src/Documentacao/AVS.Documentacao.API/AVS.Documentacao.API.csproj"
COPY . .
WORKDIR "/src/src/Documentacao/AVS.Documentacao.API"
RUN dotnet build "AVS.Documentacao.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AVS.Documentacao.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AVS.Documentacao.API.dll"]