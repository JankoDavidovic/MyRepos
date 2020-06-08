using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationClassLibrary
{
    public class HotelReservation
    {
        const int minDaySize = 0;
        const int maxDaySize = 365;

        const string accept = "Accept";
        const string decline = "Decline";

        public int Size { get; private set; }
        private int[,] schedule;

        public HotelReservation(int size)
        {
            if (size > 1000)
                throw new ArgumentException("Max hotel size must be less than 1000");

            this.Size = size;
            schedule = new int[size, maxDaySize];
        }
        public string ReserveRoom(Tuple<int, int> reservation)
        {
            string result = accept;
            int freeRoom = 0;

            if ((reservation.Item1 < minDaySize || reservation.Item1 > maxDaySize) ||
                (reservation.Item2 < minDaySize || reservation.Item2 > maxDaySize) ||
                reservation.Item1 > reservation.Item2)
            {
                result = decline;
                return result;
            }

            for (int i = 0; i < Size; i++)
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

                    result = accept;
                    break;
                }
            }

            if (freeRoom == -1)
            {
                result = decline;
            }

            return result;
        }
    }
}
