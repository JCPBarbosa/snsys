# snsys
# Infelizmente não consegui rodar o Docker na minha máquina, ele ficava com o status starting mas não iniciava os containers
# Estou enviando aqui os scripts Sql do postgres

CREATE DATABASE "TesteSNSYS"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE TABLE tb_users (
	"Id" serial4 NOT NULL,
	"User" varchar NOT NULL,
	"Password" varchar NOT NULL,
	"Role" varchar NOT NULL,
	CONSTRAINT tb_users_pk PRIMARY KEY ("Id")
);

CREATE TABLE tb_customer (
	"Id" serial4 NOT NULL,
	"UserId" int4 NOT NULL,
	"Name" varchar(200) NULL,
	"Email" varchar(100) NULL,
	"Phone" varchar(20) NULL,
	"RegisterDate" timestamp NOT NULL,
	"UpdateDate" timestamp NULL,
	CONSTRAINT tb_customer_email_key UNIQUE ("Email"),
	CONSTRAINT tb_customer_pkey PRIMARY KEY ("Id")
);
