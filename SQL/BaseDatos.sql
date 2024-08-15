
CREATE DATABASE Biblioteca;
GO
use Biblioteca
GO
CREATE TABLE Editorial (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) unique,
    Estado BIT DEFAULT 1
);
GO
CREATE TABLE Country (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL unique,
    Estado BIT DEFAULT 1
);
GO
CREATE TABLE Language (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Genrer (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);
GO
CREATE TABLE Sex (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Sex VARCHAR(100) NOT NULL unique
);
GO
CREATE TABLE Rol (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Rol VARCHAR(100) NOT NULL unique
);
GO
CREATE TABLE [Users] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	IdSex INT FOREIGN KEY REFERENCES Sex(Id),
    Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    email VARCHAR(100) unique NOT NULL,
    UserPassword VARCHAR(100) NOT NULL,
    IdRol INT FOREIGN KEY REFERENCES Rol(Id),
    Estate BIT DEFAULT 1
);
GO
CREATE TABLE Author (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    IdSex INT FOREIGN KEY REFERENCES Sex(Id),
    IdCountry INT FOREIGN KEY REFERENCES Country(Id),
    Estate BIT DEFAULT 1
);
GO
CREATE TABLE Cover (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Img NVARCHAR(100) NOT NULL
);
GO
CREATE TABLE Book (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
	Description NVarchar(200),
    IdCover INT FOREIGN KEY REFERENCES Cover(Id),
    IdEditorial INT FOREIGN KEY REFERENCES Editorial(Id),
    IdGenrer INT FOREIGN KEY REFERENCES Genrer(Id),
    IdAuthor INT FOREIGN KEY REFERENCES Author(Id),
    IdLanguage INT FOREIGN KEY REFERENCES Language(Id),
    Year int NULL,
    NumberPages INT NULL,
    Estate BIT DEFAULT 1
);
GO

INSERT INTO Editorial (Name) VALUES 
('Planeta'), 
('Penguin Random House'), 
('HarperCollins'), 
('Ediciones B'), 
('Anaya'), 
('Salamandra'), 
('Alfaguara'), 
('Destino'), 
('Espasa'), 
('Roca');
GO

INSERT INTO Country (Name) VALUES
('España'),
('Estados Unidos'),
('Reino Unido'),
('México'),
('Argentina'),
('Colombia'),
('Francia'),
('Italia'),
('Alemania'),
('Japón');
GO

INSERT INTO Language (Name) VALUES
('Español'),
('Inglés'),
('Francés'),
('Italiano'),
('Alemán');
GO

INSERT INTO Genrer (Name) VALUES
('Novela'),
('Ciencia Ficción'),
('Fantasía'),
('Romance'),
('Terror'),
('Misterio'),
('Historia'),
('Biografía'),
('Autoayuda'),
('Filosofía');
GO

INSERT INTO Sex (Sex) VALUES
('Masculino'),
('Femenino');
GO

INSERT INTO Rol (Rol) VALUES
('Administrador'),
('Usuario');
GO

INSERT INTO Author (Name, IdSex, IdCountry) VALUES
('Stephen King', 1, 2),
('J.K. Rowling', 2, 3),
('George Orwell', 1, 3),
('Gabriel García Márquez', 1, 4),
('Paulo Coelho', 1, 5),
('Haruki Murakami', 1, 9),
('Margaret Atwood', 2, 2),
('Jane Austen', 2, 3),
('Dan Brown', 1, 2),
('Ken Follett', 1, 3),
('Ernest Hemingway', 1, 2),
('F. Scott Fitzgerald', 1, 2),
('Virginia Woolf', 2, 3),
('William Faulkner', 1, 2),
('Toni Morrison', 2, 2),
('Maya Angelou', 2, 2),
('Emily Dickinson', 2, 2),
('Walt Whitman', 1, 2),
('Edgar Allan Poe', 1, 2),
('Charles Dickens', 1, 3),
('Terry Pratchett', 1, 3),
('Neil Gaiman', 1, 3),
('Suzanne Collins', 2, 2),
('J.R.R. Tolkien', 1, 3),
('Frank Herbert', 1, 2),
('Philip K. Dick', 1, 2),
('Arthur C. Clarke', 1, 3),
('Isaac Asimov', 1, 2),
('Ray Bradbury', 1, 2),
('Ursula K. Le Guin', 2, 2),
('Douglas Adams', 1, 3),
('H.P. Lovecraft', 1, 2),
('Mary Shelley', 2, 3),
('Bram Stoker', 1, 3),
('Stephenie Meyer', 2, 2),
('Cassandra Clare', 2, 2),
('Rick Riordan', 1, 2),
('Veronica Roth', 2, 2),
('John Green', 1, 2),
('Rainbow Rowell', 2, 2);
GO

INSERT INTO Cover (Img) VALUES
('https://covers.openlibrary.org/b/id/10001-L.jpg'),
('https://covers.openlibrary.org/b/id/9764-L.jpg'), 
('https://covers.openlibrary.org/b/id/14354-L.jpg'),  
('https://covers.openlibrary.org/b/id/11867-L.jpg'),  
('https://covers.openlibrary.org/b/id/21650-L.jpg'), 
('https://covers.openlibrary.org/b/id/1340712-L.jpg'), 
('https://covers.openlibrary.org/b/id/8062-L.jpg'),  
('https://covers.openlibrary.org/b/id/10044-L.jpg'), 
('https://covers.openlibrary.org/b/id/12922-L.jpg'), 
('https://covers.openlibrary.org/b/id/8157-L.jpg'),  
('https://covers.openlibrary.org/b/id/7545-L.jpg'),  
('https://covers.openlibrary.org/b/id/11407-L.jpg'),  
('https://covers.openlibrary.org/b/id/11395-L.jpg'),  
('https://covers.openlibrary.org/b/id/14363-L.jpg'), 
('https://covers.openlibrary.org/b/id/11039-L.jpg'), 
('https://covers.openlibrary.org/b/id/8010-L.jpg'),  
('https://covers.openlibrary.org/b/id/14027-L.jpg'),  
('https://covers.openlibrary.org/b/id/13698-L.jpg'),  
('https://covers.openlibrary.org/b/id/11234-L.jpg'),  
('https://covers.openlibrary.org/b/id/11014-L.jpg'), 
('https://covers.openlibrary.org/b/id/12239-L.jpg'), 
('https://covers.openlibrary.org/b/id/10642-L.jpg'), 
('https://covers.openlibrary.org/b/id/35831-L.jpg'), 
('https://covers.openlibrary.org/b/id/7239-L.jpg'), 
('https://covers.openlibrary.org/b/id/11171-L.jpg'), 
('https://covers.openlibrary.org/b/id/9473-L.jpg'), 
('https://covers.openlibrary.org/b/id/11198-L.jpg'), 
('https://covers.openlibrary.org/b/id/9772-L.jpg'), 
('https://covers.openlibrary.org/b/id/10139-L.jpg'), 
('https://covers.openlibrary.org/b/id/11429-L.jpg'),
('https://covers.openlibrary.org/b/id/9904-L.jpg'), 
('https://covers.openlibrary.org/b/id/9043-L.jpg'), 
('https://covers.openlibrary.org/b/id/13120-L.jpg'), 
('https://covers.openlibrary.org/b/id/11205-L.jpg'), 
('https://covers.openlibrary.org/b/id/54341-L.jpg'), 
('https://covers.openlibrary.org/b/id/71393-L.jpg'), 
('https://covers.openlibrary.org/b/id/50502-L.jpg'), 
('https://covers.openlibrary.org/b/id/57730-L.jpg'), 
('https://covers.openlibrary.org/b/id/61637-L.jpg'), 
('https://covers.openlibrary.org/b/id/78441-L.jpg');
GO
INSERT INTO Book (Title, Description, IdCover, IdEditorial, IdGenrer, IdAuthor, IdLanguage, Year, NumberPages, Estate) VALUES
('It', 'Siete niños enfrentan a una entidad maligna que se alimenta del miedo, "It", en el pueblo de Derry.', 1, 1, 5, 1, 1, 1986, 1138, 1),
('Harry Potter y la piedra filosofal', 'Harry descubre que es mago y asiste a Hogwarts, donde se une a Hermione y Ron para enfrentar una amenaza oscura.', 2, 2, 2, 2, 1, 1997, 309, 1),
('1984', 'Winston se rebela contra el régimen totalitario del Gran Hermano en un mundo de vigilancia constante y represión del pensamiento.', 3, 3, 1, 3, 1, 1949, 328, 1),
('Cien años de soledad', 'La historia de la familia Buendía en el pueblo mágico de Macondo, marcada por el destino y el amor.', 4, 4, 1, 4, 1, 1967, 472, 1),
('El alquimista', 'Un joven pastor emprende un viaje en busca de un tesoro, aprendiendo lecciones de vida y siguiendo su corazón.', 5, 5, 1, 5, 1, 1988, 180, 1),
('Kafka en la orilla', 'Un hombre solitario y un gato parlante se encuentran en un mundo surrealista donde la realidad se fusiona con la fantasía.', 6, 6, 1, 6, 1, 2002, 600, 1),
('El cuento de la criada', 'En una sociedad distópica, las mujeres fértiles son obligadas a ser "Criadas" para las familias adineradas.', 7, 7, 1, 7, 1, 1985, 336, 1),
('Orgullo y prejuicio', 'Elizabeth Bennet se enfrenta a las presiones sociales para casarse y se enamora del orgulloso Fitzwilliam Darcy.', 8, 8, 1, 8, 1, 1813, 432, 1),
('El código Da Vinci', 'Robert Langdon y Sophie Neveu desentrañan pistas ocultas en obras de arte para descubrir la verdad sobre el Santo Grial.', 9, 9, 1, 9, 1, 2003, 454, 1),
('Los pilares de la tierra', 'La construcción de una catedral en la Inglaterra medieval refleja la vida, la muerte y la fe de sus habitantes.', 10, 10, 1, 10, 1, 1989, 990, 1),
('El viejo y el mar', 'Un pescador cubano lucha contra un enorme pez espada en el mar, reflexionando sobre la perseverancia y la naturaleza.', 11, 1, 1, 11, 1, 1952, 127, 1),
('El gran Gatsby', 'Jay Gatsby se obsesiona con Daisy Buchanan, retratando los sueños, las ilusiones y la decadencia de la sociedad.', 12, 2, 1, 12, 1, 1925, 180, 1),
('La señora Dalloway', 'Clarissa Dalloway se enfrenta a los recuerdos del pasado, las relaciones y la vida misma en un día en Londres.', 13, 3, 1, 13, 1, 1925, 214, 1),
('Mientras agonizo', 'La familia Bundren emprende un viaje desgarrador para llevar el cuerpo de Addie Bundren a su ciudad natal.', 14, 4, 1, 14, 1, 1930, 326, 1),
('Beloved', 'Sethe, una ex esclava, lucha con el trauma del pasado y la pérdida de su hija, explorando la historia de la esclavitud.', 15, 5, 1, 15, 1, 1987, 321, 1),
('Sé por qué canta el pájaro enjaulado', 'Maya Angelou narra su infancia en el sur de Estados Unidos durante la segregación racial, mostrando resiliencia y superación.', 16, 6, 1, 16, 1, 1969, 352, 1),
('Cartas a nadie', 'Poemas de Emily Dickinson, explorando temas como la muerte, la naturaleza, el amor y la fe con un estilo único.', 17, 7, 1, 17, 1, 1924, 144, 1),
('Hojas de hierba', 'Poemas de Walt Whitman celebrando la vida, la naturaleza y la democracia con un estilo libre y lenguaje directo.', 18, 8, 1, 18, 1, 1855, 432, 1),
('El cuervo', 'Un hombre se enfrenta a la visita de un cuervo que le habla de una pérdida irreparable, explorando temas de muerte y melancolía.', 19, 9, 1, 19, 1, 1845, 16, 1),
('Un cuento de dos ciudades', 'La historia de Londres y París durante la Revolución Francesa, narrando las vidas de personajes en ambos lugares.', 20, 10, 1, 20, 1, 1859, 544, 1),
('Mort', 'Mort, un aprendiz de Muerte, descubre que no está destinado a ser un segador, pero su destino se complica.', 21, 1, 2, 21, 1, 1987, 336, 1),
('Sandman', 'Sueños, mitos y realidades se entrelazan en las historias de Morfeo, el Señor de los Sueños, y otros seres mitológicos.', 22, 2, 2, 22, 1, 1989, 256, 1),
('Los juegos del hambre', 'Katniss Everdeen participa en un brutal torneo televisado donde los jóvenes luchan hasta la muerte por la supervivencia.', 23, 3, 2, 23, 1, 2008, 374, 1),
('El hobbit', 'Bilbo Bolsón se embarca en una aventura épica con un grupo de enanos para recuperar su tesoro de un dragón.', 24, 4, 2, 24, 1, 1937, 310, 1),
('Dune', 'Paul Atreides, heredero de una noble familia, se enfrenta a la traición, el poder y la lucha por el control de un planeta desértico.', 25, 5, 1, 25, 1, 1965, 412, 1),
('¿Sueñan los androides con ovejas eléctricas?', 'Un detective busca a androides fugitivos en un futuro donde la distinción entre humanos y máquinas es borrosa.', 26, 6, 1, 26, 1, 1968, 224, 1),
('2001, una odisea del espacio', 'Un viaje a través del tiempo y el espacio, explorando la evolución humana y la inteligencia artificial.', 27, 7, 1, 27, 1, 1968, 180, 1),
('Fundación', 'Una saga épica que explora la caída y el surgimiento de una civilización, con el poder de la ciencia y el destino humano.', 28, 8, 1, 28, 1, 1951, 240, 1),
('Fahrenheit 451', 'En un futuro donde los libros están prohibidos, un bombero descubre la belleza de la literatura y se rebela contra el régimen.', 29, 9, 1, 29, 1, 1953, 164, 1),
('La mano izquierda de la oscuridad', 'En un planeta donde el género es fluido, un diplomático humano se enfrenta a la diferencia y la búsqueda de identidad.', 30, 10, 1, 30, 1, 1969, 208, 1),
('La guía del autoestopista galáctico', 'Un viaje cómico a través del universo, con humor absurdo y situaciones inesperadas.', 31, 1, 1, 31, 1, 1979, 224, 1),
('La llamada de Cthulhu', 'Una colección de relatos de terror cósmico donde seres antiguos y poderosos amenazan la humanidad.', 32, 2, 5, 32, 1, 1928, 128, 1),
('Frankenstein', 'Un científico crea una criatura monstruosa a partir de partes de cadáveres, dando lugar a una historia de horror y ética.', 33, 3, 1, 33, 1, 1818, 200, 1),
('Drácula', 'Un abogado viaja a Transilvania para encontrar a su cliente y se enfrenta al vampiro Drácula, en una lucha por la supervivencia.', 34, 4, 5, 34, 1, 1897, 480, 1),
('Crepúsculo', 'Bella Swan se enamora de Edward Cullen, un vampiro, en una historia de amor, romance y misterio sobrenatural.', 35, 5, 3, 35, 1, 2005, 498, 1),
('Cazadores de sombras: Ciudad de hueso', 'Clary Fray descubre que pertenece a un mundo secreto de cazadores de sombras que combaten a los demonios.', 36, 6, 2, 36, 1, 2007, 488, 1),
('El ladrón del rayo', 'Percy Jackson, un semidiós, se embarca en una aventura para encontrar a su madre, enfrentando peligros y criaturas mitológicas.', 37, 7, 2, 37, 1, 2005, 384, 1),
('Divergente', 'Beatrice Prior vive en una sociedad dividida en facciones, donde descubre que es "Divergente" y amenaza el orden establecido.', 38, 8, 2, 38, 1, 2011, 416, 1),
('Bajo la misma estrella', 'Hazel Grace, una adolescente con cáncer, se enamora de Gus, un chico que lucha contra su propia enfermedad.', 39, 9, 1, 39, 1, 2012, 312, 1),
('Eleanor & Park', 'Eleanor y Park, dos adolescentes marginados, se enamoran en un ambiente hostil, enfrentando las presiones de su entorno.', 40, 10, 3, 40, 1, 2013, 336, 1);
GO


create procedure cargarBook 
	@Title NVARCHAR(200),
    @Description NVARCHAR(200),
    @Img NVARCHAR(200),
    @IdEditorial INT,
    @IdGenrer INT,
    @IdAuthor INT,
    @IdLanguage INT,
    @Year INT,
    @NumberPages INT
as
	begin
	 DECLARE @IdCover INT;
		begin try
			begin transaction 


				insert into  Cover (Img) 
				VALUES (@Img);

				SET @IdCover = SCOPE_IDENTITY();

				INSERT INTO Book (Title, Description, IdCover, IdEditorial, IdGenrer, IdAuthor, IdLanguage, Year, NumberPages)
				VALUES (@Title, @Description, @IdCover, @IdEditorial, @IdGenrer, @IdAuthor, @IdLanguage, @Year, @NumberPages);

				


			commit transaction
		end try
		begin catch
			rollback transaction
			print error_message()
		end catch
	end
	go