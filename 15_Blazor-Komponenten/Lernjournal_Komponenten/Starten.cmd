@echo off
cd /d "%~dp0"
echo Blazor Datenlabor startet auf http://localhost:5104
echo Beenden mit Strg+C.
dotnet run --launch-profile http
pause
