CREATE TABLE EstudanteNotas (
    Id INT PRIMARY KEY IDENTITY(1,1), -- O Id da nota tambem sera auto-incrementado
    EstudanteId INT NOT NULL,
    Disciplina NVARCHAR(100) NOT NULL,
    Nota DECIMAL(4,2) NOT NULL, --total de digitos \ numeros depois da virgula
    CONSTRAINT FK_EstudanteNotas_Estudantes FOREIGN KEY (EstudanteId) REFERENCES Estudantes(Id)
);