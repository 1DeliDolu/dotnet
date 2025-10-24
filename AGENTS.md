# Repository Guidelines

## Project Structure & Module Organization
- Solution entry point is `Readme.sln`; the console host lives in `DotnetPlayground.csproj` with `Program.cs` routing to topic modules.
- Feature demos reside under enumerated folders such as `1_RecordTypes/`, each exposing a `*Topic.cs` entry point and its own project file.
- Shared launch profiles sit in `Properties/launchSettings.json`; reuse these when adding new environments.
- Helper scripts are under `scripts/`, currently focused on WSL integration via `scripts/wsl/enable-windows-dotnet.sh`.
- Build artifacts land in `bin/` and `obj/`; keep them out of source control.

## Build, Test, and Development Commands
```bash
dotnet restore Readme.sln
dotnet build Readme.sln
dotnet run --project DotnetPlayground.csproj
dotnet run --project 1_RecordTypes/RecordTypes.csproj
```
- Use the restore/build commands before committing to ensure dependencies and compilation succeed.
- The per-topic `dotnet run` command lets you iterate on a module without launching the main menu.

## Coding Style & Naming Conventions
- Stick to C# defaults: 4-space indentation, `PascalCase` for types/namespaces, `camelCase` for locals and parameters.
- Keep files small and focused; place new demos inside their numbered folder with matching `README.md`.
- Nullable reference types and implicit usings are enabled; honour the null-safety annotations.
- Run `dotnet format` (if installed) before pushing to keep spacing and using directives aligned with SDK rules.

## Testing Guidelines
- No automated tests live in this repository yet; add xUnit projects under a future `tests/` directory.
- Name test projects `<TopicName>.Tests` and individual classes `<Subject>Tests`.
- Wire new tests into the solution and execute them via `dotnet test Readme.sln`; enforce high-coverage discipline by default.

## Commit & Pull Request Guidelines
- Existing history uses short imperative subjects (for example, `init`); follow that style and keep the first line under 72 characters.
- Reference the affected topic or script in the body when context is non-obvious.
- Pull requests should include: purpose summary, key testing steps (`dotnet build`/`dotnet test` output), and screenshots for console output changes when relevant.

## WSL Setup Notes
- For WSL development against the Windows SDK, run `scripts/wsl/enable-windows-dotnet.sh` once per distro, then `source ~/.bashrc`.
- Select the appropriate `WSL` launch profile in Visual Studio or use `dotnet run` from your WSL shell to trigger the same configuration.
