create database bd_testeRissi

use bd_testeRissi

create table Carros(
  IdCarro int identity not null,
  Nome varchar(300) not null,
  Eixos int not null,
  Categoria varchar(100) not null,
  TamanhoPortaMalas int not null,
  Portas int not null,
  Preco decimal not null,
  CreatedAt datetime not null,
  UpdatedAt datetime not null,
  constraint Carros_pk
    primary key (IdCarro)
);

create table Cliente(
  idCliente int identity not null,
  Nome varchar(50) not null,
  Email varchar(100) not null,
  Senha varchar(20) not null,
);

insert into Carros (
  Nome,
  Eixos,
  Categoria,
  TamanhoPortaMalas,
  Portas,
  Preco,
  CreatedAt,
  UpdatedAt
)
values (
  'New Fiesta',
  2,
  'Hatch',
  250,
  4,
  40000,
  '20210819 16:19:03.000',
  '20210819 16:19:05.000'
);

insert into Carros (
  Nome,
  Eixos,
  Categoria,
  TamanhoPortaMalas,
  Portas,
  Preco,
  CreatedAt,
  UpdatedAt
)
values (
  'Civic',
  2,
  'Sedan',
  400,
  4,
  85707,
  '20210819 16:22:35.000',
  '20210819 16:22:39.000'
);

insert into Carros (
  Nome,
  Eixos,
  Categoria,
  TamanhoPortaMalas,
  Portas,
  Preco,
  CreatedAt,
  UpdatedAt
)
values (
  'testeSUV',
  2,
  'SUV',
  300,
  4,
  95500,
  '20210822 16:22:35.000',
  '20210901 16:25:39.000'
);

insert into Carros (
  Nome,
  Eixos,
  Categoria,
  TamanhoPortaMalas,
  Portas,
  Preco,
  CreatedAt,
  UpdatedAt
)
values (
  'testeUtilitario',
  2,
  'Utilitario',
  500,
  4,
  45780,
  '20210822 16:25:35.000',
  '20210901 16:29:39.000'
);

insert into Carros (
  Nome,
  Eixos,
  Categoria,
  TamanhoPortaMalas,
  Portas,
  Preco,
  CreatedAt,
  UpdatedAt
)
values (
  'testePicape',
  2,
  'Picape',
  700,
  4,
  47780,
  '20210822 16:20:35.000',
  '20210901 16:23:39.000'
);

select * from Carros

