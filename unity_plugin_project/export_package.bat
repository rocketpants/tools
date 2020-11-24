set UNITY_PATH="C:\Program Files\Unity\Editor\Unity.exe"
set PROJECT_PATH=%cd%
set BUILD_PATH=%PROJECT_PATH%/Build
set LOG_PATH=%PROJECT_PATH%/Temp/export_package_log.txt
set NAME=ProjectName
set /p VERSION=<VERSION.txt
set ASSETS="Assets/RocketPants"
set EXPORT_PATH="%BUILD_PATH%/%NAME%-%VERSION%.unitypackage"

%UNITY_PATH% -batchmode -projectPath %PROJECT_PATH% -exportPackage %ASSETS% %EXPORT_PATH% -logFile %LOG_PATH% -quit