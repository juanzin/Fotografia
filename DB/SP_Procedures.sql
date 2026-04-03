USE photography;
GO

---get all photos
CREATE OR ALTER PROCEDURE Get_All_Photos
AS
BEGIN
	SELECT * FROM Photos;
END
GO

--get all categories
CREATE OR ALTER PROCEDURE Get_All_Categories
AS 
BEGIN
	SELECT * FROM Categories;
END
GO

--get photographer information
CREATE OR ALTER PROCEDURE Get_Photographer_info_for_about
	@Id INT
AS 
BEGIN
	SELECT Name, Biography, Instagram, Facebook FROM Photographers WHERE Id = @Id;
END
GO

--add a new photographer
CREATE OR ALTER PROCEDURE SP_Insert_Photographer
	@Name VARCHAR(100),
	@Materno VARCHAR(100),
	@Paterno VARCHAR(100),	
	@Username VARCHAR(100),
	@UrlFoto VARCHAR(150),
	@Password VARCHAR(100),
	@Instagram  VARCHAR(200),
	@Facebook VARCHAR(200),
	@Email VARCHAR(200),
	@Biography VARCHAR(200),
	@TypeUser INT
AS
BEGIN
	INSERT INTO Photographers(Name, Materno, Paterno, Username, UrlFoto,Password,Instagram, Facebook, Email, Biography, Type_User)
	VALUES(@Name, @Materno, @Paterno, @Username, @UrlFoto, @Password, @Instagram, @Facebook, @Email, @Biography, @TypeUser)
END 
GO

---update a photographer
CREATE OR ALTER PROCEDURE SP_Update_Photographer
	@Id INT,
	@Username VARCHAR(100),
	@Password VARCHAR(100),
	@Instagram  VARCHAR(200),
	@Facebook VARCHAR(200),
	@Email VARCHAR(200),
	@Biography VARCHAR(200),
	@UrlFoto VARCHAR(150)
AS
BEGIN
	UPDATE Photographers
	SET
		Username = @Username,
		Password = @Password,
		Instagram = @Instagram,
		Facebook = @Facebook,
		Email = @Email,
		Biography = @Biography,
		UrlFoto = @UrlFoto
	WHERE Id = @Id;
END 
GO

CREATE OR ALTER PROCEDURE SP_Insert_Photo
@Title VARCHAR(100),
@Description VARCHAR(200),
@DateCreation DATETIME,
@PhotographerId INT,
@UrlPhoto VARCHAR(150),
@CategoryId INT
AS
BEGIN
	INSERT INTO Photos(Title, Description, Created_date, Photographer_Id, Url_Photo, Category_Id)
	VALUES(@Title, @Description, @DateCreation, @PhotographerId, @UrlPhoto, @CategoryId)
END
GO

CREATE OR ALTER PROCEDURE SP_Update_Photo
@Id INT,
@Title VARCHAR(100),
@Description VARCHAR(200),
@DateCreation DATETIME,
@PhotographerId INT,
@UrlPhoto VARCHAR(150),
@CategoryId INT
AS
BEGIN
	UPDATE Photos
	SET Title = @Title,
	Description = @Description,
	Created_date = @DateCreation,
	Photographer_Id = @PhotographerId,
	Url_Photo = @UrlPhoto,
	Category_Id = @CategoryId
	WHERE Id = @Id
END
GO


---- EXECUTIONS ---
--getters
EXEC Get_All_Photos;
EXEC Get_All_Categories;
EXEC Get_Photographer_info_for_about 1;

--setters
EXEC SP_Insert_Photographer 'Irving', 'Lopez', 'Martinez','Irving','https://www.myprofile.com', 'memelas', 'https://www.instagram.com/kualtzin_photo/', 'https://www.facebook.com/', 'irvg@hotmail.com', 'soy chido', 1;

EXEC SP_Insert_Photo 'animal',' new description', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/animal.png', 3;
EXEC SP_Insert_Photo 'landing','new decription', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/landing.png', 4;
EXEC SP_Insert_Photo 'mexico',' new description', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/mexico.png', 4;
EXEC SP_Insert_Photo 'nature','new decription', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/nature.png', 1;
EXEC SP_Insert_Photo 'portrait',' new description', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/portrait.png', 2;
EXEC SP_Insert_Photo 'profile','new decription', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/profile.png', 2;
EXEC SP_Insert_Photo 'snapshot',' new description', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/snapshot.png', 5;
EXEC SP_Insert_Photo 'unfreezing','new decription', '2026-03-30 14:30:00', 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/unfreezing.png', 6;
--deletes


--updates
EXEC SP_Update_Photographer 1, 'Mexican', 'montania', 'https://www.instagram.com/kualtzin_photo/', 'https://www.facebook.com/', 'irvg@hotmail.com', 'soy buen fotografo', 'https://www.myprofile.com';
EXEC SP_Update_Photo 1, 'new title','new decription', DATETIME, 1, 'https://juanzin-photos-mx.s3.us-east-1.amazonaws.com/animal.png', 1;