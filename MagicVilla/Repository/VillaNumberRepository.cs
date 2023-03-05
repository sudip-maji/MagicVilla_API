using MagicVilla_VillaAPI.Repository.IRepository;
using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MagicVilla_VillaAPI.Repository{
    
    public class VillaNumberRepository : Repository<VillaNumber>,IVillaNumberRepository
    {
        private readonly ApplicationDBContext _db;
        public VillaNumberRepository(ApplicationDBContext db) :base(db)
        {
            _db=db;
        }
        public async  Task<VillaNumber> Update(VillaNumber entity)
        {
          entity.UpdatedDate=DateTime.Now;
            _db.VillaNumbers.Update(entity);
              await _db.SaveChangesAsync();
              return entity;
        }
    }
    }
