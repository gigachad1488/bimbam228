namespace bimbam537;

public class Responsible
{
    
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    
    public Responsible(int id, string name, string surname)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
    }
}