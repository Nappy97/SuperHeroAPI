﻿using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperHeroController : Controller
{
    private readonly ISuperHeroService _superHeroService;

    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        return await _superHeroService.GetAllHeroes();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
    {
        var result = await _superHeroService.GetSingleHero(id);
        if (result is null)
            return NotFound("읎어ㅏ!");

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        var result = await _superHeroService.AddHero(hero);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
    {
        var result = await _superHeroService.UpdateHero(id, request);

        if (result is null)
            return NotFound("읎어ㅏ!");

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<SuperHero>> DeleteHero(int id)
    {
        var result = await _superHeroService.DeleteHero(id);

        if (result is null)
            return NotFound("읎어ㅏ!");

        return Ok(result);
    }
}