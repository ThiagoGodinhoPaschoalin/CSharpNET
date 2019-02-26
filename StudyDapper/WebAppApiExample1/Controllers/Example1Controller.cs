using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppApiExample1.Model;
using WebAppApiExample1.Models;
using Dapper;

namespace WebAppApiExample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Example1Controller : ControllerBase
    {
        private readonly WebAppApiExample1Context _context;
        private readonly IDbConnection _conn;

        public Example1Controller(IDbConnection dbConnection, WebAppApiExample1Context context)
        {
            _conn = dbConnection;
            _context = context;
        }

        #region DAPPER

        [Route("Dapper")]
        public async Task<IActionResult> Dapper_GetAllExample()
        {
            string sql = @"SELECT * FROM [dbo].[ExampleModel]";
            var result = await _conn.QueryAsync<ExampleModel>(sql);
            return Ok(result);
        }

        #endregion

        #region EF

        // GET: api/Example1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExampleModel>>> GetExampleModel()
        {
            return await _context.ExampleModel.ToListAsync();
        }

        // GET: api/Example1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleModel>> GetExampleModel(Guid id)
        {
            var exampleModel = await _context.ExampleModel.FindAsync(id);

            if (exampleModel == null)
            {
                return NotFound();
            }

            return exampleModel;
        }

        // PUT: api/Example1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExampleModel(Guid id, ExampleModel exampleModel)
        {
            if (id != exampleModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(exampleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExampleModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Example1
        [HttpPost]
        public async Task<ActionResult<ExampleModel>> PostExampleModel(ExampleModel exampleModel)
        {
            _context.ExampleModel.Add(exampleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExampleModel", new { id = exampleModel.Id }, exampleModel);
        }

        // DELETE: api/Example1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExampleModel>> DeleteExampleModel(Guid id)
        {
            var exampleModel = await _context.ExampleModel.FindAsync(id);
            if (exampleModel == null)
            {
                return NotFound();
            }

            _context.ExampleModel.Remove(exampleModel);
            await _context.SaveChangesAsync();

            return exampleModel;
        }

        private bool ExampleModelExists(Guid id)
        {
            return _context.ExampleModel.Any(e => e.Id == id);
        }

        #endregion
    }
}
