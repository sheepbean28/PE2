/****** SSMS 中 SelectTopNRows 命令的指令碼  ******/
INSERT INTO Calibrate 
       ([Eq_id]
      ,[Eq_no]
      ,[Eq_name]
      ,[Eq_factory]
      ,[Eq_factory_no]
      ,[Eq_Assets_no]
      ,[Cp_Date_Range]
      ,[Last_Cp_Date]
      ,[Next_Cp_Date]
      ,[Cp_Place]
      ,[Cp_Type]
      ,[Cp_Note]
      ,[Cp_Note1])
SELECT TOP 1000 [儀器編號]
      ,[儀器代碼]
      ,[儀器名稱]
      ,[廠牌]
      ,[型號]
      ,[資產編號]
      ,[校正週期]
      ,[上次            校正日期]
      ,[下次            校正預定]
      ,[校正地點]
      ,[校正別]
      ,[狀態]
      ,[備註]
  FROM [PE2].[dbo].[儀器設備總表$]
  
  
  update Calibrate set cp_type = replace(cp_type,'內校','0')
update Calibrate set cp_type = replace(cp_type,'外校','1')
update Calibrate set cp_type = replace(cp_type,'免校','2')


update calibrate set [Cp_Date_Range] = replace([Cp_Date_Range],'6個月','6')
update calibrate set [Cp_Date_Range] = replace([Cp_Date_Range],'1年','12')
update calibrate set [Cp_Date_Range] = replace([Cp_Date_Range],'2年','24')