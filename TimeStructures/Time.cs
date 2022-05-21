namespace TimeStructures;
/// <summary>
/// Struktura reprezentujaca punkt w czasie (max 24h),
/// możliwy jest czas na minusie (nie było uwagi na ten temat w projekcie)
/// </summary>
public readonly struct Time: IEquatable<Time>, IComparable<Time>
{
    public byte Hours { get; }
    public byte Minutes { get; }
    public byte Seconds { get; }

    #region consturctors
    public Time(int hours = 0, int minutes = 0, int seconds = 0)
    {
        Hours   = Convert.ToByte(hours % 24);
        Minutes = Convert.ToByte(minutes % 60);
        Seconds = Convert.ToByte(seconds % 60);
    }

    public Time(byte hours = 0, byte minutes = 0, byte seconds = 0) : 
        this(Convert.ToInt32(hours),
            Convert.ToInt32(minutes),
            Convert.ToInt32(seconds))
    {
        
    }

    public Time(string timeString)
    {
        string[] split = timeString.Split(":");
        if (split.Length == 0 || split.Length > 3)
        {
            throw new Exception("Not Proper Time Format");
        }

        byte hours = 0, minutes = 0, seconds = 0;
        switch (split.Length)
        {
            case 1:
                if(!byte.TryParse(split[0],out hours))
                    throw new Exception("Not Proper Time Format");
                break;
            case 2:
                if(!byte.TryParse(split[0],out hours) ||
                   !byte.TryParse(split[1],out minutes))
                    throw new Exception("Not Proper Time Format");
                break;
            case 3:
                if(!byte.TryParse(split[0],out hours) ||
                   !byte.TryParse(split[1],out minutes) ||
                   !byte.TryParse(split[2],out seconds))
                    throw new Exception("Not Proper Time Format");
                break;
            default:
                throw new Exception("Internal Exception");
        }

        Hours   = Convert.ToByte(hours % 24);
        Minutes = Convert.ToByte(minutes % 60);
        Seconds = Convert.ToByte(seconds % 60);
    }
    #endregion

    #region Operators
    public bool Equals(Time other)
    {
        return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
    }

    public int CompareTo(Time other)
    {
        if (Hours > other.Hours)
            return 1;
        if (Hours < other.Hours)
            return -1;
        if (Minutes > other.Minutes)
            return 1;
        if (Minutes < other.Minutes)
            return -1;
        if (Seconds > other.Seconds)
            return 1;
        if (Seconds < other.Seconds)
            return -1;
        return 0;
    }

    public static bool operator ==(Time t1, Time t2)
    {
        return t1.Equals(t2);
    }

    public static bool operator !=(Time t1, Time t2)
    {
        return !(t1 == t2);
    }
    public static bool operator < (Time t1, Time t2)
    {
        if (t1.Hours < t2.Hours)
            return true;
        if (t1.Hours > t2.Hours)
            return false;
        if (t1.Minutes < t2.Minutes)
            return true;
        if (t1.Minutes > t2.Minutes)
            return false;
        if (t1.Seconds < t2.Seconds)
            return true;
        if (t1.Seconds > t2.Seconds)
            return false;
        return false;
    }

    public static bool operator >(Time t1, Time t2)
    {
        if (t1.Hours > t2.Hours)
            return true;
        if (t1.Hours < t2.Hours)
            return false;
        if (t1.Minutes > t2.Minutes)
            return true;
        if (t1.Minutes < t2.Minutes)
            return false;
        if (t1.Seconds > t2.Seconds)
            return true;
        if (t1.Seconds < t2.Seconds)
            return false;
        return false;
    }

    public static bool operator >=(Time t1, Time t2)
    {
        if (t1.Hours > t2.Hours)
            return true;
        if (t1.Hours < t2.Hours)
            return false;
        if (t1.Minutes > t2.Minutes)
            return true;
        if (t1.Minutes < t2.Minutes)
            return false;
        if (t1.Seconds > t2.Seconds)
            return true;
        if (t1.Seconds < t2.Seconds)
            return false;
        return true;
    }

    public static bool operator <=(Time t1, Time t2)
    {
        if (t1.Hours < t2.Hours)
            return true;
        if (t1.Hours > t2.Hours)
            return false;
        if (t1.Minutes < t2.Minutes)
            return true;
        if (t1.Minutes > t2.Minutes)
            return false;
        if (t1.Seconds < t2.Seconds)
            return true;
        if (t1.Seconds > t2.Seconds)
            return false;
        return true;
    }

    public static Time operator +(Time t1, Time t2)
    {
        return new Time(t1.Hours + t2.Hours, t1.Minutes + t2.Minutes, t1.Seconds + t2.Seconds);
    }

    public static Time operator -(Time t1, Time t2)
    {
        return new Time(t1.Hours - t2.Hours, t1.Minutes - t2.Minutes, t1.Seconds - t2.Seconds);
    }
    #endregion

    public override string ToString()
    {
        return $"{Hours.ToString("00")}:{Minutes.ToString("00")}:{Seconds.ToString("00")}";
    }
}