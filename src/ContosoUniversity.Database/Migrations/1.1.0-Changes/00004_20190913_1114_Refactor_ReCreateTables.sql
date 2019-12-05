-- <Migration ID="6a10bb3a-0a0b-4e9d-818e-ce8c88c5c230" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.09.13
** CREATION:     Refactor effort: Re-create tables
**************************************************************************/
CREATE TABLE dbo.Department
(
    DepartmentId INTEGER IDENTITY(1,1) NOT NULL CONSTRAINT UK_Department_DepartmentID UNIQUE CLUSTERED
	,DepartmentGuid UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Department_DepartmentGuid DEFAULT NEWSEQUENTIALID()
    ,DepartmentName VARCHAR(100) NOT NULL
    ,DepartmentChairGuid UNIQUEIDENTIFIER NULL 
	,Budget DECIMAL(19, 4) NOT NULL
    ,FoundedDate DATE NOT NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_Department_IsActive DEFAULT (1)
	,RecordVersion TIMESTAMP NULL
	,AuditCreateDateTime DATETIME NOT NULL CONSTRAINT DF_Department_AuditCreateDateTime DEFAULT GETDATE()
	,AuditUpdateDateTime DATETIME NOT NULL CONSTRAINT DF_Department_AuditUpdateDateTime DEFAULT GETDATE()        
    ,CONSTRAINT PK_Department PRIMARY KEY NONCLUSTERED (DepartmentGuid ASC)
)

CREATE TABLE dbo.Course
(
    CourseId INTEGER IDENTITY(1,1) NOT NULL CONSTRAINT UK_Course_CourseGuid UNIQUE CLUSTERED
	,CourseGuid UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Course_CourseGuid DEFAULT NEWSEQUENTIALID()
	,DepartmentGuid UNIQUEIDENTIFIER NOT NULL 
	,Title VARCHAR(100) NULL
    ,Credits INTEGER NOT NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_Course_IsActive DEFAULT (1)
	,RecordVersion TIMESTAMP NULL
	,AuditCreateDateTime DATETIME NOT NULL CONSTRAINT DF_Course_AuditCreateDateTime DEFAULT GETDATE()
	,AuditUpdateDateTime DATETIME NOT NULL CONSTRAINT DF_Course_AuditUpdateDateTime DEFAULT GETDATE()        
    ,CONSTRAINT PK_Course PRIMARY KEY NONCLUSTERED (CourseGuid ASC)
)

CREATE TABLE dbo.Instructor
(
	InstructorId INTEGER IDENTITY(1,1) NOT NULL CONSTRAINT UK_Instructor_InstructorGuid UNIQUE CLUSTERED
	,InstructorGuid UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Instructor_InstructorGuid DEFAULT NEWSEQUENTIALID()
	,Prefix VARCHAR(25) NULL
	,FirstName VARCHAR(100) NOT NULL
    ,MiddleName VARCHAR(100) NULL
	,LastName VARCHAR(100) NOT NULL
    ,Suffix VARCHAR(25) NULL
    ,DateOfBirth DATE NULL
    ,HireDate DATE NOT NULL
	,OfficeLocation VARCHAR(50) NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_Instructor_IsActive DEFAULT (1)
	,RecordVersion TIMESTAMP NULL
	,AuditCreateDateTime DATETIME NOT NULL CONSTRAINT DF_Instructor_AuditCreateDateTime DEFAULT GETDATE()
	,AuditUpdateDateTime DATETIME NOT NULL CONSTRAINT DF_Instructor_AuditUpdateDateTime DEFAULT GETDATE()
    ,CONSTRAINT PK_Instructor PRIMARY KEY NONCLUSTERED (InstructorGuid ASC)
)

CREATE TABLE dbo.Student
(    
	StudentId INTEGER IDENTITY(1,1) NOT NULL CONSTRAINT UK_Student_StudentId UNIQUE CLUSTERED
	,StudentGuid UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Student_StudentGuid DEFAULT NEWSEQUENTIALID()
	,Prefix VARCHAR(25) NULL
	,FirstName VARCHAR(100) NOT NULL
    ,MiddleName VARCHAR(100) NULL
	,LastName VARCHAR(100) NOT NULL
    ,Suffix VARCHAR(25) NULL
    ,DateOfBirth DATE NULL
	,EnrollmentDate DATE NOT NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_Student_IsActive DEFAULT (1)
	,RecordVersion TIMESTAMP NULL
	,AuditCreateDateTime DATETIME NOT NULL CONSTRAINT DF_Student_AuditCreateDateTime DEFAULT GETDATE()
	,AuditUpdateDateTime DATETIME NOT NULL CONSTRAINT DF_Student_AuditUpdateDateTime DEFAULT GETDATE()
    ,CONSTRAINT PK_Student PRIMARY KEY NONCLUSTERED (StudentGuid ASC)
)

CREATE TABLE dbo.Enrollment
(
    EnrollmentId INTEGER IDENTITY(1, 1) NOT NULL CONSTRAINT UK_Enrollment_EnrollmentId UNIQUE CLUSTERED
	,EnrollmentGuid UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Enrollment_EnrollmentGuid DEFAULT NEWSEQUENTIALID()
    ,CourseGuid UNIQUEIDENTIFIER NOT NULL
    ,StudentGuid UNIQUEIDENTIFIER NOT NULL 
    ,Grade INTEGER NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_Enrollment_IsActive DEFAULT (1)
	,RecordVersion TIMESTAMP NULL
	,AuditCreateDateTime DATETIME NOT NULL CONSTRAINT DF_Enrollment_AuditCreateDateTime DEFAULT GETDATE()
	,AuditUpdateDateTime DATETIME NOT NULL CONSTRAINT DF_Enrollment_AuditUpdateDateTime DEFAULT GETDATE()
    ,CONSTRAINT PK_Enrollment PRIMARY KEY NONCLUSTERED (EnrollmentGuid ASC)
)

CREATE TABLE dbo.CourseAssignment
(
    InstructorGuid UNIQUEIDENTIFIER NOT NULL
    ,CourseGuid UNIQUEIDENTIFIER NOT NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_CourseAssignment_IsActive DEFAULT (1)
	,RecordVersion TIMESTAMP NULL
	,AuditCreateDateTime DATETIME NOT NULL CONSTRAINT DF_CourseAssignment_AuditCreateDateTime DEFAULT GETDATE()
	,AuditUpdateDateTime DATETIME NOT NULL CONSTRAINT DF_CourseAssignment_AuditUpdateDateTime DEFAULT GETDATE()
    ,CONSTRAINT PK_CourseAssignment PRIMARY KEY CLUSTERED (CourseGuid ASC, InstructorGuid ASC)
);