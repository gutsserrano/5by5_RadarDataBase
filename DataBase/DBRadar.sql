USE DBRadar
GO

CREATE TABLE Radar
(
    id INT IDENTITY(1,1) NOT NUll,
    concessionaria VARCHAR(60) NOT NUll, 
    ano_do_pnv_snv INT NOT NUll, 
    tipo_de_radar VARCHAR(20) NOT NUll, 
    rodovia VARCHAR(20) NOT NUll, 
    uf CHAR(2) NOT NULL, 
    km_m NUMERIC(6, 3) NOT NULL, 
    municipio VARCHAR(60) NOT NULL, 
    tipo_pista VARCHAR(20) NOT NULL, 
    sentido VARCHAR(20) NOT NULL, 
    situacao VARCHAR(15) NOT NULL, 
    data_da_inativacao DATE,
    latitude NUMERIC(8, 6), 
    longitude NUMERIC(8, 6), 
    velocidade_leve int NOT NULL,
    CONSTRAINT pkradar PRIMARY KEY (id)
)
GO