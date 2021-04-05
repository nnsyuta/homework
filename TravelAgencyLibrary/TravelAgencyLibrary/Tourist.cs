using System;

namespace TravelAgencyLibrary
{
    public class Tourist
    {
        public string Name;
        public string Surname;
        public readonly long TourCode;
        public DateTime FirstDayOfTravel;
        public readonly DateTime LastDayOfTravel;
        public long PriceOfTravel;

        public readonly TypeOfPayment PaymentType;

        public int DurationOfTravel
        {
            get
            {
                return ((int)(LastDayOfTravel - FirstDayOfTravel).TotalDays);
            }
        }

        public Tourist(string name, string surname, long tourCode, string firstDayOfTravel, string lastDayOfTravel, long priceOfTravel, TypeOfPayment paymentType)
        {
            Name = name;
            Surname = surname;
            TourCode = tourCode;
            FirstDayOfTravel = DateTime.Parse(firstDayOfTravel);
            LastDayOfTravel = DateTime.Parse(lastDayOfTravel);
            PriceOfTravel = priceOfTravel;
            PaymentType = paymentType;
            
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {TourCode}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);

            string paymentType="";
            switch (PaymentType)
            {
                case TypeOfPayment.Cash:
                    paymentType = "оплата наличными";
                    break;
                case TypeOfPayment.Card:
                    paymentType = "оплата банковской картой";
                    break;
                case TypeOfPayment.Transfer:
                    paymentType = "оплата по номеру счета";
                    break;
            }

            Console.WriteLine($"Дата начала тура: {FirstDayOfTravel:d}. Продолжительность тура: {DurationOfTravel}. Дата окончания тура: {LastDayOfTravel:d}. Стоимость тура: {PriceOfTravel}. Тип платежа: {paymentType}.");
        }
    }
}
