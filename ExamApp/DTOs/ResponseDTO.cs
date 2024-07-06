namespace ExamApp.DTOs;

public class ResponseDTO<T>
{
    public T Data { get; set; }

    public decimal UpdatedRowCount { get; set; }
}
