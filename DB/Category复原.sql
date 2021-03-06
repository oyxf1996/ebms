USE [YHCms201607]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 04/14/2017 13:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
if exists(select * from sysobjects where name='Category')
drop table Category
go
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[ParentId] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[SortIndex] [int] NOT NULL,
	[Url] [varchar](100) NOT NULL,
	[Content] [nvarchar](2000) NOT NULL,
	[IdPath] [varchar](100) NOT NULL,
	[Depth] [int] NOT NULL,
	[HasChildren] [tinyint] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类类型 1链接 2内容页 3新闻列表 4产品列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0不显示 1显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'SortIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'跳转链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类编号路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'IdPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类深度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Depth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否有子分类 0否 1是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'HasChildren'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category'
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (1, N'网站首页', 1, 0, 1, 1, N'/Index.aspx', N'', N',1,', 1, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (2, N'关于公司', 1, 0, 1, 2, N'/About/Intro.aspx', N'', N',2,', 1, 1)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (3, N'公司介绍', 2, 2, 1, 1, N'/About/Intro.aspx', N'<p style="text-indent: 2em;"><span style="color: rgb(255, 0, 0);">你好啊</span>&nbsp; &nbsp; &nbsp;&nbsp;</p>', N',2,3,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (4, N'组织机构', 2, 2, 1, 2, N'/About/Group.aspx', N'', N',2,4,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (5, N'企业文化', 2, 2, 1, 3, N'/About/Culture.aspx', N'', N',2,5,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (6, N'公司环境', 2, 2, 1, 4, N'/About/Enviro.aspx', N'', N',2,6,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (7, N'公司业务', 2, 2, 1, 5, N'/About/Business.aspx', N'', N',2,7,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (8, N'新闻动态', 1, 0, 1, 3, N'/NewsList.aspx', N'', N',8,', 1, 1)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (9, N'公司新闻', 3, 8, 1, 1, N'/News/CompanyNews.aspx', N'', N',8,9,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (10, N'行业新闻', 3, 8, 1, 2, N'/News/IndustryNews.aspx', N'', N',8,10,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (11, N'公司产品', 1, 0, 1, 4, N'/ProductList.aspx', N'', N',11,', 1, 1)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (12, N'数码播放器', 4, 11, 1, 1, N'123', N'', N',11,12,', 2, 1)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (13, N'MP3', 4, 12, 1, 1, N'', N'', N',11,12,13,', 3, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (14, N'MP4', 4, 12, 1, 2, N'', N'', N',11,12,14,', 3, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (15, N'GPS导航仪', 4, 11, 1, 2, N'', N'', N',11,15,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (16, N'联系我们', 1, 0, 1, 7, N'/Contact.aspx', N'', N',16,', 1, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (17, N'访客留言', 1, 0, 1, 8, N'/Feedback.aspx', N'', N',17,', 1, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (18, N'人才招聘', 1, 0, 1, 6, N'/Recruit.aspx', N'', N',18,', 1, 1)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (19, N'技术支持', 1, 0, 1, 5, N'/Support.aspx', N'', N',19,', 1, 1)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (20, N'人才培养', 2, 18, 1, 1, N'', N'', N',18,20,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (21, N'福利待遇', 2, 18, 1, 2, N'', N'', N',18,21,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (22, N'招聘职位', 1, 18, 1, 3, N'/Job.aspx', N'', N',18,22,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (23, N'售后服务', 2, 19, 1, 1, N'', N'', N',19,23,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (24, N'下载中心', 3, 19, 1, 2, N'', N'', N',19,24,', 2, 0)
INSERT [dbo].[Category] ([CategoryId], [Name], [Type], [ParentId], [Status], [SortIndex], [Url], [Content], [IdPath], [Depth], [HasChildren]) VALUES (25, N'常见问题', 1, 19, 1, 3, N'/FAQ.aspx', N'', N',19,25,', 2, 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Default [DF_Category_Name]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Name]  DEFAULT ('') FOR [Name]
GO
/****** Object:  Default [DF_Category_Type]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Type]  DEFAULT ((1)) FOR [Type]
GO
/****** Object:  Default [DF_Category_ParentId]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
/****** Object:  Default [DF_Category_Status]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_Category_SortIndex]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_SortIndex]  DEFAULT ((0)) FOR [SortIndex]
GO
/****** Object:  Default [DF_Category_Url]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Url]  DEFAULT ('') FOR [Url]
GO
/****** Object:  Default [DF_Category_HasChildren]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_HasChildren]  DEFAULT ('') FOR [Content]
GO
/****** Object:  Default [DF_Category_IdPath]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_IdPath]  DEFAULT ('') FOR [IdPath]
GO
/****** Object:  Default [DF_Category_Depth]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Depth]  DEFAULT ((1)) FOR [Depth]
GO
/****** Object:  Default [DF_Category_HasChildren_1]    Script Date: 04/14/2017 13:52:48 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_HasChildren_1]  DEFAULT ((0)) FOR [HasChildren]
GO
