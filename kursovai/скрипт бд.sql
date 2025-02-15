USE [is1-25-popovmskyrs]
GO
/****** Object:  Table [dbo].[users]    Script Date: 22.05.2024 11:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id_users] [int] IDENTITY(1,1) NOT NULL,
	[surname] [varchar](100) NULL,
	[name] [varchar](100) NULL,
	[patronymic] [varchar](100) NULL,
	[login] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[levels] [varchar](100) NULL,
	[blok] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_users] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id_users], [surname], [name], [patronymic], [login], [password], [levels], [blok]) VALUES (1, N'Попов', N'Максим', N'Сергеевич', N'Admin', N'admin123', N'Администратор', 0)
INSERT [dbo].[users] ([id_users], [surname], [name], [patronymic], [login], [password], [levels], [blok]) VALUES (2, N'Наймушина', N'Екатерина', N'Максимовна', N'Teacher', N'teacher123', N'Учитель', 0)
INSERT [dbo].[users] ([id_users], [surname], [name], [patronymic], [login], [password], [levels], [blok]) VALUES (3, N'Борисов', N'Тимофей', N'Сергеевич', N'Student', N'student123', N'Ученик', 0)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
