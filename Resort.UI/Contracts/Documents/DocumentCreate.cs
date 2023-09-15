namespace Resort.UI.Contracts.Documents;

public class DocumentCreate
{
    public string Name { get;  set; }
    public string Type { get;  set; }
    public string Extension { get;  set; }
    public long Size { get;  set; }
    public string Path { get;  set; }
}