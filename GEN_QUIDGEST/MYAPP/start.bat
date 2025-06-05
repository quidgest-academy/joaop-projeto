@echo off
setlocal

::-------------------------------------------------------------------
:: Deploy Solution
echo Starting Docker Compose...
docker compose up -d --build
if %ERRORLEVEL% neq 0 (
    echo Error: Docker Compose failed with exit code %ERRORLEVEL%
    exit /b %ERRORLEVEL%
)
echo Deployment complete!

::-------------------------------------------------------------------
:: Database maintenance
docker exec -i webadmin bash < docker_db_maintenance.sh

endlocal