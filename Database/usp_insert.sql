CREATE PROCEDURE [dbo].[usp_insert]
(
    @FirstName VARCHAR(256),
    @Address VARCHAR(512),
    @PhoneNumber VARCHAR(12),
    @Email VARCHAR(256),
    @Age INT,
    @ContactPreference INT
)
as
begin
	set nocount on;

	insert into dbo.Registration(FirstName, Address, PhoneNumber, Email, Age, ContactPreference)
	select @FirstName, @Address, @PhoneNumber, @Email, @Age, @ContactPreference;

end
