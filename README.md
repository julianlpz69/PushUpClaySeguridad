# PushUpClaySeguridade table pais (
id int primary key,
nombre_pais varchar(50));

create table departamento(
id int primary key,
nombre_dep varchar (50),
id_pais int,
FOREIGN KEY(id_pais) REFERENCES pais(id));

create table ciudad(
id int primary key,
nombre_ciudad varchar (50),
id_dep int,
FOREIGN KEY(id_dep) REFERENCES departamento(id));

create table tipo_persona(
id int primary key,
descripcion varchar(100));


create table tipo_contacto(
id int primary key,
descripcion varchar(100));


create table categoria_persona(
id int primary key,
nombre_categoria varchar(50));

create table turno(
id int primary key,
nombre_turno varchar(50),
hora_turno_inicio float,
hora_turno_final float);


create table persona (
id int primary key,
id_persona varchar(50),
nombre varchar(100),
date_registro date,
id_tipo_persona int,
id_categoria int ,
id_ciudad int,
foreign key (id_tipo_persona) references tipo_persona(id),
foreign key (id_categoria) references categoria_persona(id),
foreign key (id_ciudad) references ciudad(id))


create table contacto_persona(
id int primary key,
descripcion varchar(100),
id_persona int,
id_contacto int,
foreign key (id_persona) references persona(id),
foreign key (id_contacto) references tipo_contacto(id));

create table estado(
id int primary key,
descripcion varchar(50));

create table contrato (
id int primary key,
fecha_contrato date,
fecha_fin date,
id_cliente int,
id_empleado int,
id_estado int,
foreign key (id_cliente) references persona(id),
foreign key (id_empleado) references persona(id),
foreign key (id_estado) references estado(id));

create table programacion(
id int primary key,
id_contrato int,
id_turno int,
id_empleado int,
foreign key (id_contrato) references contrato(id),
foreign key (id_turno) references turno(id),
foreign key (id_empleado) references persona(id));
