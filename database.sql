CREATE TABLE expenses.users (
	id_user INT not null AUTO_INCREMENT, 
	user VARCHAR(25) not null,
	password VARCHAR(125) not null,
	created_on datetime not null,
	PRIMARY KEY (id_user)
);
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
---------------------------------------
CREATE TABLE expenses.clients_payments (
  id_client_payment int NOT NULL AUTO_INCREMENT,
  id_client int NOT NULL,
  value decimal(10,0) NOT NULL,
  date date NOT NULL,
  created_on datetime NOT NULL,
  PRIMARY KEY (`id_client_payment`)
);
----------------------------------
CREATE TABLE expenses.expenses (
	id_expense INT not null AUTO_INCREMENT,
	description varchar(125) not null,
	value decimal not null,
	date date not null,
	created_on datetime not null,
	PRIMARY KEY (id_expense)
);
------------------------------------
CREATE TABLE expenses.general (
	id_general INT not null AUTO_INCREMENT,
	initial_balance decimal not null,
	PRIMARY KEY (id_general)
);