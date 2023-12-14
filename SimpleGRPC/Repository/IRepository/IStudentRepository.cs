﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGRPC.Model;

namespace SimpleGRPC.Repository.IRepository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public void AddNewStudent(Student student);

        public void UpdateStudent(Student studentUpdate);

        public void DeleteStudent(Student student);

        public List<Student> SortData();

        public Student GetStudentById(int id);
        public int GetIDNewStudent();
    }
}
