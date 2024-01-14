﻿USE activityDb;
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