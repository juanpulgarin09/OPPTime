namespace OPPTime.Backend;

public class Time
{
//Fields
private int _hour;
private int _minute;
private int _second;
private int _millisecond;

//Constructors
public Time()
    {
        _hour = 0; 
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

public Time(int hour);
    {
        Hour = hour;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

public Time(int hour, int minute);
    {
         Hour = hour;
         Minute = minute;
         _second = 0;
         _millisecond = 0;
    }


public Time(int hour, int minute, int second);
    {
         Hour = hour;
         Minute = minute;
         Second = second;
         _millisecond = 0;
    }

public Time(int hour, int minute, int second, int millisecond);
    {
         Hour = hour;
         Minute = minute;
         Second = second;
         Millisecond = millisecond;
    }


//Properties
public int Hour(int hour)
    {
        get => _hour;
        set => _hour = ValidateHour(value); 
    }

public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);    
    }

public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value); 
    }

public int Milliseconds
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }



//Methods
private int ValidateHour(int hour);
{
    if(hour < 0 || hour > 23)
    {
        throw new ArgumentOutOfRangeException(nameof(hour),"Hour must be between 0 and 23.");
    }
    return hour;
}

private int ValidateMinute(int minute);
{
    if(minute < 0 || minute > 59 )
    {
        throw new ArgumentOutOfRangeException(nameof(minute), "Minute must be between 0 and 59.");
    }
    return minute();
}
