-- <Migration ID="e7519d53-56fe-4307-ac33-9cdc873f0123" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.09.13
** CREATION:     Refactor effort: Insert Data
**************************************************************************/
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('F60D906A-3FD6-E911-B7F0-989096C0B27B','English',350000.0000,'2007-05-01');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('F70D906A-3FD6-E911-B7F0-989096C0B27B','Mathematics',100000.0000,'2007-05-02');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('F80D906A-3FD6-E911-B7F0-989096C0B27B','Engineering',350000.0000,'2007-05-03');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('F90D906A-3FD6-E911-B7F0-989096C0B27B','Economics',100000.0000,'2007-05-04');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('FA0D906A-3FD6-E911-B7F0-989096C0B27B','History',100000.0000,'2007-05-05');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('FB0D906A-3FD6-E911-B7F0-989096C0B27B','Accounting',100000.0000,'2007-05-06');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('FC0D906A-3FD6-E911-B7F0-989096C0B27B','Computer Science',100000.0000,'2007-05-07');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('FD0D906A-3FD6-E911-B7F0-989096C0B27B','Religious Studies',100000.0000,'2007-05-08');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('FE0D906A-3FD6-E911-B7F0-989096C0B27B','Environmental Science',100000.0000,'2007-05-09');
INSERT INTO dbo.Department (DepartmentGuid,DepartmentName,Budget,FoundedDate)VALUES('FF0D906A-3FD6-E911-B7F0-989096C0B27B','Performing Arts',100000.0000,'2007-05-10');

INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('19138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Precalculus',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('1A138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Calculus I',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('1B138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Calculus II',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('1C138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Linear Algebra',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('1D138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Abstract Algebra',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('1E138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Discrete Mathematics',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('1F138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Number Theory',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('20138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Trigonometry',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('21138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Geometry',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('22138F58-42D6-E911-B7F0-989096C0B27B','F70D906A-3FD6-E911-B7F0-989096C0B27B','Statistics',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('23138F58-42D6-E911-B7F0-989096C0B27B','F60D906A-3FD6-E911-B7F0-989096C0B27B','Composition',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('24138F58-42D6-E911-B7F0-989096C0B27B','F60D906A-3FD6-E911-B7F0-989096C0B27B','Creative Writing',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('25138F58-42D6-E911-B7F0-989096C0B27B','F60D906A-3FD6-E911-B7F0-989096C0B27B','English Grammar',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('26138F58-42D6-E911-B7F0-989096C0B27B','F60D906A-3FD6-E911-B7F0-989096C0B27B','Literary Theory',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('27138F58-42D6-E911-B7F0-989096C0B27B','F90D906A-3FD6-E911-B7F0-989096C0B27B','Principles of Microeconomics I',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('28138F58-42D6-E911-B7F0-989096C0B27B','F90D906A-3FD6-E911-B7F0-989096C0B27B','Principles of Macroeconomics II',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('29138F58-42D6-E911-B7F0-989096C0B27B','F90D906A-3FD6-E911-B7F0-989096C0B27B','Principles of Microeconomics I',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('2A138F58-42D6-E911-B7F0-989096C0B27B','F90D906A-3FD6-E911-B7F0-989096C0B27B','Principles of Microeconomics II',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('2B138F58-42D6-E911-B7F0-989096C0B27B','FC0D906A-3FD6-E911-B7F0-989096C0B27B','Introduction to Data Structures',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('2C138F58-42D6-E911-B7F0-989096C0B27B','FC0D906A-3FD6-E911-B7F0-989096C0B27B','Object-oriented Programming',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('2D138F58-42D6-E911-B7F0-989096C0B27B','FC0D906A-3FD6-E911-B7F0-989096C0B27B','Principles of Programming Languages',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('2E138F58-42D6-E911-B7F0-989096C0B27B','FC0D906A-3FD6-E911-B7F0-989096C0B27B','Theory of Computing',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('2F138F58-42D6-E911-B7F0-989096C0B27B','FA0D906A-3FD6-E911-B7F0-989096C0B27B','American Civilization',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('30138F58-42D6-E911-B7F0-989096C0B27B','FA0D906A-3FD6-E911-B7F0-989096C0B27B','World History',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('31138F58-42D6-E911-B7F0-989096C0B27B','FB0D906A-3FD6-E911-B7F0-989096C0B27B','Financial Accounting',3);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('32138F58-42D6-E911-B7F0-989096C0B27B','FB0D906A-3FD6-E911-B7F0-989096C0B27B','Managerial Accounting',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('33138F58-42D6-E911-B7F0-989096C0B27B','FB0D906A-3FD6-E911-B7F0-989096C0B27B','Accounting Systems',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('34138F58-42D6-E911-B7F0-989096C0B27B','FF0D906A-3FD6-E911-B7F0-989096C0B27B','Theatre History',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('35138F58-42D6-E911-B7F0-989096C0B27B','FF0D906A-3FD6-E911-B7F0-989096C0B27B','Musical Theatre',4);
INSERT INTO dbo.Course (CourseGuid,DepartmentGuid,Title,Credits)VALUES('36138F58-42D6-E911-B7F0-989096C0B27B','FF0D906A-3FD6-E911-B7F0-989096C0B27B','Dramatic Literature',4);

INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('4AF112CE-3BD6-E911-B7F0-989096C0B27B','Mrs.','Abercrombiess','Kim','2017-03-11');
INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('4BF112CE-3BD6-E911-B7F0-989096C0B27B','Ms','Fakhouri','Fadi','2017-07-06');
INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('4CF112CE-3BD6-E911-B7F0-989096C0B27B','Mr.','Harui','Roger','2017-07-01');
INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('4DF112CE-3BD6-E911-B7F0-989096C0B27B','Mrs.','Kapoor','Candace','2017-01-15');
INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('4EF112CE-3BD6-E911-B7F0-989096C0B27B','Mr.','Zheng','Roger','2017-02-12');
INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('4FF112CE-3BD6-E911-B7F0-989096C0B27B','Mr.','Ruth','Babe','2017-02-08');
INSERT INTO dbo.Instructor (InstructorGuid,Prefix,LastName,FirstName,HireDate)VALUES('50F112CE-3BD6-E911-B7F0-989096C0B27B','Mr.','Mantle','Mickey','2017-02-10');

INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4AF112CE-3BD6-E911-B7F0-989096C0B27B','19138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4AF112CE-3BD6-E911-B7F0-989096C0B27B','1A138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4BF112CE-3BD6-E911-B7F0-989096C0B27B','27138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4BF112CE-3BD6-E911-B7F0-989096C0B27B','28138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4BF112CE-3BD6-E911-B7F0-989096C0B27B','29138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4DF112CE-3BD6-E911-B7F0-989096C0B27B','34138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4DF112CE-3BD6-E911-B7F0-989096C0B27B','35138F58-42D6-E911-B7F0-989096C0B27B');
INSERT INTO dbo.CourseAssignment (InstructorGuid,CourseGuid)VALUES('4DF112CE-3BD6-E911-B7F0-989096C0B27B','36138F58-42D6-E911-B7F0-989096C0B27B');

INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('AAE2F718-37D6-E911-B7F0-989096C0B27B','Mr.','Alexander','Carson','2018-09-01', '2000-01-01');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('ABE2F718-37D6-E911-B7F0-989096C0B27B','Ms.','Alonso','Meredith','2018-09-01', '2000-01-02');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('ACE2F718-37D6-E911-B7F0-989096C0B27B','Mr.','Anand','Arturo','2018-09-01', '2000-01-03');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('ADE2F718-37D6-E911-B7F0-989096C0B27B','Mr.','Barzdukas','Gytis','2018-09-01', '2000-01-04');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('AEE2F718-37D6-E911-B7F0-989096C0B27B','Miss','Li','Yan','2018-09-01', '2000-01-05');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('AFE2F718-37D6-E911-B7F0-989096C0B27B','Ms.','Justice','Peggy','2018-09-01', '2000-01-06');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('B0E2F718-37D6-E911-B7F0-989096C0B27B','Mrs.','Norman','Laura','2018-09-01', '2000-01-07');
INSERT INTO dbo.Student (StudentGuid,Prefix,LastName,FirstName,EnrollmentDate,DateOfBirth)VALUES('B1E2F718-37D6-E911-B7F0-989096C0B27B','Mr.','Olivetto','Nino','2018-09-01', '2000-01-08');

INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('19138F58-42D6-E911-B7F0-989096C0B27B','AAE2F718-37D6-E911-B7F0-989096C0B27B',NULL);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('19138F58-42D6-E911-B7F0-989096C0B27B','ACE2F718-37D6-E911-B7F0-989096C0B27B',2);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('19138F58-42D6-E911-B7F0-989096C0B27B','ADE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('27138F58-42D6-E911-B7F0-989096C0B27B','ABE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('27138F58-42D6-E911-B7F0-989096C0B27B','ADE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('29138F58-42D6-E911-B7F0-989096C0B27B','AFE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('29138F58-42D6-E911-B7F0-989096C0B27B','AAE2F718-37D6-E911-B7F0-989096C0B27B',NULL);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('34138F58-42D6-E911-B7F0-989096C0B27B','ACE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('34138F58-42D6-E911-B7F0-989096C0B27B','AAE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('34138F58-42D6-E911-B7F0-989096C0B27B','AFE2F718-37D6-E911-B7F0-989096C0B27B',1);
INSERT INTO dbo.Enrollment (CourseGuid,StudentGuid,Grade)VALUES('34138F58-42D6-E911-B7F0-989096C0B27B','AFE2F718-37D6-E911-B7F0-989096C0B27B',1);

