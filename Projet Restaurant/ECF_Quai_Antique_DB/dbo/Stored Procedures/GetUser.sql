-- =============================================
-- Author:		Lapa Denis
-- Create date: 22/02/2022
-- Description:	During the connexion retrieve the user
-- =============================================
CREATE PROCEDURE [dbo].[GetUser] 
	@Email		VARCHAR(255),
	@Password	VARCHAR(MAX)
AS
	BEGIN
		SET NOCOUNT ON;
		SELECT u.Id, U.Email, U.Password, U.Guest, U.RoleId, R.Label
		FROM Users U
		LEFT JOIN Roles R ON R.Id = U.RoleId
		WHERE U.Email = @Email AND U.Password = @Password;
	END