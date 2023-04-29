USE activityDb;
CREATE TABLE IF NOT EXISTS activiesDays(
    id INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(200) NOT NULL,
    startTime TIME,
    endTime TIME,
    description TEXT,
    picture VARCHAR(200),
    dayOfWeek INT(1) DEFAULT 1,
    CONSTRAINT dayOfWeek_Ck CHECK (dayOfWeek IN (0,1,2,3,4,5,6,7)),
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);