using ExampleCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int action = 0;
            using (EFContext context = new EFContext())
            {
                do
                {
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Add UserProfiles");
                    Console.WriteLine("2. Get all UserProfiles");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Find");
                    Console.WriteLine("5. Delete");
                    Console.WriteLine("6. Find by ID");



                    action = int.Parse(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            {
                                UserProfile user = new UserProfile();
                                Console.WriteLine("Name: ");
                                user.Name = Console.ReadLine();
                                Console.WriteLine("Image: ");
                                user.Image = Console.ReadLine();
                                Console.WriteLine("Telephone: ");
                                user.Telephone = Console.ReadLine();
                                context.UserProfiles.Add(user);
                                context.SaveChanges();
                                break;
                            }
                        case 2:
                            {
                                foreach (var user in context.UserProfiles)
                                {
                                    Console.WriteLine($"Id: {user.Id}\t" +
                                        $"Name: {user.Name}\t" +
                                        $"Telephone: {user.Telephone}\t" +
                                        $"Image: {user.Image}");
                                }
                                break;
                            }
                        case 3:
                            {
                                int _id;
                                Console.Write("Id: ");
                                try
                                {
                                    _id = int.Parse(Console.ReadLine());
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                                UserProfile tmp;
                                try
                                {
                                    tmp = context.UserProfiles.Find(_id);


                                    Console.Write("Name: ");
                                    tmp.Name = Console.ReadLine();
                                    Console.Write("Telephone: ");
                                    tmp.Telephone = Console.ReadLine();
                                    Console.Write("Image: ");
                                    tmp.Image = Console.ReadLine();
                                    context.SaveChanges();
                                }
                                catch 
                                {
                                    Console.WriteLine("wrong id");
                                    continue;
                                }
                                break; 
                            }
                        case 4:
                            {
                                
                                Console.Write("Name: ");
                                string tmpName = Console.ReadLine();
                                Console.Write("Telephone: ");
                                string tmpTelephone = Console.ReadLine();
                                Console.Write("Image: ");
                                string tmpImage = Console.ReadLine();


                                List<UserProfile> tmp = context.UserProfiles.Where
                                    (x=>(((!string.IsNullOrEmpty(tmpName))?(x.Name == tmpName):true)&&
                                    ((!string.IsNullOrEmpty(tmpTelephone)) ? (x.Telephone == tmpTelephone):true)&&
                                    ((!string.IsNullOrEmpty(tmpImage)) ? (x.Image == tmpImage) : true))).ToList();
                                foreach (var user in tmp)
                                {
                                    Console.WriteLine($"Id: {user.Id}\t" +
                                        $"Name: {user.Name}\t" +
                                        $"Telephone: {user.Telephone}\t" +
                                        $"Image: {user.Image}");
                                }
                                break;

                            }
                        case 5:
                            {
                                int _id;
                                Console.Write("Id: ");
                                try
                                {
                                    _id = int.Parse(Console.ReadLine());
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                                try
                                {
                                    context.UserProfiles.Remove(context.UserProfiles.Find(_id));
                                    context.SaveChanges();
                                }
                                catch 
                                {
                                    Console.WriteLine("wrong id");
                                    continue;
                                }
                                break;

                            }
                        case 6:
                            {
                                int _id;
                                Console.Write("Id: ");
                                try
                                {
                                    _id = int.Parse(Console.ReadLine());
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                                try
                                {
                                    UserProfile tmp = context.UserProfiles.Find(_id);
                                    Console.WriteLine($"Id: {tmp.Id}\t" +
                                    $"Name: {tmp.Name}\t" +
                                    $"Telephone: {tmp.Telephone}\t" +
                                    $"Image: {tmp.Image}");
                                }
                                catch 
                                {
                                    Console.WriteLine("wrong id");
                                    continue;
                                }
                                break;
                            }
                        default:
                            break;
                    }

                } while (action != 0);
            }
        }
    }
}
