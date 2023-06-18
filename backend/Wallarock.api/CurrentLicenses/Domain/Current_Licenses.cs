namespace License.viewer.api.Models;

public sealed class Current_Licenses
{
    public Current_Licenses(
        string devicecode,
        string mac,
        string expiredate,
        string calldate,
        string contractnumber,
        string devicechanged,
        string typeofcontract,
        string customertype,
        Boolean demo,
        string requestedby,
        string region,
        string productid,
        string environment,
        string details
    )
    {
        this.DeviceCode = devicecode;
        this.MAC = mac;
        this.ExpireDate = expiredate;
        this.CallDate = calldate;
        this.ContractNumber = contractnumber;
        this.DeviceCode = devicecode;
        this.DeviceChanged = devicechanged;
        this.TypeOfContract = typeofcontract;
        this.CustomerType = customertype;
        this.Demo = demo;
        this.RequestedBy = requestedby;
        this.Region = region;
        this.ProductID = productid;
        this.Environment = environment;
        this.Details = details;
    }
    public string DeviceCode { get; }

    public string MAC { get; }

    public string ExpireDate { get;  }

    public string CallDate { get;  }

    public string ContractNumber { get; }

    public string DeviceChanged { get;  }

    public string TypeOfContract { get; }

    public string CustomerType { get;  }
    public Boolean Demo { get; }

    public string RequestedBy { get;  }

    public string Region { get; }

    public string ProductID { get; }

    public string Environment { get; }

    public string Details { get; }

}
