using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repositories
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _db.LeaveTypes.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _db.LeaveTypes.Find(id);
        }

        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
        {
            //var employees = _db.Employees.Where(id => id.)
            throw new NotImplementedException();
        }

        public bool ItExists(int id)
        {
            var exists = _db.LeaveTypes.Any(model => model.Id == id);
            return exists;
        }

        public bool Save()
        {
            // If returns a number greater than 0 then the transaction was successful
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
