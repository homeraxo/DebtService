-- Insertar usuarios
INSERT INTO Users (user_id, fullname, email, created_at) VALUES
(1, 'Juan Pérez', 'juan.perez@example.com', NOW()),
(2, 'Ana Gómez', 'ana.gomez@example.com', NOW());

-- Insertar contratos de arrendamiento
INSERT INTO VehicleLeases (vehiclelease_id, user_id, vehicle_vin, vehicle_model, start_date, end_date, weekly_payment, status, contract_number, created_at) VALUES
(1, 1, '1HGCM82633A004352', 'BYD D1', '2023-01-01', '2024-01-01', 750.00, 'Activo', 'CTR-001-JP', NOW()),
(2, 2, '2HGFA16598H302345', 'GAC AION ES', '2023-02-01', '2024-02-01', 650.00, 'Activo', 'CTR-002-AG', NOW());

-- Insertar wallets
INSERT INTO Wallets (wallet_id, user_id, lease_id, balance_amount, status, created_at) VALUES
(1, 1, 1, -150.00, 'En deuda', NOW()),
(2, 2, 2, 500.00, 'Activa', NOW());

-- Insertar transacciones
INSERT INTO Transactions (transaction_id, wallet_id, amount, description, transaction_date, created_at) VALUES
(1, 1, -750.00, 'Pago semanal', '2024-03-01 08:00:00', NOW()),
(2, 1, 600.00, 'Pago recibido', '2024-03-05 09:00:00', NOW()),
(3, 2, -650.00, 'Pago semanal', '2024-03-02 10:00:00', NOW()),
(4, 2, 1150.00, 'Pago recibido', '2024-03-06 12:00:00', NOW());

-- Insertar eventos de deuda
INSERT INTO DebtEvents (debtevent_id, wallet_id, start_date, end_date, duration_hours, settled, created_at) VALUES
(1, 1, '2024-03-01 08:00:00', '2024-03-05 09:00:00', 97, true, NOW()),
(2, 1, '2024-03-10 07:00:00', '2024-03-13 13:00:00', 78, true, NOW());
