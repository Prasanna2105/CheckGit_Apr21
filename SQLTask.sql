use pubs
-----1--------------------------------------------------------------------------------------------------------------------------------------------------

select city, count(au_fname) No_of_authors from authors group by city

-----2------------------------------------------------------------------------------------------------------------------------------------------------

select concat(au_fname,au_lname) Name_of_the_authors from authors where city not in
(select city from publishers where pub_name = 'New Moon Books');

-----3-------------------------------------------------------------------------------------------------------------------------------------------
create proc proc_Updatetheprice(@au_fname varchar(20),@au_lname varchar(20),@newprice float)
as
begin
	--select * from authors
	--select * from titleauthor
	--select * from titles
	update titles
	set  price = @newprice where title_id in
	(select title_id from titleauthor where au_id in
	(select au_id from authors where au_fname = @au_fname and au_lname = @au_lname));
end

exec proc_Updatetheprice 'Ann', 'Dull',25.00


------------4---------------------------------------------------------------------------------------------------------------------------------------------------------

create function fn_CalculateTax(@qty int)
returns float
as
begin				--select * from sales
	declare
	@tax float
	if(@qty<10)
		set @tax=2
	else if(@qty>=10 and @qty<20)
		set @tax=5
	else if(@qty>=20 and @qty<30)
		set @tax=6
	else
		set @tax=7.5   
	return @tax
end

select title_id, qty,dbo.fn_CalculateTax(qty) Tax from sales


