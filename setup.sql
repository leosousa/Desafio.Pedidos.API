IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'PedidosDb')
BEGIN
    CREATE DATABASE PedidosDb
END