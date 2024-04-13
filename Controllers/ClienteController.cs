using API_GestionCliente.Data;
using API_GestionCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GestionCliente.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController(GestionClientesContext context, ILogger<ClienteController> logger) : Controller
    {
        private readonly GestionClientesContext _context = context;
        private readonly ILogger<ClienteController> _logger = logger;

        
        // Endpoint para crear un cliente
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> CreateCliente(ClienteModel cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al crear un cliente");
                return StatusCode(500, "Se produjo un error interno del servidor");
            }
        }

        // Endpoint para actualizar un cliente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, ClienteModel cliente)
        {
            try
            {
                if (id != cliente.Id)
                    return BadRequest("ID del cliente no es válido");

                var existingCliente = await _context.Clientes.FindAsync(id);

                if (existingCliente == null)
                    return NotFound("Cliente no existe");

                // Actualiza solo los campos proporcionados en el cuerpo de la solicitud
                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Apellido = cliente.Apellido;
                existingCliente.CorreoElectronico = cliente.CorreoElectronico;

                await _context.SaveChangesAsync();

                return Ok("Cliente actualizado exitosamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                    return NotFound("Cliente no existe");
                else
                    throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al actualizar el cliente");
                return StatusCode(500, "Se produjo un error interno del servidor");
            }
        }

        // Endpoint para obtener un cliente por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                    return NotFound("Cliente no existe");

                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al obtener el cliente");
                return StatusCode(500, "Se produjo un error interno del servidor");
            }
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

    }
}