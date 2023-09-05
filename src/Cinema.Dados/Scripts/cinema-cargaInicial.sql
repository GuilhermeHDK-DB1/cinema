﻿INSERT INTO Genero(nome) VALUES
('Ação'),
('Comédia'),
('Romance'),
('Documentário'),
('Suspense'),
('Terror'),
('Ficção Científica');


INSERT INTO Filme (nome, ano_de_lancamento, duracao, genero_id, classificacao) VALUES
-- Ação
('Ação Explosiva', '2021', 130, 1, 'PG-13'),
('Missão Adrenalina', '2022', 118, 1, 'PG'),
('Operação Eclipse', '2023', 145, 1, 'PG-13'),
('Ataque Implacável', '2022', 110, 1, 'PG'),
('Resgate Extremo', '2023', 125, 1, 'PG-13'),
('Caos Urbano', '2021', 105, 1, 'PG'),
('Alvo em Movimento', '2022', 122, 1, 'PG-13'),
('Sobrevivência Extrema', '2023', 135, 1, 'PG-13'),
('Confronto nas Ruas', '2021', 112, 1, 'PG'),
('Rastro de Vingança', '2022', 128, 1, 'PG-13'),
('Invasão Terminal', '2022', 132, 1, 'PG-13'),
('Código de Honra', '2023', 118, 1, 'PG'),
('Risco Iminente', '2021', 140, 1, 'PG-13'),
('Sobrevivência Urbana', '2022', 120, 1, 'PG'),
('Conspiração Global', '2023', 126, 1, 'PG-13'),
-- Comédia
('Risos na Vizinhança', '2022', 100, 2, 'PG'),
('Confusões em Série', '2023', 95, 2, 'PG'),
('Amor e Riso', '2021', 110, 2, 'PG'),
('Loucuras em Família', '2022', 105, 2, 'PG'),
('O Amor é uma Piada', '2023', 98, 2, 'PG'),
('Comédia no Escritório', '2021', 112, 2, 'PG'),
('Rindo à Toa', '2022', 105, 2, 'PG'),
('Cenas Engraçadas', '2023', 100, 2, 'PG'),
('Risos e Romance', '2022', 115, 2, 'PG'),
('Confusão de Amigos', '2021', 102, 2, 'PG'),
('Amigos Risonhos', '2023', 110, 2, 'PG'),
('Comédia de Erros', '2022', 105, 2, 'PG'),
('Rindo até Cair', '2021', 98, 2, 'PG'),
('Amor às Gargalhadas', '2023', 112, 2, 'PG'),
('Risos no Palco', '2022', 100, 2, 'PG'),
-- Romance
('Amor Inesperado', '2022', 110, 3, 'PG'),
('Corações Entrelaçados', '2023', 120, 3, 'PG'),
('Paixão à Primeira Vista', '2021', 105, 3, 'PG'),
('Eternamente Seu', '2022', 115, 3, 'PG'),
('Amor nas Estrelas', '2023', 108, 3, 'PG'),
('Destinos Cruzados', '2021', 122, 3, 'PG'),
('Romance à Beira-Mar', '2022', 112, 3, 'PG'),
('Promessa de Amor', '2023', 118, 3, 'PG'),
('O Poder do Afeto', '2022', 105, 3, 'PG'),
('Momentos de Paixão', '2021', 110, 3, 'PG'),
('Amor em Paris', '2023', 120, 3, 'PG'),
('Laços do Coração', '2022', 115, 3, 'PG'),
('Amor Verdadeiro', '2021', 108, 3, 'PG'),
('Para Sempre ao Seu Lado', '2023', 122, 3, 'PG'),
('Encontro Romântico', '2022', 112, 3, 'PG'),
-- Documentário
('Explorando o Oceano Profundo', '2022', 90, 4, 'PG'),
('Vida nas Florestas Tropicais', '2023', 85, 4, 'PG'),
('Segredos da História Antiga', '2021', 100, 4, 'PG'),
('A Ciência do Cosmos', '2022', 95, 4, 'PG'),
('Biografias Inspiradoras', '2023', 88, 4, 'PG'),
('Terra: Um Retrato Aéreo', '2021', 105, 4, 'PG'),
('Grandes Invenções da Humanidade', '2022', 92, 4, 'PG'),
('Explorando o Espaço Sideral', '2023', 98, 4, 'PG'),
('A Vida nas Profundezas Marinhas', '2022', 91, 4, 'PG'),
('Povos e Culturas Esquecidos', '2021', 96, 4, 'PG'),
('Mistérios da Natureza', '2023', 87, 4, 'PG'),
('O Universo Microscópico', '2022', 102, 4, 'PG'),
('Arqueologia Desvendada', '2021', 89, 4, 'PG'),
('A História da Tecnologia', '2023', 93, 4, 'PG'),
('Ecossistemas em Perigo', '2022', 94, 4, 'PG'),
-- Suspense
('Segredos Obscuros', '2022', 110, 5, 'PG-13'),
('Perigo Iminente', '2023', 105, 5, 'PG-13'),
('No Limite da Escuridão', '2021', 120, 5, 'PG-13'),
('Desaparecimento Misterioso', '2022', 115, 5, 'PG-13'),
('Conspiração Mortal', '2023', 108, 5, 'PG-13'),
('Jogo de Sobrevivência', '2021', 122, 5, 'PG-13'),
('À Beira do Abismo', '2022', 112, 5, 'PG-13'),
('Amigos em Perigo', '2023', 118, 5, 'PG-13'),
('Enigma na Cidade', '2022', 105, 5, 'PG-13'),
('Sussurros da Noite', '2021', 110, 5, 'PG-13'),
('Ameaça Virtual', '2023', 120, 5, 'PG-13'),
('Traição Obscura', '2022', 115, 5, 'PG-13'),
('À Sombra do Medo', '2021', 108, 5, 'PG-13'),
('Rastro de Desaparecimento', '2023', 122, 5, 'PG-13'),
('Intrigas Mortais', '2022', 112, 5, 'PG-13'),
-- Terror
('Pesadelos Noturnos', '2022', 95, 6, 'R'),
('Maldição das Sombras', '2023', 90, 6, 'R'),
('A Casa Assombrada', '2021', 100, 6, 'R'),
('Terror na Floresta', '2022', 85, 6, 'R'),
('A Visita Sinistra', '2023', 92, 6, 'R'),
('Horror Profundo', '2021', 105, 6, 'R'),
('A Maldição da Lua Cheia', '2022', 88, 6, 'R'),
('Pesadelos do Passado', '2023', 94, 6, 'R'),
('O Mal Desperta', '2022', 97, 6, 'R'),
('Almas Atormentadas', '2021', 102, 6, 'R'),
('O Despertar do Pesadelo', '2023', 98, 6, 'R'),
('A Noite dos Horrores', '2022', 91, 6, 'R'),
('Terror nas Profundezas', '2021', 96, 6, 'R'),
('O Mistério do Abandono', '2023', 99, 6, 'R'),
('O Desconhecido', '2022', 93, 6, 'R'),
-- Ficção Científica
('Viagem Interplanetária', '2022', 120, 7, 'PG-13'),
('Revolução Tecnológica', '2023', 115, 7, 'PG-13'),
('Alienígenas na Terra', '2021', 130, 7, 'PG-13'),
('Universo Paralelo', '2022', 125, 7, 'PG-13'),
('Máquinas Conscientes', '2023', 118, 7, 'PG-13'),
('Exploração Espacial', '2021', 135, 7, 'PG-13'),
('A Revolta das Máquinas', '2022', 122, 7, 'PG-13'),
('Cidades do Futuro', '2023', 128, 7, 'PG-13'),
('Realidade Virtual', '2022', 120, 7, 'PG-13'),
('Invasão Robótica', '2021', 125, 7, 'PG-13'),
('Conquista Espacial', '2023', 132, 7, 'PG-13'),
('Experimento Genético', '2022', 128, 7, 'PG-13'),
('O Mistério do Tempo', '2021', 123, 7, 'PG-13'),
('Mundos Distantes', '2023', 130, 7, 'PG-13'),
('Ciborgues em Ação', '2022', 126, 7, 'PG-13');


INSERT INTO Sala (nome, sala_vip , sala_3d , capacidade) VALUES
('Sala 1', 0, 0, 10),
('Sala 2', 0, 0, 10),
('Sala 3', 0, 0, 10),
('Sala 4', 0, 0, 10),
('Sala 5', 0, 1, 10),
('Sala 6', 0, 1, 10),
('Sala 7', 0, 1, 10),
('Sala 8', 0, 1, 10),
('Sala 9', 1, 1, 5),
('Sala 10', 1, 0, 5);


INSERT INTO Sessao(filme_id, sala_id, horario, idioma) VALUES
-- Sala 1
(1, 1, CONVERT(datetime, '2023-08-28 10:00:00', 121), 0),
(11, 1, CONVERT(datetime, '2023-08-28 13:00:00', 121), 1),
(21, 1, CONVERT(datetime, '2023-08-28 16:00:00', 121), 0),
(31, 1, CONVERT(datetime, '2023-08-28 19:00:00', 121), 1),
(41, 1, CONVERT(datetime, '2023-08-28 22:00:00', 121), 0),
-- Sala 5
(14, 5, CONVERT(datetime, '2023-08-28 10:00:00', 121), 0),
(63, 5, CONVERT(datetime, '2023-08-28 13:00:00', 121), 1),
(48, 5, CONVERT(datetime, '2023-08-28 16:00:00', 121), 0),
(38, 5, CONVERT(datetime, '2023-08-28 19:00:00', 121), 1),
(11, 5, CONVERT(datetime, '2023-08-28 22:00:00', 121), 0),
-- Sala 9
(37, 9, CONVERT(datetime, '2023-08-28 10:00:00', 121), 0),
(102, 9, CONVERT(datetime, '2023-08-28 13:00:00', 121), 1),
(97, 9, CONVERT(datetime, '2023-08-28 16:00:00', 121), 0),
(49, 9, CONVERT(datetime, '2023-08-28 19:00:00', 121), 1),
(37, 9, CONVERT(datetime, '2023-08-28 22:00:00', 121), 0),
-- Sala 10
(87, 10, CONVERT(datetime, '2023-08-28 10:00:00', 121), 0),
(59, 10, CONVERT(datetime, '2023-08-28 13:00:00', 121), 1),
(73, 10, CONVERT(datetime, '2023-08-28 16:00:00', 121), 0),
(52, 10, CONVERT(datetime, '2023-08-28 19:00:00', 121), 1),
(10, 10, CONVERT(datetime, '2023-08-28 22:00:00', 121), 0);


INSERT INTO Cliente(nome, cpf, email, data_de_nascimento) VALUES
('João da Silva', '69103086038', 'joao.silva@email.com', '1985-03-10'),
('Maria Santos', '45490764023', 'maria.santos@email.com', '1990-07-25'),
('Pedro Oliveira', '09086494013', 'pedro.oliveira@email.com', '1982-12-15'),
('Ana Pereira', '25915654061', 'ana.pereira@email.com', '1995-09-05'),
('Carlos Ferreira', '52536783014', 'carlos.ferreira@email.com', '1987-06-20'),
('Laura Carvalho', '74342851091', 'laura.carvalho@email.com', '1993-04-12'),
('André Alves', '06159856022', 'andre.alves@email.com', '1980-11-30'),
('Sofia Ribeiro', '13225195014', 'sofia.ribeiro@email.com', '1998-02-08'),
('Tiago Machado', '45198523070', 'tiago.machado@email.com', '1989-10-19'),
('Carolina Santos', '08422607069', 'carolina.santos@email.com', '1991-07-02'),
('José da Silva', '08422607069', 'jose.silva@email.com', '1984-03-15'),
('Paula Santos', '65045169017', 'paula.santos@email.com', '1992-08-20'),
('Ricardo Oliveira', '53507580047', 'ricardo.oliveira@email.com', '1981-12-25'),
('Clara Pereira', '26520776009', 'clara.pereira@email.com', '1994-09-12'),
('Fernando Ferreira', '10953695042', 'fernando.ferreira@email.com', '1986-05-05'),
('Lúcia Carvalho', '78907700060', 'lucia.carvalho@email.com', '1990-04-02'),
('Miguel Alves', '50058101020', 'miguel.alves@email.com', '1979-10-10'),
('Alice Ribeiro', '95736600080', 'alice.ribeiro@email.com', '1997-03-08'),
('Luís Machado', '10018996019', 'luis.machado@email.com', '1988-11-14'),
('Isabel Santos', '97306436015', 'isabel.santos@email.com', '1993-06-30'),
('Antônio Pereira', '09006658073', 'antonio.pereira@email.com', '1987-04-17'),
('Beatriz Almeida', '24687121020', 'beatriz.almeida@email.com', '1996-02-09'),
('Eduardo Fernandes', '26140760070', 'eduardo.fernandes@email.com', '1982-09-23'),
('Vitória Sousa', '26140760070', 'vitoria.sousa@email.com', '1990-07-28'),
('Hugo Lima', '91968796029', 'hugo.lima@email.com', '1985-05-07'),
('Mariana Costa', '91968796029', 'mariana.costa@email.com', '1998-01-11'),
('Gustavo Santos', '19551890051', 'gustavo.santos@email.com', '1989-12-03'),
('Carla Rodrigues', '36867155030', 'carla.rodrigues@email.com', '1991-04-05'),
('Roberto Silva', '55956521015', 'roberto.silva@email.com', '1983-03-19'),
('Tatiana Oliveira', '09757683019', 'tatiana.oliveira@email.com', '1980-10-14'),
('Marcelo Pereira', '19324708082', 'marcelo.pereira@email.com', '1995-08-22'),
('Sônia Santos', '89072385020', 'sonia.santos@email.com', '1987-07-26'),
('Fábio Almeida', '67200958034', 'fabio.almeida@email.com', '1993-02-18'),
('Renata Fernandes', '35750561020', 'renata.fernandes@email.com', '1981-09-07'),
('Gustavo Lima', '21871904048', 'gustavo.lima@email.com', '1994-06-03'),
('Cristina Costa', '36732344048', 'cristina.costa@email.com', '1998-11-16'),
('Rui Sousa', '56670157061', 'rui.sousa@email.com', '1986-08-29'),
('Lara Santos', '45733451084', 'lara.santos@email.com', '1989-12-12'),
('Pedro Martins', '60396295509', 'pedro.martins@email.com', '1994-03-23'),
('Carlos Rodrigues', '03762347093', 'carlos.rodrigues@email.com', '1990-03-04');


INSERT INTO Ingresso (cliente_id, sessao_id, tipo) VALUES
(44, 45, 0),
(44, 46, 0),
(44, 47, 0),
(45, 48, 1),
(45, 49, 1),
(45, 50, 1),
(46, 45, 0),
(46, 46, 0),
(46, 47, 0),
(47, 48, 1),
(47, 49, 1),
(47, 50, 1);