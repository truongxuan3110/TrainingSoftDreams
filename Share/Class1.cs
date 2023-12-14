using ProtoBuf.Grpc;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Share;

[DataContract]
public class Empty
{

}

[DataContract]
public class StudentGrpc
{
    [DataMember(Order = 1)]
    public virtual int Id { get; set; }

    [DataMember(Order = 2)]
    public virtual string Name { get; set; }

    [DataMember(Order = 3)]
    public virtual DateTime Dob { get; set; }

    [DataMember(Order = 4)]
    public virtual string Address { get; set; }

    [DataMember(Order = 5)]
    public virtual int ClassId { get; set; }
}
[DataContract]
public class ListStudents
{
    [DataMember(Order = 1)]
    public List<StudentGrpc> List = new List<StudentGrpc>();
}

[ServiceContract]
public interface StudentProto
{
    [OperationContract]
    ListStudents GetListStudents(Empty request,
        CallContext context = default);
    [OperationContract]
    Empty AddStudent(StudentGrpc request,
        CallContext context = default);
    [OperationContract]
    Empty UpdateStudent(StudentGrpc request,
        CallContext context = default);
    [OperationContract]
    Empty DeleteStudent(StudentGrpc request,
        CallContext context = default);
}

[DataContract]
public class ClassGrpc
{
    [DataMember(Order = 1)]
    public virtual int Id { get; set; }
    [DataMember(Order = 2)]
    public virtual string Name { get; set; }

    [DataMember(Order = 3)]
    public virtual string Subject { get; set; }

    [DataMember(Order = 4)]
    public virtual int TeacherId { get; set; }
}
[DataContract]
public class ListClasses
{
    [DataMember(Order = 1)]
    public List<ClassGrpc> List = new List<ClassGrpc>();
}

[ServiceContract]
public interface ClassProto
{
    [OperationContract]
    ListClasses GetListClass(Empty request,
        CallContext context = default);
}