CREATE PROCEDURE spSaveMessage
    (
      @Id INT ,
      @UserId INT ,
      @UserName NVARCHAR(20) , 
      @Context NVARCHAR(200) , 
      @CreatDate DateTime
    )
AS
    BEGIN      
        UPDATE  "Message"
        SET     UserId = @UserId ,
                UserName = @UserName ,
                Context = @Context ,
                CreatDate = getdate()
        WHERE   Id = @Id; 
    END; 
GO