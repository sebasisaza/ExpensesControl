CREATE TABLE expenses.users (
	id_user INT not null AUTO_INCREMENT, 
	user VARCHAR(25) not null,
	password VARCHAR(125) not null,
	created_on datetime not null,
	PRIMARY KEY (id_user)
);

insert into expenses.users (user, password, created_on) values ('cata', 'cbee8a4e86e2833292ea13c0106fff1e', CURRENT_TIMESTAMP());