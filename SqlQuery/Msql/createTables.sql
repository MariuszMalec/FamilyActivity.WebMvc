USE testactivityDb
CREATE TABLE testactiviesDays(
    Id int identity(1,1) not null,
    StartTime TIME,
    EndTime TIME,
    Description TEXT,
    Picture VARCHAR(200),
    dayOfWeek INT DEFAULT 1,
	ModelPersonFamilyId INT DEFAULT 1,
	ModelPictureActivityId INT DEFAULT 1,
    CreatedAt time DEFAULT CURRENT_TIMESTAMP,
	constraint PK_ActiviesDays primary key (Id),
	constraint dayOfWeek_Ck CHECK (dayOfWeek IN (0,1,2,3,4,5,6,7)),
)