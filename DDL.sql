CREATE TABLE CONTACTS
(
  Contact_ID         GUID PRIMARY KEY				NOT NULL,
  Date_Added              DATETIME     				NOT NULL,
  Name                    VARCHAR2(50) 				NOT NULL,
  Surname                 VARCHAR2(50) 				NOT NULL,
  Land_Line               VARCHAR2(15) 				NOT NULL,
  Cell                    VARCHAR2(15)              NOT NULL,
  Email                   VARCHAR2(50)              NULL 
);

Insert Into CONTACTS
Values(1,'2016-08-25','Werner','VDR','n/A','+27826449294','Werner@Gmail.com');