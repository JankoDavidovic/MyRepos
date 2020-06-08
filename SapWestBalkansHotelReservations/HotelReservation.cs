using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapWestBalkansHotelReservations
{
    public class Rooms
    {
        int size = 2;
        static int startDate = Int32.Parse(Console.ReadKey().ToString());
        static int endDate = Int32.Parse(Console.ReadKey().ToString());
        Tuple<int, int> tuple = new Tuple<int, int>(startDate, endDate);
        List<int> RoomOneAll;
        List<int> RoomOneNone;
        List<int> RoomTwoAll;
        List<int> RoomTwoNone;

        public Rooms()
        {
            RoomOneAll = new List<int>();
            RoomOneNone = new List<int>();
            RoomTwoAll = new List<int>();
            RoomTwoNone = new List<int>();
            for (int i = 0; i < 365; i++)
            {
                RoomOneAll.Add(i);
                RoomTwoAll.Add(i);
            }
        }

    }

    class HotelReservation
    {
        static void Main(string[] args)
        {
            int size = 2;
            int numOfDays = 11;
            int[,] schedule = new int[size, numOfDays];

            List<Tuple<int, int>> allReservation = new List<Tuple<int, int>>();
            allReservation.Add(new Tuple<int, int>(1, 3));
            allReservation.Add(new Tuple<int, int>(0, 4));
            allReservation.Add(new Tuple<int, int>(2, 3));
            allReservation.Add(new Tuple<int, int>(5, 5));
            allReservation.Add(new Tuple<int, int>(4, 10));
            allReservation.Add(new Tuple<int, int>(10, 10));
            allReservation.Add(new Tuple<int, int>(6, 7));
            allReservation.Add(new Tuple<int, int>(8, 10));
            allReservation.Add(new Tuple<int, int>(8, 9));

            foreach (var reservation in allReservation)
            {
                int freeRoom = 0;
                for (int i = 0; i < size; i++)
                {
                    freeRoom = i;
                    for (int j = reservation.Item1; j <= reservation.Item2; j++)
                    {
                        if (schedule[i, j] == 1)
                        {
                            freeRoom = -1;
                            break;
                        }

                    }


                    if (freeRoom != -1)
                    {
                        for (int j = reservation.Item1; j <= reservation.Item2; j++)
                        {
                            schedule[freeRoom, j] = 1;
                        }

                        Console.WriteLine("Free room is room number: " + (freeRoom + 1));
                        Console.WriteLine("Accepted");
                        break;
                    }

                }

                if (freeRoom == -1)
                {
                    Console.WriteLine("Declined");
                }
                Print2DArray<int>(schedule);
            }

            Console.Read();
        }

        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
