use FiapSmartCity

CREATE TABLE PESSOA (
      ID    int identity(1,1)        PRIMARY KEY,
      NOME VARCHAR(50)  NOT NULL,
      ENDERECO  VARCHAR(50)  NOT NULL);