#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER api;
    CREATE DATABASE aquafoo;
    GRANT ALL PRIVILEGES ON DATABASE aquafoo TO api;
EOSQL