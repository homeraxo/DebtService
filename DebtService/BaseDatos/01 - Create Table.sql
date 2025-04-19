CREATE TABLE `Users` (
  `user_id` integer PRIMARY KEY,
  `fullname` nvarchar(255) NOT NULL,
  `email` nvarchar(100) UNIQUE NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE `VehicleLeases` (
  `vehiclelease_id` integer PRIMARY KEY,
  `user_id` integer NOT NULL,
  `vehicle_vin` nvarchar(100) NOT NULL,
  `vehicle_model` nvarchar(100) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `weekly_payment` decimal(18,2) NOT NULL,
  `status` nvarchar(50) NOT NULL,
  `contract_number` nvarchar(100) UNIQUE NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE `Wallets` (
  `wallet_id` integer PRIMARY KEY,
  `user_id` integer NOT NULL,
  `lease_id` integer NOT NULL,
  `balance_amount` decimal(18,2) NOT NULL,
  `status` nvarchar(50) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE `Transactions` (
  `transaction_id` integer PRIMARY KEY,
  `wallet_id` integer NOT NULL,
  `amount` decimal(18,2) NOT NULL,
  `description` nvarchar(255),
  `transaction_date` timestamp NOT NULL DEFAULT (now()),
  `created_at` timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE `DebtEvents` (
  `debtevent_id` integer PRIMARY KEY,
  `wallet_id` integer NOT NULL,
  `start_date` timestamp NOT NULL,
  `end_date` timestamp NOT NULL,
  `duration_hours` integer NOT NULL,
  `settled` boolean NOT NULL DEFAULT true,
  `created_at` timestamp NOT NULL DEFAULT (now())
);

ALTER TABLE `Wallets` ADD CONSTRAINT `Users_Wallets` FOREIGN KEY (`user_id`) REFERENCES `Users` (`user_id`);

ALTER TABLE `VehicleLeases` ADD CONSTRAINT `Users_Leases` FOREIGN KEY (`user_id`) REFERENCES `Users` (`user_id`);

ALTER TABLE `Wallets` ADD CONSTRAINT `Wallets_Leases` FOREIGN KEY (`lease_id`) REFERENCES `VehicleLeases` (`vehiclelease_id`);

ALTER TABLE `Transactions` ADD CONSTRAINT `Wallets_Transactions` FOREIGN KEY (`wallet_id`) REFERENCES `Wallets` (`wallet_id`);

ALTER TABLE `DebtEvents` ADD CONSTRAINT `Wallets_DebtEvents` FOREIGN KEY (`wallet_id`) REFERENCES `Wallets` (`wallet_id`);
