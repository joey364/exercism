using System;

class RemoteControlCar
{
    private int _distance = 0;
    private int _battery = 100;

    private int _speed = 20;
    private int _batteryDrain = 1;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        if (_battery == 0) return "Battery empty";
        return $"Battery at {_battery}%";
    }

    public void Drive()
    {
        if (_battery > 0)
        {
            _battery -= _batteryDrain;
            _distance += _speed;
        }
    }
}
