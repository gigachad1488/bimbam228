namespace bimbam537;

public class Status
{
    public int id { get; set; }
    
    public string status { get; set; }

    public Status(int id, string sts)
    {
        this.id = id;
        status = sts;
    }
}