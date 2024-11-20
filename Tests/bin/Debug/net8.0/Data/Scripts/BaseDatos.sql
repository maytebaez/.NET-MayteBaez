SET IDENTITY_INSERT Clientes ON;

IF NOT EXISTS(select 1 from Clientes Where Id = 1)
BEGIN INSERT INTO Clientes (Id, Name, Address, PhoneNumber, Password, State, Gender, Age, DocumentNumber) 
VALUES (1, 'Jose Lema', 'Otavalo sn y principal', '098254785', '1234', 1, 'Masculino', 24, '1726356356')
END;

IF NOT EXISTS(select 1 from Clientes Where Id = 2)
BEGIN INSERT INTO Clientes (Id, Name, Address, PhoneNumber, Password, State, Gender, Age, DocumentNumber) 
VALUES (2,'Marianela Montalvo', 'Amazonas y NNUU', '0987548965', '5678', 1, 'Femenino', 26, '1723653236')
END;

IF NOT EXISTS(select 1 from Clientes Where Id = 3)
BEGIN INSERT INTO Clientes (Id, Name, Address, PhoneNumber, Password, State, Gender, Age, DocumentNumber) 
VALUES (3, 'Juan Osorio', '13 de junio y Equinoccial', '098874587', '1245', 1, 'Masculino', 36, '1752365563')
END;

SET IDENTITY_INSERT Clientes OFF;