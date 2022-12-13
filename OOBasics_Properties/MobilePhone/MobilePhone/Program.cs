// See https://aka.ms/new-console-template for more information

using MobilePhoneLogic;

MobilePhone active = new MobilePhone("0123456", "Active");
MobilePhone passive = new MobilePhone("9876543", "Passive");
active.StartCallTo(passive);
System.Threading.Thread.Sleep(3100);
active.StopCall();