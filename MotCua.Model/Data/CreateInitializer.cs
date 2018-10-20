using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MotCua.Model.Data
{
    public class CreateInitializer : DropCreateDatabaseIfModelChanges<MotCuaDbContext>
    {
        protected override void Seed(MotCuaDbContext context)
        {
            var group = new List<Group>
            {
                new Group { GroupName = "Admin"},
                new Group { GroupName = "Student"}
            };
            group.ForEach(s => context.Groups.AddOrUpdate(s));

            var faculty = new List<Faculty>
            {
                new Faculty { FacultyName = "Công Nghệ Thông Tin"}
            };
            faculty.ForEach(s => context.Faculties.AddOrUpdate(s));

            var user = new List<User>
            {
                new User { Address = "Hải Phòng", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, Email = "f7deat@gmail.com", FacultyId = 1, FullName = "Đinh Công Tân", Gender = true, GroupId = 1, Image = "noimage.jpg", Password = "123", PhoneNumber = "0762559696", Status = true},
                new User { Address = "Hải Phòng", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, Email = "f7deat@gmail.com", FacultyId = 1, FullName = "Lê Đắc Nhường", Gender = true, GroupId = 1, Image = "noimage.jpg", Password = "123", PhoneNumber = "0762559696", Status = true},
                new User { Address = "Hải Phòng", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, Email = "f7deat@gmail.com", FacultyId = 1, FullName = "Nguyễn Văn Phóng", Gender = true, GroupId = 2, Image = "noimage.jpg", Password = "123", PhoneNumber = "0762559696", Status = true}
            };
            user.ForEach(s => context.Users.AddOrUpdate(s));

            context.SaveChanges();
        }
    }
}
