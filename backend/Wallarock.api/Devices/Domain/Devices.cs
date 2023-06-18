namespace License.viewer.api.Models;

public sealed class Devices
{
    public Devices(
        string devicecode,
        string demo,
        string specialtest,
        string mac1,
        string mac2,
        string mac3,
        string mac4,
        string mac5,
        string mac6,
        string environment
    )
    {
        this.DeviceCode = devicecode;
        this.Demo = demo;
        this.SpecialTest = specialtest;
        this.Mac1 = mac1;
        this.Mac2 = mac2;
        this.Mac3 = mac3;
        this.Mac4 = mac4;
        this.Mac5 = mac5;
        this.Mac6 = mac6;
        this.Environment = environment;
    }

    public string DeviceCode { get; private set; }
    public string Demo { get; private set; }
    public string SpecialTest { get; private set;}
    public string Mac1 { get; private set;}
    public string Mac2 { get; private set;}
    public string Mac3 { get; private set;}
    public string Mac4 { get; private set;}
    public string Mac5 { get; private set;}
    public string Mac6 { get; private set;}
    public string Environment { get; private set;}

}
