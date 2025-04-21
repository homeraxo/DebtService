-- Datos para la tabla Users
INSERT INTO Users (user_id, fullname, email, created_at) VALUES
(1, 'Juan Pérez Rodríguez', 'juan.perez@email.com', '2024-01-15 09:30:00'),
(2, 'María González López', 'maria.gonzalez@email.com', '2024-01-20 14:45:00'),
(3, 'Carlos Sánchez Martín', 'carlos.sanchez@email.com', '2024-02-05 11:20:00'),
(4, 'Ana Martínez García', 'ana.martinez@email.com', '2024-02-10 16:30:00'),
(5, 'Luis Fernández Ruiz', 'luis.fernandez@email.com', '2024-03-01 10:15:00'),
(6, 'Elena Torres Díaz', 'elena.torres@email.com', '2024-03-15 13:45:00'),
(7, 'Miguel Ramírez Vidal', 'miguel.ramirez@email.com', '2024-04-02 09:00:00'),
(8, 'Laura Jiménez Ortiz', 'laura.jimenez@email.com', '2024-04-10 15:20:00');

-- Datos para la tabla VehicleLeases
INSERT INTO VehicleLeases (vehiclelease_id, user_id, vehicle_vin, vehicle_model, start_date, end_date, weekly_payment, status, contract_number, created_at) VALUES
(101, 1, 'JN1AZ0CP3BT008009', 'Toyota Corolla 2023', '2024-01-20', '2025-01-19', 125.50, 'ACTIVE', 'LEASE-A00123', '2024-01-17 14:30:00'),
(102, 2, 'WBADT43483G023456', 'Honda Civic 2023', '2024-01-25', '2025-01-24', 140.00, 'ACTIVE', 'LEASE-A00124', '2024-01-22 10:15:00'),
(103, 3, '1HGCM82633A123456', 'Nissan Sentra 2022', '2024-02-10', '2025-02-09', 115.75, 'ACTIVE', 'LEASE-A00125', '2024-02-07 09:45:00'),
(104, 4, '2FMDK4JC4CBA56789', 'Ford Focus 2023', '2024-02-15', '2025-02-14', 130.25, 'ACTIVE', 'LEASE-A00126', '2024-02-12 15:30:00'),
(105, 5, 'JTDKN3DU0E0345678', 'Chevrolet Malibu 2022', '2024-03-05', '2025-03-04', 145.50, 'ACTIVE', 'LEASE-A00127', '2024-03-03 11:20:00'),
(106, 6, '5YJSA1E64HF123456', 'Hyundai Elantra 2023', '2024-03-20', '2025-03-19', 120.00, 'ACTIVE', 'LEASE-A00128', '2024-03-17 13:10:00'),
(107, 7, 'JM1BL1SF1A1234567', 'Mazda 3 2023', '2024-04-05', '2025-04-04', 135.25, 'ACTIVE', 'LEASE-A00129', '2024-04-03 10:45:00'),
(108, 1, 'KMHDU4AD0AU123456', 'Kia Optima 2022', '2024-04-15', '2025-04-14', 132.75, 'ACTIVE', 'LEASE-A00130', '2024-04-12 14:20:00');

-- Datos para la tabla Wallets
INSERT INTO Wallets (wallet_id, user_id, lease_id, balance_amount, status, created_at) VALUES
(201, 1, 101, 250.00, 'ACTIVE', '2024-01-17 14:35:00'),
(202, 2, 102, 180.50, 'ACTIVE', '2024-01-22 10:20:00'),
(203, 3, 103, 210.75, 'ACTIVE', '2024-02-07 09:50:00'),
(204, 4, 104, 175.25, 'ACTIVE', '2024-02-12 15:35:00'),
(205, 5, 105, 320.00, 'ACTIVE', '2024-03-03 11:25:00'),
(206, 6, 106, 240.50, 'ACTIVE', '2024-03-17 13:15:00'),
(207, 7, 107, 195.75, 'ACTIVE', '2024-04-03 10:50:00'),
(208, 1, 108, 265.25, 'ACTIVE', '2024-04-12 14:25:00');

-- Datos para la tabla Transactions
INSERT INTO Transactions (transaction_id, wallet_id, amount, description, transaction_date, created_at) VALUES
(301, 201, 500.00, 'Depósito inicial', '2024-01-17 14:40:00', '2024-01-17 14:40:00'),
(302, 201, -125.50, 'Pago semanal de arrendamiento', '2024-01-24 09:00:00', '2024-01-24 09:00:00'),
(303, 201, -125.50, 'Pago semanal de arrendamiento', '2024-01-31 09:00:00', '2024-01-31 09:00:00'),
(304, 202, 450.00, 'Depósito inicial', '2024-01-22 10:25:00', '2024-01-22 10:25:00'),
(305, 202, -140.00, 'Pago semanal de arrendamiento', '2024-01-29 09:00:00', '2024-01-29 09:00:00'),
(306, 202, -140.00, 'Pago semanal de arrendamiento', '2024-02-05 09:00:00', '2024-02-05 09:00:00'),
(307, 203, 400.00, 'Depósito inicial', '2024-02-07 09:55:00', '2024-02-07 09:55:00'),
(308, 203, -115.75, 'Pago semanal de arrendamiento', '2024-02-14 09:00:00', '2024-02-14 09:00:00'),
(309, 203, -115.75, 'Pago semanal de arrendamiento', '2024-02-21 09:00:00', '2024-02-21 09:00:00'),
(310, 204, 425.00, 'Depósito inicial', '2024-02-12 15:40:00', '2024-02-12 15:40:00'),
(311, 204, -130.25, 'Pago semanal de arrendamiento', '2024-02-19 09:00:00', '2024-02-19 09:00:00'),
(312, 204, -130.25, 'Pago semanal de arrendamiento', '2024-02-26 09:00:00', '2024-02-26 09:00:00'),
(313, 205, 475.00, 'Depósito inicial', '2024-03-03 11:30:00', '2024-03-03 11:30:00'),
(314, 205, -145.50, 'Pago semanal de arrendamiento', '2024-03-10 09:00:00', '2024-03-10 09:00:00'),
(315, 205, -145.50, 'Pago semanal de arrendamiento', '2024-03-17 09:00:00', '2024-03-17 09:00:00'),
(316, 206, 380.00, 'Depósito inicial', '2024-03-17 13:20:00', '2024-03-17 13:20:00'),
(317, 206, -120.00, 'Pago semanal de arrendamiento', '2024-03-24 09:00:00', '2024-03-24 09:00:00'),
(318, 206, -120.00, 'Pago semanal de arrendamiento', '2024-03-31 09:00:00', '2024-03-31 09:00:00'),
(319, 207, 410.00, 'Depósito inicial', '2024-04-03 10:55:00', '2024-04-03 10:55:00'),
(320, 207, -135.25, 'Pago semanal de arrendamiento', '2024-04-10 09:00:00', '2024-04-10 09:00:00'),
(321, 207, -135.25, 'Pago semanal de arrendamiento', '2024-04-17 09:00:00', '2024-04-17 09:00:00'),
(322, 208, 430.00, 'Depósito inicial', '2024-04-12 14:30:00', '2024-04-12 14:30:00'),
(323, 208, -132.75, 'Pago semanal de arrendamiento', '2024-04-19 09:00:00', '2024-04-19 09:00:00');

-- Datos para la tabla DebtEvents (casos donde hubo retrasos en pagos)
INSERT INTO DebtEvents (debtevent_id, wallet_id, start_date, end_date, duration_hours, settled, created_at) VALUES
(401, 201, '2024-01-31 09:00:00', '2024-02-01 15:30:00', 30, true, '2024-02-01 15:30:00'),
(402, 203, '2024-02-21 09:00:00', '2024-02-22 11:45:00', 27, true, '2024-02-22 11:45:00'),
(403, 204, '2024-02-26 09:00:00', '2024-02-28 14:20:00', 53, true, '2024-02-28 14:20:00'),
(404, 205, '2024-03-17 09:00:00', '2024-03-18 10:15:00', 25, true, '2024-03-18 10:15:00'),
(405, 206, '2024-03-31 09:00:00', '2024-04-02 16:30:00', 55, true, '2024-04-02 16:30:00'),
(406, 208, '2024-04-19 09:00:00', '2024-04-20 12:45:00', 28, false, '2024-04-20 12:45:00');