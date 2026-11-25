using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data;

/// <summary>Basic CRUD contract for an entity.</summary>
public interface IRepository<T> where T : EntityBase
{
    List<T> GetAll();
    T GetById(int id);
    int Add(T entity);
    void Update(T entity);
    void Delete(int id);
}
