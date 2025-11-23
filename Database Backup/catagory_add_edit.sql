create PROCEDURE [dbo].[Add_Catagory]
	
	
	@id int,
	@name nvarchar(200),
	@active bit
	
	AS
--BEGIN
	declare @temp int
	if exists (select id from Catagory where  id=@id) 
	begin
     update Catagory set name=@name,active=@active
		  where id=@id
     set @temp=1;
    end
    else
    begin
	 SET NOCOUNT ON 
		 INSERT INTO Catagory
	                      (name,active)
	VALUES     (@name,@active)
	set @temp=1
     end
	return @temp
