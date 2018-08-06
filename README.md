# sProcomALE
Aplicativo ASP.NET para a comissão de Defesa do Consumidor da ALE-AM

Ferramenta de Desenvolvimento:  VISUAL STUDIO 2015
Linguagem de Programação: VB.NET / ASP.NET
Banco de DADOS: MYSQL
Ferramenta de relatórios: Crystal Reports for VS 2015

1. Dados de configuração
O servidor utilizado nesta aplicação é o Windows Server 2012. O IIS deste servidor foi configurado somente par 
uso interno na Câmara Legislativa da casa. 

2. Esta aplicação foi criada para uso da Comissão de Defesa do Consumidor e com uso somente interno, acessível da intranet da ALE-AM (http://intranet.aleam.gov.br) que funciona somente internamente nos prédios da Casa Legislativa. A mesma foi desenvovida baseadas nas inúmeras planilhas utilizadas pelos atendentes de modo geral para a anotação das reclamações e a devida geração de informações sobre as reclamações realizadas a empresas. 

3. BANCO DE DADOS: MYSQL
----------------------

CRIAÇÃO DO BANCO DE DADOS:
`proconaleam`.CREATE DATABASE `proconaleam` /*!40100 DEFAULT CHARACTER SET latin1 */;

TABELAS DA APLICAÇÃO

DROP TABLE IF EXISTS `proconaleam`.`motivo`;
CREATE TABLE  `proconaleam`.`motivo` (
  `codmotivo` varchar(5) NOT NULL DEFAULT '',
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codmotivo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


DROP TABLE IF EXISTS `proconaleam`.`reclamacao`;
CREATE TABLE  `proconaleam`.`reclamacao` (
  `codreclamacao` varchar(5) NOT NULL DEFAULT '',
  `codreclamante` varchar(5) NOT NULL DEFAULT '',
  `codreclamado` varchar(5) NOT NULL DEFAULT '',
  `codmotivo` varchar(35) NOT NULL DEFAULT '',
  `fatoocorrido` text,
  `pedido` text,
  `dataaudiencia` varchar(10) DEFAULT NULL,
  `hora` varchar(10) DEFAULT NULL,
  `atendente` varchar(45) DEFAULT NULL,
  `nomereclamante` varchar(75) DEFAULT NULL,
  `nomereclamado` varchar(75) DEFAULT NULL,
  `datareclamacao` varchar(20) DEFAULT NULL,
  `Notificacao` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`codreclamacao`,`codreclamante`,`codreclamado`,`codmotivo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


DROP TABLE IF EXISTS `proconaleam`.`reclamado`;
CREATE TABLE  `proconaleam`.`reclamado` (
  `codigo` varchar(5) NOT NULL DEFAULT '',
  `reclamado` varchar(75) DEFAULT NULL,
  `CNPJ` varchar(20) DEFAULT NULL,
  `CPF` varchar(15) DEFAULT NULL,
  `endereco` varchar(47) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cep` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `uf` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `proconaleam`.`reclamante`;
CREATE TABLE  `proconaleam`.`reclamante` (
  `codreclamante` varchar(5) NOT NULL DEFAULT '',
  `reclamante` varchar(70) DEFAULT NULL,
  `datanasc` varchar(20) DEFAULT NULL,
  `naturalidade` varchar(45) DEFAULT NULL,
  `rg` varchar(10) DEFAULT NULL,
  `cpf` varchar(15) DEFAULT NULL,
  `estadocivil` varchar(15) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `filiacao` varchar(75) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `contato` varchar(20) DEFAULT NULL,
  `cep` varchar(15) DEFAULT NULL,
  `profissao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codreclamante`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


DROP TABLE IF EXISTS `proconaleam`.`usuario`;
CREATE TABLE  `proconaleam`.`usuario` (
  `login` varchar(20) NOT NULL DEFAULT '',
  `senha` varchar(15) DEFAULT NULL,
  `nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



