use photography;

INSERT INTO TypeUsers(Type)
VALUES('Photographer'),
('Guest')

INSERT INTO Categories(Name)
VALUES('Nature'),
('portrait'),
('animal'),
('mexico'),
('snapshots'),
('unfreezing')

INSERT INTO Photographers(Name, Materno, Paterno, Username, Password, UrlFoto, Instagram, Facebook, Email, Biography, Type_User)
VALUES('Juan', 'Onofre', 'Feliciano', 'Juanzin', 'fotitos','https://www.myprofile.com', 'https://www.instagram.com/kualtzin_photo/', 'https://www.facebook.com/', 'juan_1020305060@hotmail.com', 'soy chido', 1)

INSERT INTO Photos(Title, Description, Url_Photo, Created_date, Photographer_Id, Category_Id)
VALUES('Amanecer','mi mejor foto', 'https://www.instagram.com/p/DDq5u1CxSpH/', GETDATE(), 1, 1)