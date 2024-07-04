CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20),
    FechaRegistro DATETIME DEFAULT GETDATE()
);


CREATE TABLE Mesas (
    MesaID INT PRIMARY KEY IDENTITY(1,1),
    NumeroMesa INT NOT NULL,
    Capacidad INT NOT NULL,
    Ubicacion NVARCHAR(100)
);

CREATE TABLE Horarios (
    HorarioID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL
);

CREATE TABLE Reservaciones (
    ReservacionID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    MesaID INT FOREIGN KEY REFERENCES Mesas(MesaID),
    HorarioID INT FOREIGN KEY REFERENCES Horarios(HorarioID),
    FechaReservacion DATETIME DEFAULT GETDATE()
);

-- INSERT DATA

INSERT INTO Clientes (Nombre, Apellido, Email, Telefono)
VALUES ('Juan', 'Perez', 'juan.perez@example.com', '1234567890'),
       ('Maria', 'Lopez', 'maria.lopez@example.com', '0987654321');

INSERT INTO Mesas (NumeroMesa, Capacidad, Ubicacion)
VALUES (1, 4, 'Ventana'),
       (2, 2, 'Centro'),
       (3, 6, 'Patio');


INSERT INTO Horarios (Fecha, HoraInicio, HoraFin)
VALUES ('2024-07-05', '18:00', '20:00'),
       ('2024-07-05', '20:00', '22:00'),
       ('2024-07-06', '18:00', '20:00');

INSERT INTO Reservaciones (ClienteID, MesaID, HorarioID)
VALUES (1, 1, 1),
       (2, 2, 2),
       (1, 3, 3);


select * from Reservaciones;