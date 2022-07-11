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
	  [標籤代碼] as Assts_no
      ,[資產編號] as Assts_id
      ,[資產名稱] as Assts_name
      ,[設備序號] as Assts_eq_id
      ,[管制資產名稱] as Assts_eq_name
      ,[數量] as Assts_Quantity
      ,[客戶] as Assts_Customer
      ,isnull((Select place_sn from Place Where [Place_name_forAssets] = [Sheet1].[線別]),0) as place_sn
      ,[儲位代碼] as Place_Assets_sn
      ,isnull([關聯儲位],0) as Place_Assets_Detail_sn
      ,isnull((Select User_sn from [User] Where [User_name] = [Sheet1].[操作人員]),0) as LastUser_sn
      --,isnull([操作時間],'1911-1-1') as LastChange_date 
      ,('2015/1/1 01:01:01') as LastChange_date
      ,[一般說明] as Note
      ,[管理人員說明] as SysNote
      ,[測試站功能] as Assts_Station
      ,isnull([站體數量],0) as Assts_Station_num
      ,1
  FROM [PE2].[dbo].[Sheet1]
  Where [儲位代碼] is not null
  
  
  
    
  update 資產明細 set [關聯儲位] = 0
  from 資產明細 
  where [關聯儲位] = 'ENG'

