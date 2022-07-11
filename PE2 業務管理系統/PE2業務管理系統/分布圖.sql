

Select 
	[Floor]
	,(Select Count(Assets_sn) from v_Assets  as Detail Where Assts_eq_name = 'I7PC' and v_Assets.Floor = Detail.Floor ) as 'I7PC' 
		,(Select Count(Assets_sn) from v_Assets  as Detail Where Assts_eq_name = 'I5PC' and v_Assets.Floor = Detail.Floor ) as 'I5PC' 
			,(Select Count(Assets_sn) from v_Assets  as Detail Where Assts_eq_name = 'I3PC' and v_Assets.Floor = Detail.Floor ) as 'I3PC' 
	from v_Assets
Group by [Floor]
order by [Floor]