﻿using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Model.Mapping
{
    class TeacherMapping : ClassMapping<Teacher>
    {
        public TeacherMapping()
        {
            Table("Teacher");

            Id(x => x.Id, map => map.Column("Id"));

            Property(x => x.Name);

            Property(x => x.Dob);
        }
    }
}
