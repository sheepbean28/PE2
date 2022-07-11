INSERT INTO [PE2].[dbo].[Fixture]
           ([Fixture_no]
           ,[Fixture_car]
           ,[Fixture_car1]
           ,[Fixture_car2]
           ,[Fixture_name]
           ,[Fixture_usefor]
           ,[Fixture_no_old]
           ,[Fixture_lic_old]
           ,[Fixture_sn_old]
           ,[Status]
           ,[Quantity]
           ,[LastOut_sn]
           ,[LastOut_date]
           ,[Create_date]
           ,[Limit_date]
           ,[Note])
   select 
   
		[新治具產編_(手動)]
      ,[治具位置_(無須輸入)]
      ,[台車_編號_(手動)]
      ,[台  車_流水號_(手動)]
      ,[治具名稱_(手動)]
      ,[治具用途_(手動)]
      ,[舊 產 編_(無需輸入)]
      ,[舊治具產編_(手動)]
      ,[舊產編_流水號_(手動)]
      ,[庫存_(無須輸入)]
      ,[入 庫_(手動)]
      ,0
      ,null
      ,[收到日期_(手動)]
      ,[使用年限_(無須輸入)]
      ,[管理備註(手動)_(正常、報廢、送修)]
      
      FROM 工作表
   Where [新治具產編_(手動)] is not null
   
   
   
   
   
   
   
   
   
   
   
   
   
