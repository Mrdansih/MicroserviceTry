CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(200) NOT NULL
);

CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(255) UNIQUE,
    ProductDescription TEXT,
    ProductCategory VARCHAR(100),
    ProductPrice DECIMAL(10,2) NOT NULL,
    ProductImageUrl VARCHAR(500)
);

INSERT INTO Products (ProductName, ProductCategory, ProductDescription, ProductPrice, ProductImageUrl)
VALUES
-- Laptops (15)
('UltraBook X1', 'Laptops', 'Lightweight and powerful laptop for professionals.', 1299.99, 'hello'),
('ProLap 14', 'Laptops', '14-inch portable laptop for work.', 1099.99, 'hello'),
('ProLap 16 Max', 'Laptops', '16-inch powerhouse laptop for creators.', 1899.99, 'hello'),
('BudgetPro Laptop', 'Laptops', 'Affordable laptop for students.', 599.99, 'hello'),
('CloudPad Mini', 'Laptops', 'Compact laptop with detachable keyboard.', 499.99, 'hello'),
('CloudPad Pro', 'Laptops', 'High-performance laptop for multitasking.', 799.99, 'hello'),
('SlimBook Air', 'Laptops', 'Ultra-thin laptop for travel.', 999.99, 'hello'),
('WorkMate Lite', 'Laptops', 'Affordable work laptop with long battery life.', 749.99, 'hello'),
('GamingBlade 15', 'Laptops', 'Gaming laptop with RGB keyboard and high refresh screen.', 1599.99, 'hello'),
('EcoLaptop', 'Laptops', 'Energy-efficient laptop with sustainable materials.', 899.99, 'hello'),
('MaxBook Pro', 'Laptops', 'High-end laptop with 4K screen.', 2199.99, 'hello'),
('NanoBook X', 'Laptops', 'Ultra-light and compact laptop.', 699.99, 'hello'),
('EliteBook Studio', 'Laptops', 'Powerful laptop for creatives and developers.', 1799.99, 'hello'),
('VisionAir Laptop', 'Laptops', 'Lightweight laptop for productivity.', 1299.99, 'hello'),
('QuickStart Laptop', 'Laptops', 'Entry-level laptop for everyday tasks.', 499.99, 'hello'),

-- Desktops (15)
('ProGamer Z500', 'Desktops', 'High-performance desktop built for gaming.', 1799.50, 'hello'),
('WorkMate Elite', 'Desktops', 'Reliable desktop designed for office productivity.', 999.00, 'hello'),
('Gaming Station RGB', 'Desktops', 'Custom gaming station with water cooling.', 2399.99, 'hello'),
('CompactMini PC', 'Desktops', 'Compact mini-PC for small spaces.', 699.99, 'hello'),
('GameTower PC', 'Desktops', 'Ultimate high-end gaming PC tower.', 2599.99, 'hello'),
('OfficeStation', 'Desktops', 'Desktop optimized for office use.', 799.99, 'hello'),
('SpeedWork PC', 'Desktops', 'Fast and reliable desktop for productivity.', 1199.99, 'hello'),
('DesignerBox', 'Desktops', 'Workstation desktop for creative professionals.', 2199.99, 'hello'),
('StarterBox', 'Desktops', 'Affordable desktop for beginners.', 499.99, 'hello'),
('SilentPC Tower', 'Desktops', 'Silent high-performance desktop tower.', 1399.99, 'hello'),
('HyperCore Mini', 'Desktops', 'Compact desktop with powerful specs.', 899.99, 'hello'),
('CloudBox Server', 'Desktops', 'Small server desktop for home labs.', 1499.99, 'hello'),
('Performance Cube', 'Desktops', 'Cube desktop with powerful cooling.', 1899.99, 'hello'),
('BudgetBox', 'Desktops', 'Entry-level desktop for home and school.', 449.99, 'hello'),
('CreatorPro Tower', 'Desktops', 'Tower desktop for 3D rendering and editing.', 2299.99, 'hello'),

-- Keyboards (15)
('TypeMaster Pro', 'Keyboards', 'Mechanical keyboard with RGB lighting.', 129.99, 'hello'),
('SilentType Slim', 'Keyboards', 'Slim wireless keyboard with silent keys.', 79.99, 'hello'),
('HyperKey TKL', 'Keyboards', 'Compact TKL mechanical keyboard.', 109.99, 'hello'),
('NanoKey Keyboard', 'Keyboards', 'Mini mechanical keyboard for travel.', 89.99, 'hello'),
('OfficeMate Keyboard', 'Keyboards', 'Silent office keyboard with numeric pad.', 59.99, 'hello'),
('SpeedType Wireless', 'Keyboards', 'Wireless keyboard with fast response.', 99.99, 'hello'),
('ProWriter', 'Keyboards', 'Ergonomic keyboard for writers.', 119.99, 'hello'),
('RGB Clicker', 'Keyboards', 'RGB gaming keyboard with macro keys.', 149.99, 'hello'),
('TravelBoard', 'Keyboards', 'Portable wireless keyboard for tablets.', 49.99, 'hello'),
('UltraKeys Slim', 'Keyboards', 'Thin keyboard with quiet keys.', 69.99, 'hello'),
('GamerKeys', 'Keyboards', 'Mechanical keyboard with programmable switches.', 159.99, 'hello'),
('StudioBoard', 'Keyboards', 'Creative keyboard for audio and video editing.', 199.99, 'hello'),
('Compact Wireless', 'Keyboards', 'Compact wireless keyboard for portability.', 89.99, 'hello'),
('NumericPad Plus', 'Keyboards', 'Standalone numeric keypad.', 39.99, 'hello'),
('HyperOffice Board', 'Keyboards', 'Business keyboard with shortcut keys.', 109.99, 'hello'),

-- Accessories (15)
('USB-C Dock Plus', 'Accessories', 'Multiport USB-C dock with HDMI and Ethernet.', 149.99, 'hello'),
('HD Webcam 1080p', 'Accessories', 'Full HD webcam with noise-cancelling mic.', 89.99, 'hello'),
('SoundBlast Pro', 'Accessories', 'Wireless noise-cancelling headphones.', 249.99, 'hello'),
('TrackPad Pro', 'Accessories', 'Multi-touch trackpad for creatives.', 129.99, 'hello'),
('USB Hub Extreme', 'Accessories', '12-port USB hub with smart charging.', 79.99, 'hello'),
('SmartDock Hub', 'Accessories', 'Docking hub with 100W charging.', 129.99, 'hello'),
('HyperDesk Mat', 'Accessories', 'RGB desk mat for gaming setup.', 49.99, 'hello'),
('ThunderLink Cable', 'Accessories', 'High-speed Thunderbolt cable.', 39.99, 'hello'),
('GamePro Mouse Pad', 'Accessories', 'Large RGB mouse pad.', 29.99, 'hello'),
('ProSound Bar', 'Accessories', 'Compact soundbar for desktops.', 129.99, 'hello'),
('VR Headset X', 'Accessories', 'Next-gen VR headset for gaming.', 599.99, 'hello'),
('FastCharge Pro', 'Accessories', '65W USB-C charger for laptops and phones.', 59.99, 'hello'),
('Precision Pen', 'Accessories', 'Digital pen for tablets and touchscreen laptops.', 69.99, 'hello'),
('UltraWeb Camera', 'Accessories', 'Full HD webcam with AI autofocus.', 99.99, 'hello'),
('PowerDock 10-in-1', 'Accessories', 'Dock with 10 essential ports.', 159.99, 'hello');
