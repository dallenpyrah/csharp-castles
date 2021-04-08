using System;
using System.Collections.Generic;
using System.Data;
using castles.Models;
using Dapper;

namespace castles.Repository
{
    public class WifesRepository
    {

        public readonly IDbConnection _db;

        public WifesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Wife> GetAll()
        {
            string sql = "SELECT * FROM wifes;";
            return _db.Query<Wife>(sql);
        }

        internal Wife GetOneById(int id)
        {
            string sql = "SELECT * FROM wifes WHERE id = @id;";
            return _db.QueryFirstOrDefault<Wife>(sql, new { id });
        }

        internal Wife CreateWife(Wife newWife)
        {
            string sql = @"INSERT INTO wifes
            (name, age, skills, knightId)
            VALUES
            (@Name, @Age, @Skills, @KnightId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newWife);
            newWife.Id = id;
            return newWife;
        }

        internal object GetWifeByKnightId(int id)
        {
            string sql = "SELECT * FROM wifes WHERE knightId = @id;";
            return _db.Query<Wife>(sql, new { id });
        }

        internal Wife EditWife(Wife current)
        {
            string sql = @"UPDATE wifes
            SET
                name = @Name,
                age = @Age,
                skills = @Skills
                WHERE id = @id;
            SELECT * FROM wifes WHERE id = @id;";
            int id = _db.QueryFirstOrDefault<int>(sql, current);
            return current;
        }

        internal void DeleteWife(int id)
        {
            string sql = "DELETE FROM wifes WHERE id = @id;";
            _db.QueryFirstOrDefault<Wife>(sql, new { id });
            return;
        }
    }
}