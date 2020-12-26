CREATE DATABASE `db_travelmanager` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

-- db_travelmanager.usuario definition

CREATE TABLE `usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nome_completo` varchar(100) NOT NULL,
  `data_nascimento` datetime NOT NULL,
  `login` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  `tipo` int NOT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- db_travelmanager.pacote_turistico definition

CREATE TABLE `pacote_turistico` (
  `id_pacote_turistico` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `origem` varchar(100) NOT NULL,
  `destino` varchar(100) NOT NULL,
  `atrativos` varchar(100) NOT NULL,
  `saida` datetime NOT NULL,
  `retorno` datetime NOT NULL,
  `cod_usuario_criacao` int NOT NULL,
  PRIMARY KEY (`id_pacote_turistico`),
  KEY `pacote_turistico_FK` (`cod_usuario_criacao`),
  CONSTRAINT `pacote_turistico_FK` FOREIGN KEY (`cod_usuario_criacao`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;