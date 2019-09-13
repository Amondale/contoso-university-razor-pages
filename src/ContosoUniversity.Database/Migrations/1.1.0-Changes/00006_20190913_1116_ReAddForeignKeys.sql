-- <Migration ID="c52c0d04-b8d8-495c-8915-b1d51da34f79" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.09.13
** CREATION:     Refactor effort: Re-Add Foreign Keys
**************************************************************************/
ALTER TABLE dbo.Course WITH CHECK
ADD CONSTRAINT FK_Course_Department FOREIGN KEY (DepartmentGuid) REFERENCES dbo.Department (DepartmentGuid);
ALTER TABLE dbo.Course CHECK CONSTRAINT FK_Course_Department;

ALTER TABLE dbo.CourseAssignment WITH CHECK
ADD CONSTRAINT FK_CourseAssignment_Course FOREIGN KEY (CourseGuid) REFERENCES dbo.Course (CourseGuid);
ALTER TABLE dbo.CourseAssignment CHECK CONSTRAINT FK_CourseAssignment_Course;

ALTER TABLE dbo.CourseAssignment WITH CHECK
ADD CONSTRAINT FK_CourseAssignment_Instructor FOREIGN KEY (InstructorGuid) REFERENCES dbo.Instructor (InstructorGuid);
ALTER TABLE dbo.CourseAssignment CHECK CONSTRAINT FK_CourseAssignment_Instructor;

ALTER TABLE dbo.Department WITH CHECK
ADD CONSTRAINT FK_Department_Instructor FOREIGN KEY (DepartmentChairGuid) REFERENCES dbo.Instructor (InstructorGuid);
ALTER TABLE dbo.Department CHECK CONSTRAINT FK_Department_Instructor;

ALTER TABLE dbo.Enrollment  WITH CHECK 
ADD CONSTRAINT FK_Enrollment_Course FOREIGN KEY(CourseGuid) REFERENCES dbo.Course (CourseGuid)
ALTER TABLE dbo.Enrollment CHECK CONSTRAINT FK_Enrollment_Course

ALTER TABLE dbo.Enrollment WITH CHECK
ADD CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentGuid) REFERENCES dbo.Student (StudentGuid);
ALTER TABLE dbo.Enrollment CHECK CONSTRAINT FK_Enrollment_Student;

