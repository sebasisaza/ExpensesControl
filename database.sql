CREATE TABLE expenses.users (
	id_user INT not null AUTO_INCREMENT, 
	user VARCHAR(25) not null,
	password VARCHAR(125) not null,
	created_on datetime not null,
	PRIMARY KEY (id_user)
);

insert into expenses.users (user, password, created_on) values ('cata', 'cbee8a4e86e2833292ea13c0106fff1e', CURRENT_TIMESTAMP());
--------------------------------

CREATE TABLE expenses.clients (
	id_client INT not null AUTO_INCREMENT, 
	name VARCHAR(50) not null,
	identification int not null,
	phone varchar(25) not null,
	loan decimal not null,
	time_limit int not null,
	interest_rate decimal not null,
	payment_type smallint not null,
	days_added smallint not null,
	created_on datetime not null,
	PRIMARY KEY (id_client)
);

insert into expenses.clients (name,identification,phone,loan,time_limit,interest_rate,payment_type,days_added,created_on) values ('Sebastian', '123', '316',5000000,30, 15, 1,0, CURRENT_TIMESTAMP());