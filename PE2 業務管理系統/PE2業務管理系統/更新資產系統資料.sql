--�ק�{�����
update [PE2].[dbo].[Assets] 
set 
			[Assts_no] = A.[���ҥN�X]
           ,[Assts_id] = A.[�겣�s��]
           ,[Assts_name] = A.[�겣�W��]
           ,[Assts_eq_id] = A.[�]�ƧǸ�]
           ,[Assts_eq_name] = A.[�ި�겣�W��]
           ,[Assts_Quantity] = A.[�ƶq]
           ,[Assts_Customer] = A.[�Ȥ�]
           ,[Place_sn] = isnull((Select place_sn from Place Where [Place_name_forAssets] =  A.[�u�O]),0)
           ,[Place_Assets_sn] = isnull(A.[�x��N�X],0)
           ,[Place_Assets_Detail_sn] = isnull(A.[���p�x��],0)
           ,[LastUser_sn] = isnull((Select User_sn from [User] Where [User_name] = A.[�ާ@�H��]),0)
           ,[LastChange_date]= isnull(A.[�ާ@�ɶ�],GETDATE())
           ,[Note]= A.[�@�뻡��]
           ,[SysNote]= A.[�޲z�H������]
           ,[Assts_Station]= A.[���կ��\��]
           ,[Assts_Station_num]= isnull(A.[����ƶq],0)
           ,[Assts_Sttatus]= 1
 
FROM [PE2].[dbo].AssetInLog as A
where [Assts_no] = A.[���ҥN�X]  AND A.[Last] = 1
--�s�W���ϥθ��
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

		[Assts_no] = A.[���ҥN�X]
           ,[Assts_id] = A.[�겣�s��]
           ,[Assts_name] = A.[�겣�W��]
           ,[Assts_eq_id] = A.[�]�ƧǸ�]
           ,[Assts_eq_name] = A.[�ި�겣�W��]
           ,[Assts_Quantity] = A.[�ƶq]
           ,[Assts_Customer] = A.[�Ȥ�]
           ,[Place_sn] = isnull((Select place_sn from Place Where [Place_name_forAssets] =  A.[�u�O]),0)
           ,[Place_Assets_sn] =  isnull(A.[�x��N�X],0)
           ,[Place_Assets_Detail_sn] = isnull(A.[���p�x��],0)
           ,[LastUser_sn] = isnull((Select User_sn from [User] Where [User_name] = A.[�ާ@�H��]),0)
           ,[LastChange_date]= isnull(A.[�ާ@�ɶ�],GETDATE())
           ,[Note]= A.[�@�뻡��]
           ,[SysNote]= A.[�޲z�H������]
           ,[Assts_Station]= A.[���կ��\��]
           ,[Assts_Station_num]= isnull(A.[����ƶq],0)
           ,[Assts_Sttatus]= 1
 
FROM [PE2].[dbo].AssetInLog as A WHERE 
A.[Last] = 1 
And not exists(select * from [Assets] where [Assets].[Assts_no]= A.[���ҥN�X])

Update [PE2].[dbo].[AssetInLog] set[Last] = 0


----/****** SSMS �� SelectTopNRows �R�O�����O�X  ******/
----Update [PE2].[dbo].[AssetInLog] set[Last] = 0



		
           
    