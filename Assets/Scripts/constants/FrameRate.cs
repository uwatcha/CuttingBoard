public static class FrameRate
{
    public const int fps = 60;
    public static double FrameToMilliseconds(int frame)
    {
        return (double)frame / fps * 1000;
    }
}