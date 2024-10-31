-- Kiểm tra và tạo Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DoAn')
BEGIN
    CREATE DATABASE DoAn;
END
GO

USE DoAn;

-- Bảng ConservationStatus (Tình trạng bảo tồn)
CREATE TABLE ConservationStatus (
    Status_ID INT PRIMARY KEY,
    Status_Name VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Bảng Diet (Chế độ ăn)
CREATE TABLE Diet (
    Diet_ID INT PRIMARY KEY,
    Diet_Type NVARCHAR(255) NOT NULL,
    Description TEXT
);

-- Bảng Regions (Khu vực)
CREATE TABLE Regions (
    Region_ID INT PRIMARY KEY,
    Region_Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Climate VARCHAR(255)
);

-- Bảng Habitat (Môi trường sống)
CREATE TABLE Habitat (
    Habitat_ID INT PRIMARY KEY,
    Habitat_Type VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Bảng Animals (Động vật)
CREATE TABLE Animals (
    ID INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Habitat_ID INT,
    Conservation_Status INT,
    Diet INT,
    Lifespan VARCHAR(50),
    Size VARCHAR(50),
    Image_URL VARCHAR(255),
    Region INT,
    FOREIGN KEY (Conservation_Status) REFERENCES ConservationStatus(Status_ID) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (Diet) REFERENCES Diet(Diet_ID) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (Region) REFERENCES Regions(Region_ID) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (Habitat_ID) REFERENCES Habitat(Habitat_ID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Bảng Comments (Bình luận)
CREATE TABLE Comments (
    Comment_ID INT PRIMARY KEY,
    User_ID INT,
    Animal_ID INT,
    Comment_Text TEXT,
    Date_Posted DATETIME,
    FOREIGN KEY (Animal_ID) REFERENCES Animals(ID) ON DELETE CASCADE ON UPDATE CASCADE
);


-- Bảng Articles (Bài viết)
CREATE TABLE Articles (
    Article_ID INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Content TEXT,
    Author VARCHAR(255),
    Date_Published DATETIME,
    Animal_ID INT,
    FOREIGN KEY (Animal_ID) REFERENCES Animals(ID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Thêm dữ liệu vào bảng ConservationStatus
INSERT INTO ConservationStatus (Status_ID, Status_Name, Description) VALUES
(1, 'Nguy cấp', 'Loài đang bị đe dọa nghiêm trọng và có nguy cơ tuyệt chủng.'),
(2, 'Ít nguy cơ', 'Loài có số lượng ổn định và không bị đe dọa.'),
(3, 'Sắp nguy cấp', 'Loài có nguy cơ tuyệt chủng trong tương lai gần.');

-- Thêm dữ liệu vào bảng Diet
INSERT INTO Diet (Diet_ID, Diet_Type, Description) VALUES
(1, 'Thịt', 'Động vật ăn thịt'),
(2, 'Thực vật', 'Động vật ăn thực vật'),
(3, 'Thực vật và thịt', 'Động vật ăn cả thực vật và thịt.');

-- Thêm dữ liệu vào bảng Regions
INSERT INTO Regions (Region_ID, Region_Name, Description, Climate) VALUES
(1, 'Rừng nhiệt đới', 'Khu vực rừng rậm ẩm ướt với sự đa dạng sinh học cao.', 'Nóng ẩm'),
(2, 'Sa mạc', 'Khu vực có khí hậu khô hạn, ít mưa.', 'Khô và nóng'),
(3, 'Đồng bằng', 'Khu vực bằng phẳng với đất màu mỡ.', 'Ôn hòa');

-- Thêm dữ liệu vào bảng Habitat
INSERT INTO Habitat (Habitat_ID, Habitat_Type, Description) VALUES
(1, 'Rừng', 'Môi trường sống chủ yếu là cây cối.'),
(2, 'Biển', 'Môi trường sống dưới nước với đa dạng sinh vật.'),
(3, 'Savanna', 'Môi trường sống có cỏ và cây rải rác.');

-- Thêm dữ liệu vào bảng Animals
INSERT INTO Animals (ID, Name, Description, Habitat_ID, Conservation_Status, Diet, Lifespan, Size, Image_URL, Region) VALUES
(1, 'Hổ', 'Một loài động vật ăn thịt lớn thuộc họ mèo.', 1, 1, 1, '10-15 năm', 'Lớn', 'https://example.com/tiger.jpg', 1),
(2, 'Voi', 'Loài động vật lớn nhất trên cạn.', 3, 2, 3, '60-70 năm', 'Rất lớn', 'https://example.com/elephant.jpg', 2),
(3, 'Cá mập', 'Một loài cá ăn thịt sống dưới biển.', 2, 3, 1, '20-30 năm', 'Lớn', 'https://example.com/shark.jpg', 3);

-- Thêm dữ liệu vào bảng Comments
INSERT INTO Comments (Comment_ID, User_ID, Animal_ID, Comment_Text, Date_Posted) VALUES
(1, 1, 1, 'Hổ là một loài động vật rất mạnh mẽ!', '2024-10-30 10:00:00'),
(2, 2, 2, 'Tôi yêu voi! Chúng rất thông minh.', '2024-10-30 11:00:00');

-- Thêm dữ liệu vào bảng Media
INSERT INTO Media (Media_ID, Animal_ID, Media_Type, URL) VALUES
(1, 1, 'Hình ảnh', 'https://example.com/tiger-image.jpg'),
(2, 2, 'Video', 'https://example.com/elephant-video.mp4');

-- Thêm dữ liệu vào bảng Articles
INSERT INTO Articles (Article_ID, Title, Content, Author, Date_Published, Animal_ID) VALUES
(1, 'Đặc điểm của loài hổ', 'Hổ là một trong những loài động vật ăn thịt lớn nhất trên thế giới.', 'Nguyễn Văn A', '2024-10-25 09:00:00', 1),
(2, 'Voi: Những điều thú vị', 'Voi là loài động vật xã hội và rất thông minh.', 'Trần Thị B', '2024-10-26 09:00:00', 2);
