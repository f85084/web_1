CREATE PROCEDURE spAddMessage
    (
      @UserId INT ,
      @UserName NVARCHAR(20) , 
      @Context NVARCHAR(200) , 
      @CreatDate DateTime
    )
AS
    BEGIN  
--	ALTER TABLE [Message]
--ADD FOREIGN KEY (UserId)
--REFERENCES [User](Id)
        INSERT  INTO [Message]
        VALUES  ( @UserId, @UserName, @Context, getdate() );  
    END;
GO
