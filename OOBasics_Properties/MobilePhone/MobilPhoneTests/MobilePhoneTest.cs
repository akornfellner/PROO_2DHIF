using MobilePhoneLogic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectMobilePhone
{
    [TestClass]
    public class MobilePhoneTest
    {
        /// <summary>
        /// MobilePhone mit Nummer erzeugen
        /// </summary>
        [TestMethod()]
        public void T01_CreateSimpleMobilePhoneTest()
        {
            MobilePhone mobile = new MobilePhone("0123456");
            Assert.AreEqual("0123456", mobile.PhoneNumber);
        }

        /// <summary>
        /// MobilePhonemit Nummer und Namen erzeugen
        /// </summary>
        [TestMethod()]
        public void T02_CreateSimpleMobilePhoneTest()
        {
            MobilePhone mobile = new MobilePhone("0123456", "Huber");
            Assert.AreEqual("0123456", mobile.PhoneNumber);
            Assert.AreEqual("Huber", mobile.Name);
        }

        /// <summary>
        /// MobilePhone mit Nummer und fehlerhaftem Namen erzeugen
        /// </summary>
        [TestMethod()]
        public void T03_CreateErrorMobile_NameNull()
        {
            MobilePhone mobile = new MobilePhone("0123456", null);
            Assert.AreEqual("0123456", mobile.PhoneNumber);
            Assert.AreEqual("ERROR", mobile.Name);
        }

        [TestMethod()]
        public void T04_CreateErrorMobile_NameEmpty()
        {
            MobilePhone mobile = new MobilePhone("0123456", "");
            Assert.AreEqual("0123456", mobile.PhoneNumber);
            Assert.AreEqual("ERROR", mobile.Name);
        }

        [TestMethod()]
        public void T05_CreateErrorMobile_NameTooShort()
        {
            MobilePhone mobile = new MobilePhone("0123456", "A");
            Assert.AreEqual("0123456", mobile.PhoneNumber);
            Assert.AreEqual("ERROR", mobile.Name);
        }

        /// <summary>
        /// MobilePhone mit Nummer und fehlerhaftem Namen erzeugen
        /// </summary>
        [TestMethod()]
        public void T06_CreateErrorMobile_NameOk()
        {
            MobilePhone mobile = new MobilePhone("0123456", "A1");
            Assert.AreEqual("0123456", mobile.PhoneNumber);
            Assert.AreEqual("A1", mobile.Name);

            mobile = new MobilePhone("0123456", "1234");
            Assert.AreEqual("0123456", mobile.PhoneNumber);
            Assert.AreEqual("ERROR", mobile.Name);
        }


        /// <summary>
        /// Ersten Call erzeugen
        /// </summary>
        [TestMethod()]
        public void T07_SimpleCallTest()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            MobilePhone passive = new MobilePhone("9876543", "Passive");
            active.StartCallTo(passive);
            System.Threading.Thread.Sleep(3000);
            Assert.IsTrue(active.StopCall());
            Assert.AreEqual("9876543", active.LastCalledNumber, "LastCalledNumber");
            Assert.AreEqual(60, active.LastCallSeconds, "Active Seconds");
            Assert.AreEqual(60, passive.LastCallSeconds, "Passive Seconds");
        }

        /// <summary>
        /// Ersten Call verrechnen
        /// </summary>
        [TestMethod()]
        public void T08_SimpleToPayTest()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            MobilePhone passive = new MobilePhone("9876543", "Passive");
            active.StartCallTo(passive);
            System.Threading.Thread.Sleep(3000);
            Assert.IsTrue(active.StopCall());
            Assert.AreEqual(8, active.CentsToPay, "60 seconds ==> 1 minute ==> 8 cents");
        }

        /// <summary>
        /// Call knapp über 1 Minute verrechnen
        /// </summary>
        [TestMethod()]
        public void T09_ToPayTest()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            MobilePhone passive = new MobilePhone("9876543", "Passive");
            active.StartCallTo(passive);
            System.Threading.Thread.Sleep(3100);
            Assert.IsTrue(active.StopCall());
            Assert.AreEqual(12, active.CentsToPay, "62 seconds > 1 minute ==> 12 cents");
        }

        /// <summary>
        /// Mehrere Calls verrechnen
        /// </summary>
        [TestMethod()]
        public void T10_MoreCallsToPayTest()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            MobilePhone passive1 = new MobilePhone("1111111", "Passive1");
            MobilePhone passive2 = new MobilePhone("2222222", "Passive2");
            active.StartCallTo(passive1);
            System.Threading.Thread.Sleep(3000);
            Assert.IsTrue(active.StopCall(), "Stop Call passive1");
            active.StartCallTo(passive2);
            System.Threading.Thread.Sleep(2200);
            Assert.IsTrue(active.StopCall(), "Stop Call passive2");
            Assert.AreEqual(16, active.CentsToPay);
            Assert.AreEqual(60, passive1.LastCallSeconds, 1, "Passive 1 Sekunden");
            Assert.AreEqual(44, passive2.LastCallSeconds, 1, "Passive 2 Sekunden");
        }

        /// <summary>
        /// Mehrere Calls verrechnen
        /// </summary>
        [TestMethod()]
        public void T11_StopPassive()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            MobilePhone passive = new MobilePhone("9876543", "Passive");
            active.StartCallTo(passive);
            System.Threading.Thread.Sleep(3100);
            Assert.IsTrue(passive.StopCall());
            Assert.AreEqual(12, active.CentsToPay, "62 seconds > 1 minute ==> 12 cents");
            Assert.AreEqual(0, passive.CentsToPay);
            Assert.AreEqual(62, passive.LastCallSeconds, 1);
            Assert.AreEqual(62, active.LastCallSeconds, 1);
        }

        /// <summary>
        /// StopCall ohne StartCall testen
        /// </summary>
        [TestMethod()]
        public void T12_StopCallErrorTest()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            Assert.IsFalse(active.StopCall());
        }

        [TestMethod()]
        public void T13_BusyPhoneTest()
        {
            MobilePhone active = new MobilePhone("0123456", "Active");
            MobilePhone passive = new MobilePhone("9876543", "Passive");
            MobilePhone active2 = new MobilePhone("01234562", "Active2");
            MobilePhone passive2 = new MobilePhone("01234563", "Passive2");
            bool result = active.StartCallTo(passive);
            Assert.AreEqual(true, result, "First call should be ok!");
            result = active.StartCallTo(passive2);
            Assert.AreEqual(false, result, "Active phone already busy! Returnvalue false expected!");
            result = active2.StartCallTo(passive);
            Assert.AreEqual(false, result, "Passive phone already busy! Returnvalue false expected!");
            System.Threading.Thread.Sleep(1000);
            Assert.IsTrue(active.StopCall());
            result = active.StartCallTo(passive2);
            Assert.AreEqual(true, result, "After call has ended, a new call shall be available");
        }

    }
}
