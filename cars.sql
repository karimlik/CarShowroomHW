DELETE FROM Cars

DBCC CHECKIDENT ('Cars', RESEED, 0)

insert into Showrooms (ShowroomName, ShowroomPhone, ShowroomAddress) values ('Kshlerin and Sons', '954535', '75769 Vera Place');
insert into Showrooms (ShowroomName, ShowroomPhone, ShowroomAddress) values ('Kozey and Sons', '6075412', '990 5th Place');
insert into Showrooms (ShowroomName, ShowroomPhone, ShowroomAddress) values ('Brekke-Bartell', '4362395', '67883 Jackson Circle');
insert into Showrooms (ShowroomName, ShowroomPhone, ShowroomAddress) values ('Frami and Sons', '6064478', '72757 Randy Crossing');
insert into Showrooms (ShowroomName, ShowroomPhone, ShowroomAddress) values ('Baumbach-Murazik', '25153326', '224 Graceland Park');
insert into Showrooms (ShowroomName, ShowroomPhone, ShowroomAddress) values ('Leuschke, Casper and Beatty', '62421816', '13494 Erie Terrace');


insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Mercury', 'Tracer', 1993, 4882, 7351950, 1);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Mitsubishi', 'Lancer', 2007, 7833, 5988184, 2);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Audi', '100', 1991, 1556, 5824880, 3);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Volkswagen', 'Scirocco', 1985, 2249, 2399473, 4);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Mercedes-Benz', 'SLK-Class', 2011, 6573, 1017277, 5);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Suzuki', 'Esteem', 2000, 8616, 3461895, 4);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Infiniti', 'Q', 1996, 2701, 1218729, 3);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Volkswagen', 'R32', 2009, 1471, 2093566, 2);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Mitsubishi', 'Lancer', 2012, 1386, 8812989, 1);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Chevrolet', 'Bel Air', 1967, 3227, 6268486, 6);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Cadillac', 'Seville', 1994, 3239, 8214130, 1);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Mercury', 'Grand Marquis', 2006, 5415, 4480400, 2);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Volvo', 'S40', 2011, 3045, 1108000, 3);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Lincoln', 'Town Car', 1986, 3952, 2101891, 4);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('GMC', 'Yukon Denali', 2006, 9068, 6028880, 5);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('GMC', 'Savana 1500', 1997, 7087, 562792, 4);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Bentley', 'Brooklands', 2010, 7416, 2561602, 3);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Suzuki', 'Esteem', 1996, 3130, 3801060, 2);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('BMW', '600', 1958, 3887, 1603254, 1);
insert into Cars (Make, Model, ModelYear, EngineCapacity, Price, ShowId) values ('Ford', 'Escort', 2001, 5728, 5866790, 6);