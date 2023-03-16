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
		SELECT U.Id, U.Name, U.Email, U.Password, U.Guest, R.Id AS RoleId, R.Label AS RoleLabel, A.Id AS AllergieId, A.Label AS AllergieLabel
		FROM Users U
		LEFT JOIN Roles R ON R.Id = U.RoleId
		LEFT JOIN Users_Allergies UA ON UA.UserId = U.Id
		LEFT JOIN Allergies A ON A.Id = UA.AllergieId
		WHERE U.Email = @Email AND U.Password = @Password;
	END