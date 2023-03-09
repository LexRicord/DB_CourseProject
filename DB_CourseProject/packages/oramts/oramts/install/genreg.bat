echo off
rem script: genreg.bat
rem generates a .reg file to install or deinstall OraMTS

rem fix the slashes to double slashes for adding to the registry ....
set orcl_home=%orcl_home:\=\\%

if (%1) == (deinstall) goto :deinstall
if (%1) == (install)   goto :install

:install
rem  generate registry for setup
echo Windows Registry Editor Version 5.00
echo.
echo [HKEY_LOCAL_MACHINE\SOFTWARE\Oracle]
echo.
echo [HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\KEY_%2]
echo "OMTSRECO_PORT"=hex(2):32,00,30,00,33,00,30,00,00,00
echo.
echo [HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\OracleMTSRecoveryServices]
echo "KEY_%2"=hex(2):32,00,30,00,33,00,30,00,00,00
echo.
echo [HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\%mts_svcname%]
echo "ServiceSidType"=dword:00000001
goto :eof

:deinstall
rem generate registry for deinstall
echo Windows Registry Editor Version 5.00
echo.
echo [HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\KEY_%2]
echo "OMTSRECO_PORT"=-
echo.
echo [HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\OracleMTSRecoveryServices]
echo "KEY_%2"=-
goto :eof

:eof
