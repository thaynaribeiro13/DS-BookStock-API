using BookStock.Data;
using BookStock.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStock.Models.Enuns;

namespace BookStock.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivrosController : ControllerBase
    {
        
        private readonly DataContext _context;

        public LivrosController(DataContext context)
        {
            _context = context;
        }
    

    
    [HttpGet("{id}")] //Buscar livro por id
    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            Livro l = await _context.TB_LIVROS
                .FirstOrDefaultAsync(lBusca => lBusca.Id == id);
            
            return Ok(l);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAll")] //Buscar todos os livros
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Livro> lista = await _context.TB_LIVROS.ToListAsync();
            return Ok(lista);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Livro novoLivro)
    {
        try
        {
            _context.TB_LIVROS.Update(novoLivro);
            int idAlterado = await _context.SaveChangesAsync();
            return Ok(idAlterado);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Livro pRemover = await _context.TB_LIVROS.FirstOrDefaultAsync(p => p.Id == id);

            _context.TB_LIVROS.Remove(pRemover);
            int idDeletado = await _context.SaveChangesAsync();
            return Ok(idDeletado);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    }
}