@echo off
SETLOCAL EnableDelayedExpansion

set "modId=vartsTradeGuild"
set "modName=VARTS Trade Guild"
set "modVersion=%1%"
set "modulesPath=D:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules"
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

"!msbuildExePath!" "!workDir!\!modId!.csproj"

xcopy "!outDir!\*Harmony*" "!modPath!\bin\Win64_Shipping_Client\"
xcopy "!outDir!\*!modId!*" "!modPath!\bin\Win64_Shipping_Client\"

del /s /q "!outDir!\*" >nul 2>&1

xcopy "!workDir!\Modules\!modId!\GUI" "!modPath!\GUI" /E /I
xcopy "!workDir!\Modules\!modId!\ModuleData" "!modPath!\ModuleData" /E /I

xcopy "!workDir!\Modules\!modId!\SubModule.xml" "!modPath!\SubModule.xml*"

cd /d D:\
cd !modPath!

powershell -Command "(gc SubModule.xml) -replace 'MOD_ID', '!modId!' | Out-File SubModule.xml"
powershell -Command "(gc SubModule.xml) -replace 'MOD_NAME', '!modName!' | Out-File SubModule.xml"
powershell -Command "(gc SubModule.xml) -replace 'MOD_VERSION', '%1%' | Out-File SubModule.xml"
powershell -Command "Get-Content SubModule.xml | Set-Content -Encoding utf8 SubModule2.xml"
del /s /q "SubModule.xml" >nul 2>&1
copy "SubModule2.xml" "SubModule.xml"
del /s /q "SubModule2.xml" >nul 2>&1

cd /d C:\
cd !outDir!
mkdir Modules
cd Modules
mkdir !modId!
cd !modId!
xcopy "!modPath!" "%cd%" /E /I

cd !outDir!
"!sevenZip!" a -r !modId!_!modVersion!.zip Modules
