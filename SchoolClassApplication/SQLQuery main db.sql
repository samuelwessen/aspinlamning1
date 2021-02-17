﻿CREATE TABLE SchoolClasses (
	Id uniqueidentifier not null primary key,
	ClassName nvarchar(20) not null,
	TeacherId nvarchar(450),
	Created date not null
)
GO

CREATE TABLE SchoolCourses (
	Id uniqueidentifier not null primary key,
	CourseName nvarchar(20) not null	
)
GO

CREATE TABLE SchoolClassStudents (
	StudentId nvarchar(450) not null primary key,
	SchoolClassId uniqueidentifier not null references SchoolClasses(Id)
)
GO

CREATE TABLE SchoolClassCourses (
	SchoolClassId uniqueidentifier not null references SchoolClasses(Id),
	SchoolCourseId uniqueidentifier not null references SchoolCourses(Id),
	TeacherId nvarchar(450) null

	primary key(SchoolClassId, SchoolCourseId)
)
GO