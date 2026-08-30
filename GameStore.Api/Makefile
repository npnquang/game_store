db_up:
	docker compose --env-file .env up -d
server_up: db_up
	dotnet run