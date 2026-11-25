USE HospitalDB;
GO

INSERT INTO Departments (Name, Description) VALUES
('Cardiology', 'Heart and blood vessel care'),
('Pediatrics', 'Medical care for children'),
('Orthopedics', 'Bones, joints, and muscles'),
('Dermatology', 'Skin, hair, and nails'),
('General Medicine', 'General check-ups and common illnesses');

INSERT INTO Doctors (FullName, Specialization, Phone, Email, DepartmentId) VALUES
('Dr. Ahmed Hassan', 'Cardiologist', '01012345601', 'ahmed.hassan@hospital.com', 1),
('Dr. Mona Samir', 'Pediatrician', '01012345602', 'mona.samir@hospital.com', 2),
('Dr. Karim Adel', 'Orthopedic Surgeon', '01012345603', 'karim.adel@hospital.com', 3),
('Dr. Nada Fathy', 'Dermatologist', '01012345604', 'nada.fathy@hospital.com', 4),
('Dr. Omar Khaled', 'General Practitioner', '01012345605', 'omar.khaled@hospital.com', 5),
('Dr. Salma Youssef', 'Cardiologist', '01012345606', 'salma.youssef@hospital.com', 1);

INSERT INTO Patients (FullName, DateOfBirth, Gender, Phone, Email, Address) VALUES
('Mohamed Ali', '1985-03-12', 'Male', '01122334401', 'mohamed.ali@mail.com', 'Cairo'),
('Sara Mahmoud', '1992-07-25', 'Female', '01122334402', 'sara.mahmoud@mail.com', 'Giza'),
('Youssef Tarek', '2015-01-09', 'Male', '01122334403', NULL, 'Fayoum'),
('Hana Ibrahim', '1978-11-30', 'Female', '01122334404', 'hana.ibrahim@mail.com', 'Alexandria'),
('Khaled Nabil', '1965-05-18', 'Male', '01122334405', NULL, 'Cairo'),
('Mariam Adel', '2001-09-02', 'Female', '01122334406', 'mariam.adel@mail.com', 'Giza'),
('Omar Fouad', '1999-12-21', 'Male', '01122334407', 'omar.fouad@mail.com', 'Fayoum'),
('Laila Samy', '1988-04-14', 'Female', '01122334408', NULL, 'Cairo'),
('Ziad Hesham', '2012-06-06', 'Male', '01122334409', NULL, 'Giza'),
('Nour Gamal', '1995-08-27', 'Female', '01122334410', 'nour.gamal@mail.com', 'Alexandria');

DECLARE @today DATE = CAST(GETDATE() AS DATE);
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status) VALUES
(1, 1, DATEADD(DAY, -60, @today), '09:00', 'Chest pain check', 'Completed'),
(2, 1, DATEADD(DAY, -45, @today), '10:30', 'Blood pressure follow-up', 'Completed'),
(3, 2, DATEADD(DAY, -40, @today), '09:30', 'Child vaccination', 'Completed'),
(4, 3, DATEADD(DAY, -35, @today), '11:00', 'Knee pain', 'Completed'),
(5, 4, DATEADD(DAY, -30, @today), '12:00', 'Skin rash', 'Completed'),
(6, 5, DATEADD(DAY, -20, @today), '09:00', 'General check-up', 'Completed'),
(7, 2, DATEADD(DAY, -15, @today), '10:00', 'Fever in child', 'Cancelled'),
(8, 6, DATEADD(DAY, -10, @today), '14:00', 'Heart check-up', 'Completed'),
(9, 1, DATEADD(DAY, 1, @today), '09:00', 'ECG test', 'Scheduled'),
(10, 3, DATEADD(DAY, 2, @today), '10:30', 'Back pain', 'Scheduled'),
(1, 5, DATEADD(DAY, 3, @today), '11:30', 'Flu symptoms', 'Scheduled'),
(2, 4, DATEADD(DAY, 4, @today), '13:00', 'Allergy review', 'Scheduled'),
(3, 2, DATEADD(DAY, 5, @today), '09:30', 'Growth check', 'Scheduled'),
(4, 6, DATEADD(DAY, 7, @today), '15:00', 'Blood pressure', 'Scheduled');

INSERT INTO Users (Username, Password, Role, DoctorId) VALUES
('admin', 'admin123', 'Admin', NULL),
('reception', 'reception123', 'Receptionist', NULL),
('dr.ahmed', 'doctor123', 'Doctor', 1);
GO
