#!/bin/bash

echo "Starting the database..."

docker-compose up -d

sleep 10

echo "Managing the database..."
dotnet ef database update

echo "Starting your project..."
dotnet run
