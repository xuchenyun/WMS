using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CIT.Wcf.Utils;
namespace CIT.MES
{
    public class Utils
    {
        public static void AddLog(string log)
        {
            string date = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString();
            string serverpath = Environment.CurrentDirectory + "\\Assets\\";
            string filename = serverpath + "logs\\" + date + ".log";
            if (!System.IO.Directory.Exists(serverpath + "logs\\"))
                System.IO.Directory.CreateDirectory(serverpath + "logs\\");
            System.IO.StreamWriter sr = null;
            try
            {
                if (!System.IO.File.Exists(filename))
                {
                    sr = System.IO.File.CreateText(filename);
                }
                else
                {
                    sr = System.IO.File.AppendText(filename);
                }

                sr.WriteLine("\n" + DateTime.Now.ToLocalTime().ToString() + " ==>  " + log);
            }
            catch
            {

            }
            finally
            {
                if (sr != null)
                {
                    sr.Flush();
                    sr.Close();
                }
            }
        }
        #region 判断日志表是否存在 如果不存在创建相应的表与修改存储过程  nancy 2017.07.27
        public static void existsTable()
        {
            string sql = string.Format(@"
                        if not object_id(N'SyssystemLog',N'U') is not null
            begin
  ---SyssystemLog 表

CREATE TABLE [dbo].[SyssystemLog](
	[Fguid] [uniqueidentifier] NOT NULL,
	[line] [nvarchar](50) NULL,
	[WoCode] [nvarchar](50) NULL,
	[SfcNo] [nvarchar](50) NULL,
	[ProuctCode] [nvarchar](50) NULL,
	[PartNumber] [nvarchar](500) NULL,
	[ReelID] [nvarchar](50) NULL,
	[pocode] [nvarchar](50) NULL,
	[SupplierID] [nvarchar](50) NULL,
	[HouseCode] [nchar](10) NULL,
	[Qty] [decimal](18, 2) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Creator] [nvarchar](50) NULL,
	[CreatTime] [datetime] NULL,
 CONSTRAINT [PK_SyssystemLog] PRIMARY KEY CLUSTERED 
(
	[Fguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[SyssystemLog] ADD  CONSTRAINT [DF_SyssystemLog_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'WoCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制令单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'SfcNo'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'ProuctCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'料号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'PartNumber'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'ReelID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'pocode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产厂商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'SupplierID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'HouseCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'Qty'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'Remarks'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SyssystemLog', @level2type=N'COLUMN',@level2name=N'Creator'
    select 1
            end
else begin
select 0
end
");
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sql);
            if (int.Parse(dt.Rows[0][0].ToString()) > 0)
            {
                sql = string.Format(@"

--包装

GO
/****** Object:  StoredProcedure [dbo].[InPackage]    Script Date: 2017/7/26 13:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InPackage](
@childCode nvarchar(50), 
@project nvarchar(50), 
@Product nvarchar(50),
@line nvarchar(50), 
@pcb nvarchar(50), 
@Type nvarchar(50), 
@spec nvarchar(50), 
@parentCode nvarchar(50), 
@UserName nvarchar(50)
)
AS

BEGIN
DECLARE @Types int
	if exists(select * from SfcDatProductProRouteLog where PCBCode=@childCode ) 
	begin 
		select '0','进过维修室' return 
	end
	if not exists (select * from TRS_Base_PCBCode where PCBCode=@childCode ) 
	begin 
	select '0','未绑定' return 
	end
	if (@Type<>'维修') 
	begin 
		if exists (select * from SfcdatPackage where childcode=@childCode) 
		begin  
			select '0','已存在.' return 
		end
		else begin
			insert into [SfcdatPackage](Fguid,Project,Product,Line,PCB,Type,PackType,ParentCode,ChildCode,Creator,Createtime,status)
			values(newid(),@project,@Product,@line,@pcb,@Type,@spec,UPPER(@parentCode),UPPER(@childCode),@UserName,getdate(),'0')
			 insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
             select newid(),line,'','',Product,'',ChildCode,'',Project,'003',1,'MES托盘装(正常)',@UserName from  SfcdatPackage where ChildCode=UPPER(@childCode)
			select '1','绑定成功' 
			select ParentCode,count(ParentCode) as 'total' from SfcdatPackage WHERE ParentCode=UPPER(@parentCode)  group by ParentCode 
		end
	end
	else begin 
		insert into [SfcdatPackage](Fguid,Project,Product,Line,PCB,Type,PackType,ParentCode,ChildCode,Creator,Createtime,status)
		values(newid(),@project,@Product,@line,@pcb,@Type,@spec,UPPER(@parentCode),UPPER(@childCode),@UserName,getdate(),'0')
		insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
        select newid(),line,'','',Product,'',ChildCode,'',Project,'003',1,'MES托盘装(正常)',@UserName from  SfcdatPackage where ChildCode=UPPER(@childCode)
		select '1','绑定成功' 
		select ParentCode,count(ParentCode) as 'total' from SfcdatPackage WHERE ParentCode=UPPER(@parentCode)  group by ParentCode 
	end
END

--包装
GO
/****** Object:  StoredProcedure [dbo].[InPackage1]    Script Date: 2017/7/26 15:10:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InPackage1](
@childCode nvarchar(50), 
@project nvarchar(50), 
@Product nvarchar(50),
@line nvarchar(50), 
@pcb nvarchar(50), 
@Type nvarchar(50), 
@spec nvarchar(50), 
@parentCode nvarchar(50), 
@UserName nvarchar(50)
)
AS

BEGIN
DECLARE @Types int
	select TOP 1 @Types=isnull([Type],2) from SfcDatProductProRouteLog where PCBCode=@childCode order by Createtime desc 
	begin 
	if(@Types=0)
	begin
		select '0','在维修室.' return 
		end
	end
	if not exists (select * from TRS_Base_PCBCode where PCBCode=@childCode ) 
	begin 
	select '0','未绑定' return 
	end
	if (@Type<>'维修') 
	begin 
		if exists (select * from SfcdatPackage where childcode=@childCode) 
		begin  
			select '0','已存在.' return 
		end
		else begin
			insert into [SfcdatPackage](Fguid,Project,Product,Line,PCB,Type,PackType,ParentCode,ChildCode,Creator,Createtime,status)
			values(newid(),@project,@Product,@line,@pcb,@Type,@spec,UPPER(@parentCode),UPPER(@childCode),@UserName,getdate(),'0')
			insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
            select newid(),line,'','',Product,'',ChildCode,'',Project,'003',1,'MES托盘装',@UserName from  SfcdatPackage where ChildCode=UPPER(@childCode)
			select '1','绑定成功' 
			select ParentCode,count(ParentCode) as 'total' from SfcdatPackage WHERE ParentCode=UPPER(@parentCode)  group by ParentCode 
		end
	end
	else begin 
		insert into [SfcdatPackage](Fguid,Project,Product,Line,PCB,Type,PackType,ParentCode,ChildCode,Creator,Createtime,status)
		values(newid(),@project,@Product,@line,@pcb,@Type,@spec,UPPER(@parentCode),UPPER(@childCode),@UserName,getdate(),'0')
		insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
            select newid(),line,'','',Product,'',ChildCode,'',Project,'003',1,'MES托盘装',@UserName from  SfcdatPackage where ChildCode=UPPER(@childCode)
		select '1','绑定成功' 
		select ParentCode,count(ParentCode) as 'total' from SfcdatPackage WHERE ParentCode=UPPER(@parentCode)  group by ParentCode 
	end
END

--维修包装
GO
/****** Object:  StoredProcedure [dbo].[InPackageWei]    Script Date: 2017/7/26 13:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InPackageWei](
@childCode nvarchar(50), 
@project nvarchar(50), 
@Product nvarchar(50),
@line nvarchar(50), 
@pcb nvarchar(50), 
@Type nvarchar(50), 
@spec nvarchar(50), 
@parentCode nvarchar(50), 
@UserName nvarchar(50)
)
AS

BEGIN
DECLARE @Types int
	select TOP 1 @Types=isnull([Type],2) from SfcDatProductProRouteLog where PCBCode=@childCode order by Createtime desc 
	begin 
	if(@Types=0)
	begin
		select '0','在维修室' return 
		end
	else if(@Types=2)
	begin
		select '0','未进过维修室' return 
		end
	end
	if not exists (select * from TRS_Base_PCBCode where PCBCode=@childCode ) 
	begin 
	select '0','未绑定' return 
	end
	if (@Type<>'维修') 
	begin 
		if exists (select * from SfcdatPackage where childcode=@childCode) 
		begin  
			select '0','已存在.' return 
		end
		else begin
			insert into [SfcdatPackage](Fguid,Project,Product,Line,PCB,Type,PackType,ParentCode,ChildCode,Creator,Createtime,status)
			values(newid(),@project,@Product,@line,@pcb,@Type,@spec,UPPER(@parentCode),UPPER(@childCode),@UserName,getdate(),'0')
			insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
            select newid(),line,'','',Product,'',ChildCode,'',Project,'003',1,'MES托盘装(维修)',@UserName from  SfcdatPackage where ChildCode=UPPER(@childCode)
			select '1','绑定成功' 
			select ParentCode,count(ParentCode) as 'total' from SfcdatPackage WHERE ParentCode=UPPER(@parentCode)  group by ParentCode 
		end
	end
	else begin 
		insert into [SfcdatPackage](Fguid,Project,Product,Line,PCB,Type,PackType,ParentCode,ChildCode,Creator,Createtime,status)
		values(newid(),@project,@Product,@line,@pcb,@Type,@spec,UPPER(@parentCode),UPPER(@childCode),@UserName,getdate(),'0')
			insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
            select newid(),line,'','',Product,'',ChildCode,'',Project,'003',1,'MES托盘装(维修)',@UserName from  SfcdatPackage where ChildCode=UPPER(@childCode)
		select '1','绑定成功' 
		select ParentCode,count(ParentCode) as 'total' from SfcdatPackage WHERE ParentCode=UPPER(@parentCode)  group by ParentCode 
	end
END

--pvs拆封
GO
/****** Object:  StoredProcedure [dbo].[MdcDatSolderUnpacking_check]    Script Date: 2017/7/26 14:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[MdcDatSolderUnpacking_check](
@SfcNo nvarchar(50),
@ReelID nvarchar(50),
@UerName nvarchar(20)
)
as
begin
	begin try
		declare @sfcnumber nvarchar(50) set @sfcnumber=null
		declare @isenable int set @isenable=null
		select @sfcnumber=SfcNo,@isenable=IsEnable from MdcDatVStorage where ReelID=@ReelID and [Status] in (4,5)
		if(@sfcnumber is null)
		begin
			select 0,'未指定制令单' return
		end
		if(@isenable is null)
		begin
			select 0,'未指定是否为禁用' return
		end
		--是否与制令单相符
		if (@sfcnumber<>@SfcNo)
		begin
			select 0,'此锡膏与制令单不符' return
		end
		--是否禁用
		if (@isenable=1)
		begin
			select 0,'已被禁用' return
		end
		if not exists (select * from MdcdatMainlog where ReelID=@ReelID and Statu=5)
		begin
			update MdcdatSolderAttribute set ExposeUpdate=GETDATE() where ReelID=@ReelID
		end
		declare @MaxThawingtime int
		select top 1 a.ReelID,c.Lifetime,c.ExposeDate,c.Unpacking,c.MaxThawingtime into #a from (select * from MdcDatVStorage  where Reelid=@ReelID and [Status] in (4,5)) as a left join MdcdatMaterial as b on a.PartNumber=b.MaterialCode left join MdcDatGradTime as c on b.Type=c.Types and b.Grade=c.Grad where c.Types='锡膏' and a.Updatetime is not null and c.MaxThawingtime is not null and c.Thawingtime is not null
		select @MaxThawingtime=MaxThawingtime from  MdcDatGradTime where Types='锡膏'
		declare @Thawingtime int set @Thawingtime=(select Thawingtime+isnull(DATEDIFF(MINUTE,ThawingUpdate,GETDATE()),0) from [MdcdatSolderAttribute] where ReelID=@ReelID);
	    declare @Lifetime int set @Lifetime=(select Lifetime+isnull(DATEDIFF(MINUTE,LifeUpDate,GETDATE()),0) from [MdcdatSolderAttribute] where ReelID=@ReelID);
		declare @Exposetime int set @Exposetime=(select Exposetime+isnull(DATEDIFF(MINUTE,ExposeUpdate,GETDATE()),0) from [MdcdatSolderAttribute] where ReelID=@ReelID);
		declare @Unpacking int set @Unpacking=(select Returntime from [MdcdatSolderAttribute] where ReelID=@ReelID);
		--计算最大回温时间
		 --if(@MaxThawingtime<@Thawingtime)
		-- begin
		-- select 0,'超出最大回温时间' return
		 --end 
		--计算车间寿命
		if ((select [Lifetime] from #a)!=0)
		begin
			if ((select isnull([Lifetime]-@Lifetime,0) from #a)<0)
			begin
				select 0,'超出车间寿命' return
			end
		end
		--计算暴露时间 
		if ((select ExposeDate from #a)!=0)
		begin
			if((select isnull(ExposeDate-@Exposetime,0) from #a)<0)
			begin
				select 0,'超出暴露时间' return
			end
		end
		--计算拆封次数
		if ((select Unpacking from #a)!=0)
		begin
			if((select isnull(Unpacking-@Unpacking,0) from #a)<0)
			begin
				select 0,'超出拆封次数' return
			end
		end
		declare @WOCode nvarchar(50)
		declare @Product nvarchar(50)
		declare @PN nvarchar(50)
		select @PN=PartNumber,@WOCode=WoCode,@SfcNo=SfcNo,@Product=ProductName from MdcDatVStorage where ReelID=@ReelID
		declare @guid uniqueidentifier set @guid=NEWID()
		update [dbo].[MdcdatSolderAttribute] set Thawingtime=@Thawingtime,Lifetime=@Lifetime,LifeUpDate=GETDATE(),Exposetime=@Exposetime,ExposeUpdate=GETDATE() where ReelID=@ReelID
		INSERT INTO [dbo].[mdcdatAttributelog1]([Guid],[ReelID],[SfcNo],[WOCode],[Product])VALUES(@guid,@ReelID,@SfcNo,@WOCode,@Product)
		INSERT INTO [dbo].[MdcdatMainlog]([Guid],[ReelID],[PN],[Types],[Statu],[DES],[Cteator],[CreateTime]) VALUES (@guid,@ReelID,@PN,'锡膏','5','拆封',@UerName,GETDATE())
		INSERT INTO [dbo].[mdcdatAttributelog]([Guid],[ReelID],[Attribute],[value]) VALUES (@guid,@ReelID,'Thawingtime',@Thawingtime)
		INSERT INTO [dbo].[mdcdatAttributelog]([Guid],[ReelID],[Attribute],[value]) VALUES (@guid,@ReelID,'Lifetime',@Lifetime)
		INSERT INTO [dbo].[mdcdatAttributelog]([Guid],[ReelID],[Attribute],[value]) VALUES (@guid,@ReelID,'Returntime',@Unpacking+1)
		INSERT INTO [dbo].[mdcdatAttributelog]([Guid],[ReelID],[Attribute],[value]) VALUES (@guid,@ReelID,'Exposetime',@Exposetime)
		--if not exists(select * from MdcDatVStorage where ReelID=@ReelID and [Status]=5)
		--begin
		update MdcDatVStorage set [Status]=99,HouseCode='099' where SfcNo=@SfcNo and [Status]=5
		--end 
		update MdcDatVStorage set [Status]=5,HouseCode='003' where ReelID=@ReelID
		insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)                    
         select newid(),line,wocode,SfcNo,'',PartNumber,ReelID,pocode,SupplierID,HouseCode,qty,'PVS锡膏拆封',@UerName from  mdcdatvstorage where ReelID=@ReelID  
		select 1,'拆封成功'
		drop table #a
	end try
	begin catch
		select 2,ERROR_MESSAGE()
	end catch
end

--钢网下架
GO
/****** Object:  StoredProcedure [dbo].[MdcDatSteelPlatePDADown]    Script Date: 2017/7/26 14:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[MdcDatSteelPlatePDADown]
@ReelID varchar(50),
@Updater varchar(50)
as 
begin
begin try
             declare @SfcNo varchar(50)
             select @SfcNo=SfcNo from MdcDatSteelPlate where ReelID=@ReelID 
	            if exists ( select * from MdcDatSteelPlate where ReelID=@ReelID and Statu in (7))
	            begin
	                declare @qty int
	                declare @useqty int
	                select @useqty=SUM(ISNULL(qty,0)) from MdcdatMainlog where Types='钢网' and Statu=8 and ReelID=@ReelID and SfcNo=@SfcNo
					select @qty=isnull(round((select actQty from SfcDatProduct where SfcNo=@SfcNo)/(select top 1 BoradCnt from MdcDatUPH where ProductName in (select Product from SfcDatProduct where SfcNo=@SfcNo) and BoardType in ('1','2')),0),0)
                    set @qty=@qty-@useqty
                    update MdcDatSteelPlate set Statu=8,UpdateTime=getdate(),Updater=@Updater,UseValue=CAST(UseValue AS int)+@qty,Remain=CAST(MaxValue  AS int)-CAST(UseValue AS int)-@qty where ReelID=@ReelID
                     
                     declare @guid uniqueidentifier set @guid=NEWID()
                    insert into MdcdatMainlog select @guid,ReelID,PlateCode,'钢网','8','钢网下线',@SfcNo,@qty,@Updater,GETDATE() from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'MaxValue',MaxValue from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'UseValue',UseValue from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Remain',Remain from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Thickness',Pthickness from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Versions',Versions from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'ROHS',ROHS from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Psurface',Psurface from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Pressure',Pressure from MdcDatSteelPlate where ReelID=@ReelID  
                     declare @wocode varchar(50)
                      declare @line varchar(50)
                      declare @product varchar(50)
                      select @wocode=wocode,@line=line,@product=product  from SfcDatProduct where sfcno=@SfcNo
					 insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
                     select newid(),@line,@wocode,SfcNo,@product,PlateCode,ReelID,'','','',1,'PVS钢网下线',@Updater from MdcDatSteelPlate where ReelID=@ReelID                     
					select 1,'下线完成' return
	            end
	            else if exists (select * from MdcDatSteelPlate where ReelID=@ReelID and Statu in (11,12))
                begin
		            select 0,'不良品/报废品' return
	            end
               	else if exists (select * from MdcDatSteelPlate where ReelID=@ReelID and Statu in (0,1,2,3,4,5,6,8,9,10))
                begin
		            select 0,'状态不对' return
	            end
                end try
                begin catch
	                select 0,ERROR_MESSAGE()
                end catch
                end

--钢网上架
GO
/****** Object:  StoredProcedure [dbo].[MdcDatSteelPlatePDAUp]    Script Date: 2017/7/26 14:30:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[MdcDatSteelPlatePDAUp]
@SfcNo varchar(50),
@ReelID varchar(50),
@SetupName varchar(50),
@Updater varchar(50)
as 
begin
	begin try
	DECLARE @len int 
	DECLARE @value int 
	              set @len=SUBSTRING(@SetupName,CHARINDEX('-',@SetupName, 1) + 1, 1)
	            if exists ( select * from MdcDatSteelPlate where ReelID=@ReelID and SfcNo=@SfcNo and Statu in (7))
	            begin
	            select 1,'校验成功' return
	            end 
	            if exists ( select * from MdcDatSteelPlate where ReelID=@ReelID and SfcNo=@SfcNo and Statu in (5,6))
	            begin
	          --  select @value=isnull(Value3,1) from MdcdatProductDetail where Value1 in(select PlateCode from MdcDatSteelPlate where ReelID=@ReelID and SfcNo=@SfcNo) and key1='SteelNet' and Value2='是' 
		         -- if(@value='')
		         -- begin
		         --set @value=1
		         -- end
		         -- if(@value=@len)
		         -- begin
		            update MdcDatSteelPlate set Statu=7,UpdateTime=getdate(),Updater=@Updater where ReelID=@ReelID
		             declare @guid uniqueidentifier set @guid=NEWID()
                    insert into MdcdatMainlog(Guid,ReelID,PN,Types,Statu,DES,Cteator,CreateTime) select @guid,ReelID,PlateCode,'钢网','7','钢网上线',@ReelID,GETDATE() from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'MaxValue',MaxValue from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'UseValue',UseValue from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Remain',Remain from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Thickness',Pthickness from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Versions',Versions from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'ROHS',ROHS from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Psurface',Psurface from MdcDatSteelPlate where ReelID=@ReelID
                    insert into mdcdatAttributelog select @guid,@ReelID,'Pressure',Pressure from MdcDatSteelPlate where ReelID=@ReelID  
		              declare @wocode varchar(50)
                      declare @line varchar(50)
                      declare @product varchar(50)
                      select @wocode=wocode,@line=line,@product=product  from SfcDatProduct where sfcno=@SfcNo
					 insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
                     select newid(),@line,@wocode,SfcNo,@product,PlateCode,ReelID,'','','',1,'PVS钢网上线',@Updater from MdcDatSteelPlate where ReelID=@ReelID                     
				    select 1,'上线完成' return
		              --end
		            --else 
		            --begin
		            -- select 0,'正反面错误' return
		            --end
	            end
	            else if not exists (select * from MdcDatSteelPlate where ReelID=@ReelID and SfcNo=@SfcNo)
				begin
		            select 0,'制令单不符,无法上线' return
	            end
				else if not exists (select * from MdcDatSteelPlate where ReelID=@ReelID and SfcNo=@SfcNo and Statu in (5,6))
				begin
		            select 0,'不是待上线状态' return
	            end

                end try
                begin catch
	                select 0,ERROR_MESSAGE()
                end catch
      end

--客供料绑定
GO
/****** Object:  StoredProcedure [dbo].[sp_POinputWMS]    Script Date: 2017/7/26 14:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_POinputWMS]
@POCODE NVARCHAR(50),
@PARTNUMBER NVARCHAR(50),
@QTY NVARCHAR(50),
@reelid nvarchar(50),
@USER NVARCHAR(50)
AS
BEGIN
	begin try
	
	declare @InQty decimal(18,4)
		set @InQty=0
		declare @totalQty  decimal(18,4)
		--可以接收数量
		select @totalQty= sum(isnull(compqty,0)) from  MdcDatIQCCheck where PO=@pocode and (Recive='0' or Recive='3') AND Status='1' and pn = @partnumber group by PN
		if @totalQty is null
			begin
				select '0','没有可接收数据' return;
			end
		--已接收数量
		IF SUBSTRING(@PARTNUMBER,1,1)='4' OR SUBSTRING(@PARTNUMBER,1,1)='8' OR SUBSTRING(@PARTNUMBER,1,1)='9'
			begin
				select @InQty= isnull(SUM(QTY),'0') from SfcDatERPKJHinfo where MESPO=@pocode and PH=@PARTNUMBER group by PH
			end
		else
			begin
				select @InQty= isnull(SUM(SQTY),'0') from SfcDatERPJHinfo where POCode=@pocode and PartNumber=@PARTNUMBER group by PartNumber
			end
		--剩余接收数量
		declare @_qty  decimal(18,4)
		set @_qty=@totalQty-@InQty
		if (@qty>@_qty)
			begin
				select '0','待入库数量大于剩余入库数量',@_qty return;
			end
		if @_qty <= 0
			begin
				select '0','可接收数量为0' return;
			end

	IF SUBSTRING(@PARTNUMBER,1,1)='4' OR SUBSTRING(@PARTNUMBER,1,1)='8' OR SUBSTRING(@PARTNUMBER,1,1)='9'
		BEGIN
			--客供料入库
			insert into SfcDatERPKJHInfo(FGuid,DB,MESPO,PH,QTY,Creator,Createtime,status)
			values(NEWID(),'1102',@POCODE,@PARTNUMBER,@QTY,@USER,GETDATE(),'0')
		END
	else
		begin
			insert into SfcDatERPJHinfo(FGUID,pocode,partnumber,sqty,nqty,status,creator,createtime)
			values(NEWID(),@POCODE,@PARTNUMBER,@QTY,'0','0',@USER,getdate())
		end
	update mdcdatvstorage set  housecode='027' where reelid=@reelid
	insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
	select newid(),line,wocode,sfcno,'',PartNumber,ReelID,pocode,SupplierID,'027',Qty,'PDA物料掉至虚拟仓(含账务)',@USER from mdcdatvstorage where reelid=@reelid 
	if not exists (select * from MdcDatRStorage where PartNumber=@PARTNUMBER)
		begin
			insert into MdcDatRStorage(PartNumber,Qty)values(@PARTNUMBER,'0')
		end   
			update mdcdatrstorage set qty=qty+@qty where partnumber=@PARTNUMBER
	select '1','调拨成功'
	end try
	begin catch
		select '0','调拨失败'
	end catch
END

");
                NMS.ExecTransql(PubUtils.uContext, sql);
            }
        }
        #endregion
    }
}
