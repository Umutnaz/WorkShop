using Core;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repository.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/clothing")]
public class ClothingController : ControllerBase
{
    private IClothingRepository _repository;

    public ClothingController(IClothingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("getall")]
    public async Task<Clothing[]> getall()
    {
        return await _repository.GetAllClothing();
    }

    [HttpGet]
    [Route("getclothingowner/{ownerId:int}")]
    public async Task<Clothing[]> getClothingByOwnerId(int ownerId)
    {
        return await _repository.GetClothingByOwnerId(ownerId);
    }

    [HttpGet]
    [Route("getoneclothing/{clothingId:int}")]
    public async Task<Clothing> getClothingByClothingId(int clothingId)
    {
        return await _repository.GetClothingById( clothingId);
    }

    [HttpPost]
    [Route("add")]
    public void add(Clothing clothing)
    {
        _repository.AddClothing(clothing);
    }

    [HttpDelete]
    [Route("delete/{clothingId:int}")]
    public void delete(int clothingId)
    {
        _repository.DeleteClothingById(clothingId);
    }

    [HttpPut]
    [Route("update/{clothingId:int}")]
    public void update(int clothingId, Clothing updatedClothing)
    {
        _repository.UpdateClothingById(clothingId, updatedClothing);
    }
    
}