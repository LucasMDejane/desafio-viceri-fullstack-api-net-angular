CREATE TABLE Estudantes (
    Id INT PRIMARY KEY IDENTITY(1,1), --id auto-incrementado \ começando em 1 e aumentando de 1 em 1
    Nome NVARCHAR(100) NOT NULL,
    Idade INT NOT NULL
)