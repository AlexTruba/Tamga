using DB.Model.Interfaces;
using System;

namespace DB.Model
{
    public class User: IEntity
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }

        public bool Employed { get; set; }
        public string OrganizationName { get; set; }
        public DateTime? StartOnUtc { get; set; }
    }
}