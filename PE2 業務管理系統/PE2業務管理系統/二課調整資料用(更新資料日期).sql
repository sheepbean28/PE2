
Update [PE2].[dbo].[OutFixture] set [Out_date] = DATEADD (MONTH , 3 , [Out_date] )
Where  [Out_date] <= '2019-02-26'

SELECT * FROM [PE2].[dbo].[OutFixture]
Where  [Out_date] <= '2019-02-26'


Update [PE2].[dbo].[InFixture] set [In_date] = DATEADD (MONTH , 6 , [In_date] )
Where [In_date] <= '2019-01-26'


Update [PE2].[dbo].[Fixture] set [Limit_date] = DATEADD (MONTH , 12 , [Limit_date] )
Where [Limit_date] <= '2019-06-26'

  Update [ShieldingBox] set [Cp_date] = [Limit_date]
  Where [Limit_date] <= '2019-06-26'
  
  Update [ShieldingBox] set [Limit_date] = DATEADD (MONTH , 3 , [Limit_date] )
  Where [Limit_date] <= '2019-06-26'
      
      
