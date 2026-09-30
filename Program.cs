using System;

namespace RobotPrototypePattern
{
    
    public abstract class Robot : ICloneable
    {
        public string ModelName { get; set; }
        public int BatteryCapacity { get; set; }
        public string SoftwareVersion { get; set; }

        public abstract Robot Clone();

        object ICloneable.Clone()
        {
            return Clone();
        }

        public abstract void DisplayInfo();
    }

    
    public class ServiceRobot : Robot
    {
        public string ServiceTask { get; set; }

        public override Robot Clone()
        {
            return (ServiceRobot)this.MemberwiseClone();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Service Robot] Model: {ModelName}, Battery: {BatteryCapacity}h, Software: {SoftwareVersion}, Task: {ServiceTask}");
        }
    }

  
    public class IndustrialRobot : Robot
    {
        public string IndustrialTask { get; set; }

        public override Robot Clone()
        {
            return (IndustrialRobot)this.MemberwiseClone();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Industrial Robot] Model: {ModelName}, Battery: {BatteryCapacity}h, Software: {SoftwareVersion}, Task: {IndustrialTask}");
        }
    }

   
    public class EntertainmentRobot : Robot
    {
        public string EntertainmentFeature { get; set; }

        public override Robot Clone()
        {
            return (EntertainmentRobot)this.MemberwiseClone();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Entertainment Robot] Model: {ModelName}, Battery: {BatteryCapacity}h, Software: {SoftwareVersion}, Feature: {EntertainmentFeature}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
         
            ServiceRobot baseServiceRobot = new ServiceRobot
            {
                ModelName = "CareBot-X1",
                BatteryCapacity = 10,
                SoftwareVersion = "v1.0",
                ServiceTask = "Patient Care & Monitoring"
            };

            Console.WriteLine("--- Original Robot ---");
            baseServiceRobot.DisplayInfo();

            
            ServiceRobot customServiceRobot = (ServiceRobot)baseServiceRobot.Clone();
            customServiceRobot.BatteryCapacity = 14; 
            customServiceRobot.SoftwareVersion = "v1.1";

            Console.WriteLine("\n--- Cloned and Customized Robot ---");
            customServiceRobot.DisplayInfo();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}