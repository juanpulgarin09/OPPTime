namespace OPPTime.Backend;

public class Time
{
    //Fields
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;


    //Constructor
    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        _millisecond = 0;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    //Properties
    public int Hour
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

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }



//Methods

    public override string ToString()
    {
        string tt = Hour < 12 ? "AM" : "PM";
        int displayHour = Hour % 12;
        if (displayHour == 0) displayHour = 12;

        return $"{displayHour:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {tt}";
    }

    public long ToMilliseconds()
    {
        return ((long)Hour * 3_600_000)
             + ((long)_minute * 60_000)
             + ((long)_second * 1_000)
             + _millisecond;
    }

    public double ToSeconds() => ToMilliseconds() / 1_000.0;

    public double ToMinutes() => ToMilliseconds() / 60_000.0;

    public bool IsOtherDay(Time other)
    {
        return this.ToMilliseconds() + other.ToMilliseconds() >= 86_400_000;
    }

    public Time Add(Time other)
    {
        long total = (this.ToMilliseconds() + other.ToMilliseconds()) % 86_400_000;

        int ms = (int)(total % 1_000); total /= 1_000;
        int sec = (int)(total % 60); total /= 60;
        int min = (int)(total % 60); total /= 60;
        int hr = (int)(total % 24);

        return new Time(hr, min, sec, ms);
    }


    //Validations
    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour: {hour}, is not valid.");
        }
        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute}, is not valid.");
        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second}, is not valid.");
        }
        return second;
    }

    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond: {millisecond} , is not valid.");
        }
        return millisecond;
    }

}