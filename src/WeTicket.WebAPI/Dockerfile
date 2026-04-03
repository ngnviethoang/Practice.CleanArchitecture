FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS sdk
WORKDIR /src
COPY ["src/WeTicket.WebAPI/WeTicket.WebAPI.csproj", "src/WeTicket.WebAPI/"]
COPY ["src/WeTicket.Application/WeTicket.Application.csproj", "src/WeTicket.Application/"]
COPY ["src/WeTicket.Domain/WeTicket.Domain.csproj", "src/WeTicket.Domain/"]
COPY ["src/WeTicket.Contract/WeTicket.Contract.csproj", "src/WeTicket.Contract/"]
COPY ["src/WeTicket.Infrastructure/WeTicket.Infrastructure.csproj", "src/WeTicket.Infrastructure/"]
COPY ["src/WeTicket.Persistence/WeTicket.Persistence.csproj", "src/WeTicket.Persistence/"]
RUN dotnet restore "WeTicket.WebAPI/WeTicket.WebAPI.csproj"

FROM sdk AS publish
WORKDIR /src/WeTicket.WebAPI
ARG CERT_PASSWORD=SampleValue
RUN dotnet publish "WeTicket.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false && \
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
ENTRYPOINT ["dotnet", "WeTicket.WebAPI.dll"]