namespace kubernetes.dotnet.domain.Entities;

public class Base{
    public long Id { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate {get; set;}

    public DateTime? EditedDate {get; set;}

    public DateTime? DeletedDate {get; set;}

    public bool IsActive {get; set;} = true;
}