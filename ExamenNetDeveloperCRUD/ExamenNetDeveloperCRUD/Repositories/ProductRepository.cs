using Dapper;
using ExamenNetDeveloperCRUD.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNetDeveloperCRUD.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var procedure = "spGetAllProducts";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Product>(procedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Producto WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Product>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(Product entity)
        {
            try
            {
                var query = "INSERT INTO Producto (Nombre, Precio, Stock, FechaRegistro) VALUES (@Nombre, @Precio, @Stock, @FechaRegistro)";

                var parameters = new DynamicParameters();
                parameters.Add("Nombre", entity.Nombre, DbType.String);
                parameters.Add("Precio", entity.Precio, DbType.Decimal);
                parameters.Add("Stock", entity.Stock, DbType.Int32);
                parameters.Add("FechaRegistro", entity.FechaRegistro, DbType.DateTime);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            try
            {
                var query = "UPDATE Producto SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock  WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Nombre", entity.Nombre, DbType.String);
                parameters.Add("Precio", entity.Precio, DbType.Decimal);
                parameters.Add("Stock", entity.Stock, DbType.Int32);
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Product entity)
        {
            try
            {
                var query = "DELETE FROM Producto WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}