using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Identity;

using DB.Models;

namespace DB
{
    public static class MyDbInitializer
    {
        private static MyDbContext _context;

        private static UserManager<ApplicationUser> _userManager;
        private static RoleManager<IdentityRole<int>> _roleManager;

        public static void Initialize(MyDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            String fileDirectoryFullPath)
        {
            _context = context;
            _context.Database.EnsureCreated();

            _userManager = userManager;
            _roleManager = roleManager;

            if (_context.Table1s.Any() == false)
            {
                try
                {
                    SeedApplicationUsers();

                    SeedTable3s(fileDirectoryFullPath);
                    SeedTable2s();
                    SeedTable1s();
                }
                catch (Exception exception)
                {
                    _context.Database.EnsureDeleted();

                    throw exception;
                }
            }
        }

        private static void SeedApplicationUsers()
        {
            var adminRole = new IdentityRole<int>("admin");
            CheckErrors(_roleManager.CreateAsync(adminRole).Result);

            var userRole = new IdentityRole<int>("user");
            CheckErrors(_roleManager.CreateAsync(userRole).Result);

            var adminUser = new ApplicationUser()
            {
                UserName = "admin",
                Name = "Admin",
                Email = "admin@example.com",
            };
            var adminUserPassword = "Almafa123";
            CheckErrors(_userManager.CreateAsync(adminUser, adminUserPassword).Result);
            CheckErrors(_userManager.AddToRoleAsync(adminUser, adminRole.Name).Result);

            var testUser1 = new ApplicationUser()
            {
                UserName = "test1",
                Name = "Test 1",
                Email = "test1@example.com",
            };
            var testUser1Password = "Almafa123";
            CheckErrors(_userManager.CreateAsync(testUser1, testUser1Password).Result);
            CheckErrors(_userManager.AddToRoleAsync(testUser1, userRole.Name).Result);

            var testUser2 = new ApplicationUser()
            {
                UserName = "test2",
                Name = "Test 2",
                Email = "test2@example.com",
            };
            var testUser2Password = "Almafa123";
            CheckErrors(_userManager.CreateAsync(testUser2, testUser2Password).Result);
            CheckErrors(_userManager.AddToRoleAsync(testUser2, userRole.Name).Result);

            var testUser3 = new ApplicationUser()
            {
                UserName = "test3",
                Name = "Test 3",
                Email = "test3@example.com",
            };
            var testUser3Password = "Almafa123";
            CheckErrors(_userManager.CreateAsync(testUser3, testUser3Password).Result);
            CheckErrors(_userManager.AddToRoleAsync(testUser3, userRole.Name).Result);

            _context.SaveChanges();
        }

        private static void SeedTable1s()
        {
            _context.Table1s.Add(new Table1() { /*Id = 1,*/ Table2Id = 1, UserId = 1 });
            _context.Table1s.Add(new Table1() { /*Id = 1,*/ Table2Id = 1, UserId = 2 });
            _context.Table1s.Add(new Table1() { /*Id = 1,*/ Table2Id = 2, UserId = 2 });
            _context.Table1s.Add(new Table1() { /*Id = 1,*/ Table2Id = 3, UserId = 2 });
            _context.Table1s.Add(new Table1() { /*Id = 1,*/ Table2Id = 4, UserId = 2 });

            _context.SaveChanges();
        }

        private static void SeedTable2s()
        {
            _context.Table2s.Add(new Table2() { /*Id = 1,*/ Table3Id = 1 });
            _context.Table2s.Add(new Table2() { /*Id = 2,*/ Table3Id = 2 });
            _context.Table2s.Add(new Table2() { /*Id = 3,*/ Table3Id = 2 });
            _context.Table2s.Add(new Table2() { /*Id = 4,*/ Table3Id = 3 });
            _context.Table2s.Add(new Table2() { /*Id = 5,*/ Table3Id = 4 });
            _context.Table2s.Add(new Table2() { /*Id = 6,*/ Table3Id = 4 });
            _context.Table2s.Add(new Table2() { /*Id = 7,*/ Table3Id = 4 });

            _context.SaveChanges();
        }

        private static void SeedTable3s(String fileDirectoryFullPath)
        {
            List<Byte[]> fileDatas = new List<Byte[]>();

            if (Directory.Exists(fileDirectoryFullPath))
            {
                //Int32 index = 1;
                foreach (String filePath in Directory.EnumerateFiles(fileDirectoryFullPath))
                {
                    if (File.Exists(filePath))
                    {
                        fileDatas.Add(File.ReadAllBytes(filePath));
                        //index += 1;
                    }
                }
            }

            _context.Table3s.Add(new Table3() { /*Id = 1,*/ FileData = null });
            _context.Table3s.Add(new Table3() { /*Id = 2,*/ FileData = fileDatas[0] });
            _context.Table3s.Add(new Table3() { /*Id = 3,*/ FileData = fileDatas[1] });
            _context.Table3s.Add(new Table3() { /*Id = 4,*/ FileData = null });
            _context.Table3s.Add(new Table3() { /*Id = 5,*/ FileData = null });

            _context.SaveChanges();
        }

        private static void CheckErrors(IdentityResult result)
        {
            String errors = "";
            foreach (IdentityError error in result.Errors)
            {
                errors += String.Format("Error while creating users.{2}\tCode: {0};{2}\tDescription: {1}.{2}{2}", error.Code, error.Description, Environment.NewLine);
            }

            if (String.IsNullOrEmpty(errors) == false)
            {
                throw new Exception(errors);
            }
        }
    }
}
