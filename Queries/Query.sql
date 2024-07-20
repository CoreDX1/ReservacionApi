CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    EmailVerified BIT DEFAULT 0,
    FullName NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE Properties (
    PropertyID INT PRIMARY KEY IDENTITY(1,1),
    OwnerID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(100),
    State NVARCHAR(100),
    Country NVARCHAR(100),
    AverageRating DECIMAL(3, 2),
    PricePerNight DECIMAL(10, 2) NOT NULL,
    MaxGuests INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (OwnerID) REFERENCES Users(UserID)
);


CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    PropertyID INT NOT NULL,
    UserID INT NOT NULL,
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PropertyID) REFERENCES Properties(PropertyID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50),
    TransactionID NVARCHAR(100),
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID)
);

CREATE TABLE PropertyImages (
    ImageID INT PRIMARY KEY IDENTITY(1,1),
    PropertyID INT NOT NULL,
    ImageURL NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PropertyID) REFERENCES Properties(PropertyID)
);

CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    PropertyID INT NOT NULL,
    UserID INT NOT NULL,
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    Comment NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PropertyID) REFERENCES Properties(PropertyID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

--- AMENITIES ---
CREATE TABLE Amenities (
    AmenityID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE PropertyAmenities (
    PropertyID INT NOT NULL,
    AmenityID INT NOT NULL,
    PRIMARY KEY (PropertyID, AmenityID),
    FOREIGN KEY (PropertyID) REFERENCES Properties(PropertyID),
    FOREIGN KEY (AmenityID) REFERENCES Amenities(AmenityID)
);


--- LOGIN AND AUTHENTICATION ---

CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);

CREATE TABLE UserRoles (
    UserID INT NOT NULL,
    RoleID INT NOT NULL,
    PRIMARY KEY (UserID, RoleID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE Tokens (
    TokenID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Token NVARCHAR(255) NOT NULL,
    Expiration DATETIME NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE LoginAttempts (
    AttemptID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    AttemptTime DATETIME DEFAULT GETDATE(),
    Success BIT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE PasswordResets (
    ResetID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ResetToken NVARCHAR(255) NOT NULL,
    Expiration DATETIME NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


--- INSERT DATA ---

INSERT INTO Users (Email, PasswordHash,UserName, FullName, EmailVerified)
VALUES ('W4wUq@example.com', 'password', 'admin', 'Admin User', 1);

INSERT INTO Users (Email, PasswordHash, UserName, FullName, EmailVerified)
VALUES 
('jdoe@example.com', 'password1', 'jdoe', 'John Doe', 1),
('asmith@example.com', 'password2', 'asmith', 'Alice Smith', 1),
('bwhite@example.com', 'password3', 'bwhite', 'Bob White', 1),
('cmiller@example.com', 'password4', 'cmiller', 'Chris Miller', 1),
('djohnson@example.com', 'password5', 'djohnson', 'Diane Johnson', 1),
('ewilliams@example.com', 'password6', 'ewilliams', 'Evan Williams', 1),
('ffox@example.com', 'password7', 'ffox', 'Fiona Fox', 1),
('ggreen@example.com', 'password8', 'ggreen', 'George Green', 1),
('hclark@example.com', 'password9', 'hclark', 'Hannah Clark', 1),
('ijones@example.com', 'password10', 'ijones', 'Ian Jones', 1),
('klee@example.com', 'password11', 'klee', 'Karen Lee', 1),
('lmorgan@example.com', 'password12', 'lmorgan', 'Liam Morgan', 1),
('mreyes@example.com', 'password13', 'mreyes', 'Maria Reyes', 1),
('nmartin@example.com', 'password14', 'nmartin', 'Nina Martin', 1),
('operez@example.com', 'password15', 'operez', 'Oscar Perez', 1),
('prussell@example.com', 'password16', 'prussell', 'Paul Russell', 1),
('qsanders@example.com', 'password17', 'qsanders', 'Quincy Sanders', 1),
('rturner@example.com', 'password18', 'rturner', 'Rachel Turner', 1),
('swalker@example.com', 'password19', 'swalker', 'Sam Walker', 1),
('tking@example.com', 'password20', 'tking', 'Tina King', 1);



SELECT * FROM Users;

DELETE FROM Users
WHERE UserID IN (28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41);
