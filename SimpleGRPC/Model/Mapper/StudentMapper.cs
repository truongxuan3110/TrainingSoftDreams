﻿using Share;
using SimpleGRPC.Model.DTO;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Model.Mapper
{
    public class StudentMapper
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        //public StudentMapper(IStudentRepository studentRepository, IClassRepository classRepository)
        //{
        //    _studentRepository = studentRepository;
        //    _classRepository = classRepository;
        //}
        public StudentDTO StudentToStudentDTO(Student student, Boolean isCreate)
        {
            StudentDTO studentDTO = new StudentDTO();
            if(isCreate)
            {
                studentDTO.Id = _studentRepository.GetIDNewStudent();
                return studentDTO;
            }
            else
            {
                studentDTO.Id = student.Id;
                studentDTO.Name = student.Name;
                studentDTO.Address = student.Address;
                studentDTO.Dob = student.Dob;
                studentDTO.ClassId = student.ClassStudent.Id;
                return studentDTO;
            }
        }

        //convert student get in form to student - which act with NHibernate
        public Student StudentDTOToStudent(StudentDTO studentDTO, bool isCreate)
        {
            Student student;
            //Case: create student
            if (isCreate)
            {
                student = new Student();
                student.Id = _studentRepository.GetIDNewStudent();
                student.Name = studentDTO.Name;
                student.Address = studentDTO.Address;
                student.Dob = studentDTO.Dob;
                student.ClassStudent = _classRepository.GetClassById(studentDTO.ClassId);
                return student;

            }
            //Case: Update student
            if (!isCreate)
            {
                student = _studentRepository.GetStudentById(studentDTO.Id);
                student.Name = studentDTO.Name;
                student.Address = studentDTO.Address;
                student.Dob = studentDTO.Dob;
                student.ClassStudent = _classRepository.GetClassById(studentDTO.ClassId);
                return student;
            }
            return null;
        }
    }
}
