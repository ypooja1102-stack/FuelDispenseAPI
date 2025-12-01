ALTER PROCEDURE sp_GetFuelDispense
    @DispenserNo VARCHAR(10) = NULL,
    @PaymentMode VARCHAR(20) = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL
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
        (@DispenserNo IS NULL OR DispenserNo = @DispenserNo)
        AND (@PaymentMode IS NULL OR PaymentMode = @PaymentMode)
        AND (@StartDate IS NULL OR DispenseDate >= @StartDate)
        AND (@EndDate IS NULL OR DispenseDate <= @EndDate)
    ORDER BY DispenseDate DESC;
END
