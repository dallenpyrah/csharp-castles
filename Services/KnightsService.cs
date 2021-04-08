using System;
using System.Collections.Generic;
using castles.Models;
using castles.Repository;

namespace castles.Services
{
    public class KnightsService
    {

        private readonly KnightsRepository _repo;

        public KnightsService(KnightsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Knight> GetAll()
        {
            return _repo.GetAll();
        }

        internal Knight CreateKnight(Knight newKnight)
        {
            return _repo.CreateKnight(newKnight);
        }

        internal Knight GetOneById(int id)
        {
            Knight current = _repo.GetOneById(id);
            if (current == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                return current;
            }
        }

        internal IEnumerable<Knight> GetAllKnightsByCastleId(int id)
        {
            return _repo.GetAllKnightsByCastleid(id);
        }

        internal Knight EditKnight(Knight editKnight)
        {
            Knight current = GetOneById(editKnight.Id);
            if (current == null)
            {
                throw new SystemException("INVALID ID");
            }else{
                current.Age = editKnight.Age != null ? editKnight.Age : current.Age;
                current.Name = editKnight.Name != null ? editKnight.Name : current.Name;
                current.Gender = editKnight.Gender != null ? editKnight.Gender : current.Gender;
                current.Height = editKnight.Height != null ? editKnight.Height : current.Height;
                return _repo.EditKnight(current);
            }
        }

        internal Knight DeleteKnight(int id)
        {
           Knight current = GetOneById(id);
           if(current == null){
               throw new SystemException("INVALID ID");
           } else {
               _repo.DeleteKnight(id);
               return current;
           }
        }
    }
}