INSERT INTO Booking ([CreatedDate], [OutboundDate], [ReturnDate], [From], [To]) OUTPUT INSERTED.Id VALUES ('20081111', '20081111', '20081112', 'Aalborg', 'Copenhagen')

SELECT b.Id,[CreatedDate], [OutboundDate], [ReturnDate], [From], [To], [FirstName], [MiddleName], [LastName], [Country], [PassportNo], [ExpireDate] FROM Booking b INNER JOIN Passenger p on p.BookingId = b.Id
SELECT b.*, p.* FROM Booking b INNER JOIN Passenger p on p.BookingId = b.Id
