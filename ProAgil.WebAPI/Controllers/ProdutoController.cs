using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebSalao.Domain.Cadasto;
using WebSalao.Repository;
using WebSalao.WebAPI.Dtos;

namespace WebSalao.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public IRepository _repo { get; }
        public IMapper _mapper { get; }

        public ProdutoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try  
            {
                var produtos = await _repo.GetAllProdutoAsync(true);
                var results = _mapper.Map<ProdutosDto[]>(produtos);
                return Ok(results);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"erro -> Banco de dados Falhou {ex.Message}");
            }
        }

        [HttpPost("{ProdutoId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int ProdutoId)
        {
            try
            {
                var produto = await _repo.GetProdutoAsyncById(ProdutoId, true);
                var results = _mapper.Map<ProdutosDto>(produto);

                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou");
            }
        }

        [HttpGet("getByDescricao/{descricao}")]
        public async Task<IActionResult> Get(string descricao)
        {
            try
            {
                var produtos = await _repo.GetAllProdutoAsyncByDescricao(descricao, true);

                var results = _mapper.Map<ProdutosDto[]>(produtos);

                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutosDto model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                _repo.Add(produto);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/produto/{model.ID}", _mapper.Map<ProdutosDto>(produto));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco de Dados Falhou {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{ProdutoId}")]
        public async Task<IActionResult> Put(int ProdutoId, ProdutosDto model)
        {
            try
            {
                //fazer as relaçao com as outras tabelas, ex - categoria, Fornecedores

                var produto = await _repo.GetEventoAsyncById(ProdutoId, false);
                if (produto == null) return NotFound();

                _mapper.Map(model, produto);
                _repo.Update(produto);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/produto/{model.ID}", _mapper.Map<ProdutosDto>(produto));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("{ProdutoId}")]
        public async Task<IActionResult> Delete(int ProdutoId)
        {
            try
            {
                var produto = await _repo.GetProdutoAsyncById(ProdutoId, false);
                if (produto == null) return NotFound();

                _repo.Delete(produto);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco de dados falhou");
            }

            return BadRequest();
        }


    }
}
