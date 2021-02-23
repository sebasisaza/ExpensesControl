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
----------------------------------
CREATE TABLE expenses.expenses (
	id_expense INT not null AUTO_INCREMENT,
	description varchar(125) not null,
	value decimal not null,
	date date not null,
	created_on datetime not null,
	PRIMARY KEY (id_expense)
);

insert into expenses.expenses (description, value, date, created_on) values ('Pago ayudante', 400000, '2021-02-19', CURRENT_TIMESTAMP());

------------------------------------

Create or replace View `DayCollectionsView` as 
Select
    id_client,
    name as 'name_client',
    phone as 'phone_client',
    CASE 
        WHEN payment_type = 1 
        	THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL days_added+1 day)
        WHEN payment_type = 2
        	THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL days_added+7 day)
        WHEN payment_type = 3
        	THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL days_added+14 day)
        WHEN payment_type = 4
        	THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL 1 month)
    end as 'day_payment',
    CASE 
        WHEN payment_type = 1 
        	then ROUND(time_limit/1, 0)
        WHEN payment_type = 2
        	then ROUND(time_limit/7)
        WHEN payment_type = 3
        	then ROUND(time_limit/15)
        WHEN payment_type = 4
        	then ROUND(time_limit/30)
    end as 'scheduled_payments',
    (select count(1) from expenses.clients_payments where c.id_client = id_client) as 'total_payments',
    CASE 
        WHEN payment_type = 1 
        	then loan/(ROUND(time_limit/1))
        WHEN payment_type = 2
        	then loan/(ROUND(time_limit/7))
        WHEN payment_type = 3
        	then loan/(ROUND(time_limit/14))
        WHEN payment_type = 4
        	then loan/(ROUND(time_limit/30))
    end as 'scheduled_value'
From
    expenses.clients c
        