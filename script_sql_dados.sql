/**************************************************************************
	Populando tabelas para visualizar os dados através da API 
	Regra: 
	1 - Especificação: permitir apenas os valores: (Infantil, Fundamental, Médio e Superior)
***************************************************************************/
insert into [Escolaridade] (Descricao) Values ('Infantil')
insert into [Escolaridade] (Descricao) Values ('Fundamental')
insert into [Escolaridade] (Descricao) Values ('Médio')
insert into [Escolaridade] (Descricao) Values ('Superior')

/**************************************************************************
	Populando tabelas para visualizar os dados através da API 
	Regra: 
***************************************************************************/
insert into Usuarios (Nome,Sobrenome,Email,DataNascimento,EscolaridadeId,HistoricoEscolarId)
values ('Viviane', 'Brianezi', 'vbrianezi@hotmail.com', '12/05/1984',4, null)
insert into Usuarios (Nome,Sobrenome,Email,DataNascimento,EscolaridadeId,HistoricoEscolarId)
values ('Maria', 'Silva', 'maria@hotmail.com', '06/05/1988',3, null)
insert into Usuarios (Nome,Sobrenome,Email,DataNascimento,EscolaridadeId,HistoricoEscolarId)
values ('João', 'Rogerio', 'joao@gmail.com', '08/08/2020',1, null)

/**************************************************************************
	Consultas
***************************************************************************/
select * from [Escolaridade]
select * from Usuarios
