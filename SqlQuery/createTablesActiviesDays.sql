USE activityDb;
CREATE TABLE IF NOT EXISTS activiesDays(
    id INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    startTime TIME,
    endTime TIME,
    description TEXT,
    dayOfWeek INT(1) DEFAULT 1,
	ModelPersonFamilyId INT(1) DEFAULT 1,
	ModelPictureActivityId INT(10) DEFAULT 1,
	createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT dayOfWeek_Ck CHECK (dayOfWeek IN (0,1,2,3,4,5,6,7))
);