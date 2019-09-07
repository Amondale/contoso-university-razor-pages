-- <Migration ID="2dcd84e2-bf07-48c6-bfc8-5c92b6a84a3b" />
GO
CREATE TABLE dbo.Department
(
    DepartmentID INT NOT NULL IDENTITY(1, 1)
    ,Name NVARCHAR(50) NULL
    ,Budget MONEY NOT NULL
    ,StartDate DATETIME2 NOT NULL
    ,InstructorID INT NULL
    ,RowVersion TIMESTAMP NULL
);
ALTER TABLE dbo.Department ADD CONSTRAINT PK_Department PRIMARY KEY CLUSTERED (DepartmentID);
CREATE NONCLUSTERED INDEX IX_Department_InstructorID ON dbo.Department (InstructorID);

CREATE TABLE dbo.Course
(
    CourseID INT NOT NULL
    ,Title NVARCHAR(50) NULL
    ,Credits INT NOT NULL
    ,DepartmentID INT NOT NULL CONSTRAINT DF__Course__Departme__3E52440B DEFAULT ((0))
);

ALTER TABLE dbo.Course ADD CONSTRAINT PK_Course PRIMARY KEY CLUSTERED (CourseID);

CREATE NONCLUSTERED INDEX IX_Course_DepartmentID ON dbo.Course (DepartmentID);

CREATE TABLE dbo.CourseAssignment
(
    InstructorID INT NOT NULL
    ,CourseID INT NOT NULL
);

ALTER TABLE dbo.CourseAssignment ADD CONSTRAINT PK_CourseAssignment PRIMARY KEY CLUSTERED
                                         (CourseID, InstructorID);

CREATE NONCLUSTERED INDEX IX_CourseAssignment_InstructorID ON dbo.CourseAssignment (InstructorID);

CREATE TABLE dbo.Instructor
(
    ID INT NOT NULL IDENTITY(1, 1)
    ,LastName NVARCHAR(50) NOT NULL
    ,FirstName NVARCHAR(50) NOT NULL
    ,HireDate DATETIME2 NOT NULL
);

ALTER TABLE dbo.Instructor ADD CONSTRAINT PK_Instructor PRIMARY KEY CLUSTERED (ID);

CREATE TABLE dbo.Enrollment
(
    EnrollmentID INT NOT NULL IDENTITY(1, 1)
    ,CourseID INT NOT NULL
    ,StudentID INT NOT NULL
    ,Grade INT NULL
);

ALTER TABLE dbo.Enrollment ADD CONSTRAINT PK_Enrollment PRIMARY KEY CLUSTERED (EnrollmentID);

CREATE NONCLUSTERED INDEX IX_Enrollment_CourseID ON dbo.Enrollment (CourseID);

CREATE NONCLUSTERED INDEX IX_Enrollment_StudentID ON dbo.Enrollment (StudentID);

CREATE TABLE dbo.Student
(
    ID INT NOT NULL IDENTITY(1, 1)
    ,LastName NVARCHAR(50) NOT NULL
    ,FirstName NVARCHAR(50) NULL
    ,EnrollmentDate DATETIME2 NOT NULL
);

ALTER TABLE dbo.Student ADD CONSTRAINT PK_Student PRIMARY KEY CLUSTERED (ID);

CREATE TABLE dbo.OfficeAssignment
(
    InstructorID INT NOT NULL
    ,Location NVARCHAR(50) NULL
);

ALTER TABLE dbo.OfficeAssignment ADD CONSTRAINT PK_OfficeAssignment PRIMARY KEY CLUSTERED (InstructorID);

CREATE TABLE dbo.__EFMigrationsHistory
(
    MigrationId NVARCHAR(150) NOT NULL
    ,ProductVersion NVARCHAR(32) NOT NULL
);

ALTER TABLE dbo.__EFMigrationsHistory ADD CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY CLUSTERED
                                              (MigrationId);
GO

ALTER TABLE dbo.CourseAssignment
ADD CONSTRAINT FK_CourseAssignment_Instructor_InstructorID FOREIGN KEY (InstructorID) REFERENCES dbo.Instructor
                                                             (ID) ON DELETE CASCADE;

ALTER TABLE dbo.CourseAssignment
ADD CONSTRAINT FK_CourseAssignment_Course_CourseID FOREIGN KEY (CourseID) REFERENCES dbo.Course (CourseID) ON DELETE CASCADE;

ALTER TABLE dbo.Enrollment
ADD CONSTRAINT FK_Enrollment_Course_CourseID FOREIGN KEY (CourseID) REFERENCES dbo.Course (CourseID) ON DELETE CASCADE;

ALTER TABLE dbo.Enrollment ADD CONSTRAINT FK_Enrollment_Student_StudentID FOREIGN KEY (StudentID) REFERENCES dbo.Student
                                                                                (ID) ON DELETE CASCADE;

ALTER TABLE dbo.Course
ADD CONSTRAINT FK_Course_Department_DepartmentID FOREIGN KEY (DepartmentID) REFERENCES dbo.Department
                                                   (DepartmentID) ON DELETE CASCADE;

ALTER TABLE dbo.Department ADD CONSTRAINT FK_Department_Instructor_InstructorID FOREIGN KEY (InstructorID) REFERENCES dbo.Instructor
                                                                                      (ID);

ALTER TABLE dbo.OfficeAssignment
ADD CONSTRAINT FK_OfficeAssignment_Instructor_InstructorID FOREIGN KEY (InstructorID) REFERENCES dbo.Instructor
                                                             (ID) ON DELETE CASCADE;
