using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InvestMent.Application.Features.IngredientsFeatures;
using InvestMent.DAL.DTOs;
using InvestMent.Domain.Models;
using InvestMent.Persistence;
using MediatR;

namespace InvestMent.Api.Controllers
{
    public class IngredientsController : ApiController
    {
        private readonly IMediator mediator;

        public IngredientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/Ingredients
        public async Task<List<IngredientsDTO>> GetIngredientNames()
        {
            return await mediator.Send(new GetIngredientsNameAndIdRequest());
        }

        //// GET: api/Ingredients/5
        //[ResponseType(typeof(Ingredient))]
        //public async Task<IHttpActionResult> GetIngredient(long id)
        //{
        //    Ingredient ingredient = await db.Ingredient.FindAsync(id);
        //    if (ingredient == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ingredient);
        //}

        //// PUT: api/Ingredients/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutIngredient(long id, Ingredient ingredient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != ingredient.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(ingredient).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IngredientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Ingredients
        //[ResponseType(typeof(Ingredient))]
        //public async Task<IHttpActionResult> PostIngredient(Ingredient ingredient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Ingredient.Add(ingredient);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = ingredient.Id }, ingredient);
        //}

        //// DELETE: api/Ingredients/5
        //[ResponseType(typeof(Ingredient))]
        //public async Task<IHttpActionResult> DeleteIngredient(long id)
        //{
        //    Ingredient ingredient = await db.Ingredient.FindAsync(id);
        //    if (ingredient == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Ingredient.Remove(ingredient);
        //    await db.SaveChangesAsync();

        //    return Ok(ingredient);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool IngredientExists(long id)
        //{
        //    return db.Ingredient.Count(e => e.Id == id) > 0;
        //}
    }
}
