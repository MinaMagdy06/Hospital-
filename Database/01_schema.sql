IF DB_ID('HospitalDB') IS NULL
    CREATE DATABASE HospitalDB;
GO
USE HospitalDB;
GO

CREATE TABLE Departments (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(300) NULL,
    CONSTRAINT UQ_Departments_Name UNIQUE (Name)
);

CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NULL,
    DepartmentId INT NOT NULL,
    CONSTRAINT FK_Doctors_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);
CREATE UNIQUE INDEX UX_Doctors_Email ON Doctors(Email) WHERE Email IS NOT NULL;

CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(200) NULL,
    CONSTRAINT CK_Patients_Gender CHECK (Gender IN ('Male', 'Female')),
    CONSTRAINT UQ_Patients_NameDob UNIQUE (FullName, DateOfBirth)
);

CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME(0) NOT NULL,
    Reason NVARCHAR(200) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Scheduled',
    CONSTRAINT FK_Appointments_Patients FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    CONSTRAINT FK_Appointments_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    CONSTRAINT CK_Appointments_Status CHECK (Status IN ('Scheduled', 'Completed', 'Cancelled'))
);
CREATE UNIQUE INDEX UX_Appointments_DoctorSlot
    ON Appointments(DoctorId, AppointmentDate, AppointmentTime)
    WHERE Status <> 'Cancelled';
CREATE INDEX IX_Appointments_Date ON Appointments(AppointmentDate);
CREATE INDEX IX_Appointments_Patient ON Appointments(PatientId);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    DoctorId INT NULL,
    CONSTRAINT UQ_Users_Username UNIQUE (Username),
    CONSTRAINT CK_Users_Role CHECK (Role IN ('Admin', 'Receptionist', 'Doctor')),
    CONSTRAINT FK_Users_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
GO
