using System;

namespace bimbam537;

public class Request
{
    
    public int id { get; set; }
    public DateTime addDate { get; set; }
    public string equipment { get; set; }
    public string defectType { get; set; }
    public string problemDesc { get; set; }
    public string client { get; set; }
    public string requestStatus { get; set; }
    
    public Request(int id, DateTime addDate, string equipment, string defectType, string problemDesc, string client, string requestStatus)
    {
        this.id = id;
        this.addDate = addDate;
        this.equipment = equipment;
        this.defectType = defectType;
        this.problemDesc = problemDesc;
        this.client = client;
        this.requestStatus = requestStatus;
    }

}

public enum DefectType
{
    
}

public enum RequestStatus
{
    Pendind,
    InProgress,
    Done
}