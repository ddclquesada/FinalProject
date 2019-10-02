FROM mcr.microsoft.com/mssql/server:2017-latest

ARG SA_PASSWORD
ENV SA_PASSWORD=P@ssw0rd.123
ARG ACCEPT_EULA
ENV ACCEPT_EULA=Y 

COPY import-data.sh /usr/src/app/
COPY setup.sql /usr/src/app/

# Grant permissions for the import-data script to be executable
RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i /usr/src/app/setup.sql \
    && pkill sqlservr 