create table users(
id_users int   primary key identity not null ,
surname varchar(100),
name varchar(100),
patronymic varchar(100),
login varchar(100),
password varchar(100),
levels varchar(100),
blok int,
)
insert users values ('Попов','Максим','Сергеевич','Admin','admin123','Администратор','0')
insert users values ('Наймушина','Екатерина','Максимовна','Teacher','teacher123','Учитель','0')
insert users values ('Борисов','Тимофей','Сергеевич','Student','student123','Ученик','0')