namespace bimbam537;

public class ResponsiblesForRequest
{
    public int id { get; set; }
    public int requestId { get; set; }
    public int responsibleId { get; set; }
    
    public ResponsiblesForRequest(int id, int requestId, int responsibleId)
    {
        this.id = id;
        this.requestId = requestId;
        this.responsibleId = responsibleId;
    }
}