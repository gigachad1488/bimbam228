using System.Collections.Generic;

namespace bimbam537;

public class Defect
{
    public int id { get; set; }
    public string defect { get; set; }

    public Defect(int id, string def)
    {
        this.id = id;
        defect = def;
    }
}