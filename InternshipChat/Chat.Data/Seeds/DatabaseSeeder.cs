using Chat.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
                //Seed for Users
                builder.Entity<User>()
               .HasData(new List<User>
               {
                        new User("Mario", "Mitov","mariomitov@gmail.com",true,"12345678")
                        {
                            Id = 1,
                        },
                        new User("John", "Doe","johndoe@gmail.com",false,"12345678")
                       {
                         Id = 2,
                       },

                       new User("Jane", "Smith","janesmith@gmail.com",false,"12345678")
                       {
                         Id = 3,
                       },

                       new User("Peter", "Jones","peterjones@gmail.com",false,"12345678")
                       {
                         Id = 4,
                       },

                       new User("Elizabeth", "Williams","elizabethwilliams@gmail.com",false,"12345678")
                       {
                         Id = 5,
                       },

                       new User("Michael", "Brown","michaelbrown@gmail.com",false,"12345678")
                       {
                         Id = 6,
                       },

                       new User("Susan", "Anderson","susananderson@gmail.com",false,"12345678")
                       {
                         Id = 7,
                       },

                       new User("David", "Taylor","davidtaylor@gmail.com",false,"12345678")
                       {
                         Id = 8,
                       },

                       new User("Emily", "Wilson","emilywilson@gmail.com",false,"12345678")
                       {
                         Id = 9,
                       },

                       new User("Charles", "Garcia","charlesgarcia@gmail.com",false,"12345678")
                       {
                         Id = 10,
                       },

                       new User("Margaret", "Robinson","margaretrobinson@gmail.com",false,"12345678")
                       {
                         Id = 11,
                       },

                       new User("Robert", "Martinez","robertmartinez@gmail.com",false,"12345678")
                       {
                         Id = 12,
                       },

                       new User("Jennifer", "Thompson","jenniferthompson@gmail.com",false,"12345678")
                       {
                         Id = 13,
                       },
               });

              //Seed for GroupChats
               builder.Entity<GroupChat>()
              .HasData(new List<GroupChat>
              {
                      new GroupChat("Developers")
                      {
                            GroupChatId = 1
                      },

                      new GroupChat("Marketing")
                      {
                            GroupChatId = 2
                      },

                      new GroupChat("Multimedia")
                      {
                            GroupChatId = 3
                      },

                      new GroupChat("Designers")
                      {
                            GroupChatId = 4
                      },
              });

            //Seed for UserGroup
            builder.Entity<UserGroup>()
              .HasData(new List<UserGroup>
              {
                      //First group
                      new UserGroup()
                      {
                            GroupChatId = 1,
                            UserId=1,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 1,
                            UserId=2,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 1,
                            UserId=3,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 1,
                            UserId=4,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 1,
                            UserId=5,
                      },
                      //Second group
                      new UserGroup()
                      {
                            GroupChatId = 2,
                            UserId=5,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 2,
                            UserId=6,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 2,
                            UserId=7,
                      },
                      //Third group
                      new UserGroup()
                      {
                            GroupChatId = 3,
                            UserId=8,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 3,
                            UserId=9,
                      },
                      //Fourth group
                      new UserGroup()
                      {
                            GroupChatId = 4,
                            UserId=9,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 4,
                            UserId=10,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 4,
                            UserId=11,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 4,
                            UserId=12,
                      },
                      new UserGroup()
                      {
                            GroupChatId = 4,
                            UserId=13,
                      },
              });

            //Seed for Private message
            builder.Entity<PrivateMessage>()
           .HasData(new List<PrivateMessage>
           {
               new PrivateMessage(1,2,"Hej, Sretan Božić!")
               {
                   Id=1,
               },
               new PrivateMessage(2,1,"Hvala, također!")
               {
                   Id=2,
               },

               new PrivateMessage(2,3,"Možeš li mi pomoć sutra?")
               {
                   Id=3,
               },
               new PrivateMessage(3,2,"Moogu oko 3 popodne.")
               {
                   Id=4,
               },
           });


            //Seed for Grou message
            builder.Entity<GroupMessage>()
           .HasData(new List<GroupMessage>
           {
               new GroupMessage(1,1,"Kada je rok za domaći?")
               {
                   Id=1,
               },
               new GroupMessage(2,1,"4. siječnja")
               {
                   Id=2,
               },

               new GroupMessage(2,1,"2024")
               {
                   Id=3,
               },
               new GroupMessage(3,1,"Odlično!")
               {
                   Id=4,
               },
           });
        }
    }
}