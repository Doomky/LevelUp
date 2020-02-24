CREATE TABLE avatars
 (
	id				INT						NOT NULL,
	level			INT						NOT NULL,
	xp				INT						NOT NULL,
	xp_max			INT						NOT NULL,
	size			INT						NOT NULL,
	PRIMARY KEY (id),
);

CREATE TABLE users
(
	id				INT IDENTITY(1, 1)       NOT NULL,
	login			VARCHAR(255)             NOT NULL,
	firstname		VARCHAR(255)             NOT NULL,
	lastname		VARCHAR(255)			 NOT NULL,
	email			VARCHAR(255)			 NOT NULL,
	last_login_date VARCHAR(255),
	password_hast   VARCHAR(255),
	avatar_id		INT FOREIGN KEY REFERENCES avatars(id)	 NOT NULL,
	PRIMARY KEY (id),
);



CREATE TABLE open_food_facts_datas (
  id				INT	IDENTITY(1, 1)		NOT NULL,
  code				INT						NOT NULL,
  name				VARCHAR(255)			NOT NULL,
  protein			VARCHAR(255)			NOT NULL,
  glucide			VARCHAR(255)			NOT NULL,
  PRIMARY KEY (id),
);

CREATE TABLE quests_types (
  id				INT IDENTITY(1, 1)		NOT NULL,
  type				varchar(255),
  PRIMARY KEY (id),
);

CREATE TABLE categories (
  id				INT IDENTITY(1, 1)		NOT NULL,
  category			VARCHAR(255),
  PRIMARY KEY (id),
);

CREATE TABLE quests (
  id				INT IDENTITY(1, 1)		NOT NULL,
  category_id		INT FOREIGN KEY REFERENCES categories(id) NOT NULL,
  type_id			INT FOREIGN KEY REFERENCES quests_types(id) NOT NULL,
  progress_value	INT	NOT NULL,
  progress_count	INT	NOT NULL,
  PRIMARY KEY (id),
);


CREATE TABLE food_entries (
  id						INT IDENTITY(1, 1)									 NOT NULL,
  user_id					INT	FOREIGN KEY REFERENCES users(id)				 NOT NULL,
  open_food_facts_data_id	INT FOREIGN KEY REFERENCES open_food_facts_datas(id) NOT NULL,
  date						TIMESTAMP											 NOT NULL,
  PRIMARY KEY (id),
);

CREATE TABLE physical_activites (
  id					   INT IDENTITY(1, 1)									NOT NULL,
  name					   VARCHAR(255)											NOT NULL,
  kcal_per_hour			   NUMERIC												NOT NULL
  PRIMARY KEY (id),
);

CREATE TABLE physical_activites_entries (
  id					   INT	IDENTITY(1, 1)									NOT NULL,
  user_id				   INT	FOREIGN KEY REFERENCES users(id)				NOT NULL,
  physical_activites_id	   INT  FOREIGN KEY REFERENCES physical_activites(id)	NOT NULL,
  date					   TIMESTAMP											NOT NULL,
  PRIMARY KEY (id),
);

CREATE TABLE sleep_entries (
  id					  INT identity(1, 1)									NOT NULL,
  user_id				  INT FOREIGN KEY REFERENCES users(id)					NOT NULL,
  duration_minutes		  NUMERIC												NOT NULL,
  date					  TIMESTAMP												NOT NULL,				
  PRIMARY KEY (id),

);

CREATE TABLE advices (
  id					 INT IDENTITY(1, 1)										NOT NULL,
  category_id			 INT FOREIGN KEY REFERENCES categories(id)			    NOT NULL,
  text					 VARCHAR(255)											NOT NULL,					
  PRIMARY KEY (id),
);