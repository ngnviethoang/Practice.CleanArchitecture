FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS sdk
WORKDIR /src
COPY ["src/MiniStore.WebAPI/MiniStore.WebAPI.csproj", "src/MiniStore.WebAPI/"]
COPY ["src/MiniStore.Application/MiniStore.Application.csproj", "src/MiniStore.Application/"]
COPY ["src/MiniStore.Domain/MiniStore.Domain.csproj", "src/MiniStore.Domain/"]
COPY ["src/MiniStore.Contract/MiniStore.Contract.csproj", "src/MiniStore.Contract/"]
COPY ["src/MiniStore.Infrastructure/MiniStore.Infrastructure.csproj", "src/MiniStore.Infrastructure/"]
COPY ["src/MiniStore.Persistence/MiniStore.Persistence.csproj", "src/MiniStore.Persistence/"]
RUN dotnet restore "MiniStore.WebAPI/MiniStore.WebAPI.csproj"

FROM sdk AS publish
WORKDIR /src/MiniStore.WebAPI
ARG CERT_PASSWORD=SampleValue
RUN dotnet publish "MiniStore.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false && \
    dotnet dev-certs https -ep /app/publish/aspnetapp.pfx -p "$CERT_PASSWORD" 

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
EXPOSE 7071
ARG CERT_PASSWORD=SampleValue
ENV ASPNETCORE_URLS="https://+:7071"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="$CERT_PASSWORD"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/aspnetapp.pfx"
COPY --from=publish /app/publish /app
WORKDIR /app
RUN id -u app >/dev/null || useradd -ms /bin/bash app && \
    chown -R app:app /app && chmod -R 755 /app
USER app
ENTRYPOINT ["dotnet", "MiniStore.WebAPI.dll"]