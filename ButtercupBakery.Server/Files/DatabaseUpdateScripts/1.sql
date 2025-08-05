BEGIN TRANSACTION;

INSERT INTO [CATEGORY] ([Name]) VALUES ('Breakfast'),('Lunch'),('Dinner'),('Bread'),('Desserts');

INSERT INTO [Version] ([Version]) VALUES (1);
COMMIT TRANSACTION;