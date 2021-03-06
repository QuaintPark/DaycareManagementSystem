USE [master]
GO
/****** Object:  Database [QuaintDMSDB]    Script Date: 3/7/2018 12:49:11 AM ******/
CREATE DATABASE [QuaintDMSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuaintDMSDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.JESHADKHAN\MSSQL\DATA\QuaintDMSDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuaintDMSDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.JESHADKHAN\MSSQL\DATA\QuaintDMSDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuaintDMSDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuaintDMSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuaintDMSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuaintDMSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuaintDMSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuaintDMSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuaintDMSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuaintDMSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuaintDMSDB] SET  MULTI_USER 
GO
ALTER DATABASE [QuaintDMSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuaintDMSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuaintDMSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuaintDMSDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuaintDMSDB]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Child]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Child]
	@ChildId int
As
Begin
	Delete
		dbo.Childs
	Where
		[ChildId] = @ChildId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Delete_Designation]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Designation]
	@DesignationId int
As
Begin
	Delete
		dbo.Designations
	Where
		[DesignationId] = @DesignationId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Member]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Member]
	@MemberId int
As
Begin
	Delete
		dbo.Members
	Where
		[MemberId] = @MemberId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Delete_OfficeExpense]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_OfficeExpense]
	@OfficeExpenseId int
As
Begin
	Delete
		dbo.OfficeExpenses
	Where
		[OfficeExpenseId] = @OfficeExpenseId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Program]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Program]
	@ProgramId int
As
Begin
	Delete
		dbo.Programs
	Where
		[ProgramId] = @ProgramId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Delete_ProgramWiseServices_By_ProgramId]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_ProgramWiseServices_By_ProgramId]
	@ProgramId int
As
Begin
	Delete
		dbo.ProgramWiseServices
	Where
		[ProgramId] = @ProgramId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Service]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Service]
	@ServiceId int
As
Begin
	Delete
		dbo.Services
	Where
		[ServiceId] = @ServiceId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Staff]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Staff]
	@StaffId int
As
Begin
	Delete
		dbo.Staffs
	Where
		[StaffId] = @StaffId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_User]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_User]
	@UserId int
As
Begin
	Delete
		dbo.Users
	Where
		[UserId] = @UserId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Child]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Child]
As
Begin
	Select
		*
	From
		dbo.Childs
End

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Designation]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Designation]
As
Begin
	Select
		*
	From
		dbo.Designations
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Member]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Member]
As
Begin
	Select
		m.*
		,CONCAT(m.MemberCode, ' -  ', m.FirstName, ' ', m.LastName) as FullName
	From
		dbo.Members m
End

GO
/****** Object:  StoredProcedure [dbo].[Get_All_OfficeExpense]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_OfficeExpense]
As
Begin
	Select
		*
	From
		dbo.OfficeExpenses
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Program]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Program]
As
Begin
	Select
		p.*
		,CONCAT(p.Title, ' -  ', p.TotalAmount) as TitleWithTotalAmount
	From
		dbo.Programs p
End

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Service]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Service]
As
Begin
	Select
		s.*
		,CONCAT(s.ServiceCode, ' -  ', s.Title, ' -  ', s. Amount, ' Tk.') as TitleWithAmountAndCode
	From
		dbo.Services as s
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Staff]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Staff]
As
Begin
	Select
		s.*
		,d.Name as DesignationName
		,d.DesignationCode as DesignationCode
	From
		dbo.Staffs s
	Left Join
		dbo.Designations d
	on
		s.DesignationId = d.DesignationId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_User]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_User]
As
Begin
	Select
		*
	From
		dbo.Users
End

GO
/****** Object:  StoredProcedure [dbo].[Get_Child_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Child_By_Id]
	@ChildId int
As
Begin
	Select
		*
	From
		dbo.Childs
	Where
		[ChildId] = @ChildId
End

GO
/****** Object:  StoredProcedure [dbo].[Get_Designation_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Designation_By_Id]
	@DesignationId int
As
Begin
	Select
		*
	From
		dbo.Designations
	Where
		[DesignationId] = @DesignationId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Member_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Member_By_Id]
	@MemberId int
As
Begin
	Select
		*
	From
		dbo.Members
	Where
		[MemberId] = @MemberId
End

GO
/****** Object:  StoredProcedure [dbo].[Get_OfficeExpense_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_OfficeExpense_By_Id]
	@OfficeExpenseId int
As
Begin
	Select
		*
	From
		dbo.OfficeExpenses
	Where
		[OfficeExpenseId] = @OfficeExpenseId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Program_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Program_By_Id]
	@ProgramId int
As
Begin
	Select
		*
	From
		dbo.Programs
	Where
		[ProgramId] = @ProgramId
End

GO
/****** Object:  StoredProcedure [dbo].[Get_ProgramWiseServices_By_ProgramId]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_ProgramWiseServices_By_ProgramId]
	@ProgramId int
As
Begin
	Select
		pws.*
		,s.Title as ServiceTitle
		,CONCAT(s.ServiceCode, ' -  ', s.Title, ' -  ', s. Amount, ' Tk.') as TitleWithAmountAndCode
		,CAST(ROW_NUMBER() OVER (ORDER BY pws.ProgramWiseServiceId) as int) as Serial
	From
		dbo.ProgramWiseServices pws
	Left Join
		dbo.Services s
	On
		pws.ServiceId = s.ServiceId
	Where
		pws.[ProgramId] = @ProgramId
End

GO
/****** Object:  StoredProcedure [dbo].[Get_Service_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Service_By_Id]
	@ServiceId int
As
Begin
	Select
		*
	From
		dbo.Services
	Where
		[ServiceId] = @ServiceId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Staff_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Staff_By_Id]
	@StaffId int
As
Begin
	Select
		*
	From
		dbo.Staffs
	Where
		[StaffId] = @StaffId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_User_By_Id]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_User_By_Id]
	@UserId int
As
Begin
	Select
		*
	From
		dbo.Users
	Where
		[UserId] = @UserId
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Child]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Child]
	@ChildCode nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = null,
	@DateOfBirth datetime = null,
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,	
	@City nvarchar(50) = null,
	@ZipCode int = null,
	@Country nvarchar(50) = null,
	@ProfilePhoto nvarchar(MAX) = null,
	@FatherName nvarchar(50),
	@FatherProfession nvarchar(50) = null,
	@FatherContactNumber nvarchar(50) = null,
	@MotherName nvarchar(50),
	@MotherProfession nvarchar(50) = null,
	@MotherContactNumber nvarchar(50) = null,
	@LocalGuardianName nvarchar(50) = null,
	@LocalGuardianProfession nvarchar(50) = null,
	@LocalGuardianContactNumber nvarchar(50) = null,
	@LocalGuardianAddressLine1 nvarchar(50) = null,
	@LocalGuardianAddressLine2 nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@MemberId int,
	@ProgramId int
As
Begin
	Insert Into dbo.Childs
		(ChildCode, FirstName, LastName, DateOfBirth, AddressLine1, AddressLine2, City, ZipCode, Country, ProfilePhoto, FatherName, FatherProfession, FatherContactNumber, MotherName, MotherProfession, MotherContactNumber, LocalGuardianName, LocalGuardianProfession, LocalGuardianContactNumber, LocalGuardianAddressLine1, LocalGuardianAddressLine2, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, MemberId, ProgramId)
	Values
		(@ChildCode, @FirstName, @LastName, @DateOfBirth, @AddressLine1, @AddressLine2, @City, @ZipCode, @Country, @ProfilePhoto, @FatherName, @FatherProfession, @FatherContactNumber, @Mothername, @MotherProfession, @MotherContactNumber, @LocalGuardianName, @LocalGuardianProfession, @LocalGuardianContactNumber, @LocalGuardianAddressLine1, @LocalGuardianAddressLine2, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @MemberId, @ProgramId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Designation]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Designation]
	@DesignationCode nvarchar(20),
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Designations
		(DesignationCode, Name, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@DesignationCode, @Name, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Member]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Member]
	@MemberCode nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = null,
	@DateOfBirth datetime = null,
	@Email nvarchar(50),
	@ContactNumber nvarchar(50) = null,
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,	
	@City nvarchar(50) = null,
	@ZipCode int = null,
	@Country nvarchar(50) = null,
	@NationalIdNumber nvarchar(50) = null,
	@PassportNumber nvarchar(50) = null,
	@DrivingLicenseNumber nvarchar(50) = null,
	@ProfilePhoto nvarchar(MAX) = null,
	@CurrentStatus nvarchar(10) = null,
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@SecurityQuestion nvarchar(MAX) = null,
	@SecurityAnswer nvarchar(MAX) = null,
	@IsVerified bit,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Members
		(MemberCode, FirstName, LastName, DateOfBirth, Email, ContactNumber, AddressLine1, AddressLine2, City, ZipCode, Country, NationalIdNumber, PassportNumber, DrivingLicenseNumber, ProfilePhoto, CurrentStatus, Password, PasswordStamp, SecurityQuestion, SecurityAnswer, IsVerified, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@MemberCode, @FirstName, @LastName, @DateOfBirth, @Email, @ContactNumber, @AddressLine1, @AddressLine2, @City, @ZipCode, @Country, @NationalIdNumber, @PassportNumber, @DrivingLicenseNumber, @ProfilePhoto, @CurrentStatus, @Password, @PasswordStamp, @SecurityQuestion, @SecurityAnswer, @IsVerified, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_OfficeExpense]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_OfficeExpense]
	@OfficeExpenseCode nvarchar(20),
	@Description nvarchar(MAX) = null,
	@Amount decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@Reference nvarchar(100) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.OfficeExpenses
		(OfficeExpenseCode, Description, Amount, AmountStatus, Reference, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@OfficeExpenseCode, @Description, @Amount, @AmountStatus, @Reference, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Program]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Program]
	@ProgramCode nvarchar(20),
	@Title nvarchar(100),
	@Description nvarchar(MAX) = null,
	@AgeRange nvarchar(50) = null,
	@Period nvarchar(50) = null,
	@TotalAmount decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Programs
		(ProgramCode, Title, Description, AgeRange, Period, TotalAmount, AmountStatus, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@ProgramCode, @Title, @Description, @AgeRange, @Period, @TotalAmount, @AmountStatus, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_ProgramWiseService]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_ProgramWiseService]
	@ProgramId int,
	@ServiceId int,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.ProgramWiseServices
		(ProgramId, ServiceId, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@ProgramId, @ServiceId, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Service]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Service]
	@ServiceCode nvarchar(20),
	@Title nvarchar(50),
	@Description nvarchar(MAX) = null,
	@Amount decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Services
		(ServiceCode, Title, Description, Amount, AmountStatus, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@ServiceCode, @Title, @Description, @Amount, @AmountStatus, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Staff]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Staff]
	@StaffCode nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = null,
	@DateOfBirth datetime = null,
	@Email nvarchar(50),
	@ContactNumber nvarchar(50) = null,
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,
	@City nvarchar(50) = null,
	@ZipCode int = null,
	@Country nvarchar(50) = null,
	@NationalIdNumber nvarchar(50) = null,
	@PassportNumber nvarchar(50) = null,
	@DrivingLicenseNumber nvarchar(50) = null,
	@ProfilePhoto nvarchar(MAX) = null,
	@JoiningDate datetime = null,
	@Salary decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@CurrentStatus nvarchar(10) = null,
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@SecurityQuestion nvarchar(MAX) = null,
	@SecurityAnswer nvarchar(MAX) = null,
	@IsVerified bit,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@DesignationId int
As
Begin
	Insert Into dbo.Staffs
		(StaffCode, FirstName, DateOfBirth, Email, ContactNumber, AddressLine1, AddressLine2, City, ZipCode, Country, NationalIdNumber, PassportNumber, DrivingLicenseNumber, ProfilePhoto, JoiningDate, Salary, AmountStatus, CurrentStatus, Password, PasswordStamp, SecurityQuestion, SecurityAnswer, IsVerified, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, DesignationId)
	Values
		(@StaffCode, @FirstName, @DateOfBirth, @Email, @ContactNumber, @AddressLine1, @AddressLine2, @City, @ZipCode, @Country, @NationalIdNumber, @PassportNumber, @DrivingLicenseNumber, @ProfilePhoto, @JoiningDate, @Salary, @AmountStatus, @CurrentStatus, @Password, @PasswordStamp, @SecurityQuestion, @SecurityAnswer, @IsVerified, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @DesignationId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_User]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_User]
	@UserCode nvarchar(50),
	@FullName nvarchar(50),
	@Email nvarchar(50) = null,
	@UserName nvarchar(50),
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@UserType nvarchar(50)
As
Begin
	Insert Into dbo.Users
		(UserCode, FullName, Email, UserName, Password, PasswordStamp, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, UserType)
	Values
		(@UserCode, @FullName, @Email, @UserName, @Password, @PasswordStamp, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @UserType)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Child]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Child]
	@ChildId int,
	@ChildCode nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = null,
	@DateOfBirth datetime = null,
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,	
	@City nvarchar(50) = null,
	@ZipCode int = null,
	@Country nvarchar(50) = null,
	@ProfilePhoto nvarchar(MAX) = null,
	@FatherName nvarchar(50),
	@FatherProfession nvarchar(50) = null,
	@FatherContactNumber nvarchar(50) = null,
	@MotherName nvarchar(50),
	@MotherProfession nvarchar(50) = null,
	@MotherContactNumber nvarchar(50) = null,
	@LocalGuardianName nvarchar(50) = null,
	@LocalGuardianProfession nvarchar(50) = null,
	@LocalGuardianContactNumber nvarchar(50) = null,
	@LocalGuardianAddressLine1 nvarchar(50) = null,
	@LocalGuardianAddressLine2 nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@MemberId int,
	@ProgramId int
As
Begin
	Update
		dbo.Childs
	Set
		 [ChildCode] = @ChildCode
		,[FirstName] = @FirstName
		,[LastName] = @LastName
		,[DateOfBirth] = @DateOfBirth
		,[AddressLine1] = @AddressLine1
		,[AddressLine2] = @AddressLine2
		,[City] = @City
		,[ZipCode] = @ZipCode
		,[Country] = @Country
		,[ProfilePhoto] = @ProfilePhoto
		,[FatherName] = @FatherName
		,[FatherProfession] = @FatherProfession
		,[FatherContactNumber] = @FatherContactNumber
		,[MotherName] = @MotherName
		,[MotherProfession] = @MotherProfession
		,[MotherContactNumber] = @MotherContactNumber
		,[LocalGuardianName] = @LocalGuardianName
		,[LocalGuardianProfession] = @LocalGuardianProfession
		,[LocalGuardianContactNumber] = @LocalGuardianContactNumber
		,[LocalGuardianAddressLine1] = @LocalGuardianAddressLine1
		,[LocalGuardianAddressLine2] = @LocalGuardianAddressLine2
		,[IsActive]= @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[MemberId] = @MemberId
		,[ProgramId] = @ProgramId
	Where		
		[ChildId] = @ChildId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Designation]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Designation]
	@DesignationId int,
	@DesignationCode nvarchar(20),
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Designations
	Set
		[DesignationCode] = @DesignationCode
		,[Name] = @Name
		,[Description] = @Description
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[DesignationId] = @DesignationId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Member]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Member]
	@MemberId int,
	@MemberCode nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = null,
	@DateOfBirth datetime = null,
	@Email nvarchar(50),
	@ContactNumber nvarchar(50) = null,
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,	
	@City nvarchar(50) = null,
	@ZipCode int = null,
	@Country nvarchar(50) = null,
	@NationalIdNumber nvarchar(50) = null,
	@PassportNumber nvarchar(50) = null,
	@DrivingLicenseNumber nvarchar(50) = null,
	@ProfilePhoto nvarchar(MAX) = null,
	@CurrentStatus nvarchar(10) = null,
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@SecurityQuestion nvarchar(MAX) = null,
	@SecurityAnswer nvarchar(MAX) = null,
	@IsVerified bit,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Members
	Set
		 [MemberCode] = @MemberCode
		,[FirstName] = @FirstName
		,[LastName] = @LastName
		,[DateOfBirth] = @DateOfBirth
		,[Email]=@Email
		,[ContactNumber] = @ContactNumber
		,[AddressLine1] = @AddressLine1
		,[AddressLine2] = @AddressLine2
		,[City] = @City
		,[ZipCode] = @ZipCode
		,[Country] = @Country
		,[NationalIdNumber] = @NationalIdNumber
		,[PassportNumber] = @PassportNumber
		,[DrivingLicenseNumber] = @DrivingLicenseNumber
		,[ProfilePhoto] = @ProfilePhoto
		,[CurrentStatus] = @CurrentStatus
		,[Password] = @Password
		,[PasswordStamp] = @PasswordStamp
		,[SecurityQuestion] = @SecurityQuestion
		,[SecurityAnswer] = @SecurityAnswer
		,[IsVerified] = @IsVerified
		,[IsActive]= @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[MemberId] = @MemberId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_OfficeExpense]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_OfficeExpense]
	@OfficeExpenseId int,
	@OfficeExpenseCode nvarchar(20),
	@Description nvarchar(MAX) = null,
	@Amount decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@Reference nvarchar(100) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.OfficeExpenses
	Set
		[OfficeExpenseCode] = @OfficeExpenseCode
		,[Description] = @Description
		,[Amount] = @Amount
		,[AmountStatus] = @AmountStatus
		,[Reference] = @Reference
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[OfficeExpenseId] = @OfficeExpenseId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Program]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Program]
	@ProgramId int,
	@ProgramCode nvarchar(20),
	@Title nvarchar(100),
	@Description nvarchar(MAX) = null,
	@AgeRange nvarchar(50) = null,
	@Period nvarchar(50) = null,
	@TotalAmount decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Programs
	Set
		[ProgramCode] = @ProgramCode
		,[Title] = @Title
		,[Description] = @Description
		,[AgeRange] = @AgeRange
		,[Period] = @Period
		,[TotalAmount] = @TotalAmount
		,[AmountStatus] = @AmountStatus
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[ProgramId] = @ProgramId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Service]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Service]
	@ServiceId int,
	@ServiceCode nvarchar(20),
	@Title nvarchar(50),
	@Description nvarchar(MAX) = null,
	@Amount decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Services
	Set
		[ServiceCode] = @ServiceCode
		,[Title] = @Title
		,[Description] = @Description
		,[Amount]=@Amount
		,[AmountStatus]=@AmountStatus
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[ServiceId] = @ServiceId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Staff]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Staff]
	@StaffId int,
	@StaffCode nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = null,
	@DateOfBirth datetime = null,
	@Email nvarchar(50),
	@ContactNumber nvarchar(50) = null,
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,
	@City nvarchar(50) = null,
	@ZipCode int = null,
	@Country nvarchar(50) = null,
	@NationalIdNumber nvarchar(50) = null,
	@PassportNumber nvarchar(50) = null,
	@DrivingLicenseNumber nvarchar(50) = null,
	@ProfilePhoto nvarchar(MAX) = null,
	@JoiningDate datetime = null,
	@Salary decimal(18, 2),
	@AmountStatus nvarchar(50) = null,
	@CurrentStatus nvarchar(10) = null,
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@SecurityQuestion nvarchar(MAX) = null,
	@SecurityAnswer nvarchar(MAX) = null,
	@IsVerified bit,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@DesignationId int
As
Begin
	Update
		dbo.Staffs
	Set
		[StaffCode] = @StaffCode
		,[FirstName] = @FirstName
		,[LastName] = @LastName
		,[DateOfBirth] = @DateOfBirth
		,[Email] = @Email
		,[ContactNumber] = @ContactNumber
		,[AddressLine1] = @AddressLine1
		,[AddressLine2] = @AddressLine2
		,[City] = @City
		,[ZipCode] = @ZipCode
		,[Country] = @Country
		,[NationalIdNumber] = @NationalIdNumber
		,[PassportNumber] = @PassportNumber
		,[DrivingLicenseNumber] = @DrivingLicenseNumber
		,[ProfilePhoto] = @ProfilePhoto
		,[JoiningDate] = @JoiningDate
		,[Salary] = @Salary
		,[AmountStatus] = @AmountStatus
		,[CurrentStatus] = @CurrentStatus
		,[Password] = @Password
		,[PasswordStamp] = @PasswordStamp
		,[SecurityQuestion] = @SecurityQuestion
		,[SecurityAnswer] = @SecurityAnswer
		,[IsVerified] = @IsVerified
		,[IsActive]= @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[DesignationId] = @DesignationId
	Where		
		[StaffId] = @StaffId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_User]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Daycare Management System (QDMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_User]
	@UserId int,
	@UserCode nvarchar(50),
	@FullName nvarchar(50),
	@Email nvarchar(50) = null,
	@UserName nvarchar(50),
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@UserType nvarchar(50)
As
Begin
	Update
		dbo.Users
	Set
		[UserCode] = @UserCode
		,[FullName] = @FullName
		,[Email] = @Email
		,[UserName] = @UserName
		,[Password] = @Password
		,[PasswordStamp] = @PasswordStamp
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[UserType] = @UserType
	Where		
		[UserId] = @UserId
End

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountCode] [nvarchar](20) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Childs]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Childs](
	[ChildId] [int] IDENTITY(1,1) NOT NULL,
	[ChildCode] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[FatherName] [nvarchar](50) NOT NULL,
	[FatherProfession] [nvarchar](50) NULL,
	[FatherContactNumber] [nvarchar](50) NULL,
	[MotherName] [nvarchar](50) NOT NULL,
	[MotherProfession] [nvarchar](50) NULL,
	[MotherContactNumber] [nvarchar](50) NULL,
	[LocalGuardianName] [nvarchar](50) NULL,
	[LocalGuardianProfession] [nvarchar](50) NULL,
	[LocalGuardianContactNumber] [nvarchar](50) NULL,
	[LocalGuardianAddressLine1] [nvarchar](50) NULL,
	[LocalGuardianAddressLine2] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[MemberId] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
 CONSTRAINT [PK_Childs] PRIMARY KEY CLUSTERED 
(
	[ChildId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designations]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationCode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonorDonations]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonorDonations](
	[DonorDonationId] [int] IDENTITY(1,1) NOT NULL,
	[DonorDonationCode] [nvarchar](20) NOT NULL,
	[DonationAmount] [decimal](18, 2) NOT NULL,
	[AmountStatus] [nvarchar](50) NULL,
	[DonationDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[DonorId] [int] NOT NULL,
 CONSTRAINT [PK_DonarDonations] PRIMARY KEY CLUSTERED 
(
	[DonorDonationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donors]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donors](
	[DonorId] [int] IDENTITY(1,1) NOT NULL,
	[DonorCode] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [int] NULL,
	[Country] [nvarchar](50) NOT NULL,
	[NationalIdNumber] [nvarchar](50) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[DrivingLicenseNumber] [nvarchar](50) NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[CurrentStatus] [nvarchar](10) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordStamp] [nvarchar](max) NULL,
	[IsVerified] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[DesignationId] [int] NOT NULL,
 CONSTRAINT [PK_Donors] PRIMARY KEY CLUSTERED 
(
	[DonorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Members]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[MemberCode] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[NationalIdNumber] [nvarchar](50) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[DrivingLicenseNumber] [nvarchar](50) NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[CurrentStatus] [nvarchar](10) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordStamp] [nvarchar](max) NULL,
	[SecurityQuestion] [nvarchar](max) NULL,
	[SecurityAnswer] [nvarchar](max) NULL,
	[IsVerified] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OfficeExpenses]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficeExpenses](
	[OfficeExpenseId] [int] IDENTITY(1,1) NOT NULL,
	[OfficeExpenseCode] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[AmountStatus] [nvarchar](50) NULL,
	[Reference] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_OfficeExpenses] PRIMARY KEY CLUSTERED 
(
	[OfficeExpenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Programs]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programs](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[ProgramCode] [nvarchar](20) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[AgeRange] [nvarchar](50) NULL,
	[Period] [nvarchar](50) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[AmountStatus] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Programs] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProgramWiseServices]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramWiseServices](
	[ProgramWiseServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ProgramId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProgramWiseServices] PRIMARY KEY CLUSTERED 
(
	[ProgramWiseServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceCode] [nvarchar](20) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[AmountStatus] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffId] [int] IDENTITY(1,1) NOT NULL,
	[StaffCode] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[NationalIdNumber] [nvarchar](50) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[DrivingLicenseNumber] [nvarchar](50) NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[JoiningDate] [datetime] NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[AmountStatus] [nvarchar](50) NULL,
	[CurrentStatus] [nvarchar](10) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordStamp] [nvarchar](max) NULL,
	[SecurityQuestion] [nvarchar](max) NULL,
	[SecurityAnswer] [nvarchar](max) NULL,
	[IsVerified] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[DesignationId] [int] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StaffSalaryRecords]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffSalaryRecords](
	[StaffSalaryRecordId] [int] IDENTITY(1,1) NOT NULL,
	[StaffSalaryRecordCode] [nvarchar](20) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[PreviousDue] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[PaidAmount] [decimal](18, 2) NOT NULL,
	[Due] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[StaffId] [int] NOT NULL,
 CONSTRAINT [PK_StaffSalaryRecords] PRIMARY KEY CLUSTERED 
(
	[StaffSalaryRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/7/2018 12:49:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordStamp] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[UserType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [QuaintDMSDB] SET  READ_WRITE 
GO
