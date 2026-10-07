FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet build

RUN pwsh bin/Debug/net9.0/playwright.ps1 install --with-deps chromium

CMD ["dotnet", "test"]