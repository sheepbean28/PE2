SELECT     (SELECT     Assts_no
                       FROM          dbo.Assets
                       WHERE      (Assts_no = SUBSTRING(dbo.隔離箱.編號, LEN(dbo.隔離箱.編號) - 4, LEN(dbo.隔離箱.編號)))) AS aa, SUBSTRING(編號, LEN(編號) - 4, LEN(編號)) AS Expr1, 
                      量測日期, 到期日期, 編號, 位置, 類別, 型式, [2G開啟], [2G關閉], [2G隔離度], [5G開啟], [5G關閉], [5G隔離度], 漏電流測量值, 漏電流單位, 備註
FROM         dbo.隔離箱