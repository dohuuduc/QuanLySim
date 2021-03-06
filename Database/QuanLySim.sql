USE [AppSearch]
GO
/****** Object:  StoredProcedure [dbo].[spBackup]    Script Date: 10/02/2017 11:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBackup]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	declare @tenbang nvarchar(30);
	declare @Chuoisql nvarchar(150);
	
	set @tenbang = N'dienthoai_goc'+ REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(19), CONVERT(DATETIME, getdate(), 112), 126), '-', ''), 'T', ''), ':', '') 
	declare @part varchar(20)
	while  EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tenbang)
	begin
		set @tenbang = N'dienthoai_goc'+ REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(19), CONVERT(DATETIME, getdate(), 112), 126), '-', ''), 'T', ''), ':', '') 
	end
	set @Chuoisql = N'select * into ' + @tenbang +' from dbo.dienthoai_goc'
	EXECUTE sp_executesql @Chuoisql
	 
end
GO
/****** Object:  Table [dbo].[dienthoai_new]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dienthoai_new](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten_khach_hang] [nvarchar](300) NULL,
	[didong] [nchar](12) NULL,
	[dia_chi] [nvarchar](600) NULL,
	[namsinh] [nvarchar](100) NULL,
	[ngay] [nvarchar](100) NULL,
	[thang] [nvarchar](100) NULL,
	[cuoc] [nvarchar](100) NULL,
	[gioi_tinh] [nvarchar](100) NULL,
	[ngan_hang] [nvarchar](100) NULL,
	[sim] [nvarchar](100) NULL,
	[tinh] [nvarchar](100) NULL,
	[tinh_cuoc] [nvarchar](100) NULL,
	[ghi_chu] [nvarchar](300) NULL,
	[filenguon] [nvarchar](300) NULL,
	[creatdate] [datetime] NULL,
	[ngay_kich_hoat] [nvarchar](100) NULL,
	[cong_ty] [nvarchar](300) NULL,
	[chuc_vu] [nvarchar](100) NULL,
	[he_dieu_hanh] [nvarchar](600) NULL,
	[goi_cuoc] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[phuong] [nvarchar](100) NULL,
	[quan_huyen] [nvarchar](100) NULL,
	[dong_may] [nvarchar](600) NULL,
 CONSTRAINT [PK_dienthoai_new] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dienthoai_new] DISABLE CHANGE_TRACKING
GO
CREATE NONCLUSTERED INDEX [index_quan] ON [dbo].[dienthoai_new] 
(
	[quan_huyen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [index_tinh] ON [dbo].[dienthoai_new] 
(
	[tinh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[dienthoai_new] ON
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (1, N'Nguyá»…n VÄƒn LÃ¢m', N'01636955831 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (2, N'HoÃ nh Thá»‹ SÆ°Æ¡ng', N'01636955863 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (3, N'Nguyá»…n Minh HÃ¹ng', N'01636955970 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (4, N'Nguyen Huu Phuoc', N'01636956022 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (5, NULL, N'01636956269 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (6, N'Tráº§n Kiá»u Trang', N'01636956332 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (7, N'SÆ¡n Hiá»‡p TÃ´ NÃ­c', N'01636956364 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (8, N'NgÃ´ Tuáº¥n Vá»¹', N'01636956619 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (9, N'Nguyen Huu Khoa', N'01636956629 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (10, N'Nguyen Ngoc Thuy', N'01636956660 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (11, N'Nguyen Huynh Trang', N'01636956747 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (12, N'ÄoÃ n Báº¯c ThÃ¡i', N'01636956838 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (13, N'Pháº¡m ThÃ nh Thá»›i', N'01636956878 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (14, N'Nguyen Van Ly', N'01636957117 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (15, N'Nguyen Quoc Thai', N'01636957152 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (16, N'Nguyen Nhu Huynh', N'01636957453 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (17, N'Nguyen Huynh Bao', N'01636957747 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (18, N'DÆ°Æ¡ng ThÃ nh DÅ©ng', N'01636957857 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (19, N'Nguyá»…n Kim Loan', N'01636957858 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (20, N'Tráº§n Ngá»c Háº±ng', N'01636958001 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (21, N'Äáº·ng VÄƒn DÅ©ng', N'01636958039 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (22, N'Huá»³nh VÄƒn TÃ i', N'01636958151 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (23, N'Nguyen Thi Cam Tien', N'01636958358 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (24, N'Nguyen Kim Hong', N'01636958380 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (25, N'Le Van Lam', N'01636958557 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (26, N'Le Van My', N'01636958797 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (27, N'Nguyá»…n Ngá»c Sang', N'01636959008 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (28, N'NgÃ´ Thá»‹ Kiá»u', N'01636959266 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (29, N'LÃª VÄƒn NÄƒm', N'01636959349 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (30, N'Nguyá»…n VÄƒn D', N'01636959369 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (31, N'ÄoÃ n Thá»‹ Thu Trang', N'01636959379 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (32, N'LÃª VÄƒn NÄƒm', N'01636959389 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (33, N'Tá»« VÄƒn TÃ¡m', N'01636959699 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (34, N'LÃª VÄƒn TÃ¡m`', N'01636959709 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (35, N'LÃª VÄƒn TÃ¡m`', N'01636959749 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (36, N'Nguyá»…n VÄƒn Quáº­n', N'01636959769 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (37, N'Chi Lan', N'01636959797 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (38, N'Le Phuong Lien', N'01636960119 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (39, NULL, N'01636960209 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (40, N'Nguyn Phong', N'01636960219 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (41, N'Phan Thi Minh Chau', N'01636960595 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (42, N'Cao Kim Anh', N'01636960639 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (43, N'Nguyen Thi Mong Tuyennguyen Tan Trieu', N'01636960877 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (44, N'Nguyen Thanh Vu', N'01636960949 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (45, N'Nguyá»…n Thanh Tuáº¥n', N'01636960989 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (46, N'Äáº·ng Thá»‹ Mai', N'01636961114 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (47, N'Nguyen Cong Nhat', N'01636961149 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (48, NULL, N'01636961378 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (49, N'Minh KhuÃª', N'01636961415 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (50, N'VÅ© Ngá»c Äáº¡t', N'01636961439 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (51, N'Tráº§n VÄƒn Song ToÃ n', N'01636961494 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (52, N'Äáº·ng Cáº©m DuyÃªn', N'01636961714 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (53, NULL, N'01636961818 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (54, N'ChÃ¢u HoÃ ng Vinh', N'01636961838 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (55, N'Pháº¡m Há»“ng ÄÃ¢y', N'01636961971 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (56, N'Quach Trung Tam', N'01636962008 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (57, NULL, N'01636962069 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (58, N'Pháº¡m Há»“ng LÄ©nh', N'01636962108 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (59, N'TÃ´ VÄƒn Äiá»n', N'01636962124 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (60, N'LÃ½ Thá»‹ Tá»‘ TÃ¢m', N'01636962325 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (61, N'Äá»— Cáº©m NgÃ¢n', N'01636962328 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (62, N'Nguyá»…n VÄƒn Hai', N'01636962419 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (63, N'Nguyen Thanh Long', N'01636962459 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (64, N'Nguyá»…n VÄƒn Trung', N'01636962619 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (65, N'Thach Thi Sa Phanl', N'01636962869 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (66, N'Äáº·ng Thá»‹ Diá»‡u Loan', N'01636962877 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (67, N'Pho Hoang Long', N'01636962984 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (68, N'Phan Ngá»c Duy', N'01636963037 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (69, N'HoÃ ng Äá»©c DÅ©ng', N'01636963135 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (70, N'SÆ¡n Thá»‹ Kim Phá»¥ng', N'01636963177 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (71, N'Pham Hoang Khai', N'01636963259 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (72, N'Há»“ Ngá»c ChÆ°Æ¡ng', N'01636963295 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (73, NULL, N'01636963419 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (74, N'Thach Thi Sa Phanl', N'01636963469 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (75, N'LÃª An TÃ¢m', N'01636963471 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (76, N'Äáº·ng Thá»‹ Nga', N'01636963485 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (77, N'Tráº§n Äá»©c Tháº£o', N'01636963532 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (78, N'Nguyá»…n VÄƒn Kim', N'01636963572 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (79, NULL, N'01636963659 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (80, N'Duong Van My', N'01636963909 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (81, N'Tráº§n NgÃ´ Báº£o', N'01636963929 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (82, N'Nguyen Thanh Tan', N'01636963997 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (83, NULL, N'01636964142 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (84, N'Ngo Van An', N'01636964244 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (85, N'Nguyá»…n Minh HÃ¹ng', N'01636964356 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (86, N'Nguyen Hoang Sang', N'01636964729 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (87, N'Tran Van Ut', N'01636964776 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (88, N'Duongthi Mong Linh', N'01636964797 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (89, N'Pháº¡m Thá»‹ Thu Yáº¿n', N'01636964913 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (90, NULL, N'01636965015 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (91, N'Há»“ Thá»‹ Báº¡ch TrÃ', N'01636965021 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (92, N'Nguyá»…n VÄƒn ChÃ¡nh', N'01636965029 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (93, N'Nguyá»…n VÄƒn NhÃ£', N'01636965054 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (94, N'Nguyá»…n VÄƒn Trung', N'01636965109 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (95, N'Tran Thanh Hao', N'01636965149 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (96, N'VÅ© Thá»‹ TrÃºc Quá»³nh', N'01636965230 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (97, N'Thach Thi Sa Phanl', N'01636965269 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (98, N'Dáº¡ HÆ°Æ¡ng', N'01636965373 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (99, N'Nguyá»…n Kim Xuyáº¿n', N'01636966322 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[dienthoai_new] ([id], [ten_khach_hang], [didong], [dia_chi], [namsinh], [ngay], [thang], [cuoc], [gioi_tinh], [ngan_hang], [sim], [tinh], [tinh_cuoc], [ghi_chu], [filenguon], [creatdate], [ngay_kich_hoat], [cong_ty], [chuc_vu], [he_dieu_hanh], [goi_cuoc], [email], [phuong], [quan_huyen], [dong_may]) VALUES (100, N'Nguyen Ngoc Ky', N'01636966500 ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A80000AAEA41 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
print 'Processed 100 total records'
SET IDENTITY_INSERT [dbo].[dienthoai_new] OFF
/****** Object:  Table [dbo].[dienthoai_goc]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dienthoai_goc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten_khach_hang] [nvarchar](300) NULL,
	[didong] [nchar](12) NULL,
	[dia_chi] [nvarchar](600) NULL,
	[namsinh] [nvarchar](100) NULL,
	[ngay] [nvarchar](100) NULL,
	[thang] [nvarchar](100) NULL,
	[cuoc] [nvarchar](100) NULL,
	[tinh_cuoc] [nvarchar](100) NULL,
	[gioi_tinh] [nvarchar](100) NULL,
	[ngan_hang] [nvarchar](100) NULL,
	[sim] [nvarchar](100) NULL,
	[tinh] [nvarchar](100) NULL,
	[ghi_chu] [nvarchar](300) NULL,
	[filenguon] [nvarchar](300) NULL,
	[creatdate] [datetime] NULL,
	[phuong] [nvarchar](100) NULL,
	[quan_huyen] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[ngay_kich_hoat] [nvarchar](100) NULL,
	[cong_ty] [nvarchar](300) NULL,
	[chuc_vu] [nvarchar](100) NULL,
	[he_dieu_hanh] [nvarchar](600) NULL,
	[goi_cuoc] [nvarchar](100) NULL,
	[dong_may] [nvarchar](600) NULL,
 CONSTRAINT [PK_dienthoai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dienthoai_goc] DISABLE CHANGE_TRACKING
GO
/****** Object:  StoredProcedure [dbo].[spExport]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
--[spExportHoSoCongTy] 
create PROCEDURE [dbo].[spExport]
	@sqlcommand varchar(8000) = null,
	@path varchar(300)
AS
BEGIN
	DECLARE @sql varchar(8000);
	SELECT @sql = 'bcp "'+@sqlcommand+'" queryout "'+@path  + '" -w -t"\t" -T -S' + @@SERVERNAME 

	print @sql
	exec master..xp_cmdshell @sql;	
	
	
end
GO
/****** Object:  StoredProcedure [dbo].[spLoadData]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLoadData]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SELECT TABLE_NAME as TABLE_NAME_OLD,TABLE_NAME
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_TYPE = 'BASE TABLE'   and TABLE_NAME not in('dienthoai_goc','dienthoai_new')
	order by TABLE_NAME desc
	
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdate_dienthoai_goc]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[spLoadSoDienThoai] '3',1,100
create PROCEDURE [dbo].[spUpdate_dienthoai_goc] 
@Id int,
@didong nchar(12),
@ten_khach_hang nvarchar(50),
@dia_chi nvarchar(500),
@namsinh nchar(50), 
@cuoc nvarchar(50), 
@gioi_tinh bit, 
@ngan_hang nvarchar(50), 
@sim nchar(10), @tinh nvarchar(50), @ghi_chu nvarchar(400)
AS
BEGIN
	update 	 dbo.dienthoai_goc
	set ten_khach_hang=@ten_khach_hang,
		dia_chi=@dia_chi,
		namsinh=@namsinh,
		cuoc=@cuoc,
		gioi_tinh=@gioi_tinh,
		ngan_hang=@ngan_hang,
		sim =@sim,
		tinh=@tinh,
		ghi_chu=@ghi_chu
	where id=@Id
	

	
end
GO
/****** Object:  StoredProcedure [dbo].[spKhoiPhuc]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--delete from dienthoai_goc
--[spKhoiPhuc] 'dienthoai_goc20151201153702'


CREATE PROCEDURE [dbo].[spKhoiPhuc]
@tenban varchar(27)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	declare @tenbang nvarchar(30);
	declare @Chuoisql nvarchar(500);
	
	delete from dienthoai_goc
	DBCC CHECKIDENT ('[dienthoai_goc]', RESEED, 0)
	
	
					  
	set @Chuoisql = N'insert into dienthoai_goc (  ten_khach_hang, didong, dia_chi, namsinh, ngay, thang, cuoc, tinh_cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu, filenguon, creatdate, phuong, quan_huyen, email, ngay_kich_hoat, dong_may, cong_ty, chuc_vu, he_dieu_hanh, goi_cuoc) 
					 select ten_khach_hang, didong, dia_chi, namsinh, ngay, thang, cuoc, tinh_cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu, filenguon, creatdate, phuong, quan_huyen, email, ngay_kich_hoat, dong_may, cong_ty, chuc_vu, he_dieu_hanh, goi_cuoc  from ['+@tenban+']'
					  
	print @Chuoisql
	EXECUTE sp_executesql @Chuoisql
	 
end
GO
/****** Object:  StoredProcedure [dbo].[spInsert]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsert]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
		   
	select a.ten_khach_hang, a.didong, a.dia_chi, a.namsinh, a.ngay, a.thang, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh, a.tinh_cuoc, a.ghi_chu, a.filenguon, a.creatdate, a.phuong, a.quan_huyen, a.email, a.ngay_kich_hoat, a.goi_cuoc, a.dong_may, a.he_dieu_hanh, a.chuc_vu, a.cong_ty, 
	--solan=(select COUNT(*) from dienthoai_new c where c.didong=a.didong)
	solan=0 --03/05/2016
	into #temp
	from dienthoai_new a left join dienthoai_goc b on a.didong=b.didong
	where b.didong is null
	
	--tìm so lieu trung
	select didong, count(*) as solan into #trung
	from #temp
	group by didong
	
	---cap nhat lai #temp
	update #temp
	set solan =b.solan
	from #temp a inner join #trung b on a.didong=b.didong
		
	insert into dienthoai_goc( ten_khach_hang, didong, dia_chi, namsinh, ngay, thang, cuoc, tinh_cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu, filenguon, creatdate, phuong, quan_huyen, email, ngay_kich_hoat, dong_may, cong_ty, chuc_vu, he_dieu_hanh, goi_cuoc)
	select  ten_khach_hang, didong, dia_chi, namsinh, ngay, thang, cuoc, tinh_cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu, filenguon, creatdate, phuong, quan_huyen, email, ngay_kich_hoat, dong_may, cong_ty, chuc_vu, he_dieu_hanh, goi_cuoc
	from #temp
	where solan=1
	
	--select didong into #t from dienthoai_new group by didong
	--select COUNT(*) from #t
	
	select a.didong into #temp1
	from dienthoai_new a left join dienthoai_goc b on a.didong=b.didong
	where b.didong is null
	group by a.didong
	
	select COUNT(*) solan from #temp1
		
end
GO
/****** Object:  StoredProcedure [dbo].[spDelTam]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spDelTam]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	
	delete from dienthoai_new
	DBCC CHECKIDENT ('[dienthoai_new]', RESEED, 0)
	
end
GO
/****** Object:  StoredProcedure [dbo].[spDelGoc]    Script Date: 10/02/2017 11:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDelGoc]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	/*
	declare @tenbang nvarchar(30);
	declare @Chuoisql nvarchar(150);
	
	set @tenbang = N'dienthoai_goc'+ REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(19), CONVERT(DATETIME, getdate(), 112), 126), '-', ''), 'T', ''), ':', '') 
	declare @part varchar(20)
	while  EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tenbang)
	begin
		set @tenbang = N'dienthoai_goc'+ REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(19), CONVERT(DATETIME, getdate(), 112), 126), '-', ''), 'T', ''), ':', '') 
	end
	set @Chuoisql = N'select * into ' + @tenbang +' from dbo.dienthoai_goc'
	EXECUTE sp_executesql @Chuoisql

	delete from dbo.dienthoai_goc
	delete from dbo.dienthoai_new
	
	 */
	 
	delete from dienthoai_goc
	DBCC CHECKIDENT ('[dienthoai_goc]', RESEED, 0)
	
	delete from dienthoai_new
	DBCC CHECKIDENT ('[dienthoai_new]', RESEED, 0)
	
end
GO
/****** Object:  Default [DF_dienthoai_new_creatdate]    Script Date: 10/02/2017 11:01:57 ******/
ALTER TABLE [dbo].[dienthoai_new] ADD  CONSTRAINT [DF_dienthoai_new_creatdate]  DEFAULT (getdate()) FOR [creatdate]
GO
/****** Object:  Default [DF_dienthoai_creatdate]    Script Date: 10/02/2017 11:01:57 ******/
ALTER TABLE [dbo].[dienthoai_goc] ADD  CONSTRAINT [DF_dienthoai_creatdate]  DEFAULT (getdate()) FOR [creatdate]
GO
