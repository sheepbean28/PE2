--修改現有資料
update [PE2].[dbo].[Assets] 
set 
			[Assts_no] = A.[標籤代碼]
           ,[Assts_id] = A.[資產編號]
           ,[Assts_name] = A.[資產名稱]
           ,[Assts_eq_id] = A.[設備序號]
           ,[Assts_eq_name] = A.[管制資產名稱]
           ,[Assts_Quantity] = A.[數量]
           ,[Assts_Customer] = A.[客戶]
           ,[Place_sn] = isnull((Select place_sn from Place Where [Place_name_forAssets] =  A.[線別]),0)
           ,[Place_Assets_sn] = isnull(A.[儲位代碼],0)
           ,[Place_Assets_Detail_sn] = isnull(A.[關聯儲位],0)
           ,[LastUser_sn] = isnull((Select User_sn from [User] Where [User_name] = A.[操作人員]),0)
           ,[LastChange_date]= isnull(A.[操作時間],GETDATE())
           ,[Note]= A.[一般說明]
           ,[SysNote]= A.[管理人員說明]
           ,[Assts_Station]= A.[測試站功能]
           ,[Assts_Station_num]= isnull(A.[站體數量],0)
           ,[Assts_Sttatus]= 1
 
FROM [PE2].[dbo].AssetInLog as A
where [Assts_no] = A.[標籤代碼]  AND A.[Last] = 1
--新增未使用資料
INSERT INTO [PE2].[dbo].[Assets] 
			([Assts_no]
           ,[Assts_id]
           ,[Assts_name]
           ,[Assts_eq_id]
           ,[Assts_eq_name]
           ,[Assts_Quantity]
           ,[Assts_Customer]
           ,[Place_sn]
           ,[Place_Assets_sn]
           ,[Place_Assets_Detail_sn]
           ,[LastUser_sn]
           ,[LastChange_date]
           ,[Note]
           ,[SysNote]
           ,[Assts_Station]
           ,[Assts_Station_num]
           ,[Assts_Sttatus])
SELECT 

		[Assts_no] = A.[標籤代碼]
           ,[Assts_id] = A.[資產編號]
           ,[Assts_name] = A.[資產名稱]
           ,[Assts_eq_id] = A.[設備序號]
           ,[Assts_eq_name] = A.[管制資產名稱]
           ,[Assts_Quantity] = A.[數量]
           ,[Assts_Customer] = A.[客戶]
           ,[Place_sn] = isnull((Select place_sn from Place Where [Place_name_forAssets] =  A.[線別]),0)
           ,[Place_Assets_sn] =  isnull(A.[儲位代碼],0)
           ,[Place_Assets_Detail_sn] = isnull(A.[關聯儲位],0)
           ,[LastUser_sn] = isnull((Select User_sn from [User] Where [User_name] = A.[操作人員]),0)
           ,[LastChange_date]= isnull(A.[操作時間],GETDATE())
           ,[Note]= A.[一般說明]
           ,[SysNote]= A.[管理人員說明]
           ,[Assts_Station]= A.[測試站功能]
           ,[Assts_Station_num]= isnull(A.[站體數量],0)
           ,[Assts_Sttatus]= 1
 
FROM [PE2].[dbo].AssetInLog as A WHERE 
A.[Last] = 1 
And not exists(select * from [Assets] where [Assets].[Assts_no]= A.[標籤代碼])

Update [PE2].[dbo].[AssetInLog] set[Last] = 0


----/****** SSMS 中 SelectTopNRows 命令的指令碼  ******/
----Update [PE2].[dbo].[AssetInLog] set[Last] = 0



		
           
    