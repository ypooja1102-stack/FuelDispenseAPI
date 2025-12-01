CREATE TABLE FuelDispense (
DispenseId INT IDENTITY(1,1) PRIMARY KEY,
DispenseDate DATETIME NOT NULL,
DispenserNo VARCHAR(10) NOT NULL,
QuantityFilled DECIMAL(10,2) NOT NULL,
Rate DECIMAL(10,2) NOT NULL,
VehicleNumber VARCHAR(20) NOT NULL,
PaymentMode VARCHAR(20) NOT NULL,
PaymentProof NVARCHAR(255) NULL,
CreatedOn DATETIME DEFAULT GETDATE()
)

INSERT INTO FuelDispense (DispenseDate, DispenserNo, QuantityFilled, Rate, VehicleNumber, PaymentMode, PaymentProof)
VALUES
('2025-11-29 10:00', 'D-01', 12.5, 90.00, 'MH12AB1234', 'Cash', '/uploads/r1.jpg'),
('2025-11-29 11:15', 'D-02', 8.0, 85.50, 'MH14CD5678', 'UPI', '/uploads/r2.png');

Select * from FuelDispense