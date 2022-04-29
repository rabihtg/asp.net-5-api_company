namespace PersonalProjectClassLibrary.Models
{
    public record RoleModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public AllowedActions AllowedActions { get; init; }
    }
    public enum AllowedActions
    {
        read = 1,
        write,
        delete,
        readWrite,
        readWriteDelete,
        readWriteDeleteUpdate
    }
}