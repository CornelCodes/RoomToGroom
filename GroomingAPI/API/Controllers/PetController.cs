using API.Data;
using API.Models;
using GroomingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private GroomingDbContext dbContext;
        private IUserService _userService;

        public PetController(GroomingDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            _userService = userService;
        }

        //Get the pet by their PetId
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(long petId)
        {
            var result = await dbContext.Pets.SingleAsync(p => p.PetId == petId);
            return Ok(result);
        }

        //Get all pets
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await dbContext.Customers.Where(c => c.UserId == _userService.GetUserId()).ToListAsync();
            var pets = new List<Pet>();
            foreach(var customer in customers)
            {
                var customerPets = await dbContext.Pets.Where(p => p.CustomerId == customer.CustomerId).ToListAsync();
                foreach(var pet in customerPets)
                {
                    pets.Add(pet);
                }
            }
            return Ok(pets);
        }

        //Get by CustomerId
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByCustomerId(long customerId)
        {
            var state = ModelState;

            var result = await dbContext.Pets.Where(p => p.CustomerId == customerId).ToListAsync();

            return Ok(result);
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Pet pet)
        {
            var state = ModelState;

            Pet newPet = new Pet()
            {
                Name = pet.Name,
                Breed = pet.Breed,
                VisualDescription = pet.VisualDescription,
                Allergies = pet.Allergies,
                TagSerialNumber = pet.TagSerialNumber,
                CustomerId = pet.CustomerId
            };

            var result = dbContext.Pets.Add(newPet);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await dbContext.Pets.FirstOrDefaultAsync(p => p.PetId == id);

            if(result != null)
            {
                dbContext.Pets.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return Ok(result);
        }

        //Update
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]Pet pet)
        {
            var petEntity = await dbContext.Pets.FirstOrDefaultAsync(p => p.PetId == pet.PetId);

            if (petEntity != null)
            {
                petEntity.Name = pet.Name;
                petEntity.Breed = pet.Breed;
                petEntity.VisualDescription = pet.VisualDescription;
                petEntity.Allergies = pet.Allergies;
                petEntity.TagSerialNumber = pet.TagSerialNumber;
                await dbContext.SaveChangesAsync();
            }

            return Ok(petEntity);
        }

    }
}
