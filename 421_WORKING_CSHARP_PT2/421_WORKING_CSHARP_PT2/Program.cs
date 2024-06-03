using System;

//TSK1
public class Light
{
    public bool IsTurnedOn { get; set; }
    public int Brightness { get; set; }
    public string Color { get; set; }

    public void SwitchLight()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void ChangeBrightness(int brightness)
    {
        Brightness = brightness;
    }

    public void ChangeColor(string color)
    {
        Color = color;
    }

    public override string ToString()
    {
        return $"Light is turned {(IsTurnedOn ? "on" : "off")}, brightness: {Brightness}, color: {Color}";
    }
}

public class TV
{
    public bool IsTurnedOn { get; set; }
    public string Program { get; set; }

    public void SwitchTV()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void TurnOnProgram(string program)
    {
        Program = program;
    }

    public override string ToString()
    {
        return $"TV is turned {(IsTurnedOn ? "on" : "off")}, current program: {Program}";
    }
}

public class AirConditioner
{
    public bool IsTurnedOn { get; set; }
    public int Temperature { get; set; }

    public void Switch()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void SetTemperature(int temperature)
    {
        Temperature = temperature;
    }

    public override string ToString()
    {
        return $"Air Conditioner is turned {(IsTurnedOn ? "on" : "off")}, temperature: {Temperature}°C";
    }
}

public class MusicStation
{
    public bool IsTurnedOn { get; set; }
    public string Music { get; set; }

    public void Switch()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void SetMusic(string music)
    {
        Music = music;
    }

    public override string ToString()
    {
        return $"Music Station is turned {(IsTurnedOn ? "on" : "off")}, currently playing: {Music}";
    }
}

public class SmartHome
{
    private Light light = new Light();
    private TV tv = new TV();
    private AirConditioner airConditioner = new AirConditioner();
    private MusicStation musicStation = new MusicStation();

    public void SetUpHome(string mode)
    {
        switch (mode)
        {
            case "Night":
                light.SwitchLight();
                tv.SwitchTV();
                airConditioner.Switch();
                airConditioner.SetTemperature(20);
                break;
            case "Party":
                light.SwitchLight();
                tv.SwitchTV();
                airConditioner.Switch();
                airConditioner.SetTemperature(18);
                musicStation.Switch();
                musicStation.SetMusic("Lofi Hip Hop");
                break;
            case "Work":
                light.SwitchLight();
                tv.SwitchTV();
                airConditioner.Switch();
                airConditioner.SetTemperature(25);
                break;
            default:
                Console.WriteLine("Invalid mode.");
                break;
        }

        Console.WriteLine(light.ToString());
        Console.WriteLine(tv.ToString());
        Console.WriteLine(airConditioner.ToString());
        Console.WriteLine(musicStation.ToString());
    }
}

//TSK2
public class Facade
{
    private Engine engine = new Engine();
    private MusicPanel musicPanel = new MusicPanel();

    public void StartCar()
    {
        engine.Start();
        musicPanel.TurnOnMusic();
        Console.WriteLine("Car started.");
    }

    public void StopCar()
    {
        engine.Stop();
        musicPanel.TurnOffMusic();
        Console.WriteLine("Car stopped.");
    }

    private class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine started.");
        }

        public void Stop()
        {
            Console.WriteLine("Engine stopped.");
        }
    }

    private class MusicPanel
    {
        public void TurnOnMusic()
        {
            Console.WriteLine("Music turned on.");
        }

        public void TurnOffMusic()
        {
            Console.WriteLine("Music turned off.");
        }
    }
}

class Program
{
    static void Main()
    {
        //TSK 1
        SmartHome smartHome = new SmartHome();
        smartHome.SetUpHome("Night");
        smartHome.SetUpHome("Party");
        smartHome.SetUpHome("Work");

        //TSK2
        Facade carFacade = new Facade();
        carFacade.StartCar();
        carFacade.StopCar();
    }
}
