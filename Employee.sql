CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(15),
    Department NVARCHAR(50),
    Salary DECIMAL(10, 2)
);

INSERT INTO Employees (FirstName, LastName, Email, Phone, Department, Salary)
VALUES 
('John', 'Doe', 'john.doe@example.com', '9876543210', 'HR', 50000.00),
('Jane', 'Smith', 'jane.smith@example.com', '9123456789', 'Finance', 65000.00),
('Robert', 'Brown', 'robert.brown@example.com', '9000000000', 'IT', 70000.00),
('Emily', 'Clark', 'emily.clark@example.com', '9888877777', 'Marketing', 55000.00),
('David', 'Wilson', 'david.wilson@example.com', '9112233445', 'Sales', 60000.00),
('Olivia', 'Taylor', 'olivia.taylor@example.com', '9871122334', 'IT', 72000.00),
('Liam', 'Johnson', 'liam.johnson@example.com', '9998887776', 'HR', 48000.00),
('Ava', 'Martin', 'ava.martin@example.com', '9765432100', 'Finance', 66000.00),
('Noah', 'Lee', 'noah.lee@example.com', '9555512345', 'Sales', 61000.00),
('Sophia', 'Walker', 'sophia.walker@example.com', '9898989898', 'Marketing', 57000.00);

