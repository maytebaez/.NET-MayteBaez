-- Insertar cuentas
IF NOT EXISTS(select 1 from Cuentas Where Number = '478758')
BEGIN INSERT INTO Cuentas (Number, Type, State, Balance, ClientId)
VALUES ('478758', 'Ahorros', 1, 2000, 1)
END;

IF NOT EXISTS(select 1 from Cuentas Where Number = '225487')
BEGIN INSERT INTO Cuentas (Number, Type, State, Balance, ClientId)
VALUES ('225487', 'Corriente', 1, 100, 2)
END;

IF NOT EXISTS(select 1 from Cuentas Where Number = '495878')
BEGIN INSERT INTO Cuentas (Number, Type, State, Balance, ClientId)
VALUES ('495878', 'Ahorros', 1, 0, 3)
END;

IF NOT EXISTS(select 1 from Cuentas Where Number = '496858')
BEGIN INSERT INTO Cuentas (Number, Type, State, Balance, ClientId)
VALUES ('496858', 'Ahorros', 1, 540, 2)
END;


-- Insertar movimientos
INSERT INTO Movimientos (Date, Type, Ammount, InitialBalance, AccountNumber)
VALUES (GETDATE(), 'Deposito', 500, 0, '495878');

INSERT INTO Movimientos (Date, Type, Ammount, InitialBalance, AccountNumber)
VALUES (GETDATE(), 'Deposito', 500, 0, '478758');

INSERT INTO Movimientos (Date, Type, Ammount, InitialBalance, AccountNumber)
VALUES (GETDATE(), 'Deposito', 500, 0, '225487');