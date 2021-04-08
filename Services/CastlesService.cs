using System;
using System.Collections.Generic;
using castles.Models;
using castles.Repository;

namespace castles.Services
{
    public class CastlesService
    {
        private readonly CastlesRepository _repo;

        public CastlesService(CastlesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> GetAll()
        {
            return _repo.GetAll();
        }

        internal Castle CreateCastle(Castle newCastle)
        {
            return _repo.CreateCastle(newCastle);
        }

        internal Castle GetCastleById(int id)
        {
            Castle original = _repo.GetCastleById(id);
            if (original == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                return original;
            }
        }

        internal object EditCastle(Castle editCastle)
        {
            Castle original = GetCastleById(editCastle.Id);
            if (original == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                original.Name = editCastle.Name != null ? editCastle.Name : original.Name;
                original.King = editCastle.King != null ? editCastle.King : original.King;
                original.Villagers = editCastle.Villagers != null ? editCastle.Villagers : original.Villagers;
                original.Armysize = editCastle.Armysize != null ? editCastle.Armysize : original.Armysize;
                return _repo.EditCastle(original);
            }
        }

        internal Castle DeleteCastle(int id)
        {
            Castle toDelete = GetCastleById(id);
            if (toDelete == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                _repo.DeleteCastle(id);
                return toDelete;
            }
        }
    }
}