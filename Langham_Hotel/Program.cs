
/*
*
*Project Name: LANGHAM HOTEL
*Author Name: MATAMARIE HOKO
*Date: 04/04/2024
*Application Purpose: ASSIGNMENT 
*
*/
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
namespace Assessment2Task2
{

    public class Room
    {
        public static int RoomNumbers;
        public bool RoomIsAllocated;

        public static void AddRooms()

        {
            try
            {
                Console.WriteLine("You have selected 'Add rooms' from the MENU \n Please enter Total amount of rooms for Hotel: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Hotel has " + num + " rooms in Total ");

                string sDateTime = DateTime.Now.ToString();
                string filepath = @"Add_Rooms_To_Hotel.txt";
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine("Please enter room number: " + i);
                        string RoomNumber = Console.ReadLine();
                        sw.WriteLine(RoomNumber);
                        sw.WriteLine(sDateTime);
                    }
                    Console.WriteLine("Thank you rooms have now been added");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("exception is: " + ex.Message);
            }
        }

        public static void DisplayRoom()
        {
            string filepath = @"Add_Rooms_To_Hotel.txt";
            string all_text;
            all_text = File.ReadAllText(filepath);
            Console.WriteLine(all_text);
        }
    }

    public class Customer
    {

        public string[] ReadAllLines;

        public static void Deallocation()
        {
            try
            {
                Console.WriteLine("You have selected 'Deallocate rooms' from the menu \n all rooms you have previously allocated will be removed \n would you like to carry on ? [y/n]");
                char ans = Convert.ToChar(Console.ReadLine());


                string filepath = @"lhms_studentid.txt";

                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                    if (ans == 'y' || ans == 'Y')
                    {
                        fs.SetLength(0);
                        fs.Close();
                    }
                    else
                    {
                        Console.WriteLine("Thank you Rooms are still assigned");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception is " + ex.Message);
            }

        }

    }

    public class RoomAllocation
    {
        public int RoomNum;
        public string RoomName;



        public static void AllocateRoomNo()
        {
            try
            {
                Console.WriteLine("You have selected 'Allocate rooms' from the MENU \n Please enter Total amount of rooms you want to allocate: ");
                int num = Convert.ToInt32(Console.ReadLine());

                string sDateTime = DateTime.Now.ToString();
                string filepath = @"lhms_studentid.txt";
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine("Please enter Customer Number: " + i);
                        string CustomerNo = (Console.ReadLine());
                        Console.WriteLine("Please enter Name: " + i);
                        string CustomerName = Console.ReadLine();
                        Console.WriteLine("Please enter Room Number: " + i);
                        int AllocateRoom = Convert.ToInt32(Console.ReadLine());
                        sw.WriteLine(CustomerNo + CustomerName + AllocateRoom);
                        sw.WriteLine(sDateTime);
                    }
                }
                Console.WriteLine("Rooms have now been allocated");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception is: " + ex.Message);
            }
        }

        public static void AllocatedCustomer()
        {
            string filepath = @"lhms_studentid.txt";
            string all_text;
            all_text = File.ReadAllText(filepath);
            Console.WriteLine(all_text);
        }

        public static void Copy()
        {
            try
            {
                string Src = @"Add_Rooms_To_Hotel.txt";
                string Dest = @"lhms_studentid.txt";

                File.Copy(Src, Dest);

                Console.WriteLine("Room Allocation details has successfully been saved to a file");

                File.Delete(Src);
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception is: " + ex.Message);
            }
        }

        public static void Backup()
        {
            try
            {
                string src = @"lhms_studentid.txt";
                string dest = @"lhms_studentid_backup.txt";

                Console.WriteLine("File is appending now");

                IEnumerable<string> lines = File.ReadAllLines(src);
                File.AppendAllLines(dest, lines);

                Console.WriteLine("File is backed up successfully");

                File.Delete(src);
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception is: " + ex.Message);
            }

        }


    }

    class Program
    {

        public static Room[] listofRooms;
        public static int[] listOfRoomAllocations;
        public static string filePath;
        public static string[] ReadAllLines;

        static void Main(string[] args)
        {
            try
            {

                string folderPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                filePath = Path.Combine(folderPath, "lhms_studentid.txt");

                string folderPath2 =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                filePath = Path.Combine(folderPath, "Add_Rooms_To_Hotel.txt");

                string folderPath3 =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                filePath = Path.Combine(folderPath, "lhms_studentid_backup.txt");
                char ans;

                do
                {
                    Console.Clear();

                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("LANGHAM HOTEL MANAGEMENT SYSTEM ");
                    Console.WriteLine("MENU");
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("1. Add Rooms");
                    Console.WriteLine("2. Display Rooms");
                    Console.WriteLine("3. Allocate Rooms");
                    Console.WriteLine("4. De-Allocate Rooms");
                    Console.WriteLine("5. Display Room Allocation Details");
                    Console.WriteLine("6. Billing");
                    Console.WriteLine("7. Save the Room Allocations To a File");
                    Console.WriteLine("8. Show the Room Allocations From a File");
                    Console.WriteLine("9. Exit");
                    Console.WriteLine("0. for backing up File");
                    Console.WriteLine("************************************************************************************");

                    Console.Write("Enter Your Choice Number Here:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            RoomAllocation.Backup();
                            break;
                        case 1:
                            Room.AddRooms();
                            break;
                        case 2:
                            Room.DisplayRoom();
                            break;
                        case 3:
                            RoomAllocation.AllocateRoomNo();
                            break;
                        case 4:
                            Customer.Deallocation();
                            break;
                        case 5:
                            RoomAllocation.AllocatedCustomer();
                            break;
                        case 6:
                            Console.WriteLine("Unfortunately Billing System in currently under construction and will be back soon");
                            break;
                        case 7:
                            RoomAllocation.Copy();
                            break;
                        case 8:
                            RoomAllocation.AllocatedCustomer();
                            break;
                        case 9:
                            Console.WriteLine("Thank you, press any key to Exit");
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                    Console.Write("\nWould You Like To Continue(Y/N):");
                    ans = Convert.ToChar(Console.ReadLine());
                } while (ans == 'y' || ans == 'Y');
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is: " + ex.Message);
            }
        }
    }
}
