/****** SSMS 中 SelectTopNRows 命令的指令碼  ******/

INSERT INTO [PE2].[dbo].[Supplies]
           ([Supplies_no]
           ,[Supplies_Class]
           ,[Supplies_C_No]
           ,[Supplies_Name]
           ,[Supplies_Price]
           ,[Supplies_Add]
           ,[Supplies_Out]
           ,[Supplies_In]
           ,[Supplies_R_OUT]
           ,[Supplies_R_IN]
           ,[Supplies_Stock]
           ,[Note]
           ,[User_sn]
           ,[Input_date])
 SELECT TOP 1000 
	 [F1]
      ,[F3]
      ,[F4]
      ,[F5]
      ,[F6]
      ,[F7]
      ,[耗 材 領 用]
      ,[耗 材 退 庫]
      ,[外 單 位 借 出]
      ,[外 單 位 歸 還]
      ,[F13]
      ,[F16]
      ,0
      ,getdate()
  FROM [PE2].[dbo].['耗材管制 data base$']
  Where F6 is not null