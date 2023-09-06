CREATE TABLE [dbo].[Booking](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[OutboundDate] [datetime] NOT NULL,
	[ReturnDate] [datetime],
	[From] [nvarchar](100) NOT NULL,
	[To] [nvarchar](100) NOT NULL
	constraint pk_booking primary key clustered (Id)
)
GO


CREATE TABLE [dbo].[Passenger](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50),
	[Country] [nvarchar](100) NOT NULL,
	[PassportNo] [bigint] NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
	[BookingId] [bigint] NOT NULL
	constraint pk_passenger primary key clustered (Id)
)
GO

ALTER TABLE [Passenger] WITH CHECK ADD CONSTRAINT fk_bookingId FOREIGN KEY (BookingId)
REFERENCES [Booking] (Id)
GO