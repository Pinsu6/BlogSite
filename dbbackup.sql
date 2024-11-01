USE [master]
GO
/****** Object:  Database [Blog]    Script Date: 28-10-2024 10:02:31 PM ******/
CREATE DATABASE [Blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blog', FILENAME = N'D:\Software\Microsoft SQL server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blog_log', FILENAME = N'D:\Software\Microsoft SQL server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Blog] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blog] SET  MULTI_USER 
GO
ALTER DATABASE [Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blog] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Blog] SET QUERY_STORE = ON
GO
ALTER DATABASE [Blog] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Blog]
GO
/****** Object:  Table [dbo].[blogsortinfo]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blogsortinfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[blogname] [varchar](255) NULL,
	[authname] [varchar](255) NULL,
	[date] [datetime] NULL,
	[shortdesc] [varchar](255) NULL,
	[image] [varchar](max) NULL,
	[descript] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](100) NOT NULL,
	[blog_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catnorm]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catnorm](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[c_id] [int] NULL,
	[b_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[cmt] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[blog_id] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contect]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
	[email] [varchar](max) NULL,
	[phone] [varchar](20) NULL,
	[message] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMERS]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMERS](
	[customer_id] [int] NOT NULL,
	[customer_name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[city] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[order_id] [int] NOT NULL,
	[order_date] [date] NULL,
	[customer_id] [int] NULL,
	[product_id] [int] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[readmore]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[readmore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[blog_id] [int] NULL,
	[detaildesc] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[IsAdmin] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[blogsortinfo] ADD  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[category]  WITH CHECK ADD  CONSTRAINT [FK_blog_category] FOREIGN KEY([blog_id])
REFERENCES [dbo].[blogsortinfo] ([id])
GO
ALTER TABLE [dbo].[category] CHECK CONSTRAINT [FK_blog_category]
GO
ALTER TABLE [dbo].[catnorm]  WITH CHECK ADD FOREIGN KEY([b_id])
REFERENCES [dbo].[blogsortinfo] ([id])
GO
ALTER TABLE [dbo].[catnorm]  WITH CHECK ADD FOREIGN KEY([c_id])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_blog_comment] FOREIGN KEY([blog_id])
REFERENCES [dbo].[blogsortinfo] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_blog_comment]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_user_comment] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_user_comment]
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[CUSTOMERS] ([customer_id])
GO
ALTER TABLE [dbo].[readmore]  WITH CHECK ADD  CONSTRAINT [FK_blog] FOREIGN KEY([blog_id])
REFERENCES [dbo].[blogsortinfo] ([id])
GO
ALTER TABLE [dbo].[readmore] CHECK CONSTRAINT [FK_blog]
GO
/****** Object:  StoredProcedure [dbo].[AddBlog]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddBlog]
    @blogname VARCHAR(20),
    @authname VARCHAR(20),
    @shortdesc VARCHAR(200),
    @image VARCHAR(50),
    @descript VARCHAR(MAX),
    @category VARCHAR(20)
AS
BEGIN
DECLARE @categoryId INT;
DECLARE @blogId INT;
    -- Insert data into blogsortinfo with explicit column names
    INSERT INTO blogsortinfo (blogname, authname, shortdesc, image, descript)
    VALUES (@blogname, @authname, @shortdesc, @image, @descript);

    -- Retrieve and output the category ID based on the provided category name
     SELECT @categoryId=id FROM category WHERE category_name = @category;

    -- Retrieve and output the blog ID based on the inserted blog name
    SELECT @blogId=id FROM blogsortinfo WHERE blogname = @blogname;

	insert into catnorm(c_id,b_id)
	values(@categoryId,@blogId)
END;
GO
/****** Object:  StoredProcedure [dbo].[AddBlogSortInfo]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddBlogSortInfo]
    @BlogName NVARCHAR(255),
    @AuthName NVARCHAR(100),
    @ShortDesc NVARCHAR(MAX),
    @Image VARBINARY(MAX) -- New parameter for the image
AS
BEGIN
    INSERT INTO BlogSortInfo (BlogName, AuthName, Date, ShortDesc, Image)
    VALUES (@BlogName, @AuthName, GETDATE(), @ShortDesc, @Image);
END;
GO
/****** Object:  StoredProcedure [dbo].[addcategory]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addcategory]
	@categoryname varchar(20)
	as
	begin
	insert into category(category_name)
	values(@categoryname)
	end
GO
/****** Object:  StoredProcedure [dbo].[addconect]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[addconect]

@name varchar(20),
@email varchar(max),
@phone varchar(20),
@message varchar(max)
as
begin
insert into contect values(@name,@email,@phone,@message)
end
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @Name NVARCHAR(100),
    @LName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password NVARCHAR(255)
AS
BEGIN
    INSERT INTO Users (Name, LName, Email, Password, IsAdmin)
    VALUES (@Name, @LName, @Email, @Password, 0);
END;
GO
/****** Object:  StoredProcedure [dbo].[blogcount]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[blogcount]
as
begin
select count(id) from blogsortinfo
end
GO
/****** Object:  StoredProcedure [dbo].[categoryAdd]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[categoryAdd]
@categoryname varchar(200)
as
begin
insert into category(category_name)
values(@categoryname)
end
GO
/****** Object:  StoredProcedure [dbo].[categoryByid]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[categoryByid] 
@id int
as
begin
select id,category_name from category 
where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[categoryDelete]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[categoryDelete]
@catid int
as
begin
delete from category where id=@catid
end
GO
/****** Object:  StoredProcedure [dbo].[categoryEdit]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[categoryEdit]
@catid int,
@categoryname varchar(200)
as
begin
update category set category_name=@categoryname
where id=@catid
end
GO
/****** Object:  StoredProcedure [dbo].[catnormdata]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[catnormdata]
@categoryname varchar(20)
as
begin
select  cat.id,cat.c_id,b_id,b.blogname, b.authname,b.shortdesc,b.image,c.category_name from catnorm cat
inner join
blogsortinfo b
on
cat.b_id=b.id
inner join
category c
on
cat.c_id=c.id
where c.category_name=@categoryname
end
GO
/****** Object:  StoredProcedure [dbo].[commentInfo]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[commentInfo]
    @BlogId INT  -- Input parameter for the blog ID
AS
BEGIN
    SELECT c.id ,c.cmt, u.name,u.id
    FROM users u
    INNER JOIN comment c ON u.id = c.user_id
    INNER JOIN blogsortinfo b ON c.blog_id = b.id
    WHERE c.blog_id = @BlogId;  -- Filter comments for a particular blog
END;
GO
/****** Object:  StoredProcedure [dbo].[contectread]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[contectread]
as
begin
select * from contect
end
GO
/****** Object:  StoredProcedure [dbo].[countbycategory]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[countbycategory]
as
begin
SELECT c.category_name, COUNT(b.id) AS blog_count
FROM catnorm cat
INNER JOIN blogsortinfo b ON b.id = cat.b_id
inner join category c on c.id=cat.c_id
GROUP BY c.category_name;
end
GO
/****** Object:  StoredProcedure [dbo].[deleteBlog]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deleteBlog]
@id int
as
begin
delete from catnorm where b_id=@id;
delete from blogsortinfo where id=@id;
delete from comment where  blog_id=@id;
end
GO
/****** Object:  StoredProcedure [dbo].[deletecmt]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deletecmt]
@id int
as
begin
delete from comment where id=@id;
end
GO
/****** Object:  StoredProcedure [dbo].[deleteComment]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteComment]
@id int
as
begin
delete from comment where id=@id;
end
GO
/****** Object:  StoredProcedure [dbo].[deletecontect]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deletecontect]
@id int
as
begin
delete from contect where id=@id;
end

GO
/****** Object:  StoredProcedure [dbo].[DetailBlog]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DetailBlog]
@id int
as
begin
select * from blogsortinfo where id =@id;
end
GO
/****** Object:  StoredProcedure [dbo].[fetchcomment]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[fetchcomment]
as
begin
select c.id ,c.cmt,u.name,b.blogname from comment c
inner join
Users u
on
c.user_id=u.id
inner join
blogsortinfo b
on
b.id=c.blog_id
end
GO
/****** Object:  StoredProcedure [dbo].[getblogById]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getblogById]
@id int
as
begin
select * from blogsortinfo where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetBlogs]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBlogs]
AS
BEGIN
    SET NOCOUNT ON; -- Prevents extra result sets from interfering with SELECT statements

    SELECT *
    FROM blogsortinfo; -- Retrieves all rows from the blogsortinfo table
END
GO
/****** Object:  StoredProcedure [dbo].[insertblog]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertblog]
    @BlogName VARCHAR(255),
    @AuthName VARCHAR(255),
   
    @ShortDesc VARCHAR(255),
    @Image VARCHAR(255),
    @Descript VARCHAR(MAX)
	as
	begin 
	INSERT INTO blogsortinfo (BlogName, AuthName, ShortDesc, Image, Descript)
    VALUES (@BlogName, @AuthName,  @ShortDesc, @Image, @Descript);
	end
GO
/****** Object:  StoredProcedure [dbo].[insertcategory]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertcategory]

@categoryname varchar(20),
@blog_id int
as
begin
insert into category
values(@categoryname,@blog_id);
end
GO
/****** Object:  StoredProcedure [dbo].[insertcomment]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertcomment]
@cmt varchar(255),
@user_id int,
@blog_id int
as
begin
insert into comment values(@cmt,@user_id,@blog_id)
end
GO
/****** Object:  StoredProcedure [dbo].[insertCommnet]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertCommnet]
@cmt varchar(200),
@user_id int,
@blog_id int
as 
begin
insert into comment values(@cmt,@user_id,@blog_id);
end
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginUser]
    @Email NVARCHAR(255),    -- Input parameter for email
    @Password NVARCHAR(255)  -- Input parameter for password
AS
BEGIN
    SET NOCOUNT ON;

    -- Selects the email and password for the user with the matching email and password
    SELECT id,name,email, password,IsAdmin
    FROM users
    WHERE email = @Email
      AND password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[search]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[search]
@title varchar(200)
as
begin
select * from blogsortinfo where blogname=@title
end
GO
/****** Object:  StoredProcedure [dbo].[selectcategorybyname]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectcategorybyname]
@categoryname varchar(20)
as
begin
select b.id, c.id, b.blogname, b.authname,b.shortdesc,b.image,category_name from blogsortinfo b
inner join
category c
on
b.id=c.blog_id
where c.category_name=@categoryname
end
GO
/****** Object:  StoredProcedure [dbo].[selectcategoryname]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectcategoryname]
as
begin
select * from category
end
GO
/****** Object:  StoredProcedure [dbo].[try]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[try]
@categoryname varchar(20)
as
begin
select  cat.id,cat.c_id,b_id,b.blogname, b.authname,b.shortdesc,b.image,category_name from catnorm cat
inner join
blog b
on
cat.b_id=b.id
inner join
category c
on
cat.c_id=c.id
end
GO
/****** Object:  StoredProcedure [dbo].[try1]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[try1]
@categoryname varchar(20)
as
begin
select  cat.id,cat.c_id,b_id,b.blogname, b.authname,b.shortdesc,b.image,category_name from catnorm cat
inner join
blogsortinfo b
on
cat.b_id=b.id
inner join
category c
on
cat.c_id=c.id
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateBlog]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBlog]
    @BlogID INT,
    @Title NVARCHAR(100),
    @Author NVARCHAR(50),
   
    @ShortDescription NVARCHAR(MAX),
   
    @Description NVARCHAR(MAX)
AS
BEGIN
   

    UPDATE blogsortinfo
    SET 
        blogname = @Title,
        authname = @Author,
        
        shortdesc = @ShortDescription,
        
        descript = @Description
    WHERE 
        id = @BlogID;
END;
GO
/****** Object:  StoredProcedure [dbo].[usercount]    Script Date: 28-10-2024 10:02:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usercount]
as
begin
select count(id) from users
end
GO
USE [master]
GO
ALTER DATABASE [Blog] SET  READ_WRITE 
GO
