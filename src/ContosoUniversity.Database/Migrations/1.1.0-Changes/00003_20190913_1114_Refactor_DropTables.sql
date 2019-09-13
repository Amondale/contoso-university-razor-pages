-- <Migration ID="476241e3-adf4-4ec0-89f2-0113db3e431d" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.09.13
** CREATION:     Refactor effort: Drop tables
**************************************************************************/
DROP TABLE IF EXISTS dbo.__EFMigrationsHistory
DROP TABLE IF EXISTS dbo.Course;
DROP TABLE IF EXISTS dbo.CourseAssignment;
DROP TABLE IF EXISTS dbo.Department;
DROP TABLE IF EXISTS dbo.Instructor;
DROP TABLE IF EXISTS dbo.OfficeAssignment;
DROP TABLE IF EXISTS dbo.Student
DROP TABLE IF EXISTS dbo.Enrollment;
