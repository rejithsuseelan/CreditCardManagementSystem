USE [CreditCardManagementSystem]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 10/26/2021 5:04:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationID] [numeric](10, 0) IDENTITY(1000000000,1) NOT NULL,
	[EmailID] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[FatherLastName] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[MaritalStatus] [int] NULL,
	[Citizenship] [int] NULL,
	[Pancard] [nvarchar](10) NULL,
	[Profession] [int] NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[AnnualIncome] [numeric](12, 2) NULL,
	[MonthlyIncome] [numeric](12, 2) NULL,
	[CorporateEmailID] [nvarchar](50) NULL,
	[Area] [nvarchar](50) NULL,
	[HouseNo] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
	[Landmark] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Pincode] [nvarchar](50) NULL,
	[IsTermsAndCondition] [bit] NULL,
	[CardName] [nvarchar](50) NULL,
	[CardStatus] [int] NULL,
	[StatusUpdatedDate] [datetime] NULL,
	[IsShipped] [bit] NULL,
	[CourierName] [nvarchar](50) NULL,
	[TrackingNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourierLogs]    Script Date: 10/26/2021 5:04:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourierLogs](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[applicationId] [numeric](10, 0) NOT NULL,
	[updatedate] [datetime] NULL,
	[statusId] [int] NULL,
 CONSTRAINT [PK_CourierLogs] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StandardValues]    Script Date: 10/26/2021 5:04:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandardValues](
	[Id] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_StandardValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_MaritalStatus]  DEFAULT ((0)) FOR [MaritalStatus]
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_Citizenship]  DEFAULT ((1)) FOR [Citizenship]
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_isTermsAndCondition]  DEFAULT ((1)) FOR [IsTermsAndCondition]
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_CardStatus]  DEFAULT ((0)) FOR [CardStatus]
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_IsShipped]  DEFAULT ((0)) FOR [IsShipped]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Citizenship_Id] FOREIGN KEY([Citizenship])
REFERENCES [dbo].[StandardValues] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Citizenship_Id]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_MaritalStatus_Id] FOREIGN KEY([MaritalStatus])
REFERENCES [dbo].[StandardValues] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_MaritalStatus_Id]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Profession_Id] FOREIGN KEY([Profession])
REFERENCES [dbo].[StandardValues] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Profession_Id]
GO
ALTER TABLE [dbo].[CourierLogs]  WITH CHECK ADD  CONSTRAINT [FK_CourierLogs_Application] FOREIGN KEY([applicationId])
REFERENCES [dbo].[Application] ([ApplicationID])
GO
ALTER TABLE [dbo].[CourierLogs] CHECK CONSTRAINT [FK_CourierLogs_Application]
GO
ALTER TABLE [dbo].[CourierLogs]  WITH CHECK ADD  CONSTRAINT [FK_CourierLogs_StandardValues] FOREIGN KEY([statusId])
REFERENCES [dbo].[StandardValues] ([Id])
GO
ALTER TABLE [dbo].[CourierLogs] CHECK CONSTRAINT [FK_CourierLogs_StandardValues]
GO
