Create Database DGII
GO


USE DGII
GO

Create table Taxpayer
(
Id int Not Null Identity(1,1),
RNCCedula Varchar(25) Not Null,
Name Varchar(250) Not Null,
Type Int Not Null Default 0,
Status Int Not Null Default 0,
Deleted bit Not Null Default 0
)
GO



Create table TaxReceipt
(
Id int Not Null Identity(1,1),
TaxpayerId Int Not Null,
NCF Varchar(25) Not Null,
Monto Decimal(18,2) Not Null Default 0,
ITBIS18 Decimal(18,2) Not Null Default 0,
Deleted bit Not Null Default 0
)

GO

ALTER TABLE Taxpayer
ADD CONSTRAINT PK_Taxpayer PRIMARY KEY (Id)
GO


ALTER TABLE TaxReceipt
ADD CONSTRAINT PK_TaxReceipt PRIMARY KEY (Id)
GO


ALTER TABLE TaxReceipt
ADD CONSTRAINT FK_Taxpayer_TaxReceipt FOREIGN KEY (TaxpayerId) REFERENCES Taxpayer(Id)
GO



INSERT INTO Taxpayer (RNCCedula, Name, Type, Status, Deleted) VALUES ('40214226843', 'Quintino Rafael', '1', '1', '0');
INSERT INTO Taxpayer (RNCCedula, Name, Type, Status, Deleted) VALUES ('40214226844', 'Camille Marie', '1', '1', '0');
INSERT INTO Taxpayer (RNCCedula, Name, Type, Status, Deleted) VALUES ('98754321012', 'JUAN PEREZ', '1', '1', '0');
INSERT INTO Taxpayer (RNCCedula, Name, Type, Status, Deleted) VALUES ('123456789', 'FARMACIA TU SALUD', '2', '0', '0');
GO

INSERT INTO TaxReceipt (TaxpayerId, NCF, Monto, ITBIS18, Deleted) VALUES ('1', 'B0100000015', '200', '36', '0');
INSERT INTO TaxReceipt (TaxpayerId, NCF, Monto, ITBIS18, Deleted) VALUES ('1', 'B0100000016', '100', '18', '0');

INSERT INTO TaxReceipt (TaxpayerId, NCF, Monto, ITBIS18, Deleted) VALUES ('2', 'B0100000017', '500', '90', '0');
INSERT INTO TaxReceipt (TaxpayerId, NCF, Monto, ITBIS18, Deleted) VALUES ('2', 'B0100000018', '1546', '278.18', '0');

INSERT INTO TaxReceipt (TaxpayerId, NCF, Monto, ITBIS18, Deleted) VALUES ('3', 'E310000000001', '200', '36.25', '0');
INSERT INTO TaxReceipt (TaxpayerId, NCF, Monto, ITBIS18, Deleted) VALUES ('3', 'E310000000002', '1000', '180', '0');
GO