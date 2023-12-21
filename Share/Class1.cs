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
    [OperationContract]
    ClassGrpc GetClassById(IntGrpc id,
        CallContext context = default);
    [OperationContract]
    Empty AddClass(ClassGrpc request, CallContext context = default);
    [OperationContract]
    bool UpdateClass(ClassGrpc classGrpc, Empty request, CallContext context = default);
    [OperationContract]
    Empty DeleteClass(Empty request, CallContext context = default);
}

[DataContract]
public class TeacherGrpc
{
    [DataMember(Order = 1)]
    public virtual int Id { get; set; }
    [DataMember(Order = 2)]
    public virtual string Name { get; set; }

    [DataMember(Order = 3)]
    public virtual DateTime Dob { get; set; }
}
[DataContract]
public class ListTeachers
{
    [DataMember(Order = 1)]
    public List<TeacherGrpc> List = new List<TeacherGrpc>();
}
[DataContract]
public class IntGrpc
{
    [DataMember(Order = 1)]
    public int Id { get; set; }
}
[ServiceContract]
public interface TeacherProto
{
    [OperationContract]
    ListTeachers GetListTeacher(Empty request,
        CallContext context = default);
    [OperationContract]
    TeacherGrpc GetTeacherById(IntGrpc id,
        CallContext context = default);
}