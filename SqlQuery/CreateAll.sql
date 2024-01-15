drop database activityDb;
-- drop database daypilotdb;

CREATE DATABASE IF NOT EXISTS activityDb;

USE activityDb;
CREATE TABLE IF NOT EXISTS personFamilies(
    Id INT(1) NOT NULL PRIMARY KEY AUTO_INCREMENT,
	PersonName INT(1) DEFAULT 1,
    PersonPicture VARCHAR(200)
);
USE activityDb;
INSERT INTO personFamilies(PersonName,PersonPicture)
VALUES 
(1,'https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
(2,'https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
(3,'https://images.unsplash.com/photo-1516627145497-ae6968895b74?q=80&w=2040&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
(4,'https://images.unsplash.com/photo-1566004100631-35d015d6a491?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
(5,'https://images.unsplash.com/photo-1696446702183-cbd13d78e1e7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');


USE activityDb;
CREATE TABLE IF NOT EXISTS pictureActivities(
    Id INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
	ActivityName INT(1) DEFAULT 1,
    Picture VARCHAR(200)
);
USE activityDb;
INSERT INTO pictureActivities(activityName,picture)
VALUES 
(1,'https://images.unsplash.com/photo-1584622650111-993a426fbf0a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'),
(11,'https://images.unsplash.com/photo-1525278070609-779c7adb7b71?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1147&q=80'),
(19,'https://images.unsplash.com/photo-1456086272160-b28b0645b729?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1632&q=80'),
(16,'https://images.unsplash.com/photo-1522069213448-443a614da9b6?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1173&q=80'),
(20,'https://images.unsplash.com/photo-1591291621164-2c6367723315?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80'),
(15,'https://images.unsplash.com/photo-1496185106368-308ed96f204b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=921&q=80'),
(21,'https://images.unsplash.com/photo-1623249288685-835abe0123b4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80'),
(22,'https://images.unsplash.com/photo-1437943085269-6da5dd4295bf?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80'),
(23,'https://images.unsplash.com/photo-1504609813442-a8924e83f76e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80'),
(5,'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1122&q=80'),
(12,'https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80'),
(17,'https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80'),
(18,'https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80'),
(9,'https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80'),
(10,'https://images.unsplash.com/photo-1459180129673-eefb56f79b45?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80'),
(7,'https://images.unsplash.com/photo-1498940757830-82f7813bf178?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80');

USE activityDb;
CREATE TABLE IF NOT EXISTS activiesDays(
    id INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    startTime TIME,
    endTime TIME,
    description TEXT,
    dayOfWeek INT(1) DEFAULT 1,
	ModelPersonFamilyId INT(1),
	ModelPictureActivityId INT,
	createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT dayOfWeek_Ck CHECK (dayOfWeek IN (0,1,2,3,4,5,6,7)),
    FOREIGN KEY (ModelPictureActivityId) REFERENCES pictureActivities(ModelPictureActivityId)
);
USE activityDb;
INSERT INTO activiesDays(startTime,endTime,description,dayOfWeek,createdAt,modelPersonFamilyId,modelPictureActivityId)
VALUES 
('9:30:00', '17:30:00', 'Kurcze', 2, CURRENT_TIMESTAMP,1,10),
('8:00:00', '16:00:00', 'Kurcze', 3, CURRENT_TIMESTAMP,1,10),
('9:30:00', '17:30:00', 'Kurcze', 4, CURRENT_TIMESTAMP,1,10),
('8:00:00', '16:00:00', 'Kurcze', 5, CURRENT_TIMESTAMP,1,10),
('9:30:00', '17:30:00', 'Kurcze', 6, CURRENT_TIMESTAMP,1,10),
('20:00:00', '21:30:00', 'Lulanko', 2, CURRENT_TIMESTAMP,1,9),
('20:00:00', '21:30:00', 'Lulanko', 3, CURRENT_TIMESTAMP,2,9),
('20:00:00', '21:30:00', 'Lulanko', 4, CURRENT_TIMESTAMP,1,9),
('20:00:00', '21:30:00', 'Lulanko', 5, CURRENT_TIMESTAMP,2,9),
('20:00:00', '21:30:00', 'Lulanko', 6, CURRENT_TIMESTAMP,1,9),
('20:00:00', '21:30:00', 'Lulanko', 7, CURRENT_TIMESTAMP,2,9),
('20:00:00', '21:30:00', 'Lulanko', 1, CURRENT_TIMESTAMP,1,9),
('17:30:00', '18:00:00', 'Czas na lekcje', 2, CURRENT_TIMESTAMP,2,5),
('17:30:00', '18:00:00', 'Czas na lekcje', 3, CURRENT_TIMESTAMP,1,5),
('17:30:00', '18:00:00', 'Czas na lekcje', 4, CURRENT_TIMESTAMP,2,5),
('17:30:00', '18:00:00', 'Czas na lekcje', 5, CURRENT_TIMESTAMP,1,5),
('10:30:00', '12:00:00', 'Czas na bajeczki', 7, CURRENT_TIMESTAMP,3,8),
('10:30:00', '11:30:00', 'Czas na bajeczki', 1, CURRENT_TIMESTAMP,4,8),
('21:00:00', '23:00:00', 'Czas na taty', 4, CURRENT_TIMESTAMP,1,13),
('19:30:00', '21:30:00', 'Czas na mamy', 5, CURRENT_TIMESTAMP,2,14),
('19:30:00', '21:00:00', 'Na dolinke', 4, CURRENT_TIMESTAMP,1,6),
('12:30:00', '14:00:00', 'Obiad', 7, CURRENT_TIMESTAMP,1,12),
('12:30:00', '14:00:00', 'Obiad', 1, CURRENT_TIMESTAMP,2,12),
('16:15:00', '17:15:00', 'Czas na wstazke', 5, CURRENT_TIMESTAMP,2,7)
;
