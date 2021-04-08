using System;
using System.Collections.Generic;
using System.Data;
using castles.Models;
using Dapper;

namespace castles.Repository
{
    public class KnightsRepository
    {
        public readonly IDbConnection _db;

        public KnightsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Knight> GetAll()
        {
            string sql = "SELECT * FROM knights;";
            return _db.Query<Knight>(sql);
        }

        internal Knight CreateKnight(Knight newKnight)
        {
            string sql = @"INSERT INTO knights
            (name, age, height, gender, castleId)
            VALUES
            (@Name, @Age, @Height, @Gender, @CastleId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKnight);
            newKnight.Id = id;
            return newKnight;
        }

        internal Knight GetOneById(int id)
        {
            string sql = "SELECT * FROM knights WHERE id = @id;";
            return _db.QueryFirstOrDefault<Knight>(sql, new { id });
        }

        internal IEnumerable<Knight> GetAllKnightsByCastleid(int id)
        {
            string sql = "SELECT * FROM knights WHERE castleId = @id;";
            return _db.Query<Knight>(sql, new { id });
        }

        internal Knight EditKnight(Knight current)
        {
            string sql = @"UPDATE knights
             SET
                name = @Name,
                height = @Height,
                age = @Age,
                gender = @Gender
                WHERE id = @id;
                SELECT * FROM knights WHERE id = @id;";
            return _db.QueryFirstOrDefault<Knight>(sql, current);
        }

        internal void DeleteKnight(int id)
        {
            string sql = "DELETE FROM knights WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}