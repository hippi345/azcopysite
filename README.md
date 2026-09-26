# AzCopySite

[![.NET CI](https://github.com/hippi345/azcopysite/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hippi345/azcopysite/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Web UI for planning and triggering [AzCopy](https://learn.microsoft.com/azure/storage/common/storage-use-azcopy-v10) operations against Azure Storage. The site collects storage account names, SAS tokens, and copy options in the browser; wire-up to the AzCopy CLI or Azure APIs is intended to run on the server using credentials you supply at runtime (never committed to the repository).

## Features

- Razor Pages shell with sections for common AzCopy scenarios:
  - Storage account to storage account copy
  - Local upload and download
  - Delete blobs or directories
  - Sync and benchmark helpers (UI scaffolding)
- Optional Azure AD sign-in (configure via app settings)
- Cookie consent banner linked to the privacy page
- Static assets (Bootstrap 3) for layout and styling

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [AzCopy v10+](https://learn.microsoft.com/azure/storage/common/storage-use-azcopy-v10) installed on the machine that will execute copy jobs (not bundled in this repo)

## Setup

```bash
git clone https://github.com/hippi345/azcopysite.git
cd azcopysite/AzCopySite
dotnet restore AzCopySite.sln
dotnet build AzCopySite.sln
```

Run the site:

```bash
dotnet run --project AzCopySite/AzCopySite.csproj
```

Then open the URL shown in the console (typically `https://localhost:5001` or `http://localhost:5000`).

## Configuration

Set values in `appsettings.json`, environment variables, or [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) for local development.

| Setting | Environment variable | Description |
| --- | --- | --- |
| `AzureAd:TenantId` | `AzureAd__TenantId` | Azure AD tenant ID (optional; required for AD login) |
| `AzureAd:ClientId` | `AzureAd__ClientId` | App registration client ID |
| `AzureAd:Instance` | `AzureAd__Instance` | Login endpoint (default Microsoft cloud) |
| `AzureAd:CallbackPath` | `AzureAd__CallbackPath` | OIDC callback path |
| `AzCopy:ExecutablePath` | `AzCopy__ExecutablePath` | Full path to `azcopy` binary if not on `PATH` |

**Do not** commit storage account keys, SAS tokens, or client secrets. Use placeholders in config files and inject real values via your secret store in production.

Example user secrets:

```bash
cd AzCopySite/AzCopySite
dotnet user-secrets init
dotnet user-secrets set "AzureAd:TenantId" "your-tenant-id"
dotnet user-secrets set "AzureAd:ClientId" "your-client-id"
```

## Usage

1. Start the application (`dotnet run`).
2. Open the home page and choose a copy/sync/delete workflow.
3. Enter storage account names and **short-lived SAS tokens** in the form fields (handled client-side today; server integration should invoke AzCopy with those parameters without logging secrets).
4. Use **Login to Azure AD** when Azure AD app registration is configured and you have appropriate RBAC on the storage account.

Official AzCopy documentation: [Configure AzCopy](https://learn.microsoft.com/azure/storage/common/storage-use-azcopy-v10).

## Tests

Integration tests use `WebApplicationFactory` and do not call Azure or run AzCopy:

```bash
cd AzCopySite
dotnet test AzCopySite.sln
```

Format check (same as CI):

```bash
dotnet format AzCopySite.sln --verify-no-changes
```

## Project structure

```
AzCopySite/
├── AzCopySite.sln
├── AzCopySite/              # ASP.NET Core Razor Pages app
│   ├── Pages/               # UI pages (Index, About, Privacy, Contact, Error)
│   ├── wwwroot/             # CSS, JS, vendor libraries
│   ├── Program.cs           # Application entry point
│   └── appsettings.json     # Non-secret configuration template
└── AzCopySite.Tests/        # xUnit integration tests
```

## License

This project is licensed under the MIT License — see [LICENSE](LICENSE).
