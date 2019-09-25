namespace SystemServiceContract.Core
{
    public enum SSC_MoveMode
    {
        REL,
        ABS
    }

    public enum SSC_PMUnitEnum
    {
        dBm,
        dB,
        mW,
        mA,
    }

    public enum SSC_IOStatusEnum
    {
        Disabled = 0,
        Enabled
    }

    public enum SSC_IOTypeEnum
    {
        Input = 0,
        Output
    }

    public enum SSC_PMRangeEnum
    {
        Range1 = 1,
        Range2,
        Range3,
        Range4,
        Range5,
        Range6,
    }

}
