CREATE PROCEDURE sp_GetRecordById 
    @Id INT
AS
BEGIN
     SELECT 
        DispenseId,
        DispenseDate,
        DispenserNo,
        QuantityFilled,
        Rate,
        VehicleNumber,
        PaymentMode,
        PaymentProof AS PaymentProofFileName
    FROM FuelDispense
    WHERE 
        DispenseId = @Id; 
        
END
GO