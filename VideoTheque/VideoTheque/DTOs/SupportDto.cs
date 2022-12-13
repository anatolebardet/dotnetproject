namespace VideoTheque.DTOs
{
    public class SupportDto
    {

        public SupportDto(int Id)
        {
            this.Id = Id;
        }

        public SupportDto(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public SupportDto()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public SupportDto(string name, int Id) {
            Name = name;
            this.Id = Id;
        }
        public SupportDto(int Id) {
            this.Id = Id;
        }
        public SupportDto() { }
    }
}
