/****** SSMS 中 SelectTopNRows 命令的指令碼  ******/
INSERT  [OutFixture]
(
	   [Fixture_sn]
      ,[User_sn]
      ,[Place_sn]
      ,[Note]
      ,[Create_date]
      ,[Out_date]
      ,[Valid]
      ,[OutStatus]
)
SELECT 
       [Fixture_sn] as [Fixture_sn]
      ,(Select User_sn from [User] Where [User_name] in (SELECT Replace([攜出人員_(無須輸入)],' ','') FROM 治具總表 WHERE [新治具產編_(手動)] = [Fixture_no])) as [User_sn]
      ,0  as [Place_sn]
      ,(SELECT Replace([攜出備註_(借用單位)(無須輸入)],' ','') FROM 治具總表 WHERE [新治具產編_(手動)] = [Fixture_no]) as [Note]
      ,getdate() as [Create_date]
      ,(SELECT [攜出時間_(無須輸入)] FROM 治具總表 WHERE [新治具產編_(手動)] = [Fixture_no]) as [Out_date]
      ,1  as [Valid]
      ,1  as [OutStatus]
     
  FROM [PE2].[dbo].[Fixture]
  Where [Status] = 0
  
  
  
  update Fixture set LastOut_sn = OutFixture.Out_sn
  from OutFixture 
  where OutFixture.Fixture_sn=Fixture.Fixture_sn