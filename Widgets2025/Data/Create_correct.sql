DROP TABLE IF EXISTS Sales;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Widgets;

GO

CREATE TABLE Widgets(
	WidgetID		int identity primary key,
	Name			varchar(20),
	CurrentPrice	money);

CREATE TABLE Customer (
	CustID			int identity primary key,
	FName			varchar(50),
	LName			varchar(50),
	CreditRating	varchar(10)
);

CREATE TABLE Sales (
	SaleNumber		int identity primary key,
	CustID			int,
	WidgetID		int,
	CONSTRAINT Sales_Cust_FK FOREIGN KEY (CustID) REFERENCES Customer,
	CONSTRAINT Sales_Widget_FK FOREIGN KEY (WidgetID) REFERENCES Widgets
);

GO

INSERT INTO Widgets VALUES ('Fidget', 100.00);
INSERT INTO Customer VALUES ('John', 'Michaels', '700');
INSERT INTO Sales VALUES (1,1);