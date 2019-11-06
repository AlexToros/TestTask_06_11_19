Create Table Article
(
ID INT Primary KEY Identity(1,1),
Title nvarchar(200),
Text nvarchar(max) 
)
Create Table Tag
(
ID INT Primary KEY Identity(1,1),
Name nvarchar(200)
)
Create Table ArticleTag
(
Article_ID int,
Tag_ID int,
Constraint [FK_ArticleTag_Article] Foreign KEY (Article_ID) References Article (ID),
Constraint [FK_ArticleTag_Tag] Foreign KEY (Tag_ID) References Tag (ID),
Constraint [PK_ArticleTag] Primary Key (Article_ID, Tag_ID)
)

SELECT 
	A.Title,
	T.Name
FROM Article A 
LEFT JOIN ArticleTag A_T on A.ID = A_T.Article_ID
JOIN Tag T on A_T.Tag_ID = T.ID