using System;
using System.Collections.Generic;
using System.Data;
using castles.Models;
using Dapper;

namespace castles.Repository
{
    public class CastlesRepository
    {
        public readonly IDbConnection _db;

        public CastlesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Castle> GetAll()
        {
            string sql = "SELECT * FROM castles;";
            return _db.Query<Castle>(sql);
        }

        internal Castle CreateCastle(Castle newCastle)
        {
            string sql = @"
            INSERT INTO castles
            (name, king, villagers, armysize)
            VALUES
            (@Name, @King, @Villagers, @Armysize);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCastle);
            newCastle.Id = id;
            return newCastle;
        }

        internal Castle GetCastleById(int id)
        {
            string sql = "SELECT * FROM castles WHERE id = @id;";
            return _db.QueryFirstOrDefault<Castle>(sql, new { id });
        }

        internal Castle EditCastle(Castle original)
        {
            string sql = @"
            UPDATE castles
            SET
                name = @Name,
                king = @King,
                villagers = @Villagers,
                armysize = @Armysize
                WHERE id = @id;
                SELECT * FROM castles WHERE id = @id;";
                return _db.QueryFirstOrDefault<Castle>(sql, original);
        }

        internal void DeleteCastle(int id)
        {
            string sql = "DELETE FROM castles WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}