namespace TimeStructures;
/// <summary>
/// Struktura reprezentująca obszar w czasie
/// </summary>
public readonly struct TimePeriod: IEquatable<TimePeriod>, IComparable<TimePeriod>
{
    public long Seconds { get; }
    
    #region consturctors
    public TimePeriod(int hours = 0, int minutes = 0, int seconds = 0)
    {
        Seconds = hours * 3600 + minutes * 60 + seconds;
    }
    
    public TimePeriod(byte hours = 0, byte minutes = 0, byte seconds = 0) : 
        this(Convert.ToInt32(hours),
            Convert.ToInt32(minutes),
            Convert.ToInt32(seconds))
    {
        
    }

    public TimePeriod(long secondsBetween)
    {
        Seconds = secondsBetween;
    }

    public TimePeriod(Time t1, Time t2)
    {
        var tdiff = t1 - t2;
        Seconds = tdiff.Hours * 3600 + tdiff.Minutes * 60 + tdiff.Seconds;
    }

    public TimePeriod(string timeString)
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

        Seconds = hours * 3600 + minutes * 60 + seconds;
    }
    #endregion

    #region Operators
    public bool Equals(TimePeriod other)
    {
        return Seconds == other.Seconds;
    }

    public int CompareTo(TimePeriod other)
    {
        if (Seconds > other.Seconds)
            return 1;
        if (Seconds < other.Seconds)
            return -1;
        return 0;
    }
    
    

    public static bool operator ==(TimePeriod t1, TimePeriod t2)
    {
        return t1.Equals(t2);
    }

    public static bool operator !=(TimePeriod t1, TimePeriod t2)
    {
        return !(t1 == t2);
    }
    public static bool operator < (TimePeriod t1, TimePeriod t2)
    {
        if (t1.Seconds < t2.Seconds)
            return true;
        if (t1.Seconds > t2.Seconds)
            return false;
        return false;
    }

    public static bool operator >(TimePeriod t1, TimePeriod t2)
    {
        if (t1.Seconds > t2.Seconds)
            return true;
        if (t1.Seconds < t2.Seconds)
            return false;
        return false;
    }

    public static bool operator >=(TimePeriod t1, TimePeriod t2)
    {
        if (t1.Seconds > t2.Seconds)
            return true;
        if (t1.Seconds < t2.Seconds)
            return false;
        return true;
    }

    public static bool operator <=(TimePeriod t1, TimePeriod t2)
    {
        if (t1.Seconds < t2.Seconds)
            return true;
        if (t1.Seconds > t2.Seconds)
            return false;
        return true;
    }

    public static TimePeriod operator +(TimePeriod t1, TimePeriod t2)
    {
        return new TimePeriod(t1.Seconds + t2.Seconds);
    }

    public static TimePeriod operator -(TimePeriod t1, TimePeriod t2)
    {
        return new TimePeriod(Math.Abs(t1.Seconds - t2.Seconds));
    }
    #endregion
    
    public override string ToString()
    {
        double hours   = Seconds / 3600d;
        double minutes = (hours - Math.Truncate(hours)) * 60;
        double seconds = (minutes - Math.Truncate(minutes)) * 60;
        return $"{Math.Truncate(hours).ToString("00")}:{Math.Truncate(minutes).ToString("00")}:{Math.Truncate(seconds).ToString("00")}";
    }
}