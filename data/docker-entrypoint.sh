#!/bin/sh
set -e
echo "The db Dockerfile ENTRYPOINT is about to start. . ."
sleep 2s
/opt/mssql-tools/bin/sqlcmd -S "localhost" -U "sa" -P "Passw0rd!" -i "migration.sql" \
& /opt/mssql/bin/sqlservr 
exec "$@"