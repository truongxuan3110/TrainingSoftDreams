using SimpleGRPC.Model;
using SimpleGRPC.Repository.IRepository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.Data;

namespace SimpleGRPC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISessionFactory _session;
        public StudentRepository(ISessionFactory session)
        {
            _session = session;
        }

        public void AddNewStudent(Student student)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        session.Insert(student);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }
        public void DeleteStudent(Student student)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        session.Delete(student);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            using (var session = _session.OpenStatelessSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .ToList();
            }
        }

        public int GetIDNewStudent()
        {
            var student = GetAllStudents().OrderByDescending(x => x.Id).First();
            return student.Id + 1;
        }

        public Student GetStudentById(int id)
        {
            using (var session = _session.OpenStatelessSession())
            {
                var student = session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .Where(s => s.Id == id)
                    .ToList()
                    .FirstOrDefault();
                return student;
            }
        }

        public List<Student> SortData()
        {
            using (var session = _session.OpenStatelessSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .OrderBy(s => s.Name)
                    .ToList();
            }
        }

        public void UpdateStudent(Student studentUpdate)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        session.Update(studentUpdate);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
