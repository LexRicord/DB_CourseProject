1. The installation of Oracle Service For Microsoft Transaction Server (OraMTS)
   creates a Windows service called Oracle<OracleHomeName>MTSRecoveryService,
   where <OracleHomeName> is the name of the Oracle Home in which OraMTS is
   installed.

2. This service is created to logon with the "NT AUTHORITY\LOCAL SERVICE" account.
   For security reasons, please modify the logon account as required.
   This can be done using the Services administrative tool.

3. The service listens on a TCP port. The default port used is 2030. Please
   modify this if needed to avoid OraMTS Recovery Service(s) on the same
   machine from using the same port number. The port number is specified at:
   - the string variable "KEY_<OracleHomeName>" in the registry under key of
   HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\OracleMTSRecoveryServices.
   - the string variable "OMTSRECO_PORT" in the registry under key of
   HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\KEY_<OracleHomeName>

4. OraMTS tracing can be enabled by setting the registry variable
   ORAMTS_CP_TRACE_LEVEL under the registry key of
   HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\KEY_<OracleHomeName>
   The value of 0 implies tracing is turned off. Values of 1 through 5 trace with
   increasing levels of detail. The location of the trace files is specified by the
   registry variable ORAMTS_CP_TRACE_DIR under the same registry key.
