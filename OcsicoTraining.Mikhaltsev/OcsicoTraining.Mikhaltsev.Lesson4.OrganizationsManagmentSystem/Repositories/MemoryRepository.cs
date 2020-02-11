using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class MemoryRepository : IMemoryRepository<Role>
    {
        MemoryStream memory = new MemoryStream();
        public void Add(Role entity)
        {
            var uniEncoding = new UnicodeEncoding();
            var bytes = uniEncoding.GetBytes(entity.ToString());

            memory.Write(bytes, 0, bytes.Length);

        }

        public List<Role> GetAll()
        {
            byte[] buffer;
            _ = memory.Seek(0, SeekOrigin.Begin);

            buffer = new byte[memory.Length];
            _ = memory.Read(buffer, 0, (int)memory.Length);

            var stringRoles = Encoding.Unicode.GetString(buffer);
            var arrStrRoles = stringRoles.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var roles = new List<Role>();
            for (var i = 0; i < arrStrRoles.Length; i++)
            {
                var temp = arrStrRoles[i].Split(' ');
                var role = new Role { Id = int.Parse(temp[0]), Name = temp[1] };
                roles.Add(role);
            }

            return roles;
        }

        public void Remove(Role entity)
        {
            var roles = GetAll();
            string strRoles = null;
            for (var i = 0; i < roles.Count; i++)
            {
                if (roles[i].Id != entity.Id)
                {
                    strRoles += roles[i].ToString();
                }
            }
            memory.SetLength(0);
            var bytes = new UnicodeEncoding().GetBytes(strRoles.ToString());
            memory.Write(bytes, 0, bytes.Length);
        }

        public void Update(Role entity)
        {
            var roles = GetAll();
            string strRoles = null;
            for (var i = 0; i < roles.Count; i++)
            {
                if (roles[i].Id == entity.Id)
                {
                    roles[i] = entity;
                }
                strRoles += roles[i].ToString();
            }
            memory.SetLength(0);
            var bytes = new UnicodeEncoding().GetBytes(strRoles.ToString());
            memory.Write(bytes, 0, bytes.Length);
        }
    }
}
