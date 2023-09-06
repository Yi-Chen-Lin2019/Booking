﻿using DFDSBooking.Application.Contracts.Persistence;
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

namespace DFDSBooking.Persistence.Repositories
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(DataContext context) : base(TableNames.BookingTableName, context) { }

        public async Task<int> AddAsync(Booking entity)
        {
            using (var connection = dataContext.CreateConnection())
            {
                string query = $"insert into {tableName} (Name, Street, City, ZipCode, Email) OUTPUT INSERTED.Id values (@name, @street, @city, @zipcode, @email)";
                return await connection.QuerySingleAsync<int>(query, new { createdDate = entity.CreatedDate });
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
            using (var connection = dataContext.CreateConnection())
            {
                List<Booking> result = new List<Booking>();
                var query = $"select * from {tableName}";
                var bookings = await connection.QueryAsync<Booking>(query);
                //foreach (var booking in bookings)
                //{
                //    booking.Address = await GetAddressFromBookingId(booking.Id);
                //    booking.Email = await GetEmailFromBookingId(booking.Id);
                //    result.Add(booking);
                //}
                return result;
            }
        }

        public async Task<Result<Booking>> GetByIdAsync(long id)
        {
            using (var connection = dataContext.CreateConnection())
            {
                string query = $"select Street, City, ZipCode from {tableName} where id = @id";
                return await connection.QuerySingleAsync<Booking>(query, new { id });
            }
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
                string command = $"update {tableName} set name = @name where id = @id";
                await connection.ExecuteAsync(command, new { createdDate = entity.CreatedDate, id = entity.Id });
                //await Task.Run(() => UpdateAddressAsync(entity.Address, entity.Id));
            }
        }
    }
}