using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TravelAgencyLibrary;
namespace TravelAgencyTestUnit
{
    [TestClass]
    public class TouristUnitTests
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            
            var ivanov = CreateTestTourist();
            long myCode = 153486;

            Assert.AreEqual("Pavel", ivanov.Name);
            Assert.AreEqual("Ivanov", ivanov.Surname);
            Assert.AreEqual(myCode, ivanov.TourCode) ;
            Assert.AreEqual("01.06.2021", ivanov.FirstDayOfTravel.ToShortDateString());
            Assert.AreEqual("15.06.2021", ivanov.LastDayOfTravel.ToShortDateString());
            Assert.AreEqual(14, ivanov.DurationOfTravel);
            Assert.AreEqual(70000, ivanov.PriceOfTravel);
            Assert.AreEqual(TypeOfPayment.Card, ivanov.PaymentType);
        }
        [TestMethod]
        public void ToStringTestMethod()
        {
            var ivanov = CreateTestTourist();
            Assert.AreEqual("Pavel Ivanov 153486", ivanov.ToString());
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var ivanov = CreateTestTourist();
            var petrova = new Tourist("Anna", "Petrova", 123123123123123123, "27.02.2021", "20.04.2021", 500600, TypeOfPayment.Transfer);
            var consoleOut = new[] { "Pavel Ivanov 153486", $"Дата начала тура: 01.06.2021. Продолжительность тура: 14. Дата окончания тура: 15.06.2021. Стоимость тура: 70000. Тип платежа: оплата банковской картой.", "Anna Petrova 123123123123123123", $"Дата начала тура: 27.02.2021. Продолжительность тура: 52. Дата окончания тура: 20.04.2021. Стоимость тура: 500600. Тип платежа: оплата по номеру счета." };

          
            TextWriter oldOut = Console.Out;
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            ivanov.PrintInfo();
            petrova.PrintInfo();
            Console.SetOut(oldOut);
            Console.WriteLine(output);
            var outputArray = output.ToString().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            
            Assert.AreEqual(4, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        private Tourist CreateTestTourist()
        {
            return new Tourist("Pavel", "Ivanov", 153486, "01.06.2021", "15.06.2021", 70000, TypeOfPayment.Card);
        }
    }
}
