-- =============================================
-- Author:		Lapa Denis
-- Create date: 23/02/2023
-- Description:	Create a new User
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser] 
	@Email		VARCHAR(255), 
	@Password	VARCHAR(MAX),
	@Guest		INT,
	@RoleId		INT,
	@Allergens	AllergiesTableType READONLY
AS
	BEGIN
		SET NOCOUNT ON;
		
		--INSERT New Allergens if not exists

		INSERT INTO Allergies ([Label])
			SELECT [Label]
			FROM @Allergens A
			WHERE NOT EXISTS 
				(
					SELECT Label 
					FROM Allergies Al
					WHERE Al.[Label] = A.[Label]
				)

		--CREATE User

		IF NOT EXISTS (SELECT Id FROM Users U WHERE U.Email = @Email AND U.[Password] = @Password)
		INSERT INTO Users ([Email], [Password], [Guest], [RoleId])
		VALUES (@Email, @Password, @Guest, @RoleId)

		--CREATE User allergens related 

		INSERT INTO Users_Allergies(UserId, AllergieId)
			SELECT U.Id AS UserId, Al.Id AS AllergenId
			FROM Users AS U
			CROSS JOIN @Allergens AS A
			INNER JOIN Allergies AS Al ON Al.[Label] = A.[Label]
			WHERE @Email = U.Email 
				AND @Password = U.[Password] 
				AND @Guest = U.Guest
				AND @RoleId = U.RoleId
	END