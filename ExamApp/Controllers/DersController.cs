using ExamApp.Abstraction;
using ExamApp.DAL;
using ExamApp.DTOs;
using ExamApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers;

[Route("[controller]")]
[ApiController]
public class DersController : ControllerBase
{
    private readonly IDersService _dersService;
    public DersController(ExamAppDbContext dbContext, IDersService dersService)
    {
        _dersService = dersService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _dersService.FetchAllAsync());
    }

    [HttpGet("{kod:regex(^.{{0,3}}$)}")]
    public async Task<IActionResult> Get(string kod)
    {
        var obj = await _dersService.FetchAsync(kod);

        if (obj == null)
        {
            return BadRequest(new { error = "Axtarılan koda uyğun dərs tapılmadı." });
        }

        return Ok(obj);
    }


    [HttpPost]
    public async Task<IActionResult> Create(RequestDTO<Ders> request)
    {
        ResponseDTO<Ders> response = new();

        var obj = await _dersService.FetchAsync(request.RequestData.Kod);

        if (obj != null)
        {
            return BadRequest(new { error = "Bu kod ilə dərs movcuddur." });
        }

        response.UpdatedRowCount = await _dersService.CreateAsync(request.RequestData);

        response.Data = request.RequestData;

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(RequestDTO<Ders> request)
    {
        ResponseDTO<Ders> response = new();

        var obj = await _dersService.FetchAsync(request.RequestData.Kod);

        if (obj == null)
        {
            return BadRequest();
        }

        response.UpdatedRowCount = await _dersService.UpdateAsync(request.RequestData);

        response.Data = request.RequestData;

        return Ok(response);
    }

    [HttpDelete("{kod:regex(^.{{0,3}}$)}")]
    public async Task<IActionResult> Delete(string kod)
    {
        ResponseDTO<Ders> response = new();

        var obj = await _dersService.FetchAsync(kod);

        if (obj == null)
        {
            return BadRequest();
        }

        response.UpdatedRowCount = await _dersService.DeleteAsync(obj);

        response.Data = obj;

        return Ok(response);
    }
}
