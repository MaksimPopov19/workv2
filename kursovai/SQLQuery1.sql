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
insert users values ('�����','������','���������','Admin','admin123','�������������','0')
insert users values ('���������','���������','����������','Teacher','teacher123','�������','0')
insert users values ('�������','�������','���������','Student','student123','������','0')