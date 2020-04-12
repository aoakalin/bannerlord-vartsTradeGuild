@echo off
setlocal enableDelayedExpansion

set "modId=vartsTradeGuild"
set "modName=VARTS Trade Guild"
set "modVersion=%1%"
set "modulesPath=C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules"
set "msbuildExePath=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
set "sevenZip=C:\Program Files\7-Zip\7z.exe"

set "workDir=%cd%"
set "outDir=!workDir!\out"

set "modPath=!modulesPath!\!modId!"

del /s /q "!modPath!\*" >nul 2>&1
rmdir "!modPath!\" >nul 2>&1
mkdir "!modPath!"
mkdir "!modPath!\bin"
mkdir "!modPath!\bin\Win64_Shipping_Client"

del /s /q "!outDir!\*" >nul 2>&1

"!msbuildExePath!" "%cd%\!modId!.csproj"

xcopy "!outDir!\*Harmony*" "!modPath!\bin\Win64_Shipping_Client\"
xcopy "!outDir!\*!modId!*" "!modPath!\bin\Win64_Shipping_Client\"

del /s /q "!outDir!\*" >nul 2>&1

xcopy "%cd%\Modules\!modId!\GUI" "!modPath!\GUI" /E /I

xcopy "%cd%\Modules\!modId!\SubModule.xml" "!modPath!\SubModule.xml*"

cd !modPath!

powershell -Command "(gc SubModule.xml) -replace 'MOD_ID', '!modId!' | Out-File SubModule.xml"
powershell -Command "(gc SubModule.xml) -replace 'MOD_NAME', '!modName!' | Out-File SubModule.xml"
powershell -Command "(gc SubModule.xml) -replace 'MOD_VERSION', '%1%' | Out-File SubModule.xml"

cd ..

"!sevenZip!" a -r !modId!_!modVersion!.zip ./!modId!/*

xcopy !modId!_!modVersion!.zip "!outDir!\"
del /q !modId!_!modVersion!.zip >nul 2>&1
