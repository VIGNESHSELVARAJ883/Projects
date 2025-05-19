namespace CRUD.DTO
{
    public class EmployeeFilterDto
    {
        public string? Filter { get; set; }
        public string? OrderByField { get; set; }
        public string? OrderBy { get; set; }
        public int? NoOfRecords { get; set; }

    }

}
