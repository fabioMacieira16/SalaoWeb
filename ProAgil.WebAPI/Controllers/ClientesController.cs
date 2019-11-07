using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSalao.Domain;
using WebSalao.Domain.Cadasto;
using WebSalao.Repository;
using WebSalao.WebAPI.Dtos;
using WebSalao.WebAPI.Dtos.CadastroDto;

namespace WebSalao.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController
    {
        public IRepository _repo { get; }
        public IMapper _mapper { get; }
        public ClientesController(IRepository repo, IMapper mapper)
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
                var cliente = await _repo.GetAllClientesAsync(true);
                var results = _mapper.Map<ClienteDto[]>(cliente);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("{ClienteId}")]
        public async Task<IActionResult> Get(int clienteId)
        {
            try
            {
                var cliente = await _repo.GetClientesAsyncById(clienteId, true);

                var results = _mapper.Map<ClienteDto>(cliente);

                return Ok(results);
            }
            catch (Exception ex)
            {

                return StatuCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getBydescricao/{descricao}")]
        public async Task<IActionResult> Get(string descricao)
        {
            try
            {
                var cliente = await _repo.GetAllClientesAsyncByDescricao(descricao, true);

                var results = _mapper.Map<ClienteDto[]>(cliente);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou { ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/clienteId/{model.ID}", _mapper.Map<ClienteDto>(cliente));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco de dados Falhou { ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{ClienteId}")]
        public async Task<IActionResult> Put(int ClienteId, ClienteDto model)
        {
            try
            {
                var cliente = await _repo.GetClientesAsyncById(ClienteId, false);
                if (cliente == null) return NotFound(); ;

                var idContas = new List<int>();

                model.Contas.ForEach(item => idContas.Add(item.Id));

                var contas = cliente.ContasClientes.Where(
                    conta => !idContas.Contains(conta.ContaId)
                    ).ToArray();
                

            }
            catch (Exception ex)
            {

                throw;
            }

            return BadRequest();
        }
    }
}
