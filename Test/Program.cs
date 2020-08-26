using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var userList = new List<User>();
            var messageList = new List<Messag>();


            var user = new User();

            user.Id = 1;
            user.Name = "kemal";
            user.Messages = new List<Messag>();

            userList.Add(user);

            //_______________________________________

            var user2 = new User();

            user2.Id = 2;
            user2.Name = "ahmet";
            user2.Messages = new List<Messag>();

            userList.Add(user2);

            //_______________________________________

            var user3 = new User();

            user3.Id = 3;
            user3.Name = "mehmet";
            user3.Messages = new List<Messag>();

            userList.Add(user3);

            //_______________________________________

            var message = new Messag();

            message.Id = 1;
            message.Description = $"Selam Ahmet naber ({user.Name})";
            message.UserId = user.Id;
            message.User = user;

            //_______________________________________

            var message3 = new Messag();

            message3.Id = 3;
            message3.Description = $"selam Ahmet ({user3.Name})";
            message3.UserId = user3.Id;
            message3.User = user3;

            //_______________________________________

            var message2 = new Messag();

            message2.Id = 2;
            message2.Description = $"Aleyküm selam kemal iyidir ({user2.Name})";
            message2.UserId = user2.Id;
            message2.User = user2;

            //_______________________________________

            var message4 = new Messag();

            message4.Id = 4;
            message4.Description = $"Napıyosun ahmet ({user.Name})";
            message4.UserId = user.Id;
            message4.User = user;

            //_______________________________________

            var message5 = new Messag();

            message5.Id = 5;
            message5.Description = $"napalım ya debug ediyorum sen kemal ? ({user2.Name})";
            message5.UserId = user2.Id;
            message5.User = user2;

            var message6 = new Messag();

            message6.Id = 6;
            message6.Description = $"sen kimsin mehmet tanıyamadım? ({user2.Name})";
            message6.UserId = user2.Id;
            message6.User = user2;


            messageList.Add(message);
            user2.Messages.Add(message);
            user.Messages.Add(message);
            userList.Add(user);

            messageList.Add(message2);
            user.Messages.Add(message2);
            user2.Messages.Add(message2);
            userList.Add(user2);

            messageList.Add(message3);
            user2.Messages.Add(message3);
            user3.Messages.Add(message3);
            userList.Add(user3);


            messageList.Add(message4);
            user2.Messages.Add(message4);
            user.Messages.Add(message4);


            messageList.Add(message5);
            user.Messages.Add(message5);
            user2.Messages.Add(message5);

            messageList.Add(message6);
            user2.Messages.Add(message6);
            user3.Messages.Add(message6);

            Console.WriteLine("BÜTÜN MESAJLAR\n\n\n \t" + messageList.Count);

            foreach (var item in messageList)
            {

                Console.WriteLine($"{item.Description}");
            }


            Console.WriteLine("\n O KULLANICIYA GELEN VE YAPTIĞI TÜM MESAJLAR------------------------------\n\t" + user2.Messages.Count);
            foreach (var item in user2.Messages)
            {
                        Console.WriteLine($"{item.Description}");

            }


            Console.WriteLine("\n Ahmetle kemal arasındaki TÜM MESAJLAR--------------------------------------\n\t" + user.Messages.Count);
            foreach (var item in user2.Messages)
            {
                foreach (var msj in user.Messages)
                {
                    if (item.Id == msj.Id )
                    {
                        Console.WriteLine($"{item.Description}");
                    }
                    else
                    {
                        //Console.WriteLine($"Farklı mesaj");
                    }
                }

            }



            Console.WriteLine("\n  Ahmetle mehmet arasınadki gelen TÜM MESAJLAR--------------------------------------\n\t" + user3.Messages.Count);
            foreach (var item in user2.Messages)
            {
                foreach (var msj in user3.Messages)
                {
                    if (item.Id == msj.Id)
                    {
                        Console.WriteLine($"{item.Description}");
                    }
                    else
                    {
                        //Console.WriteLine($"Farklı mesaj");
                    }
                }

            }


            Console.WriteLine("\n  Ahmete mesaj gönderen herkes--------------------------------------\n\t" + user3.Messages.Count);
            foreach (var item in user2.Messages)
            {

                if (item.UserId != user2.Id)
                {
                    Console.WriteLine($"{item.User.Name}");
                }
              

            }



        }
    }
}
