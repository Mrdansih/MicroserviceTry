CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(200) NOT NULL
);

CREATE TABLE Orders (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProductId INT NOT NULL,
    CustomerName VARCHAR(50),
    Quantity INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(255) UNIQUE,
    ProductDescription TEXT,
    ProductCategory VARCHAR(100),
    ProductPrice DECIMAL(10,2) NOT NULL,
    ProductQuantity INT NOT NULL,
    ProductImageUrl VARCHAR(500)
);

INSERT INTO Products (ProductName, ProductDescription, ProductCategory, ProductPrice, ProductQuantity, ProductImageUrl)
VALUES
-- Laptops (15)
('UltraBook X1', 'Lightweight and powerful laptop for professionals.', 'Laptops', 1299.99, 100, 'hello'),
('ProLap 14', '14-inch portable laptop for work.', 'Laptops', 1099.99, 100, 'hello'),
('ProLap 16 Max', '16-inch powerhouse laptop for creators.', 'Laptops', 1899.99, 100, 'hello'),
('BudgetPro Laptop', 'Affordable laptop for students.', 'Laptops', 599.99, 100, 'hello'),
('CloudPad Mini', 'Compact laptop with detachable keyboard.', 'Laptops', 499.99, 100, 'hello'),
('CloudPad Pro', 'High-performance laptop for multitasking.', 'Laptops', 799.99, 100, 'hello'),
('SlimBook Air', 'Ultra-thin laptop for travel.', 'Laptops', 999.99, 100, 'hello'),
('WorkMate Lite', 'Affordable work laptop with long battery life.', 'Laptops', 749.99, 100, 'hello'),
('GamingBlade 15', 'Gaming laptop with RGB keyboard and high refresh screen.', 'Laptops', 1599.99, 100, 'hello'),
('EcoLaptop', 'Energy-efficient laptop with sustainable materials.', 'Laptops', 899.99, 100, 'hello'),
('MaxBook Pro', 'High-end laptop with 4K screen.', 'Laptops', 2199.99, 100, 'hello'),
('NanoBook X', 'Ultra-light and compact laptop.', 'Laptops', 699.99, 100, 'hello'),
('EliteBook Studio', 'Powerful laptop for creatives and developers.', 'Laptops', 1799.99, 100, 'hello'),
('VisionAir Laptop', 'Lightweight laptop for productivity.', 'Laptops', 1299.99, 100, 'hello'),
('QuickStart Laptop', 'Entry-level laptop for everyday tasks.', 'Laptops', 499.99, 100, 'hello'),

-- Desktops (15)
('ProGamer Z500', 'High-performance desktop built for gaming.', 'Desktops', 1799.50, 100, 'hello'),
('WorkMate Elite', 'Reliable desktop designed for office productivity.', 'Desktops', 999.00, 100, 'hello'),
('Gaming Station RGB', 'Custom gaming station with water cooling.', 'Desktops', 2399.99, 100, 'hello'),
('CompactMini PC', 'Compact mini-PC for small spaces.', 'Desktops', 699.99, 100, 'hello'),
('GameTower PC', 'Ultimate high-end gaming PC tower.', 'Desktops', 2599.99, 100, 'hello'),
('OfficeStation', 'Desktop optimized for office use.', 'Desktops', 799.99, 100, 'hello'),
('SpeedWork PC', 'Fast and reliable desktop for productivity.', 'Desktops', 1199.99, 100, 'hello'),
('DesignerBox', 'Workstation desktop for creative professionals.', 'Desktops', 2199.99, 100, 'hello'),
('StarterBox', 'Affordable desktop for beginners.', 'Desktops', 499.99, 100, 'hello'),
('SilentPC Tower', 'Silent high-performance desktop tower.', 'Desktops', 1399.99, 100, 'hello'),
('HyperCore Mini', 'Compact desktop with powerful specs.', 'Desktops', 899.99, 100, 'hello'),
('CloudBox Server', 'Small server desktop for home labs.', 'Desktops', 1499.99, 100, 'hello'),
('Performance Cube', 'Cube desktop with powerful cooling.', 'Desktops', 1899.99, 100, 'hello'),
('BudgetBox', 'Entry-level desktop for home and school.', 'Desktops', 449.99, 100, 'hello'),
('CreatorPro Tower', 'Tower desktop for 3D rendering and editing.', 'Desktops', 2299.99, 100, 'hello'),

-- Keyboards (15)
('TypeMaster Pro', 'Mechanical keyboard with RGB lighting.', 'Keyboards', 129.99, 100, 'hello'),
('SilentType Slim', 'Slim wireless keyboard with silent keys.', 'Keyboards', 79.99, 100, 'hello'),
('HyperKey TKL', 'Compact TKL mechanical keyboard.', 'Keyboards', 109.99, 100, 'hello'),
('NanoKey Keyboard', 'Mini mechanical keyboard for travel.', 'Keyboards', 89.99, 100, 'hello'),
('OfficeMate Keyboard', 'Silent office keyboard with numeric pad.', 'Keyboards', 59.99, 100, 'hello'),
('SpeedType Wireless', 'Wireless keyboard with fast response.', 'Keyboards', 99.99, 100, 'hello'),
('ProWriter', 'Ergonomic keyboard for writers.', 'Keyboards', 119.99, 100, 'hello'),
('RGB Clicker', 'RGB gaming keyboard with macro keys.', 'Keyboards', 149.99, 100, 'hello'),
('TravelBoard', 'Portable wireless keyboard for tablets.', 'Keyboards', 49.99, 100, 'hello'),
('UltraKeys Slim', 'Thin keyboard with quiet keys.', 'Keyboards', 69.99, 100, 'hello'),
('GamerKeys', 'Mechanical keyboard with programmable switches.', 'Keyboards', 159.99, 100, 'hello'),
('StudioBoard', 'Creative keyboard for audio and video editing.', 'Keyboards', 199.99, 100, 'hello'),
('Compact Wireless', 'Compact wireless keyboard for portability.', 'Keyboards', 89.99, 100, 'hello'),
('NumericPad Plus', 'Standalone numeric keypad.', 'Keyboards', 39.99, 100, 'hello'),
('HyperOffice Board', 'Business keyboard with shortcut keys.', 'Keyboards', 109.99, 100, 'hello'),

-- Accessories (15)
('USB-C Dock Plus', 'Multiport USB-C dock with HDMI and Ethernet.', 'Accessories', 149.99, 100, 'hello'),
('HD Webcam 1080p', 'Full HD webcam with noise-cancelling mic.', 'Accessories', 89.99, 100, 'hello'),
('SoundBlast Pro', 'Wireless noise-cancelling headphones.', 'Accessories', 249.99, 100, 'hello'),
('TrackPad Pro', 'Multi-touch trackpad for creatives.', 'Accessories', 129.99, 100, 'hello'),
('USB Hub Extreme', '12-port USB hub with smart charging.', 'Accessories', 79.99, 100, 'hello'),
('SmartDock Hub', 'Docking hub with 100W charging.', 'Accessories', 129.99, 100, 'hello'),
('HyperDesk Mat', 'RGB desk mat for gaming setup.', 'Accessories', 49.99, 100, 'hello'),
('ThunderLink Cable', 'High-speed Thunderbolt cable.', 'Accessories', 39.99, 100, 'hello'),
('GamePro Mouse Pad', 'Large RGB mouse pad.', 'Accessories', 29.99, 100, 'hello'),
('ProSound Bar', 'Compact soundbar for desktops.', 'Accessories', 129.99, 100, 'hello'),
('VR Headset X', 'Next-gen VR headset for gaming.', 'Accessories', 599.99, 100, 'hello'),
('FastCharge Pro', '65W USB-C charger for laptops and phones.', 'Accessories', 59.99, 100, 'hello'),
('Precision Pen', 'Digital pen for tablets and touchscreen laptops.', 'Accessories', 69.99, 100, 'hello'),
('UltraWeb Camera', 'Full HD webcam with AI autofocus.', 'Accessories', 99.99, 100, 'hello'),
('PowerDock 10-in-1', 'Dock with 10 essential ports.', 'Accessories', 159.99, 100, 'hello');

