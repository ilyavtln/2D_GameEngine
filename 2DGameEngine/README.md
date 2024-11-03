# Для сборки в один exe файл запустить

```bash
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true
