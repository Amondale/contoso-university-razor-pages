-- <Migration ID="d20e3d47-94bc-483c-ad7f-2f5db3066672" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.09.30
** CREATION:     Adding more data to make the app more fun!
**************************************************************************/
DELETE	c
FROM	dbo.CourseAssignment c
WHERE	EXISTS (SELECT 1 FROM dbo.Instructor i WHERE c.InstructorGuid  = i.InstructorGuid AND InstructorId > 5)

DELETE 
FROM	dbo.Instructor 
WHERE	InstructorId > 5

SET IDENTITY_INSERT dbo.Instructor ON
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(6,'4040565A-C701-4EE6-E76C-08D742BC182C',NULL,'Joseph','Vincent','McCarthy',NULL,'1887-04-21','2018-08-05','Yankee Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(7,'5C2CD7A0-F28C-4FC7-E76D-08D742BC182C',NULL,'Connie',NULL,'Mack',NULL,'1862-12-22','2018-08-01','Nationals Park',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(8,'C4964DFF-CB87-4AB2-E76E-08D742BC182C',NULL,'Casey',NULL,'Stengel',NULL,'1890-07-30','2018-08-05','Yankee Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(9,'5D848C5C-C06C-4ED2-E76F-08D742BC182C',NULL,'Sparky','Lee','Anderson',NULL,'1934-08-22','2018-08-05','Riverfront Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(10,'7F303E6D-1D13-419B-E770-08D742BC182C','Mr.','Tommy','Charles','Lasorda',NULL,'1927-09-22','2018-08-05','Dodger Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(11,'A5432254-E60A-4E0F-8B0C-16FB73642AB3','Mr.','Tony',NULL,'La Russa','Jr.','10-04-1944','2018-08-01','Busch Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(12,'C861BAD1-E756-4C3A-814A-CEEA4F884BA4','Mr.','Mike',NULL,'Scioscia',NULL,'11-27-1958','2018-08-03','Angel Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(13,'34A2CA68-9E36-4DE5-A251-661FC96F4A4E','Mr.','Joe',NULL,'Torre',NULL,'07-18-1940','2018-08-02','Yankee Stadium',1);
INSERT INTO dbo.Instructor (InstructorId,InstructorGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,HireDate,OfficeLocation,IsActive)VALUES(14,'A5A6F9B1-5BF0-48D1-8E9A-A04B1FC48287','Mr.','Bobby',NULL,'Cox',NULL,'05-21-1941','2018-08-02','Turner Field',1);

SET IDENTITY_INSERT dbo.Instructor OFF

DELETE FROM dbo.Student WHERE StudentId > 10

SET IDENTITY_INSERT dbo.Student ON

INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(11,'B187CDB7-B89A-42B3-4109-08D741C1DD47','Mr.','Joe','Clifford','Montana',NULL,'1956-06-11','2019-08-08');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(12,'CFD27D38-718F-4584-410A-08D741C1DD47',NULL,'Peyton','Williams','Manning',NULL,'1976-03-24','2019-08-01');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(13,'6CDF522E-3262-4328-410B-08D741C1DD47','Mr.','Dan','Constantine','Marino',NULL,'1961-09-15','2019-08-01');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(14,'4C5A325E-771D-4385-410C-08D741C1DD47','Mr.','Brett','Lorenzo','Farve',NULL,'1969-10-10','2019-08-02');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(15,'62ECEFFA-73F5-44CA-410D-08D741C1DD47','Ms.','Diana','Lorena','Taurasi',NULL,'1982-06-11','2019-08-05');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(16,'59DE0723-24D4-4566-410E-08D741C1DD47','Ms.','Sue','Brigit','Bird',NULL,'1980-10-16','2019-08-08');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(17,'3CF1AC1B-00F0-48BD-410F-08D741C1DD47','Mrs.','Lisa',NULL,'Leslie',NULL,'1972-07-07','2019-08-10');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(18,'B68D0231-41B1-4EED-4110-08D741C1DD47',NULL,'Candace',NULL,'Parker',NULL,'1986-04-19','2019-08-01');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(19,'D2EDEA8B-B31C-48D7-4111-08D741C1DD47',NULL,'Sheryl',NULL,'Swoopes',NULL,'1971-03-25','2019-08-15');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(20,'B310ED85-06DD-46EC-4112-08D741C1DD47',NULL,'Lauren',NULL,'Jackson',NULL,'1981-03-11','2019-08-05');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(21,'704C42DA-6D40-46C4-322C-08D741C4A701','Mr.','John','Albert','Elway',NULL,'1960-06-28','2019-08-12');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(22,'4D0770EE-E330-4811-322D-08D741C4A701','Mr.','Troy','Kenneth','Aikman',NULL,'1966-11-21','2019-08-15');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(23,'59960B3D-20AE-498C-322E-08D741C4A701',NULL,'Steve',NULL,'Young',NULL,'1961-10-11','2019-08-02');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(24,'080D354E-FFBC-4B2A-322F-08D741C4A701',NULL,'Kurt',NULL,'Warner',NULL,'1971-06-22','2019-08-06');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(25,'BD06DB34-9EA4-403F-3230-08D741C4A701',NULL,'Jim','Edward','Kelly',NULL,'1960-02-14','2019-08-12');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(26,'4834E6C0-C0EA-4979-3231-08D741C4A701','Mr.','Eli','Nelson','Manning',NULL,'1981-01-03','2019-08-01');
INSERT INTO dbo.Student (StudentId,StudentGuid,Prefix,FirstName,MiddleName,LastName,Suffix,DateOfBirth,EnrollmentDate)VALUES(27,'72D7074B-3F03-420E-3232-08D741C4A701',NULL,'Drew',NULL,'Brees',NULL,'1979-01-15','2019-08-08');

SET IDENTITY_INSERT dbo.Student OFF