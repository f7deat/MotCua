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
                new User { Address = "Hải Phòng", CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now, Email = "f7deat@gmail.com", FacultyId = 1, FullName = "Đinh Công Tân", Gender = true, GroupId = 2, Image = "noimage.jpg", Password = "123", PhoneNumber = "0762559696", Status = true}
            };
            user.ForEach(s => context.Users.AddOrUpdate(s));

            var department = new List<Department>
            {
                new Department { DepartmentName = "Đoàn thanh niên", Description = "Đoàn thanh niên" },
                new Department { DepartmentName = "Phòng Hành chính - Quản trị", Description = "Phòng Hành chính - Quản trị" },
                new Department { DepartmentName = "Phòng Kế hoạch - Tài chính", Description = "Phòng Kế hoạch - Tài chính" },
                new Department { DepartmentName = "Phòng Khảo thí - ĐNCL", Description = "Phòng Khảo thí - ĐNCL" },
                new Department { DepartmentName = "Phòng Đào tạo", Description = "Phòng Đào tạo" },
                new Department { DepartmentName = "Phòng CT - HSSV", Description = "Phòng CT - HSSV" },
                new Department { DepartmentName = "Ban giám hiệu", Description = "Ban giám hiệu" }
            };
            department.ForEach(s => context.Departments.AddOrUpdate(s));

            context.SaveChanges();
        }
    }
}
