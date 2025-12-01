ALTER PROCEDURE sp_AddFuelDispense
    @DispenserNo         VARCHAR(10),     
    @Quantity            DECIMAL(10,2),   
    @Rate                DECIMAL(10,2),
    @VehicleNumber       VARCHAR(20),     
    @PaymentMode         VARCHAR(20),
    @PaymentProofFileName NVARCHAR(255), 
    @Id                  INT OUTPUT       
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO FuelDispense
    (
        DispenserNo,
        QuantityFilled, 
        Rate,
        VehicleNumber,
        PaymentMode,
        PaymentProof,
        CreatedOn
    )
    VALUES
    (
        @DispenserNo,
        @Quantity,      
        @Rate,
        @VehicleNumber,
        @PaymentMode,
        @PaymentProofFileName,
        GETDATE()    
    );

    SET @Id = SCOPE_IDENTITY();
END;
GO