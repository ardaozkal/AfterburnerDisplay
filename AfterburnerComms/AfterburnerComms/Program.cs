using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSI.Afterburner;

namespace AfterburnerComms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AfterburnerDisplay by ardaozkal, open source on https://github.com/ardaozkal/AfterburnerDisplay");
            Console.WriteLine("Make sure MSI Afterburner is running and the ESP8266 is plugged in.");
            Console.WriteLine("Port Name? (COM3, COM4 etc):");
            var portname = Console.ReadLine();
            Console.WriteLine("Baud Rate? (default is 9600 - you still need to type):");
            var baudrate = int.Parse(Console.ReadLine());
            Console.WriteLine("Refresh Rate? (in milliseconds, so 1000 = 1 second. Higher the value, higher the accuracy of data displayed but higher screen flashing):");
            var refreshrate = int.Parse(Console.ReadLine());
            SerialPort port = new SerialPort(portname, baudrate);
            port.Open();
            while (true)
            {
                var hardwareMonitor = new HardwareMonitor();
                Console.Clear();
                Console.Write("GPU1:");
                port.Write("?GPU1:");
                foreach (var thing in hardwareMonitor.Entries)
                {
                    if (thing.SrcName == "GPU1 temperature")
                    {
                        port.Write($"{Math.Floor(thing.Data)}C");
                        Console.Write($"{Math.Floor(thing.Data)}C");
                    }
                    if (thing.SrcName == "GPU1 usage")
                    {
                        port.Write($"|%{Math.Floor(thing.Data)}");
                        Console.WriteLine("");
                        Console.Write($"%{Math.Floor(thing.Data)}");
                    }
                }
                port.Write("|CPU:");
                Console.WriteLine("");
                Console.Write("CPU:");
                foreach (var thing in hardwareMonitor.Entries)
                {
                    if (thing.SrcName == "CPU temperature")
                    {
                        port.Write($"{Math.Floor(thing.Data)}C");
                        Console.Write($"{Math.Floor(thing.Data)}C");
                    }
                    if (thing.SrcName == "CPU usage")
                    {
                        port.Write($"|%{Math.Floor(thing.Data)}");
                        Console.WriteLine("");
                        Console.Write($"%{Math.Floor(thing.Data)}");
                    }
                }
                port.Write("|RAM:");
                Console.WriteLine("");
                Console.Write("RAM:");
                foreach (var thing in hardwareMonitor.Entries)
                {
                    if (thing.SrcName == "RAM usage")
                    {
                        var percentage = (thing.Data / thing.MaxLimit) * 100;
                        port.Write($"%{Math.Floor(percentage)}");
                        Console.Write($"%{Math.Floor(percentage)}");
                    }
                }
                System.Threading.Thread.Sleep(refreshrate);
            }
            port.Close();
        }
    }
}
