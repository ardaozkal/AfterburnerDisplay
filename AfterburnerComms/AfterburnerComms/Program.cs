using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSI.Afterburner;
using System.IO;

namespace AfterburnerComms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AfterburnerDisplay by ardaozkal, open source on https://github.com/ardaozkal/AfterburnerDisplay");
            Console.WriteLine("Make sure MSI Afterburner is running and the ESP8266 is plugged in.");
            var portname = "crash";
            var baudrate = 9600;
            var refreshrate = 1000;
            if (!File.Exists("config.ini"))
            {
                Console.WriteLine("Port Name? (COM3, COM4 etc):");
                portname = Console.ReadLine();
                Console.WriteLine("Baud Rate? (default is 9600 - you still need to type):");
                baudrate = int.Parse(Console.ReadLine());
                Console.WriteLine("Refresh Rate? (in milliseconds, so 1000 = 1 second. Higher the value, higher the accuracy of data displayed but higher screen flashing):");
                refreshrate = int.Parse(Console.ReadLine());
                File.WriteAllLines("config.ini", new List<string> { portname, baudrate.ToString(), refreshrate.ToString() });
                Console.WriteLine("Saved config and started working.");
            }
            else
            {
                var lines = File.ReadAllLines("config.ini");
                if (lines.Count() < 3)
                {
                    File.Delete("config.ini");
                    Console.WriteLine("Config was broken and was therefore removed, please restart the program.");
                }
                else
                {
                    portname = lines[0];
                    baudrate = int.Parse(lines[1]);
                    refreshrate = int.Parse(lines[2]);
                    Console.WriteLine("Loaded config and started working.");
                }
            }
            SerialPort port = new SerialPort(portname, baudrate);
            port.Open();
            while (true)
            {
                var hardwareMonitor = new HardwareMonitor();
                var GPUHeat = hardwareMonitor.Entries.Where(Entry => Entry.SrcName == "GPU1 temperature").FirstOrDefault().Data;
                var GPUUsage = hardwareMonitor.Entries.Where(Entry => Entry.SrcName == "GPU1 usage").FirstOrDefault().Data;
                var GPUText = $"?GPU1:{Math.Floor(GPUHeat)}C|%{Math.Floor(GPUUsage)}";
                
                var CPUHeat = hardwareMonitor.Entries.Where(Entry => Entry.SrcName == "CPU temperature").FirstOrDefault().Data;
                var CPUUsage = hardwareMonitor.Entries.Where(Entry => Entry.SrcName == "CPU usage").FirstOrDefault().Data;
                var CPUText = $"|CPU:{Math.Floor(CPUHeat)}C|%{Math.Floor(CPUUsage)}";

                var RAMValue = hardwareMonitor.Entries.Where(Entry => Entry.SrcName == "RAM usage").FirstOrDefault();
                var RAMText = $"|RAM:%{Math.Floor((RAMValue.Data / RAMValue.MaxLimit) * 100)}";

                port.Write(GPUText + CPUText + RAMText);

                System.Threading.Thread.Sleep(refreshrate);
            }
        }
    }
}
