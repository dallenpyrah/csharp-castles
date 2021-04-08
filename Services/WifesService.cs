using System;
using System.Collections.Generic;
using castles.Models;
using castles.Repository;

namespace castles.Services
{
    public class WifesService
    {

        private readonly WifesRepository _repo;

        public WifesService(WifesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Wife> GetAll()
        {
            return _repo.GetAll();
        }

        internal Wife GetOneById(int id)
        {
            Wife current = _repo.GetOneById(id);
            if (current == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                return current;
            }
        }

        internal object GetWifeByKnightId(int id)
        {
            return _repo.GetWifeByKnightId(id);
        }

        internal Wife CreateWife(Wife newWife)
        {
            return _repo.CreateWife(newWife);
        }

        internal Wife EditWife(Wife editedWife)
        {
            Wife current = GetOneById(editedWife.Id);
            if(current == null){
                throw new SystemException("INVALID ID");
            }else{
                current.Name = editedWife.Name != null ? editedWife.Name : current.Name;
                current.Age = editedWife.Age != null ? editedWife.Age : current.Age;
                current.Skills = editedWife.Skills != null ? editedWife.Skills : current.Skills;
                return _repo.EditWife(current);
            }
        }

        internal Wife DeleteWife(int id)
        {
            Wife current = GetOneById(id);
            if(current == null){
                throw new SystemException("INVALID ID");
            }else{
                _repo.DeleteWife(id);
                return current;
            }
        }
    }
}