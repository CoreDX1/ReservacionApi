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

--- DELETE TABLE --

DROP TABLE Clientes;
DROP TABLE Horarios;
DROP TABLE Mesas;
DROP TABLE Reservaciones;