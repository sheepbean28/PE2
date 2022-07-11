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
           ,[Place_Assets_sn] = A.[儲位代碼]
           ,[Place_Assets_Detail_sn] = isnull(A.[關聯儲位],0)
           ,[LastUser_sn] = isnull((Select User_sn from [User] Where [User_name] = A.[操作人員]),0)
           ,[LastChange_date]= GETDATE()
           ,[Note]= A.[一般說明]
           ,[SysNote]= A.[管理人員說明]
           ,[Assts_Station]= A.[測試站功能]
           ,[Assts_Station_num]= isnull(A.[站體數量],0)
           ,[Assts_Sttatus]= 1
 
FROM [PE2].[dbo].[資產明細] as A
where [Assts_no] = A.[標籤代碼] 




		
           
    