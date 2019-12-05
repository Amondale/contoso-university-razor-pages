-- <Migration ID="b9b4e2fe-6fff-4875-bc23-0778403e087a" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.09.13
** CREATION:     Refactor effort: Drop foreign keys.
**************************************************************************/
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Course_Department_DepartmentID') AND parent_object_id = OBJECT_ID(N'dbo.Course'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_Course_Department_DepartmentID'
	ALTER TABLE dbo.Course DROP CONSTRAINT FK_Course_Department_DepartmentID;
END 

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_CourseAssignment_Course_CourseID') AND parent_object_id = OBJECT_ID(N'dbo.CourseAssignment'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_CourseAssignment_Course_CourseID'
	ALTER TABLE dbo.CourseAssignment DROP CONSTRAINT FK_CourseAssignment_Course_CourseID;
END 

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_CourseAssignment_Instructor_InstructorID') AND parent_object_id = OBJECT_ID(N'dbo.CourseAssignment'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_CourseAssignment_Instructor_InstructorID'
	ALTER TABLE dbo.CourseAssignment DROP CONSTRAINT FK_CourseAssignment_Instructor_InstructorID;
END 

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Department_Instructor_InstructorID') AND parent_object_id = OBJECT_ID(N'dbo.Department'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_Department_Instructor_InstructorID'
	ALTER TABLE dbo.Department DROP CONSTRAINT FK_Department_Instructor_InstructorID;
END 

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Enrollment_Course_CourseID') AND parent_object_id = OBJECT_ID(N'dbo.Enrollment'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_Enrollment_Course_CourseID'
	ALTER TABLE dbo.Enrollment DROP CONSTRAINT FK_Enrollment_Course_CourseID;
END 

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Enrollment_Student_StudentID') AND parent_object_id = OBJECT_ID(N'dbo.Enrollment'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_Enrollment_Student_StudentID'
	ALTER TABLE dbo.Enrollment DROP CONSTRAINT FK_Enrollment_Student_StudentID;
END 

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_OfficeAssignment_Instructor_InstructorID') AND parent_object_id = OBJECT_ID(N'dbo.OfficeAssignment'))
BEGIN 
	PRINT 'Dropping Foreign Key: FK_OfficeAssignment_Instructor_InstructorID'
	ALTER TABLE dbo.OfficeAssignment DROP CONSTRAINT FK_OfficeAssignment_Instructor_InstructorID;
END 
