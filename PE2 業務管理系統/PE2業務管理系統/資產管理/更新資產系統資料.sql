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
           ,[Place_Assets_sn] = A.[�x��N�X]
           ,[Place_Assets_Detail_sn] = isnull(A.[���p�x��],0)
           ,[LastUser_sn] = isnull((Select User_sn from [User] Where [User_name] = A.[�ާ@�H��]),0)
           ,[LastChange_date]= GETDATE()
           ,[Note]= A.[�@�뻡��]
           ,[SysNote]= A.[�޲z�H������]
           ,[Assts_Station]= A.[���կ��\��]
           ,[Assts_Station_num]= isnull(A.[����ƶq],0)
           ,[Assts_Sttatus]= 1
 
FROM [PE2].[dbo].[�겣����] as A
where [Assts_no] = A.[���ҥN�X] 




		
           
    