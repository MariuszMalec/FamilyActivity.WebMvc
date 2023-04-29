﻿USE activityDb;
INSERT INTO activiesDays(name,startTime,endTime,description,picture,dayOfWeek,createdAt)
VALUES 
('rysowanie','16:00:00','17:00:00','rysowanie olowkiem','https://images.unsplash.com/photo-1525278070609-779c7adb7b71?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1147&q=80',1, CURRENT_TIMESTAMP),
('malowanie','17:00:00','18:00:00','malowanie farba','https://images.unsplash.com/photo-1456086272160-b28b0645b729?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1632&q=80',2, CURRENT_TIMESTAMP),
('gra','18:00:00','19:00:00','granie w gre','https://images.unsplash.com/photo-1522069213448-443a614da9b6?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1173&q=80',3, CURRENT_TIMESTAMP),
('cwiczenia','17:00:00','18:00:00','cwiczenia fizyczne','https://images.unsplash.com/photo-1591291621164-2c6367723315?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80',2, CURRENT_TIMESTAMP),
('cwiczenia','17:00:00','18:00:00','cwiczenia fizyczne','https://images.unsplash.com/photo-1591291621164-2c6367723315?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80',4, CURRENT_TIMESTAMP),
('spacer','11:00:00','12:00:00','czas na spacer','https://images.unsplash.com/photo-1496185106368-308ed96f204b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=921&q=80',4, CURRENT_TIMESTAMP),
('zabawaZMama','16:00:00','17:00:00','gry i zabawy z mama','https://images.unsplash.com/photo-1623249288685-835abe0123b4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80',1, CURRENT_TIMESTAMP),
('zabawaZTata','17:00:00','18:00:00','gry i zabawy z tata','https://images.unsplash.com/photo-1437943085269-6da5dd4295bf?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',2, CURRENT_TIMESTAMP),
('tanczenie','19:00:00','20:00:00','taniec','https://images.unsplash.com/photo-1504609813442-a8924e83f76e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',3, CURRENT_TIMESTAMP),
('nauka','16:00:00','17:00:00','uczenie','https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1122&q=80',4, CURRENT_TIMESTAMP),
('sprzatanie','19:30:00','20:00:00','sprzatanie domu','https://images.unsplash.com/photo-1623947371527-db5fc62e08c7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',5, CURRENT_TIMESTAMP),
('bajkiWieczorne','19:30:00','20:30:00','ogladanie wieczorem','https://images.unsplash.com/photo-1586899028174-e7098604235b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80',6, CURRENT_TIMESTAMP),
('bajkiDzienne','11:30:00','12:30:00','ogladanie poranne','https://images.unsplash.com/photo-1533518463841-d62e1fc91373?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',1, CURRENT_TIMESTAMP),
('czytanie','20:00:00','20:30:00','czytanie na dobranoc','https://images.unsplash.com/photo-1553729784-e91953dec042?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',2, CURRENT_TIMESTAMP),
('czasDlaMamy','20:30:00','21:30:00','zajecia tylko dla mamy','https://plus.unsplash.com/premium_photo-1663099581782-9e1f919ca4c3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',6, CURRENT_TIMESTAMP),
('czasDlaTaty','21:30:00','23:00:00','zajecia tylko dla taty','https://images.unsplash.com/photo-1537432376769-00f5c2f4c8d2?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1025&q=80',6, CURRENT_TIMESTAMP),
('sztanga','18:30:00','19:30:00','cwiczenie taty ze sztanga','https://images.unsplash.com/photo-1557330359-ffb0deed6163?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',1, CURRENT_TIMESTAMP),
('sztanga','18:30:00','19:30:00','cwiczenie taty ze sztanga','https://images.unsplash.com/photo-1557330359-ffb0deed6163?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',3, CURRENT_TIMESTAMP),
('piosenkiDlaEmilki','17:30:00','18:30:00','piosenki dla Emilki','https://plus.unsplash.com/premium_photo-1661629272751-b8e90194074f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',5, CURRENT_TIMESTAMP),
('wycieczka','11:00:00','12:00:00','wyprawa w nieznane','https://images.unsplash.com/photo-1476514525535-07fb3b4ae5f1?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',7, CURRENT_TIMESTAMP),
('kapiel','19:30:00','20:00:00','kopanie','https://images.unsplash.com/photo-1576678433413-202829a1ab98?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',3, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',1, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',1, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',1, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',2, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',2, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',2, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',3, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',3, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',3, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',4, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',4, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',4, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',5, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',5, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',5, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',6, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',6, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',6, CURRENT_TIMESTAMP),
('sniadanie','7:00:00','8:00:00','sniadanie','https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',7, CURRENT_TIMESTAMP),
('obiad','14:00:00','15:30:00','obiad','https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',7, CURRENT_TIMESTAMP),
('kolacja','18:30:00','19:30:00','kolacja','https://images.unsplash.com/photo-1608835291093-394b0c943a75?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',7, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',1, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',2, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',3, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',4, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',5, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',6, CURRENT_TIMESTAMP),
('spanie','19:30:00','23:30:00','czas na sen','https://images.unsplash.com/photo-1563301141-3fb8b3b2df9e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',7, CURRENT_TIMESTAMP),
('pobudka','6:30:00','7:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',1, CURRENT_TIMESTAMP),
('pobudka','6:30:00','7:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',2, CURRENT_TIMESTAMP),
('pobudka','6:30:00','7:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',3, CURRENT_TIMESTAMP),
('pobudka','6:30:00','7:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',4, CURRENT_TIMESTAMP),
('pobudka','6:30:00','7:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',5, CURRENT_TIMESTAMP),
('pobudka','7:30:00','8:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',6, CURRENT_TIMESTAMP),
('pobudka','7:30:00','8:00:00','czas wstawac','https://images.unsplash.com/photo-1590656114831-9be3b832eec7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80',7, CURRENT_TIMESTAMP),
('pracaTaty','8:00:00','16:30:00','Tata, czas do pracy','https://images.unsplash.com/photo-1459180129673-eefb56f79b45?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80',2, CURRENT_TIMESTAMP),
('pracaTaty','8:00:00','16:30:00','Tata, czas do pracy','https://images.unsplash.com/photo-1459180129673-eefb56f79b45?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80',3, CURRENT_TIMESTAMP),
('pracaTaty','7:00:00','15:30:00','Tata, czas do pracy','https://images.unsplash.com/photo-1459180129673-eefb56f79b45?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80',4, CURRENT_TIMESTAMP),
('pracaTaty','6:00:00','14:30:00','Tata, czas do pracy','https://images.unsplash.com/photo-1459180129673-eefb56f79b45?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80',5, CURRENT_TIMESTAMP),
('pracaTaty','7:00:00','15:30:00','Tata, czas do pracy','https://images.unsplash.com/photo-1459180129673-eefb56f79b45?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80',6, CURRENT_TIMESTAMP),
('pracaMamy','17:00:00','19:30:00','Mama, czas do pracy','https://images.unsplash.com/photo-1484480974693-6ca0a78fb36b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',2, CURRENT_TIMESTAMP),
('pracaMamy','17:00:00','20:30:00','Mama, czas do pracy','https://images.unsplash.com/photo-1484480974693-6ca0a78fb36b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',3, CURRENT_TIMESTAMP),
('pracaMamy','17:00:00','19:30:00','Mama, czas do pracy','https://images.unsplash.com/photo-1484480974693-6ca0a78fb36b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',4, CURRENT_TIMESTAMP),
('pracaMamy','8:00:00','10:30:00','Mama, czas do pracy','https://images.unsplash.com/photo-1484480974693-6ca0a78fb36b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',5, CURRENT_TIMESTAMP),
('pracaMamy','10:00:00','12:30:00','Mama, czas do pracy','https://images.unsplash.com/photo-1484480974693-6ca0a78fb36b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80',6, CURRENT_TIMESTAMP),
('wstazka','16:10:00','17:10:00','Mama, wstazka Gosi','https://images.unsplash.com/photo-1498940757830-82f7813bf178?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80',3, CURRENT_TIMESTAMP);