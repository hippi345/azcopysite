# Security Policy

## Supported versions

| Version | Supported |
| --- | --- |
| .NET 8 (current) | Yes |
| Older runtimes | No |

## Reporting a vulnerability

If you discover a security issue, please **do not** open a public GitHub issue with exploit details.

Contact the repository owner privately (for example via GitHub Security Advisories or direct message) with:

- A description of the issue and impact
- Steps to reproduce
- Any suggested fix, if you have one

We will acknowledge reports as soon as possible and work on a fix or mitigation.

## Secrets and credentials

- Never commit storage account keys, SAS tokens, connection strings, or Azure AD client secrets.
- Configure sensitive values through environment variables or user secrets locally (`dotnet user-secrets`), and through your host's secret store in production.
- If a secret was ever committed to git history, rotate it immediately even after removal from the tree.
