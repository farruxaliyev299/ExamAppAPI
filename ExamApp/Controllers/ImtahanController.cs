using ExamApp.Abstraction;
using ExamApp.DAL;
using ExamApp.DTOs;
using ExamApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers;

[Route("[controller]")]
[ApiController]
public class ImtahanController : ControllerBase
{
    private readonly IImtahanService _dersService;
    public ImtahanController(ExamAppDbContext dbContext, IImtahanService dersService)
    {
        _dersService = dersService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _dersService.FetchAllAsync());
    }

    [HttpGet("{nomre:decimal}")]
    public async Task<IActionResult> Get(decimal nomre)
    {
        var obj = await _dersService.FetchAsync(nomre);

        if (obj == null)
        {
            return BadRequest(new { error = "Axtarılan nömrəyə uyğun imtahan tapılmadı." });
        }

        return Ok(obj);
    }


    [HttpPost]
    public async Task<IActionResult> Create(RequestDTO<Imtahan> request)
    {
        ResponseDTO<Imtahan> response = new();

        var obj = await _dersService.FetchAsync(request.RequestData.Nomre);

        if (obj != null)
        {
            return BadRequest(new { error = "Bu nömrə ilə imtahan movcuddur." });
        }

        response.UpdatedRowCount = await _dersService.CreateAsync(request.RequestData);

        response.Data = request.RequestData;

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(RequestDTO<Imtahan> request)
    {
        ResponseDTO<Imtahan> response = new();

        var obj = await _dersService.FetchAsync(request.RequestData.Nomre);

        if (obj == null)
        {
            return BadRequest();
        }

        response.UpdatedRowCount = await _dersService.UpdateAsync(request.RequestData);

        response.Data = obj;

        return Ok(response);
    }

    [HttpDelete("{nomre:decimal}")]
    public async Task<IActionResult> Delete(decimal nomre)
    {
        ResponseDTO<Imtahan> response = new();

        var obj = await _dersService.FetchAsync(nomre);

        if (obj == null)
        {
            return BadRequest();
        }

        response.UpdatedRowCount = await _dersService.DeleteAsync(obj);

        response.Data = obj;

        return Ok(response);
    }
}
