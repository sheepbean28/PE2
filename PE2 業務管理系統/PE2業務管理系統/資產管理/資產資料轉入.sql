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
	  [���ҥN�X] as Assts_no
      ,[�겣�s��] as Assts_id
      ,[�겣�W��] as Assts_name
      ,[�]�ƧǸ�] as Assts_eq_id
      ,[�ި�겣�W��] as Assts_eq_name
      ,[�ƶq] as Assts_Quantity
      ,[�Ȥ�] as Assts_Customer
      ,isnull((Select place_sn from Place Where [Place_name_forAssets] = [Sheet1].[�u�O]),0) as place_sn
      ,[�x��N�X] as Place_Assets_sn
      ,isnull([���p�x��],0) as Place_Assets_Detail_sn
      ,isnull((Select User_sn from [User] Where [User_name] = [Sheet1].[�ާ@�H��]),0) as LastUser_sn
      --,isnull([�ާ@�ɶ�],'1911-1-1') as LastChange_date 
      ,('2015/1/1 01:01:01') as LastChange_date
      ,[�@�뻡��] as Note
      ,[�޲z�H������] as SysNote
      ,[���կ��\��] as Assts_Station
      ,isnull([����ƶq],0) as Assts_Station_num
      ,1
  FROM [PE2].[dbo].[Sheet1]
  Where [�x��N�X] is not null
  
  
  
    
  update �겣���� set [���p�x��] = 0
  from �겣���� 
  where [���p�x��] = 'ENG'

