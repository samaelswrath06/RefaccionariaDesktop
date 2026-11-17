@echo off
dotnet restore
if errorlevel 1 exit /b 1
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o publish
if errorlevel 1 exit /b 1
echo Ejecutable generado en publish\RefaccionariaDesktop.exe
pause