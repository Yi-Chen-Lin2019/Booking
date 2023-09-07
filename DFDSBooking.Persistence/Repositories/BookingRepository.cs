using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Domain.AggregateRoots;
using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.ValueObjects;
using DFDSBooking.Persistence.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFDSBooking.Domain.Entities;

namespace DFDSBooking.Persistence.Repositories
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(DataContext context) : base(TableNames.BookingTableName, context) { }

        public async Task<int> AddAsync(Booking entity)
        {
            using (var connection = dataContext.CreateConnection())
            {
                var insertBooking = """
                    INSERT INTO Booking ([CreatedDate], [OutboundDate], [ReturnDate], [From], [To])
                    OUTPUT INSERTED.Id
                    VALUES (@CreatedDate, @OutboundDate, @ReturnDate, @From, @To);
                    """;
                var insertPassenger = """
                    INSERT INTO Passenger ([FirstName], [LastName], [MiddleName], [Country], [PassportNo], [ExpireDate], [BookingId])
                    OUTPUT INSERTED.Id
                    VALUES (@FirstName, @LastName, @MiddleName, @Country, @PassportNo, @ExpireDate ,@BookingId);
                    """;
                var bookingId = await connection.QuerySingleAsync<int>(insertBooking, new
                {
                    CreatedDate = entity.CreatedDate,
                    OutboundDate = entity.OutboundDate,
                    ReturnDate = entity.ReturnDate,
                    From = entity.From,
                    To = entity.To
                });

                foreach (var p in entity.Passengers)
                {
                    await connection.QuerySingleAsync<int>(insertPassenger, new
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        MiddleName = p.MiddleName,
                        Country = p.Country,
                        PassportNo = p.PassportNo,
                        ExpireDate = p.ExpireDate,
                        BookingId = bookingId
                    });
                }
                return bookingId;
            }
        }

        public void DeleteAsync(long id)
        {
            using (var connection = dataContext.CreateConnection())
            {
                string command = $"delete from {tableName} where id = @id";
                connection.Execute(command, new { id });
            }
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            IEnumerable<Booking> result = new List<Booking>();
            var sql = """
                SELECT b.Id,[CreatedDate], [OutboundDate], [ReturnDate], [From], [To],
                [FirstName], [MiddleName], [LastName], [Country], [PassportNo], [ExpireDate], p.Id
                FROM Booking b INNER JOIN Passenger p on p.BookingId = b.Id
                """;
            using (var connection = dataContext.CreateConnection())
            {
                var lookup = new Dictionary<long, Booking>();
                IEnumerable<Booking> bookings = await connection.QueryAsync<Booking, Passenger, Booking>
                    (sql, (b, p) =>
                    {
                        Booking booking;
                        if (!lookup.TryGetValue(b.Id, out booking))
                            lookup.Add(b.Id, booking = b);
                        booking.Passengers.Add(p);
                        return booking;
                    }, splitOn: "FirstName");
                result = lookup.Values.ToList();
            }
            return result;
        }

        public async Task<Result<Booking>> GetByIdAsync(long id)
        {
            Booking result;
            var sql = $"""
                    SELECT b.Id,[CreatedDate], [OutboundDate], [ReturnDate], [From], [To],
                    [FirstName], [MiddleName], [LastName], [Country], [PassportNo], [ExpireDate], p.Id
                    FROM Booking b INNER JOIN Passenger p on p.BookingId = b.Id
                    WHERE b.Id = {id}
                """;

            using (var connection = dataContext.CreateConnection())
            {
                var lookup = new Dictionary<long, Booking>();
                IEnumerable<Booking> bookings = await connection.QueryAsync<Booking, Passenger, Booking>
                    (sql, (b, p) =>
                    {
                        Booking booking;
                        if (!lookup.TryGetValue(b.Id, out booking))
                            lookup.Add(b.Id, booking = b);
                        booking.Passengers.Add(p);
                        return booking;
                    }, splitOn: "FirstName");
                result = lookup.Values.First();
            }
            return result;
        }

        /// <summary>
        /// This will only update the values of the aggregate root, not the value objects
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async void UpdateAsync(Booking entity)
        {
            using (var connection = dataContext.CreateConnection())
            {
                var updateBooking = """
                    UPDATE Booking SET
                    [OutboundDate] = @OutboundDate,
                    [ReturnDate] = @ReturnDate,
                    [From] = @From, [To] = @To
                    WHERE Id = @BookingId;
                    """;
                var updatePassenger = """
                    UPDATE Passenger SET
                    [FirstName] = @FirstName, [LastName] = @LastName,
                    [MiddleName] = @MiddleName, [Country] = @Country,
                    [PassportNo] = @PassportNo, [ExpireDate] = @ExpireDate, [BookingId] = @BookingId
                    WHERE BookingId = @BookingId AND Id = @PassengerId;
                    """;
                await connection.ExecuteAsync(updateBooking, new
                {
                    OutboundDate = entity.OutboundDate,
                    ReturnDate = entity.ReturnDate,
                    From = entity.From,
                    To = entity.To,
                    BookingId = entity.Id,
                });

                foreach (var p in entity.Passengers)
                {
                    await connection.ExecuteAsync(updatePassenger, new
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        MiddleName = p.MiddleName,
                        Country = p.Country,
                        PassportNo = p.PassportNo,
                        ExpireDate = p.ExpireDate,
                        BookingId = entity.Id,
                        PassengerId = p.Id
                    });
                }
            }
        }
    }
}
