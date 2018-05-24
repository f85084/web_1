USE [web] 
GO 

SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
ALTER PROCEDURE [dbo].[spGetMessage] 
AS 
    BEGIN 
        SELECT  * 
        FROM    "Message"; 
    END; 