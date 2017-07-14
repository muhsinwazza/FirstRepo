/****** Object:  StoredProcedure [dbo].[Prc_Employee]    Script Date: 07/14/2017 18:20:55 ******/
DROP PROCEDURE [dbo].[Prc_Employee]
GO
/****** Object:  Table [dbo].[dept]    Script Date: 07/14/2017 18:20:54 ******/
DROP TABLE [dbo].[dept]
GO
/****** Object:  Table [dbo].[emp]    Script Date: 07/14/2017 18:20:54 ******/
DROP TABLE [dbo].[emp]
GO
/****** Object:  Table [dbo].[emp]    Script Date: 07/14/2017 18:20:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[emp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ename] [varchar](max) NULL,
	[deptno] [int] NULL,
	[job] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[emp] ON
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (1, N'muhsin', 1, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (2, N'haritha', 1, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (5, N'Wayne Rooney', 2, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (6, N'Paul Pogba', 1, N'Assister')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (7, N'Ramu', 1, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (8, N'Padma', 1, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (10, N'Harish', 1, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (11, N'Jayesh', 1, N'Consultant')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (12, N'Sherin', 2, N'Developer')
INSERT [dbo].[emp] ([id], [ename], [deptno], [job]) VALUES (9, N'Keerthi', 1, N'Developer')
SET IDENTITY_INSERT [dbo].[emp] OFF
/****** Object:  Table [dbo].[dept]    Script Date: 07/14/2017 18:20:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dept](
	[deptno] [int] NULL,
	[dname] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[dept] ([deptno], [dname]) VALUES (1, N'microsoft')
INSERT [dbo].[dept] ([deptno], [dname]) VALUES (2, N'humanet')
/****** Object:  StoredProcedure [dbo].[Prc_Employee]    Script Date: 07/14/2017 18:20:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_Employee]
@id int=0,
@Name varchar(100)='',
@dept int=0,
@job varchar(100)='',
@type varchar(100),
@Msg varchar(200) out 
AS
BEGIN

	if(@type='select' and @id=0)
		select * from emp e
		left join dept d
		on e.deptno =d.deptno
	else if(@type='select' and @id<>0)
		select * from emp e
		left join dept d
		on e.deptno =d.deptno
		where e.id = @id
		
	if(@type='insert')
		BEGIN
			insert into emp (ename,deptno,job) values (@Name,@dept,@job)
			set @Msg = 'Inserted Successfully'
		END
	if(@type='dept')
		select deptno,dname from dept

END
GO
